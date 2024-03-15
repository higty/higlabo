namespace HigLabo.Anthropic.SampleConsoleApp
{
    internal class Program
    {

        static async Task Main(string[] args)
        {
            var sample = new AnthropicClientPlayground();
            await sample.ExecuteAsync();
            Console.ReadLine();
        }
    }
}
