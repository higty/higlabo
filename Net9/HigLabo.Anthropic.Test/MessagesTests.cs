using System.Net;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HigLabo.Anthropic.Test;

[TestClass]
public class MessagesTests
{
    [TestMethod]
    public async Task SendsCurrentRequestAndReadsTextToolAndUsage()
    {
        using var handler = new ResponseHandler();
        using var httpClient = new HttpClient(handler);
        var client = new AnthropicClient(new AnthropicSettings("test-key"), httpClient);
        // Removed fields must be absent even when a caller includes nulls in JSON.
        ((AnthropicJsonConverter)client.JsonConverter).SerializeSetting.NullValueHandling = NullValueHandling.Include;
        var parameter = CreateParameter();

        var response = await client.MessagesAsync(parameter);

        AssertCurrentRequest(handler, false);
        Assert.AreEqual("get_weather", (string?)handler.Body!["tools"]?[0]?["name"]);
        Assert.AreEqual("string", (string?)handler.Body["tools"]?[0]?["input_schema"]?["properties"]?["CityName"]?["type"]);
        Assert.AreEqual("any", (string?)handler.Body["tool_choice"]?["type"]);
        Assert.AreEqual("Hello", response.Content[0].Text);
        Assert.AreEqual("tool_use", response.GetStopReason());
        var function = response.GetFunctionCall()!;
        Assert.AreEqual("get_weather", function.Name);
        Assert.AreEqual("Tokyo", (string?)JObject.Parse(function.Arguments)["CityName"]);
        Assert.AreEqual(15, response.Usage.GetTotalInputTokens());
        Assert.AreEqual(7, response.Usage.Output_Tokens);
    }

    [DataTestMethod]
    [DataRow(0)]
    [DataRow(1)]
    [DataRow(2)]
    public async Task StreamingOverloadsSetStreamAndSendCurrentVersion(int overload)
    {
        using var handler = new ResponseHandler();
        using var httpClient = new HttpClient(handler);
        var client = new AnthropicClient(new AnthropicSettings("test-key"), httpClient);
        var parameter = CreateParameter();
        parameter.Stream = false;
        var result = new MessagesStreamResult();
        var stream = overload switch
        {
            0 => client.MessagesStreamAsync(parameter),
            1 => client.MessagesStreamAsync(parameter, CancellationToken.None),
            _ => client.MessagesStreamAsync(parameter, result, CancellationToken.None),
        };
        var text = new StringBuilder();
        await foreach (var item in stream)
        {
            text.Append(item);
        }

        AssertCurrentRequest(handler, true);
        Assert.AreEqual("Hello", text.ToString());
        if (overload == 2)
        {
            Assert.AreEqual("Hello", result.GetText());
            Assert.AreEqual("end_turn", result.GetStopReason());
            Assert.AreEqual(15, result.GetUsageResult()!.GetTotalInputTokens());
            Assert.AreEqual(7, result.GetUsageResult()!.Output_Tokens);
        }
    }

    [DataTestMethod]
    [DataRow(false)]
    [DataRow(true)]
    public async Task ExplicitApiVersionAndBetaHeadersArePreserved(bool stream)
    {
        using var handler = new ResponseHandler();
        using var httpClient = new HttpClient(handler);
        var settings = new AnthropicSettings("test-key") { Version = "2023-06-01", BetaVersion = "test-beta" };
        var client = new AnthropicClient(settings, httpClient);
        if (stream)
        {
            await foreach (var item in client.MessagesStreamAsync(CreateParameter())) { }
        }
        else
        {
            await client.MessagesAsync(CreateParameter());
        }

        Assert.AreEqual("2023-06-01", handler.Version);
        Assert.AreEqual("test-beta", handler.BetaVersion);
    }

    [DataTestMethod]
    [DataRow(false)]
    [DataRow(true)]
    public async Task ApiValidationErrorsAreAvailableToCaller(bool stream)
    {
        using var handler = new ResponseHandler { RejectRequest = true };
        using var httpClient = new HttpClient(handler);
        var client = new AnthropicClient(new AnthropicSettings("test-key"), httpClient);
        var error = await Assert.ThrowsExceptionAsync<AnthropicServerException>(async () =>
        {
            if (stream)
            {
                await foreach (var item in client.MessagesStreamAsync(CreateParameter())) { }
            }
            else
            {
                await client.MessagesAsync(CreateParameter());
            }
        });

        Assert.AreEqual(HttpStatusCode.BadRequest, error.Response.StatusCode);
        Assert.AreEqual("invalid_request_error", error.Error.Type);
        Assert.AreEqual("Invalid content for message role", error.Message);
        Assert.AreEqual("2026-10-21", error.Request.Headers.GetValues("anthropic-version").Single());
    }

