namespace HigLabo.OpenAI.Debug
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var cl = new OpenAIClient();
            cl.JsonConverter = new OpenAIJsonConverter();
            cl.ApiKey = File.ReadAllText("C:\\Dev\\ChatGPTApiKey.txt");

            await ChatCompletion(cl);

            Console.ReadLine();
        }
        private static async ValueTask ChatCompletion(OpenAIClient client)
        {
            var cl = client;

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