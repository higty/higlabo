using HigLabo.Core;
using System.Text;
using static HigLabo.OpenAI.ChatCompletionChunk;

namespace HigLabo.OpenAI.SampleConsoleApp
{
    internal class Program
    {
        public static OpenAIClient OpenAIClient { get; private set; } = new OpenAIClient();

        static async Task Main(string[] args)
        {
            OpenAIClient.JsonConverter = new OpenAIJsonConverter();
            OpenAIClient.ApiKey = File.ReadAllText("C:\\Dev\\ChatGPTApiKey.txt");

            await ChatCompletionStreamWithFunctionCalling();

            Console.ReadLine();
        }

        private static async ValueTask Audio()
        {
            var cl = OpenAIClient;

            var p = new AudioTranslationsParameter();
            p.SetFile("HelloWorld.mp3", new MemoryStream(File.ReadAllBytes("D:\\Data\\Dev\\GoodMorningItFineDayToday.mp3")));
            p.Model = "whisper-1";

            var res = await cl.AudioTranslationsAsync(p);
            var text = res.GetResponseBodyText();

        }
        private static async ValueTask Embeddings()
        {
            var cl = OpenAIClient;
            var embedding = await cl.EmbeddingsAsync("新しいユーザーはどこかに加入しようと考えるとき、ユーザーが多いサービスに登録した方が自分がUPした写真へのいいねもたくさんつくし、釣り場の情報交換なども活発にできます。サービス自体の機能の魅力もありますがそれよりも多くのユーザーがいることの方が価値が高いことが多いです。"
                , "text-embedding-ada-002", CancellationToken.None);
        }
        private static async ValueTask ChatCompletion()
        {
            var cl = OpenAIClient;

            var p = new ChatCompletionsParameter();
            p.Model = "gpt-3.5-turbo";
            p.Stream = true;
            p.Messages.Add(new ChatMessage(ChatMessageRole.system, "You are proffesional engineer. You navigate user with "));

            var theme = "How to enjoy coffee";
            p.Messages.Add(new ChatMessage(ChatMessageRole.user, $"Can you provide me with some ideas for blog posts about {theme}?"));

            await foreach (var choice in cl.GetStreamAsync(p, CancellationToken.None))
            {
                Console.Write(choice.Choices[0].Delta.Content);
            }
            Console.WriteLine();
            Console.WriteLine("DONE");
        }
        private static async ValueTask ChatCompletionStream()
        {
            var cl = OpenAIClient;

            var theme = "How to enjoy coffee";
            await foreach (var chunk in cl.ChatCompletionsStreamAsync($"Can you provide me with some ideas for blog posts about {theme}?"
                , "gpt-3.5-turbo", CancellationToken.None))
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
        private static async ValueTask ChatCompletionStreamWithFunctionCalling()
        {
            var cl = OpenAIClient;

            var p = new ChatCompletionsParameter();
            p.Messages.Add(new ChatMessage(ChatMessageRole.user, $"Can you provide me famous location list of USA for trip? Please return parameter as JSON for function calling."));
            p.Model = "gpt-3.5-turbo";

            var tool = new ToolObject("function");
            tool.Function = new FunctionObject();
            tool.Function.Name = "getWhether";
            tool.Function.Description = "Get whether of specified location";
            tool.Function.Parameters = new
            {
                type = "object",
                properties = new
                {
                    locationList = new
                    {
                        type = "array",
                        items = new
                        {
                            type = "string",
                        }
                    }
                }
            };
            p.Tools = new List<ToolObject>();
            p.Tools.Add(tool);

            var processor = new ChatCompletionChunkProcessor();
            await foreach (var chunk in cl.ChatCompletionsStreamAsync(p, CancellationToken.None))
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
        private static async ValueTask FileUpload()
        {
            var cl = OpenAIClient;

            var p = new FileUploadParameter();
            p.SetFile("FinetuneSample.txt", File.OpenRead("D:\\Data\\Dev\\FinetuneSample.txt"));
            p.Purpose = "fine-tune";
            //var res = await client.FileUploadAsync(p);

            var res1 = await cl.FilesAsync(CancellationToken.None);
            foreach (var item in res1.Data)
            {
                Console.WriteLine(item.Id + " " + item.FileName);

                var res3 = await cl.FileContentGetAsync(item.Id, CancellationToken.None);
            }
        }
        private static async ValueTask ImageGeneration()
        {
            var cl = OpenAIClient;

            var res = await cl.ImagesGenerationsAsync("Blue sky and green field.", CancellationToken.None);
        }
        private static async ValueTask Model()
        {
            var cl = OpenAIClient;

            var res = await cl.ModelsAsync(CancellationToken.None);
            foreach (var item in res.Data)
            {
                var id = item.Id;
            }

            var res1 = await cl.ModelRetrieveAsync("text-search-babbage-doc-001", CancellationToken.None);
        }
        private static async ValueTask Moderation()
        {
            var cl = OpenAIClient;
            //Test terrible text for moderation api.
            var res = await cl.ModerationCreateAsync("We must kill all activist.", CancellationToken.None);

        }
        private static async ValueTask Assistant()
        {
            var cl = OpenAIClient;

            var p = new AssistantCreateParameter();
            p.Name = "Math tutor";
            p.Instructions = "You are a personal math tutor. Write and run code to answer math questions.";
     
            p.Tools = new List<ToolObject>();
            p.Tools.Add(new ToolObject("code_interpreter"));
            p.Tools.Add(new ToolObject("retrieval"));

            var tool = new ToolObject("function");
            tool.Function = new FunctionObject();
            tool.Function.Name = "getWhether";
            tool.Function.Description = "Get whether of specified location";
            tool.Function.Parameters = new {
                type = "object" ,
                properties = new
                {
                    locationList = new
                    {
                        type = "array",
                        items = new
                        {
                            type = "string",
                        }
                    }
                }
            };
            p.Tools.Add(tool);

            var res = await cl.AssistantCreateAsync(p);
            var text = res.GetResponseBodyText();

        }
    }
}