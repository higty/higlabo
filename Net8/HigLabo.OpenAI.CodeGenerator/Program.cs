using AngleSharp.Dom;
using HigLabo.CodeGenerator;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI.CodeGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var g = new OpenAISourceCodeGenerator();
            g.ExecuteAsync();
            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }
    }
}