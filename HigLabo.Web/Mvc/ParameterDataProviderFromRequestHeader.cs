using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http.Controllers;

namespace HigLabo.Web.Mvc
{
    public class ParameterDataProviderFromRequestHeader : ParameterDataProvider
    {
        public override string Name
        {
            get { return "ParameterDataProviderFromRequestHeader"; }
        }
        public List<String> Keys { get; private set; }

        public ParameterDataProviderFromRequestHeader()
        {
            this.Keys = new List<string>();
        }
        public override Dictionary<String, String> GetDataSource(HttpActionContext context)
        {
            var d = new Dictionary<String, String>(StringComparer.OrdinalIgnoreCase);
            foreach (var item in context.Request.Headers.Where(el => el.Value.Any()))
            {
                if (this.Keys.Contains(item.Key, StringComparer.OrdinalIgnoreCase) == false) { continue; }
                d[item.Key] = item.Value.FirstOrDefault();
            }
            return d;
        }
    }
}
