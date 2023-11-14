using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Html
{
    public class NewLineHtmlConverter : IHtmlConverter
    {
        public async ValueTask<String> ConvertAsync(String html)
        {
            return await ValueTask.FromResult(html.Replace("\r",""));
        }
    }
}
