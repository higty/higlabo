namespace HigLabo.OpenAI.Debug
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var cl = new OpenAIClient();
            cl.JsonConverter = new OpenAIJsonConverter();
            cl.ApiKey = File.ReadAllText("C:\\Dev\\ChatGPTApiKey.txt");

            //var embedding = await cl.EmbeddingsAsync("新しいユーザーはどこかに加入しようと考えるとき、ユーザーが多いサービスに登録した方が自分がUPした写真へのいいねもたくさんつくし、釣り場の情報交換なども活発にできます。サービス自体の機能の魅力もありますがそれよりも多くのユーザーがいることの方が価値が高いことが多いです。"
            //    , "text-embedding-ada-002", CancellationToken.None);

            await FileUpload(cl);

            Console.ReadLine();
        }
        private static async ValueTask FileUpload(OpenAIClient client)
        {
            var p = new FileUploadParameter();
            p.SetFile("FinetuneSample.txt", File.OpenRead("D:\\Data\\Dev\\FinetuneSample.txt"));
            p.Purpose = "fine-tune";
            //var res = await client.FileUploadAsync(p);

            var res1 = await client.FilesAsync(CancellationToken.None);
            foreach (var item in res1.Data)
            {
                Console.WriteLine(item.Id + " " + item.FileName);
            }
            
            var res2 = await client.FileContentGetAsync("file-TSHnvdZmDjnKBqrRuhlvOSUw", CancellationToken.None);
            var res3 = await client.FileContentGetAsync("file-gSFA1NoNvuCGxCFZK3d7mnDP", CancellationToken.None);
        }
        private static async ValueTask ChatCompletion(OpenAIClient client)
        {
            var cl = client;

            await foreach (var choice in cl.ChatCompletionsStreamAsync("IT業界の専門用語を10個上げて下さい。またそれぞれについて詳細に説明してください。"
                , "gpt-3.5-turbo", CancellationToken.None))
            {
                Console.Write(choice.Choices[0].Delta.Content);
            }

            var p = new ChatCompletionsParameter();
            p.Model = "gpt-3.5-turbo";
            p.Stream = true;
            p.Messages.Add(new ChatMessage(ChatMessageRole.system, "あなたはIT業界のプロフェッショナルで様々な知識を持っています。ユーザーの問いかけに対して適切に回答しアシスタントとしてサポートしてください。"));
            p.Messages.Add(new ChatMessage(ChatMessageRole.user, "IT業界の専門用語を10個上げて下さい。またそれぞれについて簡単に説明してください。"));

            await foreach (var choice in cl.GetStreamAsync(p, CancellationToken.None))
            {
                Console.Write(choice.Choices[0].Delta.Content);
            }
            Console.WriteLine();
            Console.WriteLine("DONE");
        }
        private static async ValueTask AudioTranslations(OpenAIClient client)
        {
            var cl = client;

            var p = new AudioTranslationsParameter();
            p.SetFile("HelloWorld.mp3", new MemoryStream(File.ReadAllBytes("D:\\Data\\Dev\\GoodMorningItFineDayToday.mp3")));
            p.Model = "whisper-1";

            var res = await cl.AudioTranslationsAsync(p);
            var text = res.GetResponseBodyText();

        }
    }
}