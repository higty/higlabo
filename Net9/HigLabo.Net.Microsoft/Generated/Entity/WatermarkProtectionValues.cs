using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/watermarkprotectionvalues?view=graph-rest-1.0
/// </summary>
public partial class WatermarkProtectionValues
{
    public bool? IsEnabledForContentSharing { get; set; }
    public bool? IsEnabledForVideo { get; set; }
}
