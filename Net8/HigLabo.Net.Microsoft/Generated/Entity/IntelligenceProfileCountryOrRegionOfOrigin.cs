using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-intelligenceprofilecountryorregionoforigin?view=graph-rest-1.0
    /// </summary>
    public partial class IntelligenceProfileCountryOrRegionOfOrigin
    {
        public string? Code { get; set; }
        public string? Label { get; set; }
    }
}
