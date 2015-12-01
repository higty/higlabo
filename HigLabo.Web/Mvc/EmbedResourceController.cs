using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HigLabo.Web.Mvc
{
    public class EmbedResourceController : Controller
    {
        private static List<Assembly> AssemblyList = new List<Assembly>();

        public static Dictionary<String, String> ContentTypeMap = new Dictionary<String, String>();
        public static Func<String, Stream> GetStreamFunc = null;

        static EmbedResourceController()
        {
            InitializeContentTypeMap();
        }
        private static void InitializeContentTypeMap()
        {
            var d = ContentTypeMap;
            d[".js"] = "text/javascript";
            d[".css"] = "text/css";
            d[".jpg"] = "image/jpeg";
            d[".png"] = "image/png";
            d[".gif"] = "image/gif";
        }
        public static void AddAssembly(Assembly assembly)
        {
            AssemblyList.Add(assembly);
        }

        [Route("EmbedResource")]
        public FileStreamResult Download(String name, String contentType = null)
        {
            Stream stm = null;
            var tp = contentType ?? GetContentType(name);

            if (GetStreamFunc != null)
            {
                stm = GetStreamFunc(name);
            }
            if (stm == null)
            {
                foreach (var item in AssemblyList)
                {
                    String resourceName = item.GetManifestResourceNames().FirstOrDefault(f => f.EndsWith(name));
                    stm = item.GetManifestResourceStream(resourceName);
                }
            }
            return new FileStreamResult(stm, tp);
        }
        private string GetContentType(String name)
        {
            var ext = Path.GetExtension(name);
            var contentType = "";
            if (ContentTypeMap.TryGetValue(ext, out contentType) == true)
            {
                return contentType;
            }
            return "text/plain";
        }
    }
}
