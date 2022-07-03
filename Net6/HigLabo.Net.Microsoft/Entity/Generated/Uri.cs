using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-shared-uri?view=graph-rest-1.0
    /// </summary>
    public partial class Uri
    {
        public String[] Segments { get; set; }
    }
}
