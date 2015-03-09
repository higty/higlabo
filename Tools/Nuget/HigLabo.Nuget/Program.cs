using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Nuget
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = new NugetManager(@"C:\GitHub\higty\higlabo\");

            Console.WriteLine("Press enter to start...");
            Console.ReadLine();
            
            m.CopyDll();
            Console.WriteLine("Dll copy completed.Press enter to create package files...");
            Console.ReadLine();

            m.CreatePackageFile();
            Console.WriteLine("Nuget file created.Press enter to upload package files...");
            Console.ReadLine();

            m.UploadPackageFiles();
            Console.WriteLine("Nuget file upload.");
            Console.ReadLine();
        }

    }
}
