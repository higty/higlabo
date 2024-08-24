using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/appsinstallationoptionsforwindows?view=graph-rest-1.0
    /// </summary>
    public partial class AppsInstallationOptionsForWindows
    {
        public bool? IsMicrosoft365AppsEnabled { get; set; }
        public bool? IsProjectEnabled { get; set; }
        public bool? IsSkypeForBusinessEnabled { get; set; }
        public bool? IsVisioEnabled { get; set; }
    }
}
