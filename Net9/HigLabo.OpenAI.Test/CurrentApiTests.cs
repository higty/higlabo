using System.Net;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace HigLabo.OpenAI.Test;

[TestClass]
public class CurrentApiTests
{
    [TestMethod]
    public async Task CompactWindowRoundTripsWithoutLosingEncryptedOrUnknownFields()
    {
        var window = JArray.Parse("""
            [{"type":"message","id":"msg_1","role":"user","content":[{"type":"input_text","text":"Keep MixedCase"}]},
             {"type":"compaction","id":"cmp_1","encrypted_content":"EncryptedCase","future_field":{"KeepCase":1}}]
            """);
        using var handler = new RecordingHandler { Response = new JObject
        {
            ["object"] = "response.compaction", ["id"] = "cmp_test", ["created_at"] = 1794000000,
            ["output"] = window, ["usage"] = new JObject { ["input_tokens"] = 4000 },
        }.ToString() };
        using var http = new HttpClient(handler);
        var client = new OpenAIClient("test-key", http);
        var compact = await client.ResponseCompactAsync(new()
        {
            Model = ModelNames.Gpt_6_1_Terra, Input = "A long conversation", Instructions = "Preserve decisions",
            Previous_Response_Id = "resp_before", Prompt_Cache_Options = new() { Ttl = "30m" },
        });
        Assert.AreEqual("POST", handler.Method);
        Assert.AreEqual("/v1/responses/compact", handler.Path);
        Assert.AreEqual("resp_before", (string?)handler.Body?["previous_response_id"]);
        Assert.AreEqual("response.compaction", compact.Object);
        Assert.AreEqual(4000, compact.Usage?.Input_Tokens);
        Assert.IsTrue(JToken.DeepEquals(window, compact.Output));
        handler.Response = """{"id":"resp_next","output":[]}""";
        await client.ResponseCreateAsync(new ResponseCreateParameter
        {
            Model = ModelNames.Gpt_6_1_Terra, Input = ResponseInput.FromItems(compact.Output),
        });
        Assert.IsTrue(JToken.DeepEquals(window, handler.Body?["input"]));
        Assert.IsNull(handler.Body?["context_management"]);
    }

    [TestMethod]
    public async Task CountsTokensWithConversationAndStructuredTools()
    {
        using var handler = new RecordingHandler { Response = """{"object":"response.input_tokens","input_tokens":1234}""" };
        using var http = new HttpClient(handler);
        var client = new OpenAIClient("test-key", http);
        var response = await client.ResponseInputTokensAsync(new()
        {
            Conversation = new { id = "conv_1" }, Model = ModelNames.Gpt_6_1_Terra, Input = "Hello",
            Reasoning = new() { Effort = "high" }, Tool_Choice = new { type = "function", name = "GetItem" },
            Tools = new() { new FunctionTool { Name = "GetItem", Parameters = new
            {
                type = "object", properties = new { ItemId = new { type = "string" } },
                required = new[] { "ItemId" }, additionalProperties = false,
            } } },
        });
        Assert.AreEqual("/v1/responses/input_tokens", handler.Path);
        Assert.AreEqual("POST", handler.Method);
        Assert.AreEqual(1234, response.Input_Tokens);
        Assert.AreEqual("conv_1", (string?)handler.Body?["conversation"]?["id"]);
        Assert.IsNotNull(handler.Body?["tools"]?[0]?["parameters"]?["properties"]?["ItemId"]);
        Assert.AreEqual("GetItem", (string?)handler.Body?["tool_choice"]?["name"]);
        Assert.IsNull(handler.Body?["personality"]);
    }

    [TestMethod]
    public async Task CancellationReturnsTheResponseAndRetainsTheLegacyMethod()
    {
        using var handler = new RecordingHandler { Response = """{"id":"resp_1","status":"cancelled","background":true,"output":[]}""" };
        using var http = new HttpClient(handler);
        var client = new OpenAIClient("test-key", http);
        var response = await client.ResponseCancelAsync("resp_1");
        Assert.AreEqual("/v1/responses/resp_1/cancel", handler.Path);
        Assert.AreEqual("cancelled", response.Status);
        Assert.AreEqual(true, response.Background);
        var legacy = await client.ResponseCcancelAsync("resp_1");
        Assert.AreEqual("resp_1", legacy.Id);
        Assert.AreEqual("cancelled", legacy.Status);
    }

