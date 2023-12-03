namespace HigLabo.OpenAI.SampleConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var sample = new OpenAIPlayground();
            await sample.ExecuteAsync();
            Console.ReadLine();
        }
    }
}
