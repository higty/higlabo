namespace HigLabo.X.SampleConsoleApp;

internal class Program
{
    static async Task Main(string[] args)
    {
        var sample = new XClientPlayground();
        await sample.ExecuteAsync();
        Console.ReadLine();
    }
}