    [TestMethod]
    public async Task SendsCompactionCyberImageAndDeferredToolOptions()
    {
        using var handler = new RecordingHandler { Response = """
            {"id":"resp_1","background":true,"completed_at":1794000010,"conversation":{"id":"conv_1"},
             "access_programs":{"cyber":"standard"},"prompt_cache_options":{"ttl":"12h"},
             "prompt_cache_diagnostics":{"type":"cache_hit"},"output":[
             {"type":"function_call","call_id":"call_1","name":"GetItem","namespace":"catalog","arguments":"{\"ItemId\":1}"},
             {"type":"reasoning","encrypted_content":"secret","summary":[{"type":"summary_text","text":"Plan"}]}]}
            """ };
        using var http = new HttpClient(handler);
        var client = new OpenAIClient("test-key", http);
        var parameter = new ResponseCreateParameter
        {
            Model = ModelNames.Gpt_6_Cyber, Access_Programs = new() { Cyber = "standard" },
            Context_Management = new() { new() { Compact_Threshold = 200000 } },
            Image = new() { Context_Compression = "enabled" },
            Prompt_Cache_Options = new() { Ttl = "12h", Comparison_Response_Id = "resp_before" },
            Tool_Choice = new { type = "function", name = "GetItem" },
            Tools = new() { new ToolSearchTool(), new NamespaceTool
            {
                Name = "catalog", Tools = new() { new FunctionTool
                {
                    Name = "GetItem", Defer_Loading = true, Async = true, Allowed_Callers = new() { "direct" },
                    Output_Schema = new { type = "object", properties = new { ItemId = new { type = "string" } } },
                } },
            } },
        };
        parameter.AddUserMessage("Inspect this item");
        var response = await client.ResponseCreateAsync(parameter);
        Assert.AreEqual("compaction", (string?)handler.Body?["context_management"]?[0]?["type"]);
        Assert.AreEqual("enabled", (string?)handler.Body?["image"]?["context_compression"]);
        Assert.AreEqual("standard", (string?)handler.Body?["access_programs"]?["cyber"]);
        Assert.AreEqual("resp_before", (string?)handler.Body?["prompt_cache_options"]?["comparison_response_id"]);
        Assert.AreEqual(true, (bool?)handler.Body?["tools"]?[1]?["tools"]?[0]?["defer_loading"]);
        Assert.IsNotNull(handler.Body?["tools"]?[1]?["tools"]?[0]?["output_schema"]?["properties"]?["ItemId"]);
        Assert.AreEqual("call_1", response.Output[0].Call_Id);
        Assert.AreEqual("catalog", response.Output[0].Namespace);
        Assert.AreEqual("secret", response.Output[1].Encrypted_Content);
        Assert.AreEqual("Plan", response.Output[1].Summary?[0].Text);
        Assert.AreEqual("12h", response.Prompt_Cache_Options?.Ttl);
        Assert.AreEqual(1794000010d, response.Completed_At);
    }

