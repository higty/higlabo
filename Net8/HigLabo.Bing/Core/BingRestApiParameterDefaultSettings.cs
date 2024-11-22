using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Bing;

public class BingRestApiParameterDefaultSettings
{
    public BingMarket Market { get; set; }

    public BingRestApiParameterDefaultSettings()
    {
        this.Market = BingMarketLanguage.Create();
    }
}
