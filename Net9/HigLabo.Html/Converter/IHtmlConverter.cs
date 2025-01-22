using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Html;

public interface IHtmlConverter
{
    ValueTask<String> ConvertAsync(String html);
}