    [TestMethod]
    public async Task StreamsToolSearchArgumentsAndComputerSafetyChecks()
    {
        using var handler = new RecordingHandler { ContentType = "text/event-stream", Response = """
            event: response.output_item.done
            data: {"type":"response.output_item.done","item":{"type":"tool_search_call","execution":"client","call_id":"search_1","status":"completed","arguments":{"Goal":"Find tools"}}}

            event: response.output_item.done
            data: {"type":"response.output_item.done","item":{"type":"computer_call","actions":[{"type":"click","x":1,"y":2}],"pending_safety_checks":[{"id":"check_1","code":"confirm","message":"Check"}]}}

            event: response.output_text.delta
            data: {"type":"response.output_text.delta","delta":"Done"}

            event: response.completed
            data: {"type":"response.completed","response":{"id":"resp_stream","status":"completed","output":[{"type":"compaction","encrypted_content":"opaque"}]}}

            data: [DONE]

            """ };
        using var http = new HttpClient(handler);
        var client = new OpenAIClient("test-key", http);
        var result = new ResponseStreamResult();
        var text = new StringBuilder();
        await foreach (var delta in client.ResponseCreateStreamAsync(new ResponseCreateParameter { Model = ModelNames.Gpt_6_1_Terra }, result))
            text.Append(delta);
        Assert.AreEqual("Done", text.ToString());
        Assert.AreEqual(true, (bool?)handler.Body?["stream"]);
        var search = (ResponseStreamOutputItem)result.EventList[0].CreateTypedData();
        Assert.AreEqual("Find tools", (string?)JObject.Parse(search.Item.Arguments!)["Goal"]);
        var computer = (ResponseStreamOutputItem)result.EventList[1].CreateTypedData();
        Assert.AreEqual("check_1", computer.Item.Pending_Safety_Checks?[0].Id);
        Assert.AreEqual("click", computer.Item.Actions?[0].Type);
        Assert.AreEqual("opaque", result.Response?.Response.Output[0].Encrypted_Content);
    }

    [TestMethod]
    public async Task ChatCompletionSendsObjectToolChoiceAndCacheOptions()
    {
        using var handler = new RecordingHandler { Response = """{"id":"chat_1","choices":[]}""" };
        using var http = new HttpClient(handler);
        var client = new OpenAIClient("test-key", http);
        var parameter = new ChatCompletionCreateParameter
        {
            Model = ModelNames.Gpt_6_1_Terra, Prompt_Cache_Options = new() { Mode = "implicit", Ttl = "12h" },
            Tool_Choice = new { type = "function", function = new { name = "GetItem" } }, Verbosity = "low",
        };
        parameter.AddUserMessage("Hello");
        await client.ChatCompletionCreateAsync(parameter);
        Assert.AreEqual("/v1/chat/completions", handler.Path);
        Assert.AreEqual("12h", (string?)handler.Body?["prompt_cache_options"]?["ttl"]);
        Assert.AreEqual("GetItem", (string?)handler.Body?["tool_choice"]?["function"]?["name"]);
        Assert.AreEqual("low", (string?)handler.Body?["verbosity"]);
        parameter.Tool_Choice = "auto";
        await client.ChatCompletionCreateAsync(parameter);
        Assert.AreEqual("auto", (string?)handler.Body?["tool_choice"]);
    }

    [TestMethod]
    public async Task Image26GenerationSendsGifAndSvgOptionsAndReadsCreatedTimestamp()
    {
        using var handler = new RecordingHandler { Response = """
            {"created":1794000000,"output_format":"gif","safety_identifier":"user_hash","data":[{"b64_json":"R0lG"}],
             "usage":{"input_tokens":10,"output_tokens":20,"output_tokens_details":{"image_tokens":15,"text_tokens":5}}}
            """ };
        using var http = new HttpClient(handler);
        var client = new OpenAIClient("test-key", http);
        var parameter = new ImagesGenerationsParameter
        {
            Model = ModelNames.Gpt_Image_2_6_Flare, Prompt = "A running cat", Output_Format = "gif",
            Complexity = "high", Frame_Count = 8, Frame_Duration_Ms = 100, Safety_Identifier = "user_hash",
        };
        var response = await client.ImagesGenerationsAsync(parameter);
        Assert.AreEqual("/v1/images/generations", handler.Path);
        Assert.AreEqual(8, (int?)handler.Body?["frame_count"]);
        Assert.AreEqual(100, (int?)handler.Body?["frame_duration_ms"]);
        Assert.AreEqual("high", (string?)handler.Body?["complexity"]);
        Assert.AreEqual(1794000000L, response.Created_At);
        Assert.AreEqual(DateTimeOffset.FromUnixTimeSeconds(1794000000), response.CreateTime);
        CollectionAssert.AreEqual(new byte[] { 71, 73, 70 }, response.Data[0].GetBytes());
        Assert.AreEqual(15, response.Usage.Output_Tokens_Details?.Image_Tokens);
        parameter.Output_Format = "svg";
        parameter.Frame_Count = null;
        parameter.Frame_Duration_Ms = null;
        parameter.Svg = new() { Model = ModelNames.Gpt_6_1_Terra, Reasoning = new() { Effort = "high" } };
        await client.ImagesGenerationsAsync(parameter);
        Assert.AreEqual("high", (string?)handler.Body?["svg"]?["reasoning"]?["effort"]);
        Assert.IsNull(handler.Body?["frame_count"]);
    }

