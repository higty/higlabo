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
        public String Convert(String html)
        {
            return html.Replace("\r","");
        }
    }
}
