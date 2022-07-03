using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/internetmessageheader?view=graph-rest-1.0
    /// </summary>
    public partial class InternetMessageHeader
    {
        public String? Name { get; set; }
        public String? Value { get; set; }
    }
}
