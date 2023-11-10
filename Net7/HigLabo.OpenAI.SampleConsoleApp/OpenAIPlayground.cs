using System;
using System.Collections.Generic;
using System.Linq;
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
            await ChatCompletionStreamWithFunctionCalling();
        }
        private void SetOpenAISetting()
        {
            OpenAIClient = new OpenAIClient(File.ReadAllText("C:\\Dev\\ChatGPTApiKey.txt"));
        }
        private void SetAzureSetting()
        {
            var apiKey = File.ReadAllText("C:\\Dev\\AzureOpenAIApiKey.txt");
            OpenAIClient = new OpenAIClient(new AzureSettings(apiKey, "https://tinybetter-work-for-our-future.openai.azure.com/", "MyDeploymentName"));
        }

        private async ValueTask AudioTranslations()
        {
            var cl = OpenAIClient;

            var p = new AudioTranslationsParameter();
            p.SetFile("GoodMorningItFineDayToday.mp3", new MemoryStream(File.ReadAllBytes("D:\\Data\\Dev\\GoodMorningItFineDayToday.mp3")));
            p.Model = "whisper-1";

            var res = await cl.AudioTranslationsAsync(p);
            Console.WriteLine(res.GetResponseBodyText());

        }
        private async ValueTask AudioTranscriptions()
        {
            var cl = OpenAIClient;

            var p = new AudioTranscriptionsParameter();
            p.SetFile("GoodMorningItFineDayToday.mp3", new MemoryStream(File.ReadAllBytes("D:\\Data\\Dev\\GoodMorningItFineDayToday.mp3")));
            p.Model = "whisper-1";

            var res = await cl.AudioTranscriptionsAsync(p);
            Console.WriteLine(res.GetResponseBodyText());

        }
        private async ValueTask Embeddings()
        {
            var cl = OpenAIClient;
            var res = await cl.EmbeddingsAsync("Crafting prompts\r\nWe generally recommend taking the set of instructions and prompts that you found worked best for the model prior to fine-tuning, and including them in every training example. This should let you reach the best and most general results, especially if you have relatively few (e.g. under a hundred) training examples.\r\n\r\nIf you would like to shorten the instructions or prompts that are repeated in every example to save costs, keep in mind that the model will likely behave as if those instructions were included, and it may be hard to get the model to ignore those \"baked-in\" instructions at inference time.\r\n\r\nIt may take more training examples to arrive at good results, as the model has to learn entirely through demonstration and without guided instructions."
                , "text-embedding-ada-002");
            Console.WriteLine(res);
        }
        private async ValueTask ChatCompletion()
        {
            var cl = OpenAIClient;

            var p = new ChatCompletionsParameter();
            p.Model = "gpt-3.5-turbo";
            p.Stream = true;
            p.Messages.Add(new ChatMessage(ChatMessageRole.system, "You are proffesional engineer. You navigate user with "));

            var theme = "How to enjoy coffee";
            p.Messages.Add(new ChatMessage(ChatMessageRole.user, $"Can you provide me with some ideas for blog posts about {theme}?"));

            await foreach (var choice in cl.GetStreamAsync(p))
            {
                Console.Write(choice.Choices[0].Delta.Content);
            }
            Console.WriteLine();
            Console.WriteLine("DONE");
        }
        private async ValueTask ChatCompletionStream()
        {
            var cl = OpenAIClient;

            var theme = "How to enjoy coffee";
            await foreach (var chunk in cl.ChatCompletionsStreamAsync($"Can you provide me with some ideas for blog posts about {theme}?", "gpt-3.5-turbo"))
            {
                foreach (var choice in chunk.Choices)
                {
                    Console.Write(choice.Delta.Content);
                    foreach (var toolCall in choice.Message.Tool_Calls)
                    {
                        Console.WriteLine("■Function name is " + toolCall.Id);
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("DONE");
        }
        private async ValueTask ChatCompletionStreamWithFunctionCalling()
        {
            var cl = OpenAIClient;

            var p = new ChatCompletionsParameter();
            p.Messages.Add(new ChatMessage(ChatMessageRole.user, $"Can you provide me famous location list of USA for trip? Please return parameter as JSON for function calling."));
            p.Model = "gpt-3.5-turbo";

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

            var processor = new FunctionCallingProcessor();
            //You must set Stream property to true to receive server sent event stream on chat completion endpoint.
            p.Stream = true;
            await foreach (var chunk in cl.GetStreamAsync(p))
            {
                foreach (var choice in chunk.Choices)
                {
                    Console.Write(choice.Delta.Content);
                    processor.Process(chunk);
                }
            }
            Console.WriteLine();

            var f = processor.GetFunctionCall();
            if (f != null)
            {
                Console.WriteLine("■Function name is " + f.Name);
                Console.WriteLine("■Arguments is " + f.Arguments);
            }

            Console.WriteLine();
            Console.WriteLine("DONE");
        }
        private async ValueTask<string> FileUpload_Assistant()
        {
            var cl = OpenAIClient;

            var p = new FileUploadParameter();
            p.SetFile("076153_hanrei.pdf", File.ReadAllBytes("D:\\Data\\CourtPdf\\076153_hanrei.pdf"));
            p.Purpose = "assistants";
            var res = await cl.FileUploadAsync(p);

            return res.Id;
        }
        private async ValueTask FileUpload_Finetune()
        {
            var cl = OpenAIClient;

            var p = new FileUploadParameter();
            p.SetFile("FinetuneSample.txt", File.ReadAllBytes("D:\\Data\\Dev\\FinetuneSample.txt"));
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

            var res = await cl.ImagesGenerationsAsync("Blue sky and green field.");
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
            var res = await cl.ModerationCreateAsync("We must kill all activist who attack museum.");
            Console.WriteLine(res);
        }
        private async ValueTask AssistantCreate()
        {
            var cl = OpenAIClient;

            var p = new AssistantCreateParameter();
            p.Name = "Legal tutor1";
            p.Instructions = "You are a personal legal tutor. Write and run code to legal questions based on passed files.";
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
        private async ValueTask Runs()
        {
            var cl = OpenAIClient;

            var threadId = "thread_BjrO0VCLuPhbGKS5t3EY5ANh";
            var res = await cl.RunsAsync(threadId);
            foreach (var item in res.Data)
            {
                var res1 = await cl.RunStepsAsync(threadId, item.Id);
                foreach (var step in res1.Data)
                {
                    Console.WriteLine(step.Step_Details);
                }
            }
        }
        private async ValueTask ThreadMessage()
        {
            var cl = OpenAIClient;

            //Get thread_id from your playground. https://platform.openai.com/playground
            var threadId = "thread_BjrO0VCLuPhbGKS5t3EY5ANh";
            var res2 = await cl.MessagesAsync(threadId);
            foreach (var rMessage in res2.Data)
            {
                foreach (var content in rMessage.Content)
                {
                    Console.WriteLine(content.Text);
                }
            }
        }
    }
}
