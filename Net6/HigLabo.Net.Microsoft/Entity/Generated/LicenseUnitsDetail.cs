using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/licenseunitsdetail?view=graph-rest-1.0
    /// </summary>
    public partial class LicenseUnitsDetail
    {
        public Int32? Enabled { get; set; }
        public Int32? Suspended { get; set; }
        public Int32? Warning { get; set; }
    }
}
