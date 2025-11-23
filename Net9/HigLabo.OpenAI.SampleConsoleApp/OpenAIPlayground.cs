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
using static HigLabo.OpenAI.ChatCompletionFunctionTool;
using static System.Net.Mime.MediaTypeNames;

namespace HigLabo.OpenAI;

public class OpenAIPlayground
{
    public OpenAIClient OpenAIClient { get; set; } = new("");

    public async ValueTask ExecuteAsync()
    {
        SetOpenAISetting();
        await ResponseCreateDeepResearch();
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

        var res = await cl.AudioSpeechAsync("Stay Hungry. Stay Foolish. Thank you all very much.", "tts-1", "alloy");
        var filePath = Path.Combine(Environment.CurrentDirectory, "Generated", $"Audio_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.mp3");
        File.WriteAllBytes(filePath, res.Stream!.ToByteArray());
        Console.WriteLine($"{DateTimeOffset.Now.ChangeTimeZone(9).ToString()} File is created to " + filePath);
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

        var p = new ChatCompletionCreateParameter();
        var theme = "How to enjoy coffee";
        p.Messages.Add(new ChatMessage(ChatMessageRole.User
            , $"Can you provide me with some ideas for blog posts about {theme}?"));
        p.Model = cl.ServiceProvider switch
        {
            ServiceProvider.Groq => "llama3-70b-8192",
            ServiceProvider.DeepSeek => "deepseek-chat",
            _ => "gpt-4o",
        };
        var res = await cl.ChatCompletionCreateAsync(p);
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
        await foreach (string text in cl.ChatCompletionCreateStreamAsync("How to enjoy coffee?", model, result, CancellationToken.None))
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

        var p = new ChatCompletionCreateParameter();
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
        await foreach (string text in cl.ChatCompletionCreateStreamAsync(p, result, CancellationToken.None))
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
    private async ValueTask ChatCompletionVision()
    {
        var cl = OpenAIClient;

        var p = new ChatCompletionCreateParameter();

        var vMessage = new ChatImageMessage(ChatMessageRole.User);
        vMessage.AddTextContent("Please describe this image.");
        vMessage.AddImageFile(Path.Combine(Environment.CurrentDirectory, "Image", "Pond.jpg"));
        p.Messages.Add(vMessage);
        p.Model = "gpt-4o";
        p.Max_Completion_Tokens = 300;
        p.Stream = true;

        var result = new ChatCompletionStreamResult();
        await foreach (var text in cl.ChatCompletionCreateStreamAsync(p, result, CancellationToken.None))
        {
            Console.Write(text);
        }
        Console.WriteLine("");
        Console.WriteLine("■DONE");
    }
    private async ValueTask ChatCompletionJsonFormat()
    {
        var cl = OpenAIClient;

        var p = new ChatCompletionCreateParameter();
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

        var res = await cl.ChatCompletionCreateAsync(p);
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

        var p = new ChatCompletionCreateParameter();
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
        var res = await cl.ChatCompletionCreateAsync(p);
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

    private async ValueTask ResponseCreate()
    {
        var cl = OpenAIClient;

        var p = new ResponseCreateParameter();
        p.Model = "gpt-4o";
        p.Input.AddUserMessage("How to enjoy coffee?");
        var res = await cl.ResponseCreateAsync(p, CancellationToken.None);
        foreach (var output in res.Output)
        {
            foreach (var content in output.Content)
            {
                Console.WriteLine(content.Type);
                switch (content.Type)
                {
                    case "output_text": Console.WriteLine(content.Text); break;
                    default: break;
                }
            }
        }

        Console.WriteLine("■DONE");
    }
    private async ValueTask ResponseCreateFunctionCalling()
    {
        var cl = OpenAIClient;

        var p = new ResponseCreateParameter();
        p.Model = "gpt-4.1-mini";
        p.Input.AddUserMessage("I want to know the whether of Tokyo and longitude and latitude.");

        p.Parallel_Tool_Calls = true;
        p.Tools = new List<Tool>();
        p.Tools.Add(this.CreateGetWheatherTool());
        p.Tools.Add(this.CreateGetLatLongTool());

        var result = new ResponseStreamResult();
        await foreach (var text in cl.ResponseCreateStreamAsync(p, result, CancellationToken.None))
        {
            Console.Write(text);
        }
        Console.WriteLine();

        var ee = result.GetEventList();
        foreach (var f in result.GetFunctionCallList())
        {
            Console.WriteLine("■Function name is " + f.Name);
            Console.WriteLine("■Arguments is " + f.Arguments);
            var functionCallResultText = f.Name switch
            {
                "getWhether" => "Cloudy days. Temperature is 21℃",
                "getLatLong" => "N35°41.4′/ E139°45.6",
                _ => throw SwitchStatementNotImplementException.Create(f.Name),
            };
            p.Input.AddToolCallMessage(f, functionCallResultText);
            p.Previous_Response_Id = result.Response!.Response!.Id;
        }
        var fResult = await cl.ResponseCreateAsync(p);
        foreach (var output in fResult.Output)
        {
            foreach (var content in output.Content)
            {
                Console.WriteLine(content.Text);
            }
        }
        Console.WriteLine();
    }
    private async ValueTask ResponseCreateFunctionCallingStream()
    {
        var cl = OpenAIClient;

        var p = new ResponseCreateParameter();
        p.Model = "gpt-4.1-mini";
        p.Input.AddUserMessage("I want to know the whether of Tokyo and longitude and latitude. And I want to know the good spot to visit in Japan.");

        p.Parallel_Tool_Calls = true;
        p.Tools = new List<Tool>();
        p.Tools.Add(this.CreateGetTouristSpotTool());
        p.Tools.Add(this.CreateGetLatLongTool());

        var result = new ResponseStreamResult();
        using (var tokenSource = new CancellationTokenSource())
        {
            tokenSource.CancelAfter(TimeSpan.FromMinutes(3));

            await foreach (var item in cl.ResponseCreateEventStreamAsync(p, result, tokenSource.Token))
            {
                var oEvent = item.CreateTypedData();
                if (oEvent is IResponseStreamEventDelta oDelta)
                {
                    Console.Write(oDelta.Delta);
                }
            }
        }

        var ee = result.GetEventList();
        foreach (var f in result.GetFunctionCallList())
        {
            Console.WriteLine("■Function name is " + f.Name);
            Console.WriteLine("■Arguments is " + f.Arguments);
            var functionCallResultText = f.Name switch
            {
                "getWhether" => "Cloudy days. Temperature is 21℃",
                "getTouristSpot" => "[\"locationList\" : [\"Asakusa\"]",
                "getLatLong" => "N35°41.4′/ E139°45.6",
                _ => throw SwitchStatementNotImplementException.Create(f.Name),
            };
            p.Input.AddToolCallMessage(f, functionCallResultText);
            p.Previous_Response_Id = result.Response!.Response!.Id;
        }
        var fResult = await cl.ResponseCreateAsync(p);
        foreach (var output in fResult.Output)
        {
            foreach (var content in output.Content)
            {
                Console.WriteLine(content.Text);
            }
        }

        Console.WriteLine();
    }
    private async ValueTask ResponseCreateWebSearch()
    {
        var cl = OpenAIClient;

        var p = new ResponseCreateParameter();
        p.Model = "gpt-4.1-mini";
        p.Input.AddUserMessage("How to enjoy coffee near by Shibuya station? Please search shop list from web.");
        p.Tools = [];
        p.Tools.Add(new Tool("web_search"));
        var res = await cl.ResponseCreateAsync(p, CancellationToken.None);
        foreach (var output in res.Output)
        {
            foreach (var content in output.Content)
            {
                Console.WriteLine(content.Type);
                switch (content.Type)
                {
                    case "output_text": Console.WriteLine(content.Text); break;
                    default: break;
                }
            }
        }

        Console.WriteLine("■DONE");
    }
    private async ValueTask ResponseCreateWebSearchStream()
    {
        var cl = OpenAIClient;
        var location = "Newyork";

        var p = new ResponseCreateParameter();
        p.Model = "gpt-5";
        p.Input.AddUserMessage($"How to enjoy coffee near by {location}? Please search shop list from web.");
        p.Tools = [];
        p.Tools.Add(new Tool("web_search"));
        var result = new ResponseStreamResult();
        await foreach (string text in cl.ResponseCreateStreamAsync(p, result, CancellationToken.None))
        {
            Console.Write(text);
        }
        Console.WriteLine();
        Console.WriteLine();

        var ee = result.GetEventList();
        foreach (var item in ee)
        {
            if (item is ResponseStreamContentPart o)
            {
                foreach (var annotation in o.Part.Annotations)
                {
                    Console.WriteLine(annotation.ToString());
                }
            }
        }
        Console.WriteLine("■DONE");
    }
    private async ValueTask ResponseCreateWebSearchEventStream()
    {
        var cl = OpenAIClient;
        var location = "Newyork";

        var p = new ResponseCreateParameter();
        p.Model = "gpt-4o";
        p.Input.AddUserMessage($"How to enjoy coffee near by {location}? Please search shop list from web.");
        p.Tools = [];
        p.Tools.Add(new Tool("web_search"));
        var result = new ResponseStreamResult();
        await foreach (var item in cl.ResponseCreateEventStreamAsync(p, result, CancellationToken.None))
        {
            var oEvent = item.CreateTypedData();
            var oDelta = oEvent as IResponseStreamEventDelta;
            if (oDelta == null)
            {
                Console.WriteLine(oEvent.Type);
            }
            else
            {
                Console.Write(oDelta.Delta);
            }
        }
        Console.WriteLine();
        Console.WriteLine();

        var ee = result.GetEventList();
        foreach (var item in ee)
        {
            if (item is ResponseStreamContentPart o)
            {
                foreach (var annotation in o.Part.Annotations)
                {
                    Console.WriteLine(annotation.ToString());
                }
            }
        }
        Console.WriteLine("■DONE");
    }
    private async ValueTask ResponseCreateImageGenaration()
    {
        var cl = OpenAIClient;

        var p = new ResponseCreateParameter();
        p.Model = "gpt-5";
        p.Input.AddUserMessage("Please change this image to anime-inspired look style and generate new image.");
        //p.Input[0].AddImage("image/png", File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, "Image", "Mt_Hakuun.png")));
        //p.Input[0].AddImage("image/png", File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, "Image", "DragonEye.jpg")));
        p.Input[0].AddImage("image/png", File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, "Image", "Mt_Yari.jpg")));
        //p.Input[0].AddImage("image/png", File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, "Image", "Mt_Tsurugi.jpg")));
        p.Tools = [];
        p.Tools.Add(new Tool("image_generation"));

        Console.WriteLine("Generateing...");
        var res = await cl.ResponseCreateAsync(p, CancellationToken.None);
        foreach (var output in res.Output)
        {
            switch (output.Type)
            {
                case "message":
                    foreach (var content in output.Content)
                    {
                        if (content.Type == "output_text")
                        {
                            Console.WriteLine(content.Text);
                        }
                    }
                    break;
                case "image_generation_call":
                    Console.WriteLine(output.Revised_Prompt);
                    var imageData = Convert.FromBase64String(output.Result);
                    var folderPath = Path.Combine(Environment.CurrentDirectory, "Generated");
                    if (Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    var filePath = Path.Combine(Environment.CurrentDirectory, "Generated", $"Image_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.png");
                    File.WriteAllBytes(filePath, imageData);
                    Console.WriteLine("File is saved to");
                    Console.WriteLine(filePath);
                    break;
                default: break;
            }
        }
        Console.WriteLine("Total tokens: " + res.Usage.Total_Tokens);

        Console.WriteLine("■DONE");
    }
    private async ValueTask ResponseCreateImageGenarationStream()
    {
        var cl = OpenAIClient;

        var p = new ResponseCreateParameter();
        p.Model = "gpt-5";
        p.Input.AddUserMessage("Please change this image to anime-inspired look style and generate new image.");
        p.Input[0].AddImage("https://static.tinybetter.com/public-data/drone-image/PXL_20231018_073935194.jpg");
        p.Tools = [];
        p.Tools.Add(new Tool("image_generation"));

        Console.WriteLine("Generateing...");
        var result = new ResponseStreamResult();
        await foreach (var item in cl.ResponseCreateEventStreamAsync(p, result, CancellationToken.None))
        {
            var oEvent = item.CreateTypedData();
            if (oEvent is IResponseStreamEventDelta oDelta)
            {
                Console.Write(oDelta.Delta);
            }
            if (oEvent is ResponseStreamImageGenerationCallPartialImage oImage)
            {
                var imageData = oImage.GetBytes();
                var folderPath = Path.Combine(Environment.CurrentDirectory, "Generated");
                Directory.CreateDirectory(folderPath);
                var filePath = Path.Combine(Environment.CurrentDirectory, "Generated", $"Image_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.png");
                File.WriteAllBytes(filePath, imageData);
                Console.WriteLine("File is saved to");
                Console.WriteLine(filePath);
            }
            else
            {
                Console.WriteLine(item.Data);
            }
        }
        Console.WriteLine("Total tokens: " + result.Response?.Response?.Usage.Total_Tokens);

        Console.WriteLine("■DONE");
    }

    private async ValueTask ResponseCreateFileSearchStream()
    {
        var cl = OpenAIClient;

        var storeId = await GetVectorStoreId();

        var p = new ResponseCreateParameter();
        p.Model = "gpt-4o";
        p.Input.AddUserMessage("I want to know about 1-bit transformers.");
        p.Tools = [];
        p.Tools.Add(new FileSearchTool()
        {
            Vector_Store_Ids = [storeId],
            Max_Num_Results = 20,
        });
        var result = new ResponseStreamResult();
        await foreach (string text in cl.ResponseCreateStreamAsync(p, result, CancellationToken.None))
        {
            Console.Write(text);
        }
        Console.WriteLine();
        Console.WriteLine();

        foreach (var item in result.EventList)
        {
            if (item.EventName == "response.web_search_call.completed")
            {
                Console.WriteLine(item.Data);
            }
        }

        Console.WriteLine("■DONE");
    }
    private async ValueTask ResponseCreateFileStream()
    {
        var cl = OpenAIClient;

        var p = new ResponseCreateParameter();
        p.Model = "gpt-4o";
        p.Input.AddUserMessage("Please explain about this pdf file.");
        p.Input[0].AddImage("image/jpeg", File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, "File", "AI_Forecast.pdf")));

