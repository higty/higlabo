using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Bing;

public class LicenseAttribution
{
    public string _Type { get; set; } = "";
    public string TargetPropertyName { get; set; } = "";
    public int? TargetPropertyIndex { get; set; }
    public bool? MustBeCloseToContent { get; set; }
    public License? License { get; set; } = new();
    public string LicenseNotice { get; set; } = "";
}
