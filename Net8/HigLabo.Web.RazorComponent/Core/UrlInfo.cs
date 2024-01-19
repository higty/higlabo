using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web
{
    public class UrlInfo
    {
        public static string ImageWebSite { get; set; } = "https://localhost:7014/img";

        public static string GetIconUrl(Higlabo__ fileName)
        {
            return $"{ImageWebSite}/{fileName.GetBlobName()}";
        }
    }
}
