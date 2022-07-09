namespace HigLabo.Net.CodeGenerator
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                await Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private static async Task Execute()
        {
            if (false)
            {
                var g = new SlackSourceCodeGenerator("C:\\GitHub\\higty\\HigLabo\\Net6\\HigLabo.Net.Slack\\");
                //await g.CreateMethodSourceCodeFile("https://api.slack.com/methods/views.open");
                await g.Execute();
            }
            if (true)
            {
                var g = new MicrosoftSourceCodeGenerator("C:\\GitHub\\higty\\HigLabo\\Net6\\HigLabo.Net.Microsoft\\");
                g.HtmlCacheFolderPath = "C:\\Data\\MicrosoftGraphApi";
                //await g.CreateResourceUrlMappingFile();
                await g.LoadUrlClassNameMappingList();

                //await g.CreateEntitySourceCodeFile("https://docs.microsoft.com/en-us/graph/api/resources/callrecords-session?view=graph-rest-1.0");
                //await g.CreateEntitySourceCodeFile("https://docs.microsoft.com/en-us/graph/api/resources/driveitem?view=graph-rest-1.0", new CreateEntityClassContext());
                //await g.CreateEntitySourceCodeFile("https://docs.microsoft.com/en-us/graph/api/resources/user?view=graph-rest-1.0");
                //await g.CreateEntitySourceCodeFile("https://docs.microsoft.com/en-us/graph/api/resources/columnvalidation?view=graph-rest-1.0", new CreateEntityClassContext());
                //await g.CreateEntitySourceCodeFile("https://docs.microsoft.com/en-us/graph/api/resources/externalconnectors-identity?view=graph-rest-1.0", new CreateEntityClassContext());
                await g.CreateMethodSourceCodeFile("https://docs.microsoft.com/en-us/graph/api/mailfolder-list-messages?view=graph-rest-1.0");
                //await g.CreateEntitySourceCodeFile("https://docs.microsoft.com/en-us/graph/api/resources/accesspackageassignmentrequestrequirements?view=graph-rest-1.0", new CreateEntityClassContext());
                await g.Execute();
            }
        }
    }
}