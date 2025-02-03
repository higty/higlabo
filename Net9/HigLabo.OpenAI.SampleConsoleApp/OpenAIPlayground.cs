using HigLabo.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public class OpenAIPlayground
{
    public OpenAIClient OpenAIClient { get; set; } = new();

    public async ValueTask ExecuteAsync()
    {
        SetOpenAISetting();
        await ChatCompletionWithReasoning();
        Console.WriteLine("■Completed");
    }
    private void SetOpenAISetting()
    {
        var apiKey = File.ReadAllText("C:\\Dev\\ChatGPTApiKey.txt");
        OpenAIClient = new OpenAIClient(apiKey);
    }
    private void SetAzureSetting()
    {
        var json = File.ReadAllText("C:\\Dev\\AzureOpenAIApiKey.json");
        OpenAIClient = new OpenAIClient(JsonConvert.DeserializeObject<AzureSettings>(json)!);
    }
    private void SetGroqSetting()
    {
        var apiKey = File.ReadAllText("C:\\Dev\\GroqApiKey.txt");
        OpenAIClient = new OpenAIClient(new GroqSettings(apiKey));
    }
    private void SetDeepSeekSetting()
    {
        var apiKey = File.ReadAllText("C:\\Dev\\DeepSeekApiKey.txt");
        OpenAIClient = new OpenAIClient(new DeepSeekSettings(apiKey));
    }

    private async ValueTask AudioFileDownload()
    {
        var cl = OpenAIClient;

        var res = await cl.AudioSpeechAsync("tts-1", "Stay Hungry. Stay Foolish. Thank you all very much.", "alloy");
        File.WriteAllBytes("C:\\Data\\Dev\\GPT_Audio.mp3", res.Stream!.ToByteArray());
    }
    private async ValueTask AudioTranslations()
    {
        var cl = OpenAIClient;

        var p = new AudioTranslationsParameter();
        p.File.SetFile("GoodMorningItFineDayToday.mp3", new MemoryStream(File.ReadAllBytes("C:\\Data\\Dev\\GoodMorningItFineDayToday.mp3")));
        p.Model = "whisper-1";

        var res = await cl.AudioTranslationsAsync(p);
        Console.WriteLine(res.GetResponseBodyText());
    }
    private async ValueTask AudioTranslationsFromUrl()
    {
        var cl = OpenAIClient;

        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync("http://www.yourdomain.com/file/myfile.mp3");
        var stream = await response.Content.ReadAsStreamAsync();

        var p = new AudioTranslationsParameter();
        p.File.SetFile("myfile.mp3", stream);
        p.Model = "whisper-1";
        var res = await cl.AudioTranslationsAsync(p);
    }
    private async ValueTask AudioTranscriptions()
    {
        var cl = OpenAIClient;

        var p = new AudioTranscriptionsParameter();
        p.File.SetFile("GoodMorningItFineDayToday.mp3", new MemoryStream(File.ReadAllBytes("C:\\Data\\Dev\\GoodMorningItFineDayToday.mp3")));
        p.Model = "whisper-1";
        
        var res = await cl.AudioTranscriptionsAsync(p);
        Console.WriteLine(res.GetResponseBodyText());
    }
    private async ValueTask Embeddings()
    {
        var cl = OpenAIClient;
        var res = await cl.EmbeddingsAsync("Crafting prompts\r\nWe generally recommend taking the set of instructions and prompts that you found worked best for the model prior to fine-tuning, and including them in every training example. This should let you reach the best and most general results, especially if you have relatively few (e.g. under a hundred) training examples.\r\n\r\nIf you would like to shorten the instructions or prompts that are repeated in every example to save costs, keep in mind that the model will likely behave as if those instructions were included, and it may be hard to get the model to ignore those \"baked-in\" instructions at inference time.\r\n\r\nIt may take more training examples to arrive at good results, as the model has to learn entirely through demonstration and without guided instructions."
            , "text-embedding-ada-002");
        foreach (var item in res.Data)
        {
            var embeddings = item.Embedding;
        }
        Console.WriteLine(res);
    }
    private async ValueTask ChatCompletion()
    {
        var cl = OpenAIClient;

        var p = new ChatCompletionsParameter();
        var theme = "How to enjoy coffee";
        p.Messages.Add(new ChatMessage(ChatMessageRole.User
            , $"Can you provide me with some ideas for blog posts about {theme}?"));
        p.Model = cl.ServiceProvider switch
        {
            ServiceProvider.Groq => "llama3-70b-8192",
            ServiceProvider.DeepSeek => "deepseek-chat",
            _ => "gpt-4o",
        };
        var res = await cl.ChatCompletionsAsync(p);
        foreach (var choice in res.Choices)
        {
            Console.Write(choice.Message.Content);
        }

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("■Reasoning content");
        Console.WriteLine();
        foreach (var choice in res.Choices)
        {
            Console.Write(choice.Message.Reasoning_Content);
        }
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Total tokens: " + res.Usage.Total_Tokens);

        //And you can get actual request body and response body by these property.
        var iRes = res as IRestApiResponse;
        Console.WriteLine(iRes.RequestBodyText);
        Console.WriteLine();
        Console.WriteLine(iRes.ResponseBodyText);
    }
    private async ValueTask ChatCompletionStream()
    {
        var cl = OpenAIClient;

        var model = cl.ServiceProvider switch
        {
            ServiceProvider.Groq => "llama3-70b-8192",
            ServiceProvider.DeepSeek => "deepseek-chat",
            _ => "gpt-4o",
        };
        var result = new ChatCompletionStreamResult();
        await foreach (string text in cl.ChatCompletionsStreamAsync("How to enjoy coffee?", model, result, CancellationToken.None))
        {
            Console.Write(text);
        }
        Console.WriteLine();
        Console.WriteLine("***********************");

        Console.WriteLine(result.GetReasoningContent());
        Console.WriteLine();
        Console.WriteLine("***********************");

        Console.WriteLine("Finish reason: " + result.GetFinishReason());
        Console.WriteLine("■DONE");
    }
    private async ValueTask ChatCompletionStreamWithUsageResult()
    {
        var cl = OpenAIClient;

        var p = new ChatCompletionsParameter();
        p.AddUserMessage($"How to enjoy coffee");
        p.Model = "gpt-4o";
        if (cl.ServiceProvider == ServiceProvider.OpenAI)
        {
            p.Stream_Options = new
            {
                include_usage = true,
            };
        }
        var result = new ChatCompletionStreamResult();
        await foreach (string text in cl.ChatCompletionsStreamAsync(p, result, CancellationToken.None))
        {
            Console.Write(text);
        }
        Console.WriteLine();
        Console.WriteLine();

        var usage = result.GetUsageResult();
        if (usage != null)
        {
            Console.WriteLine("------------------------");
            Console.WriteLine("Prompt tokne: " + usage.Prompt_Tokens);
            Console.WriteLine("Completion tokne: " + usage.Completion_Tokens);
            Console.WriteLine("Total tokne: " + usage.Total_Tokens);
        }
        Console.WriteLine("------------------------");
    }
    private async ValueTask ChatCompletionStreamWithFunctionCalling()
    {
        var cl = OpenAIClient;

        var p = new ChatCompletionsParameter();
        //ChatGPT can correct Newyork,Sanflansisco to New york and San Flancisco.
        p.Messages.Add(new ChatMessage(ChatMessageRole.User, $"I want to know the whether of Tokyo."));
        p.Model = cl.ServiceProvider switch
        {
            ServiceProvider.Groq => "llama3-70b-8192",
            _ => "gpt-4o",
        };

        p.Tools = new List<ToolObject>();
        p.Tools.Add(this.CreateGetWheatherTool());
        p.Tools.Add(this.CreateGetLatLongTool());

        var result = new ChatCompletionStreamResult();
        await foreach (var text in cl.ChatCompletionsStreamAsync(p, result, CancellationToken.None))
        {
            Console.Write(text);
        }
        Console.WriteLine();

        foreach (var f in result.GetFunctionCallList())
        {
            Console.WriteLine("■Function name is " + f.Name);
            Console.WriteLine("■Arguments is " + f.Arguments);
        }

        Console.WriteLine();
        Console.WriteLine("DONE");
    }
    private async ValueTask ChatCompletionVision()
    {
        var cl = OpenAIClient;

        var p = new ChatCompletionsParameter();

        var vMessage = new ChatImageMessage(ChatMessageRole.User);
        vMessage.AddTextContent("Please describe this image.");
        vMessage.AddImageFile(Path.Combine(Environment.CurrentDirectory, "Image", "Pond.jpg"));
        p.Messages.Add(vMessage);
        p.Model = "gpt-4o";
        p.Max_Completion_Tokens = 300;
        p.Stream = true;

        var result = new ChatCompletionStreamResult();
        await foreach (var text in cl.ChatCompletionsStreamAsync(p, result, CancellationToken.None))
        {
            Console.Write(text);
        }
        Console.WriteLine("");
        Console.WriteLine("■DONE");
    }
    private async ValueTask ChatCompletionJsonFormat()
    {
        var cl = OpenAIClient;

        var p = new ChatCompletionsParameter();
        p.Messages.Add(new ChatMessage(ChatMessageRole.User, $"I want to know Japan information."));
        p.Model = cl.ServiceProvider switch
        {
            ServiceProvider.Groq => "llama3-70b-8192",
            _ => "gpt-4o",
        };

        //Use anonymous object to define json schema.
        #region
        //p.Response_Format = new
        //{
        //    type = "json_schema",
        //    json_schema = new
        //    {
        //        name = "Info",
        //        strict = true,
        //        schema = new
        //        {
        //            type = "object",
        //            properties = new
        //            {
        //                population = new
        //                {
        //                    type = "integer",
        //                    description = "Population of this country.",
        //                },
        //                area = new
        //                {
        //                    type = "integer",
        //                    description = "Area of this country.",
        //                },
        //                currency = new
        //                {
        //                    type = "string",
        //                    description = "Currency of this country.",
        //                },
        //                language = new
        //                {
        //                    type = "string",
        //                    description = "Language of this country.",
        //                },
        //            },
        //            required = new string[] { "population", "area", "currency", "language" },
        //            additionalProperties = false,
        //        },
        //    }
        //};
        #endregion
        //Use JsonSchema class to define json schema.
        var responseSchema = new JsonSchemaResponseFormat();
        responseSchema.json_schema.Name = "CountryInfo";
        var o = responseSchema.json_schema.Schema;
        o.Properties.Add("population", new JsonSchemaProperty("integer", "Population of this country."));
        o.Properties.Add("area", new JsonSchemaProperty("integer", "Area of this country."));
        o.Properties.Add("currency", new JsonSchemaProperty("string", "Currency of this country."));
        o.Properties.Add("language", new JsonSchemaProperty("string", "Language of this country."));
        o.Required = new string[] { "population", "area", "currency", "language" };

        p.Response_Format = responseSchema;

        var res = await cl.ChatCompletionsAsync(p);
        foreach (var choice in res.Choices)
        {
            Console.Write(choice.Message.Content);
            var r = JsonConvert.DeserializeObject<CountryInformation>(choice.Message.Content!);
        }
        Console.WriteLine();
    }
    private async ValueTask ChatCompletionWithReasoning()
    {
        var cl = OpenAIClient;

        var p = new ChatCompletionsParameter();
        var theme = "How to enjoy coffee";
        p.Messages.Add(new ChatMessage(ChatMessageRole.User
            , $"Can you provide me with some ideas for blog posts about {theme}?"));
        p.Model = cl.ServiceProvider switch
        {
            ServiceProvider.Groq => "llama3-70b-8192",
            ServiceProvider.DeepSeek => "deepseek-chat",
            _ => "o3-mini",
        };
        p.Reasoning_Effort = "medium";
        var res = await cl.ChatCompletionsAsync(p);
        foreach (var choice in res.Choices)
        {
            Console.Write(choice.Message.Content);
        }

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("■Reasoning content");
        Console.WriteLine();
        foreach (var choice in res.Choices)
        {
            Console.Write(choice.Message.Reasoning_Content);
        }
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Total tokens: " + res.Usage.Total_Tokens);

        //And you can get actual request body and response body by these property.
        var iRes = res as IRestApiResponse;
        Console.WriteLine(iRes.RequestBodyText);
        Console.WriteLine();
        Console.WriteLine(iRes.ResponseBodyText);
    }

    private ToolObject CreateGetWheatherTool()
    {
        var tool = new ToolObject("function");
        tool.Function = new FunctionObject();
        tool.Function.Name = "getWhether";
        tool.Function.Description = "This service can get whether of specified location.";
        //Use anonymous object to define json schema.
        #region
        //tool.Function.Parameters = new
        //{
        //    type = "object",
        //    properties = new
        //    {
        //        location = new
        //        {
        //            type = "string",
        //            description = "Location list that you want to know.",
        //        },
        //    }
        //};
        #endregion
        //Use JsonSchema class to define json schema.
        var o = new JsonSchema();
        o.Properties.Add("location", new JsonSchemaProperty("string", "Location list that you want to know."));
        tool.Function.Parameters = o;
        return tool;
    }
    private ToolObject CreateGetTouristSpotTool()
    {
        var tool = new ToolObject("function");
        tool.Function = new FunctionObject();
        tool.Function.Name = "getTouristSpot";
        tool.Function.Description = "This service can get tourist spot of specified region.";
        tool.Function.Parameters = new
        {
            type = "object",
            properties = new
            {
                locationList = new
                {
                    type = "array",
                    description = "Location list that you want to know.",
                    items = new
                    {
                        type = "string",
                    }
                }
            }
        };
        return tool;
    }
    private ToolObject CreateGetLatLongTool()
    {
        var tool = new ToolObject("function");
        tool.Function = new FunctionObject();
        tool.Function.Name = "getLatLong";
        tool.Function.Description = "This service can get latitude and longitude of specified location.";
        //Use anonymous object to define json schema.
        #region
        //tool.Function.Parameters = new
        //{
        //    type = "object",
        //    properties = new
        //    {
        //        locationList = new
        //        {
        //            type = "array",
        //            description = "Location list that you want to know.",
        //            items = new
        //            {
        //                type = "string",
        //            }
        //        }
        //    }
        //};
        #endregion
        //Use JsonSchema class to define json schema.
        var o = new JsonSchema();
        o.Properties.Add("locationList", new JsonSchemaProperty("array", "Location list that you want to know.")
        {
            Items = new JsonSchema("object") { },
        });
        tool.Function.Parameters = o;
        return tool;
    }

    private async ValueTask FileList()
    {
        var cl = OpenAIClient;

        var p = new FilesParameter();
        p.QueryParameter.Purpose = "assistants";
        var res = await cl.FilesAsync(p);
        foreach (var item in res.Data)
        {
            Console.WriteLine($"{item.Purpose} {item.FileName}");
        }
    }
    private async ValueTask FileUpload_Assistant()
    {
        var cl = OpenAIClient;

        var p = new FileUploadParameter();
        p.File.SetFile("FinetuneSample.txt", File.ReadAllBytes("C:\\Data\\Dev\\FinetuneSample.txt"));
        p.SetPurpose(FilePurpose.Assistants);
        var res = await cl.FileUploadAsync(p);
        Console.WriteLine(res);
    }
	private async ValueTask ImageFileDownload()
	{
		var cl = OpenAIClient;

		var fileResponse = await cl.FileContentGetAsync("file-ShIMh9E6jz4PNdLjWk5VJHQA");
    File.WriteAllBytes("C:\\Data\\Dev\\Hig_Download.png", fileResponse.Stream!.ToByteArray());
	}
	private async ValueTask FileUpload_Finetune()
{
    var cl = OpenAIClient;

    var p = new FileUploadParameter();
    p.File.SetFile($"FinetuneSample{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.txt", File.ReadAllBytes("C:\\Data\\Dev\\FinetuneSample.txt"));
    p.Purpose = "fine-tune";
    var res = await cl.FileUploadAsync(p);

    var res1 = await cl.FilesAsync();
    foreach (var item in res1.Data)
    {
        Console.WriteLine(item.Id + " " + item.FileName);
        if (item.Purpose == "assistants") { continue; }

        var res3 = await cl.FileContentGetAsync(item.Id);
        Console.WriteLine(res3.GetResponseBodyText());
    }
}
    private async ValueTask ImageGeneration()
    {
        var cl = OpenAIClient;

        var p = new ImagesGenerationsParameter();
        p.Prompt = "A photorealistic image of a beautiful landscape under a blue sky. The scene features a wide, lush green field, with the sun shining brightly and casting soft shadows. The sky is a clear, deep blue with a few fluffy white clouds scattered around. The field is vibrant and green, giving a sense of calm and tranquility. The image should have a high-resolution, 4K-like quality, capturing the details of the grass, the texture of the clouds, and the vividness of the blue sky.";
        p.Model = "dall-e-3";
        p.Quality = "hd";
        var res = await cl.ImagesGenerationsAsync(p);
        foreach (var item in res.Data)
        {
            Console.WriteLine(item.Url);
        }
    }
    private async ValueTask ImageVariation()
    {
        var cl = OpenAIClient;

        var res = await cl.ImagesVariationsAsync("Sea.png", new MemoryStream(File.ReadAllBytes("C:\\Data\\Dev\\Sea.png")));
        foreach (var item in res.Data)
        {
            Console.WriteLine(item.Url);
        }
    }
    private async ValueTask Model()
    {
        var cl = OpenAIClient;

        var res = await cl.ModelsAsync();
        foreach (var item in res.Data)
        {
            Console.WriteLine(item.ToString());
        }

        var res1 = await cl.ModelRetrieveAsync("text-search-babbage-doc-001");
        Console.WriteLine(res1.GetResponseBodyText());
    }
    private async ValueTask Moderation()
    {
        var cl = OpenAIClient;
        //Test terrible text for moderation api.
        var res = await cl.ModerationCreateAsync("We must kill all activist who attack museum. I will kill them and shoot myself after that.");
        Console.WriteLine(res);
    }

    private async ValueTask<(string AssistantId, string ThreadId)> CreateNewThread()
    {
        var cl = OpenAIClient;
        var assistantsResponse = await cl.AssistantsAsync();
        var assistantId = "";
        if (assistantsResponse.Data.Count == 0)
        {
            var res = await AssistantCreate("HigLabo assistant");
            assistantId = res.Id;
        }
        else
        {
            foreach (var item in assistantsResponse.Data)
            {
                if (item.Name == "HigLabo assistant")
                {
                    assistantId = item.Id;
                    break;
                }
            }
        }

        {
            var res = await cl.ThreadCreateAsync();
            return (assistantId, res.Id);
        }
    }
    private async ValueTask ProcessAssistants()
    {
        var cl = OpenAIClient;

        var (assistantId, threadId) = await this.CreateNewThread();
        {
            var p = new MessageCreateParameter();
            p.Thread_Id = threadId;
            p.Role = "user";
            p.AddTextMessage("Hello! I want to know how to enjoy coffee in my life.");
            var res = await cl.MessageCreateAsync(p);
        }
        //Streaming
        {
            var p = new RunCreateParameter();
            p.Assistant_Id = assistantId;
            p.Thread_Id = threadId;
            p.Temperature = 0.5;
   
            var result = new AssistantMessageStreamResult();
            await foreach (string text in cl.RunCreateStreamAsync(p, result, CancellationToken.None))
            {
                Console.Write(text);
            }
            Console.WriteLine();

            Console.WriteLine(JsonConvert.SerializeObject(result.Thread));
            Console.WriteLine(JsonConvert.SerializeObject(result.Run));
            Console.WriteLine(JsonConvert.SerializeObject(result.RunStep));
            Console.WriteLine(JsonConvert.SerializeObject(result.Message));

        }
    }
    private async ValueTask ProcessAssistantsWithFunctionCalling()
    {
        var cl = OpenAIClient;

        var (assistantId, threadId) = await this.CreateNewThread();
        {
            var p = new MessageCreateParameter();
            p.Thread_Id = threadId;
            p.Role = "user";
            p.AddTextMessage($"I want to know the whether of Tokyo.");
            var res = await cl.MessageCreateAsync(p);
        }
        //Streaming
        {
            var p = new RunCreateParameter();
            p.Assistant_Id = assistantId;
            p.Thread_Id = threadId;
            p.Tools = new List<ToolObject>();
            p.Tools.Add(CreateGetWheatherTool());

            var result = new AssistantMessageStreamResult();
            await foreach (string text in cl.RunCreateStreamAsync(p, result, CancellationToken.None))
            {
                Console.Write(text);
            }
            Console.WriteLine();

            Console.WriteLine(JsonConvert.SerializeObject(result.Run));

            if (result.Run != null)
            {
                if (result.Run.Status == "requires_action" &&
                    result.Run.Required_Action != null)
                {
                    var p1 = new SubmitToolOutputsParameter();
                    p1.Thread_Id = threadId;
                    p1.Run_Id = result.Run.Id;
                    p1.Tool_Outputs = new();
                    foreach (var toolCall in result.Run.Required_Action.GetToolCallList())
                    {
                        Console.WriteLine(toolCall.ToString());

                        //Pass output from calling your function. 
                        var output = new ToolOutput();
                        output.Tool_Call_Id = toolCall.Id;
                        var o = new
                        {
                            Wheather = "Cloud",
                            Temperature = "20℃",
                            Forecast = "Rain after 3 hours",
                        };
                        output.Output = $"{toolCall.Function.Arguments} is {JsonConvert.SerializeObject(o)}";
                        p1.Tool_Outputs.Add(output);
                    }
                    await foreach (var text in cl.SubmitToolOutputsStreamAsync(p1))
                    {
                        Console.Write(text);
                    }
                }
            }
        }
    }

    private async ValueTask<AssistantCreateResponse> AssistantCreate(string name)
    {
        var cl = OpenAIClient;

        var p = new AssistantCreateParameter();
        p.Name = name;
        p.Instructions = "You are a personal assistant to help general task.";
        if (cl.ServiceProvider == ServiceProvider.OpenAI)
        {
            p.Model = "gpt-4-turbo";
        }

        p.Tools = new List<ToolObject>();
        p.Tools.Add(new ToolObject("code_interpreter"));
        if (cl.ServiceProvider == ServiceProvider.OpenAI)
        {
            p.Tools.Add(new ToolObject("file_search"));
        }

        //var res0 = await cl.FilesAsync();
        //p.File_Ids = new List<string>();
        //foreach (var item in res0.Data)
        //{
        //    if (item.Purpose == "assistants" && item.FileName.EndsWith(".pdf"))
        //    {
        //        p.File_Ids.Add(item.Id);
        //    }
        //}

        var res = await cl.AssistantCreateAsync(p);
        Console.WriteLine(res);
        return res;
    }
    private async ValueTask AssistantRetrieve()
    {
        var cl = OpenAIClient;

        var res = await cl.AssistantsAsync();
        var id = "";
        foreach (var item in res.Data)
        {
            Console.WriteLine(item);
            id = item.Id;
            break;
        }

        var res1 = await cl.AssistantRetrieveAsync(id);
        Console.WriteLine(res1.GetResponseBodyText());

        var res2 = await cl.FilesAsync();
        foreach (var item in res2.Data)
        {
            if (item.Purpose == "assistants")
            {
                //var res3 = await cl.AssistantFileCreateAsync(id, item.Id);
            }
        }
    }
    private async ValueTask AssistantModify()
    {
        var cl = OpenAIClient;

        var res = await cl.AssistantsAsync();
        var id = "";
        foreach (var item in res.Data)
        {
            Console.WriteLine(item);
            id = item.Id;
            break;
        }

        var p = new AssistantModifyParameter();
        p.Assistant_Id = id;
        p.Metadata = new {
            MyKey2 = "MyValue2",
            CreateTime = DateTimeOffset.Now,
        };
        var res2 = await cl.AssistantModifyAsync(p);
        Console.WriteLine(res2.GetResponseBodyText());
    }
    private async ValueTask SendMessage()
    {
        var cl = OpenAIClient;

        var (assistantId, threadId) = await this.CreateNewThread();
        {
            var p = new MessageCreateParameter();
            p.Thread_Id = threadId;
            p.Role = "user";
            p.AddTextMessage("Hello! I want to know how to use OpenAI assistant API.");
            var res = await cl.MessageCreateAsync(p);
        }
        var runId = "";
        {
            var p = new RunCreateParameter();
            p.Assistant_Id = assistantId;
            p.Thread_Id = threadId;
            var res = await cl.RunCreateAsync(p);
            runId = res.Id;
        }
        var loopCount = 0;
        Thread.Sleep(3000);
        var interval = 1000;
        while (true)
        {
            Thread.Sleep(interval);
            var p = new RunRetrieveParameter();
            p.Thread_Id = threadId;
            p.Run_Id = runId;
            var res = await cl.RunRetrieveAsync(p);
            if (res.Status != "queued" &&
                res.Status != "in_progress" &&
                res.Status != "cancelling")
            {
                var p1 = new MessagesParameter();
                p1.Thread_Id = threadId;
                p1.QueryParameter.Order = "desc";
                var res1 = await cl.MessagesAsync(p1);
                foreach (var item in res1.Data)
                {
                    foreach (var content in item.Content)
                    {
                        if (content.Text == null) { continue; }
                        Console.WriteLine(content.Text.Value);
                    }
                }
                break;
            }
            loopCount++;
            if (loopCount > 120) { break; }
        }

    }
    private async ValueTask SendMessageAsync()
    {
        var cl = OpenAIClient;

        var (assistantId, threadId) = await this.CreateNewThread();
        {
            var p = new MessageCreateParameter();
            p.Thread_Id = threadId;
            p.Role = "user";
            p.AddTextMessage("Hello! I want to know how to enjoy camp in the mountain.");
            //p.AddTextMessage("Please answer by Japanese.");
            var res = await cl.MessageCreateAsync(p);
        }
        var runId = "";
        {
            var p = new RunCreateParameter();
            p.Assistant_Id = assistantId;
            p.Thread_Id = threadId;

            var streamResult = new AssistantMessageStreamResult();
            await foreach (string text in cl.RunCreateStreamAsync(p, streamResult, CancellationToken.None))
            {
                Console.Write(text);
            }
            runId = streamResult.Run?.Id ?? "";

            Console.WriteLine();
            Console.WriteLine();
        }
    }
    private async ValueTask SendImageAsync()
    {
        var cl = OpenAIClient;

        var (assistantId, threadId) = await this.CreateNewThread();
        {
            var p = new MessageCreateParameter();
            p.Thread_Id = threadId;
            p.Role = "user";
            p.AddTextMessage("Please explain about this picture. And how do you feel to see this landscape?");
            p.AddImageUrl("https://static.tinybetter.com/public-data/drone-image/DJI_0830-2MB.jpg");
            var res = await cl.MessageCreateAsync(p);
        }
        var runId = "";
        {
            var p = new RunCreateParameter();
            p.Assistant_Id = assistantId;
            p.Thread_Id = threadId;

            var streamResult = new AssistantMessageStreamResult();
            await foreach (string text in cl.RunCreateStreamAsync(p, streamResult, CancellationToken.None))
            {
                Console.Write(text);
            }
            runId = streamResult.Run?.Id ?? "";

            Console.WriteLine();
            Console.WriteLine();
        }
    }
    private async ValueTask SendMessageWithImageUrlAsync()
    {
        var cl = OpenAIClient;

        var (assistantId, threadId) = await this.CreateNewThread();
        {
            var p = new MessageCreateParameter();
            p.Thread_Id = threadId;
            p.Role = "user";
            p.AddTextMessage("How about this image? Please explain from photographer perspective.");
            //From https://www.stockvault.net/c/nature/landscape
            //You can change url of image!
            p.AddImageUrl("https://www.stockvault.net/data/2007/03/01/102413/thumb16.jpg");
            var res = await cl.MessageCreateAsync(p);
        }
        var runId = "";
        {
            var p = new RunCreateParameter();
            p.Assistant_Id = assistantId;
            p.Thread_Id = threadId;

            var streamResult = new AssistantMessageStreamResult();
            await foreach (string text in cl.RunCreateStreamAsync(p, streamResult, CancellationToken.None))
            {
                Console.Write(text);
            }
            runId = streamResult.Run?.Id ?? "";

            Console.WriteLine();
            Console.WriteLine();
        }
    }
    private async ValueTask SendMessageWithImageFileAsync()
    {
        var cl = OpenAIClient;

        var (assistantId, threadId) = await this.CreateNewThread();
        var fileId = "";
        {
            var p = new FileUploadParameter();
            p.File.SetFile("Yugama.jpg", File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, "Image", "Yugama.jpg")));
            p.SetPurpose(FilePurpose.Assistants);
            var res = await cl.FileUploadAsync(p);
            fileId = res.Id;
        }
        {
            var p = new MessageCreateParameter();
            p.Thread_Id = threadId;
            p.Role = "user";
            p.AddTextMessage("How about this image? Please explain from photographer perspective.");
            p.AddImageFile(fileId);
            var res = await cl.MessageCreateAsync(p);
        }
        {
            var p = new RunCreateParameter();
            p.Assistant_Id = assistantId;
            p.Thread_Id = threadId;

            var streamResult = new AssistantMessageStreamResult();
            await foreach (string text in cl.RunCreateStreamAsync(p, streamResult, CancellationToken.None))
            {
                Console.Write(text);
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
    private async ValueTask ThreadMessage()
    {
        var cl = OpenAIClient;

        int pageNumbuer = 1;
        var p = new MessagesParameter();
        p.Thread_Id = "thread_SLRZuUllau88ZWojp09K8B0U";
        p.QueryParameter.Limit = 2;
        p.QueryParameter.Order = "desc";

        var messageId = "";
        while (true)
        {
            var res = await cl.MessagesAsync(p);
            Console.WriteLine("■Page " + pageNumbuer);
            foreach (var rMessage in res.Data)
            {
                foreach (var content in rMessage.Content)
                {
                    Console.WriteLine(content.Text);
                    Console.WriteLine("--------------------------------------------------------");
                }
                messageId = rMessage.Id;
            }
            pageNumbuer++;
            if (res.Has_More == false) { break; }
            p.QueryParameter.After = res.Last_Id;
        }

        //Retrieve latest message.
        var m = await cl.MessageRetrieveAsync(p.Thread_Id, messageId);

    }
    private async ValueTask Runs()
    {
        var cl = OpenAIClient;

        var threadId = "thread_xxxxxxxxxxxxxxx";
        var res = await cl.RunsAsync(threadId);
        foreach (var item in res.Data)
        {
            var res1 = await cl.RunStepsAsync(threadId, item.Id);
            foreach (var step in res1.Data)
            {
                if (step.Step_Details != null)
                {
                    Console.WriteLine(step.Step_Details.GetDescription());
                    Console.WriteLine("--------------------------------------------------------");
                }
            }
        }
    }

    private async ValueTask RealtimeSession()
    {
        var cl = OpenAIClient;
        var res = await cl.RealtimeSessionsAsync("gpt-4o", CancellationToken.None);
        Console.WriteLine("key: " + res.Client_Secret.Value);
        Console.WriteLine("expire at:" + res.Client_Secret.ExpireTime);
    }

    private async ValueTask ProcessVectorStore()
    {
        var cl = OpenAIClient;

        var assistantId = "";
        var assistantName = "HigLabo vector store Assistant";
        var assistantsResponse = await cl.AssistantsAsync();
        foreach (var item in assistantsResponse.Data)
        {
            if (item.Name == assistantName)
            {
                assistantId += item.Id;
                break;
            }
        }
        if (assistantId.IsNullOrEmpty())
        {
            var res = await AssistantCreate(assistantName);
            assistantId = res.Id;
        }

        var storesResponse = await cl.VectorStoresAsync();
        var storeId = "";
        var vectorStoreName = "HigLabo vector store";
        if (storesResponse.Data.Count == 0)
        {
            var res = await VectorStoreCreate();
            storeId = res.Id;
        }
        else
        {
            foreach (var item in storesResponse.Data)
            {
                if (item.Name == vectorStoreName)
                {
                    storeId = storesResponse.Data[0].Id;
                    break;
                }
            }
        }
        if (storeId.IsNullOrEmpty())
        {
            var p = new VectorStoreCreateParameter();
            p.Name = vectorStoreName;
            p.Chunking_Strategy = new ChunkingStrategy()
            {
                Type = "static",
                Static = new ChunkingStrategyStatic()
                {
                    Max_Chunk_Size_Tokens = 1000,
                    Chunk_Overlap_Tokens = 100,
                },
            };
            var res = await cl.VectorStoreCreateAsync(p);
            storeId = res.Id;
            Console.WriteLine(res);
        }

        var file_id = "";
        {
            var p = new FilesParameter();
            p.QueryParameter.Purpose = "assistants";
            var res = await cl.FilesAsync(p);
            foreach (var item in res.Data)
            {
                if (item.FileName == "1bit_transformers.pdf")
                {
                    file_id = item.Id;
                    break;
                }
            }
        }
        if (file_id.IsNullOrEmpty())
        {
            var p = new FileUploadParameter();
            p.File.SetFile("1bit_transformers.pdf", File.ReadAllBytes("C:\\Data\\Dev\\1bit_transformers.pdf"));
            p.SetPurpose(FilePurpose.Assistants);
            var res = await cl.FileUploadAsync(p);
            Console.WriteLine(res);

            file_id = res.Id;
        }
        {
            var p = new VectorStoreFileBatchCreateParameter();
            p.Vector_Store_Id = storeId;
            p.File_Ids = new List<string>();
            p.File_Ids.Add(file_id);
            var res = await cl.VectorStoreFileBatchCreateAsync(p);
        }

        {
            var p = new AssistantModifyParameter();
            p.Assistant_Id = assistantId;
            p.Tool_Resources = new
            {
                file_search = new
                {
                    vector_store_ids = new string[] { storeId },
                },
            };
            var res = await cl.AssistantModifyAsync(p);
            Console.WriteLine(res);
        }


        var now = DateTimeOffset.Now;
        var threadId = "";
        if (threadId.Length == 0)
        {
            var res = await cl.ThreadCreateAsync();
            threadId = res.Id;
        }
        {
            var p = new RunCreateParameter();
            p.Assistant_Id = assistantId;
            p.Thread_Id = threadId;
            p.Temperature = 0.5;
            p.Additional_Messages = new List<ThreadAdditionalMessageObject>();
            p.Additional_Messages.Add(new ThreadAdditionalMessageObject()
            {
                Role = "user",
                Content = "I want to know about 1-bit transformers.",
            });
            var result = new AssistantMessageStreamResult();
            await foreach (string text in cl.RunCreateStreamAsync(p, result, CancellationToken.None))
            {
                Console.Write(text);
            }
            Console.WriteLine();

            Console.WriteLine(JsonConvert.SerializeObject(result.Thread));
            Console.WriteLine(JsonConvert.SerializeObject(result.Run));
            Console.WriteLine(JsonConvert.SerializeObject(result.RunStep));
            Console.WriteLine(JsonConvert.SerializeObject(result.Message));

        }
    }
    private async ValueTask<VectorStoreCreateResponse> VectorStoreCreate()
    {
        var cl = OpenAIClient;

        var p = new VectorStoreCreateParameter();
        p.Name = "HigLabo vector store";
        var res = await cl.VectorStoreCreateAsync(p);
        Console.WriteLine(res);
        return res;
    }
}
