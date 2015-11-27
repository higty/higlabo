using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace HigLabo.Web.Mvc
{
    public abstract class ParameterDataProvider
    {
        public abstract String Name { get; }
        public abstract Dictionary<String, String> GetDataSource(HttpActionContext context);
        public virtual String GetCacheKey()
        {
            return this.Name;
        }
    }
}
