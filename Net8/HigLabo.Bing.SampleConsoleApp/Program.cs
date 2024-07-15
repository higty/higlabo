namespace HigLabo.Bing.SampleConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var sample = new BingClientPlayground();
            await sample.ExecuteAsync();
            Console.ReadLine();
        }
    }
}