    [TestMethod]
    public async Task ImageEditingSupportsJsonReferencesAndMultipartMarkup()
    {
        using var handler = new RecordingHandler { Response = """{"created":1794000000,"data":[]}""" };
        using var http = new HttpClient(handler);
        var client = new OpenAIClient("test-key", http);
        await client.ImagesEditsAsync(new ImagesEditsJsonParameter
        {
            Model = ModelNames.Gpt_Image_2_6_Sunburst, Prompt = "Follow markup", Complexity = "high",
            Images = new() { new() { File_Id = "file_1" }, new() { Image_Url = "https://example.com/image.png" } },
            Markup = new() { Image_Url = "data:image/png;base64,AAAA" }, Safety_Identifier = "user_hash",
        });
        Assert.AreEqual("application/json", handler.RequestContentType);
        Assert.AreEqual("file_1", (string?)handler.Body?["images"]?[0]?["file_id"]);
        Assert.AreEqual("data:image/png;base64,AAAA", (string?)handler.Body?["markup"]?["image_url"]);
        Assert.IsNull(handler.Body?["image"]);
        Assert.IsNull(handler.Body?["mask"]);
        var multipart = new ImagesEditsParameter
        {
            Model = ModelNames.Gpt_Image_2_6_Sunburst, Prompt = "Follow markup", Complexity = "low",
            Output_Format = "svg", Svg = new() { Model = ModelNames.Gpt_6_1_Terra }, Moderation = "auto",
        };
        multipart.Image.Files.Add(new FileParameter("image[]", "input.png", new MemoryStream(new byte[] { 1, 2, 3 })));
        multipart.Markup.SetFile("markup.png", new byte[] { 4, 5, 6 });
        await client.ImagesEditsAsync(multipart);
        Assert.AreEqual("multipart/form-data", handler.RequestContentType);
        Assert.AreEqual("low", handler.Form["complexity"]);
        Assert.AreEqual("auto", handler.Form["moderation"]);
        Assert.AreEqual(ModelNames.Gpt_6_1_Terra, (string?)JObject.Parse(handler.Form["svg"])["model"]);
        Assert.IsTrue(handler.Form.ContainsKey("image[]"));
        Assert.IsTrue(handler.Form.ContainsKey("markup"));
        Assert.IsFalse(handler.Form.ContainsKey("mask"));
    }

    [TestMethod]
    public void TerraAndTwelveHourCachePricingUseCurrentRates()
    {
        var usage = new ResponseUsageResult
        {
            Input_Tokens = 2000, Output_Tokens = 1000,
            Input_Tokens_Details = new() { Cached_Tokens = 500, Cache_Write_Tokens = 500 },
        };
        Assert.AreEqual(0.00665m, ModelNames.CalculateCost(ModelNames.Gpt_6_1_Terra, usage));
        Assert.AreEqual(0.007275m, ModelNames.CalculateCost(ModelNames.Gpt_6_1_Terra, usage, "12h"));
        usage.Input_Tokens = 272001;
        usage.Input_Tokens_Details.Cached_Tokens = 270000;
        usage.Input_Tokens_Details.Cache_Write_Tokens = 1000;
        Assert.AreEqual(0.039002m, ModelNames.CalculateCost(ModelNames.Gpt_6_1_Terra, usage));
        Assert.AreEqual(0.014m, ModelNames.CalculateCost(ModelNames.Gpt_5_6_Terra, new ResponseUsageResult { Input_Tokens = 1000, Output_Tokens = 1000 }));
        Assert.AreEqual(0.0014m, ModelNames.CalculateCost(ModelNames.Gpt_5_6_Luna, new ResponseUsageResult { Input_Tokens = 1000, Output_Tokens = 1000 }));
        Assert.IsNull(ModelNames.CalculateCost(ModelNames.Gpt_Image_2_6_Flare, usage));
    }

