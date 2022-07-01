namespace HigLabo.Net.Microsoft.CodeGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var g = new MicrosoftSourceCodeGenerator("C:\\GitHub\\higty\\HigLabo\\Net6\\HigLabo.Net.Microsoft\\");
            g.Execute().GetAwaiter().GetResult();
            Console.ReadLine();
        }
    }
}