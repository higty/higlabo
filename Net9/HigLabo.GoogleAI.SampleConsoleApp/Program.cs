using HigLabo.GoogleAI.SampleConsoleApp;

namespace HigLabo.GoogleAI.SampleConsoleApp;

internal class Program
{
    static async Task Main(string[] args)
    {
        var sample = new GoogleAIClientPlayground();
        await sample.ExecuteAsync();
        Console.ReadLine();
    }
}
