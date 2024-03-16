using HigLabo.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    public class OpenAIPlayground
    {
        public OpenAIClient OpenAIClient { get; set; } = new();

        public async ValueTask ExecuteAsync()
        {
            SetOpenAISetting();
            await ChatCompletionStream();
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

        private async ValueTask AudioFileDownload()
        {
            var cl = OpenAIClient;

            var res = await cl.AudioSpeechAsync("tts-1", "Stay Hungry. Stay Foolish. Thank you all very much.", "alloy");
            File.WriteAllBytes("D:\\Data\\Dev\\GPT_Audio.mp3", res.Stream!.ToByteArray());
        }
        private async ValueTask AudioTranslations()
        {
            var cl = OpenAIClient;

            var p = new AudioTranslationsParameter();
            p.File.SetFile("GoodMorningItFineDayToday.mp3", new MemoryStream(File.ReadAllBytes("D:\\Data\\Dev\\GoodMorningItFineDayToday.mp3")));
            p.Model = "whisper-1";

            var res = await cl.AudioTranslationsAsync(p);
            Console.WriteLine(res.GetResponseBodyText());
        }
        private async ValueTask AudioTranscriptions()
        {
            var cl = OpenAIClient;

            var p = new AudioTranscriptionsParameter();
            p.File.SetFile("GoodMorningItFineDayToday.mp3", new MemoryStream(File.ReadAllBytes("D:\\Data\\Dev\\GoodMorningItFineDayToday.mp3")));
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
            p.Model = "gpt-3.5-turbo";
            var res = await cl.ChatCompletionsAsync(p);
            foreach (var choice in res.Choices)
            {
                Console.Write(choice.Message.Content);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Total tokens: " + res.Usage.Total_Tokens);
            var iRes = res as IRestApiResponse;
            Console.WriteLine(iRes.RequestBodyText);
            Console.WriteLine();
            Console.WriteLine(iRes.ResponseBodyText);
        }
        private async ValueTask ChatCompletionStream()
        {
            var cl = OpenAIClient;

            var theme = "How to enjoy coffee";
            var p = new ChatCompletionsParameter();
            p.AddUserMessage($"Can you provide me with some ideas for blog posts about {theme}?");
            p.Model = "gpt-3.5-turbo";
            p.Stream = true;

            var result = new ChatCompletionStreamResult();
            var sseResult = new ServerSentEventResult();
            await foreach (var text in cl.ChatCompletionsTextStreamAsync(p, result, CancellationToken.None))
            {
                Console.Write(text);
            }
            Console.WriteLine();
            Console.WriteLine("***********************");
            Console.WriteLine(result.GetContent());
            Console.WriteLine("Finish reason: " + result.GetFinishReason());
            Console.WriteLine("■DONE");
        }
        private async ValueTask ChatCompletionStreamWithFunctionCalling()
        {
            var cl = OpenAIClient;

            var p = new ChatCompletionsParameter();
            //ChatGPT can correct Newyork,Sanflansisco to New york and San Flancisco.
            p.Messages.Add(new ChatMessage(ChatMessageRole.User, $"I want to know the whether of these locations. Newyork, Sanflansisco, Paris, Tokyo."));
            p.Model = "gpt-3.5-turbo";

            {
                var tool = new ToolObject("function");
                tool.Function = new FunctionObject();
                tool.Function.Name = "getWhether";
                tool.Function.Description = "This service can get whether of specified location.";
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
                p.Tools = new List<ToolObject>();
                p.Tools.Add(tool);
            }
            {
                var tool = new ToolObject("function");
                tool.Function = new FunctionObject();
                tool.Function.Name = "getLatLong";
                tool.Function.Description = "This service can get latitude and longitude of specified location.";
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
                p.Tools = new List<ToolObject>();
                p.Tools.Add(tool);
            }

            var result = new ChatCompletionStreamResult();
            //You must set Stream property to true to receive server sent event stream on chat completion endpoint.
            p.Stream = true;
            await foreach (var chunk in cl.ChatCompletionsStreamAsync(p, result, CancellationToken.None))
            {
                foreach (var choice in chunk.Choices)
                {
                    Console.Write(choice.Delta.Content);
                }
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
            p.Model = "gpt-4-vision-preview";
            p.Max_Tokens = 300;
            p.Stream = true;

            var processor = new ChatCompletionStreamResult();
            var sseResult = new ServerSentEventResult();
            await foreach (var chunk in cl.GetStreamAsync<ChatCompletionsParameter, ChatCompletionChunk>(p, sseResult, CancellationToken.None))
            {
                foreach (var choice in chunk.Choices)
                {
                    Console.Write(choice.Delta.Content);
                    processor.Process(chunk);
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("***********************");
            Console.WriteLine(sseResult.ToString());
            Console.WriteLine("■DONE");
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
            p.File.SetFile("092332_hanrei.pdf", File.ReadAllBytes("D:\\Data\\CourtPdf\\092332_hanrei.pdf"));
            p.Purpose = "assistants";
            var res = await cl.FileUploadAsync(p);
            Console.WriteLine(res);
        }
		private async ValueTask ImageFileDownload()
		{
			var cl = OpenAIClient;

			var fileResponse = await cl.FileContentGetAsync("file-ShIMh9E6jz4PNdLjWk5VJHQA");
            File.WriteAllBytes("D:\\Data\\Dev\\Hig_Download.png", fileResponse.Stream!.ToByteArray());
		}
		private async ValueTask FileUpload_Finetune()
        {
            var cl = OpenAIClient;

            var p = new FileUploadParameter();
            p.File.SetFile($"FinetuneSample{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.txt", File.ReadAllBytes("D:\\Data\\Dev\\FinetuneSample.txt"));
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

            var res = await cl.ImagesVariationsAsync("Sea.png", new MemoryStream(File.ReadAllBytes("D:\\Data\\Dev\\Sea.png")));
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

        private async ValueTask AssistantsProcess()
        {
            var createResponse = await AssistantCreate();

            var cl = OpenAIClient;

            var now = DateTimeOffset.Now;
            var threadId = "";
            if (threadId.Length == 0)
            {
                var res = await cl.ThreadCreateAsync();
                threadId = res.Id;
            }
            {
                var p = new MessageCreateParameter();
                p.Thread_Id = threadId;
                p.Role = "user";
                p.Content = "Hello! I want to know how to use OpenAI assistant API to get stream response.";
                var res = await cl.MessageCreateAsync(p);
            }
            var runId = "";
            {
                var p = new RunCreateParameter();
                p.Assistant_Id = createResponse.Id;
                p.Thread_Id = threadId;
                var res = await cl.RunCreateAsync(p);
                runId = res.Id;
            }
        }
        private async ValueTask<AssistantCreateResponse> AssistantCreate()
        {
            var cl = OpenAIClient;

            var p = new AssistantCreateParameter();
            p.Name = "HigLabo assistant";
            p.Instructions = "You are a personal assistant to help general task.";
            p.Model = "gpt-4-1106-preview";

            p.Tools = new List<ToolObject>();
            p.Tools.Add(new ToolObject("code_interpreter"));
            p.Tools.Add(new ToolObject("retrieval"));

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

            var now = DateTimeOffset.Now;
            var threadId = "";
            if (threadId.Length == 0)
            {
                var res = await cl.ThreadCreateAsync();
                threadId = res.Id;
            }
            {
                var p = new MessageCreateParameter();
                p.Thread_Id = threadId;
                p.Role = "user";
                p.Content = "Hello! I want to know how to use OpenAI assistant API.";
                var res = await cl.MessageCreateAsync(p);
            }
            var runId = "";
            {
                var p = new RunCreateParameter();
                p.Assistant_Id = "asst_xxxxxxxxxxxxxx";
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
    }
}