    [TestMethod]
    public async Task JsonImageEditsStreamWithoutSwitchingToMultipart()
    {
        using var handler = new RecordingHandler { ContentType = "text/event-stream", Response = """
            event: image_edit.partial_image
            data: {"type":"image_edit.partial_image","b64_json":"AQID","partial_image_index":0}

            event: image_edit.completed
            data: {"type":"image_edit.completed","b64_json":"BAUG","output_format":"png"}

            data: [DONE]

            """ };
        using var http = new HttpClient(handler);
        var client = new OpenAIClient("test-key", http);
        var events = new List<ImageGenerationStreamEvent>();
        await foreach (var item in client.ImagesEditsStreamAsync(new ImagesEditsJsonParameter
        {
            Model = ModelNames.Gpt_Image_2_6_Sunburst, Prompt = "Change the color",
            Images = new() { new() { File_Id = "file_image" } }, Partial_Images = 1,
        })) events.Add(item);
        Assert.AreEqual("application/json", handler.RequestContentType);
        Assert.AreEqual(true, (bool?)handler.Body?["stream"]);
        Assert.AreEqual(2, events.Count);
        var completed = (ImageGenerationStreamCompleted)events[1].CreateTypedData();
        CollectionAssert.AreEqual(new byte[] { 4, 5, 6 }, completed.GetBytes());
    }

    [TestMethod]
    public void ErrorEventsRetainDetailsAndUnknownEventsRetainTheirPayload()
    {
        var error = new ResponseStreamEvent("error", """{"type":"error","code":"server_error","message":"Failed","param":"input"}""").CreateTypedData();
        Assert.IsInstanceOfType<ResponseStreamError>(error);
        Assert.AreEqual("server_error", ((ResponseStreamError)error).Code);
        Assert.AreEqual("Failed", ((ResponseStreamError)error).Message);
        Assert.AreEqual("input", ((ResponseStreamError)error).Param);
        var unknown = new ResponseStreamEvent("response.future_event", """{"type":"response.future_event","FutureData":{"KeepCase":1}}""").CreateTypedData();
        Assert.IsInstanceOfType<ResponseStreamEventUnknown>(unknown);
        Assert.AreEqual(1, (int?)JObject.Parse(((ResponseStreamEventUnknown)unknown).Data)["FutureData"]?["KeepCase"]);
    }

    private sealed class RecordingHandler : HttpMessageHandler
    {
        public string Response { get; set; } = "{}";
        public string ContentType { get; set; } = "application/json";
        public string? Method { get; private set; }
        public string? Path { get; private set; }
        public string? RequestContentType { get; private set; }
        public JObject? Body { get; private set; }
        public Dictionary<string, string> Form { get; } = new();

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            Method = request.Method.Method;
            Path = request.RequestUri!.AbsolutePath;
            RequestContentType = request.Content?.Headers.ContentType?.MediaType;
            if (request.Content is MultipartFormDataContent multipart)
            {
                foreach (var part in multipart)
                    Form[part.Headers.ContentDisposition!.Name!.Trim('"')] = await part.ReadAsStringAsync(cancellationToken);
            }
            else if (request.Content != null)
                Body = JObject.Parse(await request.Content.ReadAsStringAsync(cancellationToken));
            return new(HttpStatusCode.OK) { Content = new StringContent(Response, Encoding.UTF8, ContentType) };
        }
    }
}
