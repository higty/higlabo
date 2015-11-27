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
        private static Assembly CurrentAssembly = Assembly.GetExecutingAssembly();

        public static readonly IReadOnlyCollection<String> ResourceNames = new List<string>(CurrentAssembly.GetManifestResourceNames());
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
                String resourceName = ResourceNames.FirstOrDefault(f => f.EndsWith(name));
                stm = CurrentAssembly.GetManifestResourceStream(resourceName);
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
