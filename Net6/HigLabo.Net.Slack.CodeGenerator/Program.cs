using AngleSharp;
using HigLabo.CodeGenerator;
using System.Text;
using HigLabo.Core;

namespace HigLabo.Net.Slack.CodeGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var g = new SlackSourceCodeGenerator("C:\\GitHub\\higty\\HigLabo\\Net6\\HigLabo.Net.Slack\\");
            g.Execute().GetAwaiter().GetResult();
        }
    }
}