        var result = new ResponseStreamResult();
        await foreach (string text in cl.ResponseCreateStreamAsync(p, result, CancellationToken.None))
        {
            Console.Write(text);
        }
        Console.WriteLine();
        Console.WriteLine();

        foreach (var item in result.EventList)
        {
            if (item.EventName == "response.web_search_call.completed")
            {
                Console.WriteLine(item.Data);
            }
        }
        Console.WriteLine("■DONE");
    }
    private async ValueTask ResponseCreateFileIdStream()
    {
        var cl = OpenAIClient;

        var fileId = "";
        {
            var p = new FilesParameter();
            p.QueryParameter.Purpose = "user_data";
            var res = await cl.FilesAsync(p);
            foreach (var item in res.Data)
            {
                fileId = item.Id;
            }
        }
        {
            var p = new ResponseCreateParameter();
            p.Model = "gpt-4o";
            p.Input.AddUserMessage("Please explain about this pdf file.");
            p.Input[0].AddFile(fileId);

            var result = new ResponseStreamResult();
            await foreach (string text in cl.ResponseCreateStreamAsync(p, result, CancellationToken.None))
            {
                Console.Write(text);
            }
            Console.WriteLine();
            Console.WriteLine();

            foreach (var item in result.EventList)
            {
                if (item.EventName == "response.web_search_call.completed")
                {
                    Console.WriteLine(item.Data);
                }
            }
        }
        Console.WriteLine("■DONE");
    }

    private async ValueTask ResponseCreateDeepResearch()
    {
        var cl = OpenAIClient;

        var p = new ResponseCreateParameter();
        p.Model = "o3-deep-research";
        p.Input.AddUserMessage($"まずはWEBを検索しAIに関するニュースを集めてください。その後、それらのニュースをニュースキャスターが読むような原稿を作成してください。原稿は読み上げ時間が3分くらいのモノにしてください。");
        p.Stream = true;
        p.Tools = [];
        p.Tools.Add(new Tool("web_search_preview"));
        var result = new ResponseStreamResult();
        await foreach (var item in cl.GetResponseStreamEventAsync(p, result, CancellationToken.None))
        {
            var o = item.CreateTypedData();
            if (o is IResponseStreamEventDelta oDelta)
            {
                Console.Write(oDelta.Delta);
            }
            if (o is ResponseStreamWebSearchCall oWebSearch)
            {
                Console.WriteLine(item.Data);
            }
        }
        var usage = result.Response?.Response?.Usage;
        if (usage != null)
        {
            Console.WriteLine("Input tokens: " + usage.Input_Tokens);
            Console.WriteLine("Output tokens: " + usage.Output_Tokens);
            Console.WriteLine("Reasoning tokens: " + usage.Output_Tokens_Details.Reasoning_Tokens);
            Console.WriteLine("Total tokens: " + usage.Total_Tokens);
        }

        Console.WriteLine("■DONE");
    }

    private async ValueTask ResponseCreateReasoningEventStream()
    {
        var cl = OpenAIClient;

        var p = new ResponseCreateParameter();
        p.Model = "o4-mini";
        //p.Instructions = "You are a personal math tutor. When asked a math question, run code to answer the question.";
        p.Input.AddUserMessage($"Write a bash script that takes a matrix represented as a string with \r\nformat '[1,2],[3,4],[5,6]' and prints the transpose in the same format.");
        p.Reasoning = new();
        p.Reasoning.Effort = "high";
        p.Reasoning.Summary = "detailed";
        var result = new ResponseStreamResult();

        var mode = "";
        Console.WriteLine(p.Input[0].Content[0].Text);
        await foreach (var item in cl.ResponseCreateEventStreamAsync(p, result, CancellationToken.None))
        {
            switch (item.EventName)
            {
                case ResponseStreamEventName.Reasoning_Summary_Text.Delta:
                    {
                        var o = item.CreateTypedData() as IResponseStreamEventDelta;
                        if (mode != "Thinking")
                        {
                            mode = "Thinking";
                            Console.WriteLine("■Thinking...");
                        }
                        Console.Write(o?.Delta);
                    }
                    break;
                case ResponseStreamEventName.Reasoning_Summary_Part.Done:
                    mode = "";
                    Console.WriteLine();
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine();
                    break;
                case ResponseStreamEventName.Output_Text.Delta:
                    {
                        var o = item.CreateTypedData() as IResponseStreamEventDelta;
                        if (mode != "Output")
                        {
                            mode = "Output";
                            Console.WriteLine("■Output");
                        }
                        Console.Write(o?.Delta);
                    }
                    break;
                default:
                    break;
            }
        }
        Console.WriteLine();
        Console.WriteLine();

        var ee = result.GetEventList();
   
        if (result.Response != null)
        {
            Console.WriteLine();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("■Response Item List");
            var res = await cl.ResponseInputItemRetrieveAsync(result.Response.Response.Id);
            foreach (var item in res.Data)
            {
                foreach (var content in item.Content)
                {
                    Console.WriteLine(content.Text);
                }
            }
        }

        Console.WriteLine("■DONE");
    }
    private async ValueTask ResponseCreateMcpStream()
    {
        var cl = OpenAIClient;

        var p = new ResponseCreateParameter();
        p.Model = "gpt-4o";
        p.Input.AddUserMessage($"Please tell me about the architecture of this repository. https://github.com/openai/codex");
        p.Tools = [];
        p.Tools.Add(new McpCallTool()
        {
            Server_Label = "deepwiki",
            Server_Url = "https://mcp.deepwiki.com/mcp",
            Require_Approval = "never",
        });
        var result = new ResponseStreamResult();
        await foreach (string text in cl.ResponseCreateStreamAsync(p, result, CancellationToken.None))
        {
            Console.Write(text);
        }
        Console.WriteLine();
        Console.WriteLine();

        foreach (var item in result.EventList)
        {
            Console.WriteLine(item.Data);
        }

        var ee = result.GetEventList();
        Console.WriteLine("■DONE");
    }
    private async ValueTask ResponseCreateMcpEventStream()
    {
        var cl = OpenAIClient;

        var p = new ResponseCreateParameter();
        p.Model = "gpt-4o";
        p.Input.AddUserMessage($"Please tell me about the architecture of this repository. https://github.com/openai/codex");
        p.Tools = [];
        p.Tools.Add(new McpCallTool()
        {
            Server_Label = "deepwiki",
            Server_Url = "https://mcp.deepwiki.com/mcp",
            Require_Approval = "never",
        });
        var result = new ResponseStreamResult();
        await foreach (var item in cl.ResponseCreateEventStreamAsync(p, result, CancellationToken.None))
        {
            var oEvent = item.CreateTypedData();
            var oDelta = oEvent as IResponseStreamEventDelta;
            if (oDelta == null)
            {
                Console.WriteLine(oEvent.Type);
            }
            else
            {
                Console.Write(oDelta.Delta);
            }
        }
        Console.WriteLine();
        Console.WriteLine();

        foreach (var item in result.EventList)
        {
            Console.WriteLine(item.Data);
        }

        var ee = result.GetEventList();
        Console.WriteLine("■DONE");
    }

    private FunctionTool CreateGetWheatherChatCompletionTool()
    {
        var tool = new FunctionTool();
        tool.Name = "getWhether";
        tool.Description = "This service can get whether of specified location.";
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
        tool.Parameters = o;
        return tool;
    }
    private FunctionTool CreateGetTouristSpotChatCompletionTool()
    {
        var tool = new FunctionTool();
        tool.Name = "getTouristSpot";
        tool.Description = "This service can get tourist spot of specified region.";
        tool.Parameters = new
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
    private FunctionTool CreateGetLatLongChatCompletionTool()
    {
        var tool = new FunctionTool();
        tool.Name = "getLatLong";
        tool.Description = "This service can get latitude and longitude of specified location.";
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
            Items = new JsonSchema("string") { },
        });
        tool.Parameters = o;
        return tool;
    }
    private FunctionTool CreateDocumentFileColumnExtractChatCompletionTool()
    {
        var tool = new FunctionTool();
        tool.Name = "DataExtract";
        tool.Description = "Extract item data from file.";
        var o = new JsonSchema();
        o.Properties.Add("PersonName", new JsonSchemaProperty("string", "Person name."));
        o.Properties.Add("CompanyName", new JsonSchemaProperty("string", "Company name."));
        o.Properties.Add("Address", new JsonSchemaProperty("string", "Address.."));
        o.Properties.Add("MailAddress", new JsonSchemaProperty("string", "Email address."));
        tool.Parameters = o;
        return tool;
    }

    private Tool CreateGetWheatherTool()
    {
        var tool = new FunctionTool();
        tool.Name = "getWhether";
        tool.Description = "This service can get whether of specified location.";
        var o = new JsonSchema();
        o.Properties.Add("location", new JsonSchemaProperty("string", "Location list that you want to know."));
        tool.Parameters = o;
        return tool;
    }
    private Tool CreateGetTouristSpotTool()
    {
        var tool = new FunctionTool();
        tool.Name = "getTouristSpot";
        tool.Description = "This service can get tourist spot of specified region.";
        tool.Parameters = new
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
    private Tool CreateGetLatLongTool()
    {
        var tool = new FunctionTool();
        tool.Name = "getLatLong";
        tool.Description = "This service can get latitude and longitude of specified location.";
        var o = new JsonSchema();
        o.Properties.Add("locationList", new JsonSchemaProperty("array", "Location list that you want to know.")
        {
            Items = new JsonSchema("string") { },
        });
        tool.Parameters = o;
        return tool;
    }
    private Tool CreateDocumentFileColumnExtractTool()
    {
        var tool = new FunctionTool();
        tool.Name = "DataExtract";
        tool.Description = "Extract item data from file.";
        var o = new JsonSchema();
        o.Properties.Add("PersonName", new JsonSchemaProperty("string", "Person name."));
        o.Properties.Add("CompanyName", new JsonSchemaProperty("string", "Company name."));
        o.Properties.Add("Address", new JsonSchemaProperty("string", "Address.."));
        o.Properties.Add("MailAddress", new JsonSchemaProperty("string", "Email address."));
        tool.Parameters = o;
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
    private async ValueTask FileUpload_UserData()
    {
        var cl = OpenAIClient;

        var p = new FileUploadParameter();
        var filePath = File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, "File", "AI_Forecast.pdf"));
        p.File.SetFile("AI_Forecast.pdf", filePath);
        p.SetPurpose(FilePurpose.UserData);
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
        //p.Model = "dall-e-3";
        p.Model = "gpt-image-1";
        p.Quality = "medium";

        Console.WriteLine($"{DateTimeOffset.Now.ChangeTimeZone(9).ToString()} Image generation started");
        var res = await cl.ImagesGenerationsAsync(p);
        foreach (var item in res.Data)
        {
            var bb = item.GetBytes();
            var filePath = Path.Combine(Environment.CurrentDirectory, $"Image_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.png");
            File.WriteAllBytes(filePath, bb);
            Console.WriteLine("File is created to " + filePath);
        }
    }
    private async ValueTask ImageEdit()
    {
        var cl = OpenAIClient;

        var p = new ImagesEditsParameter();
        p.Image.Files.Add(new FileParameter("image[]", "Mt_Yari.jpg", new MemoryStream(File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, "Image", "Mt_Yari.jpg")))));
        p.Prompt = "A cinematic storyboard key frame depicting a group of people standing on the summit of a towering rocky mountain as the sun rises behind them. Vast clouds surround the mountain, bathed in warm orange and purple light. The scene should evoke feelings of awe, tranquility, and achievement. Drawn in a detailed, anime-inspired art style with emphasis on light, atmosphere, and emotional storytelling.";
        //p.Prompt = "A cinematic storyboard key frame of a mountain-top scene, using one of the following camera compositions only: Bird’s-eye view from above, Low-angle shot looking up at the climbers, Silhouette shot against the rising sun, Wide zoom-out shot showing the vast landscape, or Side lighting composition with warm sunlight rays. Each image should depict only one composition per frame and look like a cinematic anime storyboard with dramatic lighting and strong mood.";
        //p.Prompt = "A cinematic storyboard key frame capturing the moment of reaching the mountain peak, expressing one single emotion per image: Serenity and accomplishment, Joy and celebration, Solitude and reflection, Prayer and hope, or Bittersweet farewell. Use light direction, camera framing, and color tone to visually convey the emotion in anime keyframe style.";
        //p.Prompt = "A cinematic storyboard key frame showing the same mountain summit at a specific time of day — choose one per image: Before dawn (deep blue calm), Sunrise (golden light breaking through clouds), Afternoon (clear, bright atmosphere), Sunset (warm, glowing horizon), or Night (starry sky and tranquil mood). Each image should represent a single scene and resemble an anime movie keyframe with cinematic lighting transitions.";
        p.Model = "gpt-image-1";
        p.Quality = "medium";
        p.N = 4;

        Console.WriteLine($"{DateTimeOffset.Now.ChangeTimeZone(9).ToString()} Image generation started");
        var res = await cl.ImagesEditsAsync(p);
        for (int i = 0; i < res.Data.Count; i++)
        {
            var bb = res.Data[i].GetBytes();
            var filePath = Path.Combine(Environment.CurrentDirectory, "Generated", $"Image_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}_{i}.png");
            File.WriteAllBytes(filePath, bb);
            Console.WriteLine($"{DateTimeOffset.Now.ChangeTimeZone(9).ToString()} File is created to " + filePath);
        }
        Console.WriteLine("Total tokens: " + res.Usage.Total_Tokens);
    }
    private async ValueTask ImageEditStream()
    {
        var cl = OpenAIClient;

        var p = new ImagesEditsParameter();
        p.Image.Files.Add(new FileParameter("image[]", "Mt_Yari.jpg", new MemoryStream(File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, "Image", "Mt_Yari.jpg")))));
        p.Prompt = "A cinematic storyboard key frame depicting a group of people standing on the summit of a towering rocky mountain as the sun rises behind them. Vast clouds surround the mountain, bathed in warm orange and purple light. The scene should evoke feelings of awe, tranquility, and achievement. Drawn in a detailed, anime-inspired art style with emphasis on light, atmosphere, and emotional storytelling.";
        //p.Prompt = "A cinematic storyboard key frame of a mountain-top scene, using one of the following camera compositions only: Bird’s-eye view from above, Low-angle shot looking up at the climbers, Silhouette shot against the rising sun, Wide zoom-out shot showing the vast landscape, or Side lighting composition with warm sunlight rays. Each image should depict only one composition per frame and look like a cinematic anime storyboard with dramatic lighting and strong mood.";
        //p.Prompt = "A cinematic storyboard key frame capturing the moment of reaching the mountain peak, expressing one single emotion per image: Serenity and accomplishment, Joy and celebration, Solitude and reflection, Prayer and hope, or Bittersweet farewell. Use light direction, camera framing, and color tone to visually convey the emotion in anime keyframe style.";
        //p.Prompt = "A cinematic storyboard key frame showing the same mountain summit at a specific time of day — choose one per image: Before dawn (deep blue calm), Sunrise (golden light breaking through clouds), Afternoon (clear, bright atmosphere), Sunset (warm, glowing horizon), or Night (starry sky and tranquil mood). Each image should represent a single scene and resemble an anime movie keyframe with cinematic lighting transitions.";
        p.Model = "gpt-image-1";
        p.Quality = "medium";
        p.N = 1; // Streaming only supported N=1
        p.Partial_Images = 3;
        p.Stream = true;

        Console.WriteLine($"{DateTimeOffset.Now.ChangeTimeZone(9).ToString()} Image generation started");
        var result = new ImageGenerationStreamResult();
        await foreach (var item in cl.GetImageGenerateStreamEventAsync(p, result, CancellationToken.None))
        {
            var rEvent = item.CreateTypedData();
            if (rEvent is ImageGenerationStreamPartialImage partialImage)
            {
                var bb = partialImage.GetBytes();
                var filePath = Path.Combine(Environment.CurrentDirectory, "Generated", $"Image_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.png");
                File.WriteAllBytes(filePath, bb);
                Console.WriteLine($"{DateTimeOffset.Now.ChangeTimeZone(9).ToString()} File is created to " + filePath);
            }
            if (rEvent is ImageGenerationStreamCompleted completed)
            {
                var bb = completed.GetBytes();
                var filePath = Path.Combine(Environment.CurrentDirectory, "Generated", $"Image_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.png");
                File.WriteAllBytes(filePath, bb);
                Console.WriteLine($"{DateTimeOffset.Now.ChangeTimeZone(9).ToString()} File is created to " + filePath);
            }
        }
    }
    private async ValueTask ImageGenerationByGpt4o()
    {
        var cl = OpenAIClient;

        var p = new ImagesGenerationsParameter();
        p.Prompt = "A photorealistic image of a beautiful landscape under a blue sky. The scene features a wide, lush green field, with the sun shining brightly and casting soft shadows. The sky is a clear, deep blue with a few fluffy white clouds scattered around. The field is vibrant and green, giving a sense of calm and tranquility. The image should have a high-resolution, 4K-like quality, capturing the details of the grass, the texture of the clouds, and the vividness of the blue sky.";
        p.Model = "gpt-4o";
        p.Quality = "hd";

        Console.WriteLine("Image generate start");
        var res = await cl.ImagesGenerationsAsync(p);
        foreach (var item in res.Data)
        {
            Console.WriteLine(item.Url);
        }
    }
    private async ValueTask ImageVariation()
    {
        var cl = OpenAIClient;

        Console.WriteLine("Image variation start");
        var res = await cl.ImagesVariationsAsync("Sea.png", new MemoryStream(File.ReadAllBytes("C:\\Data\\Dev\\Sea.png")));
        foreach (var item in res.Data)
        {
            Console.WriteLine(item.Url);
        }
    }

    private async ValueTask VideoGeneration()
    {
        var cl = OpenAIClient;

        var p = new VideoCreateParameter();
        p.Prompt = "A baby and a fluffy kitten playing together on a soft carpet in a sunlit living room, morning light streaming through curtains, natural colors, heartwarming and gentle atmosphere, cinematic depth of field, ultra-realistic style.";
        p.Model = "sora-2";
        var job = await cl.VideoCreateAsync(p);
        Console.WriteLine("Job started.");
        while (true)
        {
            //10 seconds interval
            Thread.Sleep(10 * 1000);

            var res = await cl.VideoRetrieveAsync(job.Id);
            if (res.Status == "completed")
            {
                var stream = await cl.VideoContentGetAsync(job.Id);
                var filePath = Path.Combine(Environment.CurrentDirectory, $"video_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.mp4");
                File.WriteAllBytes(filePath, stream.ToByteArray());
                break;
            }
            else if (res.Status == "failed")
            {
                Console.WriteLine("Job failed.");
                break;
            }
            else
            {
                Console.WriteLine($"{DateTimeOffset.Now.ChangeTimeZone(9).ToIso8601String()} Job status is " + res.Status + ". Waiting...");
            }
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
            p.Tools = new ();
            p.Tools.Add(CreateGetWheatherChatCompletionTool());

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

        p.Tools = new List<ChatCompletionFunctionTool>();
        p.Tools.Add(new ChatCompletionFunctionTool("code_interpreter"));
        if (cl.ServiceProvider == ServiceProvider.OpenAI)
        {
            p.Tools.Add(new ChatCompletionFunctionTool("file_search"));
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


    private async ValueTask<string> GetVectorStoreId()
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
        return storeId;
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

        var vectorStoreName = "HigLabo vector store";
        var storeId = await GetVectorStoreId();
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
            p.File.SetFile("1bit_transformers.pdf", File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, "File", "1bit_transformers.pdf")));
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
