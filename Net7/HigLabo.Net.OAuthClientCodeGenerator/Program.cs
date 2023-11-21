namespace HigLabo.Net.CodeGenerator
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var startTime = DateTime.Now;
            try
            {
                await Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine($"{startTime.ToString("HH:mm:ss")}-{DateTime.Now.ToString("HH:mm:ss")} executed!");
        }
        private static async ValueTask Execute()
        {
            if (true)
            {
                var g = new SlackSourceCodeGenerator("C:\\GitHub\\higty\\HigLabo\\Net7\\HigLabo.Net.Slack\\Generated\\");
                //await g.CreateEntitySourceCodeFile("", new CreateEntityClassContext());
                //await g.CreateMethodSourceCodeFile("https://api.slack.com/methods/reminders.add");
                await g.Execute();
            }
            if (false)
            {
                var g = new MicrosoftSourceCodeGenerator("C:\\GitHub\\higty\\HigLabo\\Net7\\HigLabo.Net.Microsoft\\Generated\\");
                g.HtmlCacheFolderPath = "C:\\Data\\MicrosoftGraphApi";
                //await g.CreateResourceUrlMappingFile();
                //await g.LoadUrlClassNameMappingList();

                //await g.CreateEntitySourceCodeFile("https://learn.microsoft.com/en-us/graph/api/resources/educationuser?view=graph-rest-1.0", new CreateEntityClassContext());
                //await g.CreateMethodSourceCodeFile("https://learn.microsoft.com/en-us/graph/api/educationuser-post?view=graph-rest-1.0");
                //await g.CreateMethodSourceCodeFile("https://learn.microsoft.com/en-us/graph/api/user-post-users?view=graph-rest-1.0");
                //await g.CreateMethodSourceCodeFile("https://learn.microsoft.com/en-us/graph/api/user-update?view=graph-rest-1.0");
                //await g.Execute();
            }
        }
    }
}