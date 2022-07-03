namespace HigLabo.Net.CodeGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Execute().GetAwaiter().GetResult();
        }
        private static async Task Execute()
        {
            if (false)
            {
                var g = new SlackSourceCodeGenerator("C:\\GitHub\\higty\\HigLabo\\Net6\\HigLabo.Net.Slack\\");
                await g.Execute();
            }
            {
                var g = new MicrosoftSourceCodeGenerator("C:\\GitHub\\higty\\HigLabo\\Net6\\HigLabo.Net.Microsoft\\");
                //await g.CreateEntitySourceCode("https://docs.microsoft.com/en-us/graph/api/resources/teamfunsettings?view=graph-rest-1.0");
                //await g.CreateEntitySourceCode("https://docs.microsoft.com/en-us/graph/api/resources/messageruleactions?view=graph-rest-1.0");
                await g.Execute();
            }
        }
    }
}