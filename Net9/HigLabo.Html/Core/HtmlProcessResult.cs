using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Html;

public class HtmlProcessResult
{
    public String SourceHtml { get; init; }
    public String Html { get; set; } = "";

    public HtmlProcessResult(String sourceHtml)
    {
        this.SourceHtml = sourceHtml;
        this.Html = sourceHtml;
    }
}