    private static MessagesParameter CreateParameter()
    {
        var parameter = new MessagesParameter { Model = ModelNames.ClaudeSonnet4_6, Max_Tokens = 2048 };
        parameter.AddUserMessage("What is the weather in Tokyo?");
        parameter.AddAssistantMessage("I will check.");
        parameter.AddUserMessage("Please check the current weather.");
        parameter.Tools = new()
        {
            new AnthropicTool("get_weather", "Get weather")
            {
                Input_Schema = new { type = "object", properties = new { CityName = new { type = "string" } } },
            },
        };
        parameter.Tool_Choice = new { type = "any" };
        return parameter;
    }

    private static void AssertCurrentRequest(ResponseHandler handler, bool stream)
    {
        Assert.AreEqual("https://api.anthropic.com/v1/messages", handler.Url);
        Assert.AreEqual(HttpMethod.Post, handler.Method);
        Assert.AreEqual("2026-10-21", handler.Version);
        Assert.AreEqual("test-key", handler.ApiKey);
        Assert.IsNull(handler.BetaVersion);
        Assert.AreEqual("application/json", handler.ContentType);
        var body = handler.Body!;
        Assert.AreEqual("claude-sonnet-4-6", (string?)body["model"]);
        Assert.AreEqual(2048, (int?)body["max_tokens"]);
        Assert.AreEqual("user", (string?)body["messages"]?[0]?["role"]);
        Assert.AreEqual("assistant", (string?)body["messages"]?[1]?["role"]);
        Assert.IsNull(body.Property("temperature"));
        Assert.IsNull(body.Property("top_p"));
        Assert.IsNull(body.Property("top_k"));
        Assert.AreEqual(stream, (bool?)body["stream"] ?? false);
        if (stream) { Assert.AreEqual("text/event-stream", handler.Accept); }
    }

    private sealed class ResponseHandler : HttpMessageHandler
    {
        public bool RejectRequest { get; init; }
        public JObject? Body { get; private set; }
        public string? Url { get; private set; }
        public HttpMethod? Method { get; private set; }
        public string? Version { get; private set; }
        public string? BetaVersion { get; private set; }
        public string? ApiKey { get; private set; }
        public string? ContentType { get; private set; }
        public string? Accept { get; private set; }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Url = request.RequestUri!.ToString();
            Method = request.Method;
            Version = request.Headers.GetValues("anthropic-version").Single();
            BetaVersion = request.Headers.TryGetValues("anthropic-beta", out var beta) ? beta.Single() : null;
            ApiKey = request.Headers.GetValues("x-api-key").Single();
            ContentType = request.Content!.Headers.ContentType?.MediaType;
            Accept = request.Headers.Accept.FirstOrDefault()?.MediaType;
            Body = JObject.Parse(await request.Content.ReadAsStringAsync(cancellationToken));
            if (RejectRequest)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("""{"type":"error","error":{"type":"invalid_request_error","message":"Invalid content for message role"}}""", Encoding.UTF8, "application/json"),
                };
            }
            var stream = (bool?)Body["stream"] == true;
            var body = stream ? StreamResponse : MessageResponse;
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(body, Encoding.UTF8, stream ? "text/event-stream" : "application/json"),
            };
        }
    }

    private const string MessageResponse = """
        {"id":"msg_test","type":"message","role":"assistant","model":"claude-sonnet-4-6",
         "content":[{"type":"text","text":"Hello"},{"type":"tool_use","id":"tool_test","name":"get_weather","input":{"CityName":"Tokyo"}}],
         "stop_reason":"tool_use","stop_sequence":null,
         "usage":{"input_tokens":10,"cache_creation_input_tokens":3,"cache_read_input_tokens":2,"output_tokens":7}}
        """;

    private const string StreamResponse = """
        event: message_start
        data: {"type":"message_start","message":{"id":"msg_test","type":"message","role":"assistant","content":[],"model":"claude-sonnet-4-6","stop_reason":null,"stop_sequence":null,"usage":{"input_tokens":10,"cache_creation_input_tokens":3,"cache_read_input_tokens":2,"output_tokens":0}}}

        event: content_block_start
        data: {"type":"content_block_start","index":0,"content_block":{"type":"text","text":""}}

        event: content_block_delta
        data: {"type":"content_block_delta","index":0,"delta":{"type":"text_delta","text":"Hello"}}

        event: content_block_stop
        data: {"type":"content_block_stop","index":0}

        event: message_delta
        data: {"type":"message_delta","delta":{"stop_reason":"end_turn","stop_sequence":null},"usage":{"output_tokens":7}}

        event: message_stop
        data: {"type":"message_stop"}


        """;
}
