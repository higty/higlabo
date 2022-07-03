using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-onboarding-rgbcolor?view=graph-rest-1.0
    /// </summary>
    public partial class RgbColor
    {
        public Byte? R { get; set; }
        public Byte? G { get; set; }
        public Byte? B { get; set; }
    }
}
