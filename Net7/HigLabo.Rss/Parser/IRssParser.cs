using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Rss
{
    public interface IRssParser
    {
        RssFeed Parse(String xml);
    }
}
