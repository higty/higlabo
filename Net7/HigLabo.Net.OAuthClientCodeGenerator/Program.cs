namespace HigLabo.Net.CodeGenerator
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var text = T.Text.ActualTime;

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
        private static async Task Execute()
        {
            if (false)
            {
                var g = new SlackSourceCodeGenerator("C:\\GitHub\\higty\\HigLabo\\Net7\\HigLabo.Net.Slack\\");
                //await g.CreateMethodSourceCodeFile("https://api.slack.com/methods/views.open");
                await g.Execute();
            }
            if (true)
            {
                var g = new MicrosoftSourceCodeGenerator("C:\\GitHub\\higty\\HigLabo\\Net7\\HigLabo.Net.Microsoft\\Generated\\");
                g.HtmlCacheFolderPath = "C:\\Data\\MicrosoftGraphApi";
                //await g.CreateResourceUrlMappingFile();
                await g.LoadUrlClassNameMappingList();

                //await g.CreateEntitySourceCodeFile("https://learn.microsoft.com/en-us/graph/api/driveitem-createuploadsession?view=graph-rest-1.0", new CreateEntityClassContext());
                //await g.CreateMethodSourceCodeFile("https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewset-addtoreviewset?view=graph-rest-1.0");
                await g.Execute();
            }
        }
    }
}