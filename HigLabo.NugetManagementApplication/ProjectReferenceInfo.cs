using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.NugetManagementApplication
{
    public class ProjectReferenceInfo
    {
        public String ID { get; set; }
        public String Version { get; set; }
        public String Culture { get; set; }
        public String PublicKeyToken { get; set; }
        public String ProcessorArchitecture { get; set; }

        public ProjectReferenceInfo()
        {
        }
        public static ProjectReferenceInfo Parse(String text)
        {
            //Parse from "Newtonsoft.Json, Version=9.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed, processorArchitecture=MSIL"
            var p = new ProjectReferenceInfo();
            var ss = text.Split(',');
            p.ID = ss[0];
            foreach (var s in ss)
            {
                var kv = s.Split('=');
                if (kv.Length == 2)
                {
                    switch (kv[0].Trim().ToLower())
                    {
                        case "version": p.Version = kv[1].Trim(); break;
                        case "culture": p.Culture = kv[1].Trim(); break;
                        case "publickeytoken": p.PublicKeyToken = kv[1].Trim(); break;
                        case "processorarchitecture": p.ProcessorArchitecture = kv[1].Trim(); break;
                        default: break;
                    }
                }
            }
            return p;
        }
    }
}
