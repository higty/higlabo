using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/externalconnectors-schema?view=graph-rest-1.0
    /// </summary>
    public partial class Schema
    {
        public string BaseType { get; set; }
        public Property[] Properties { get; set; }
    }
}
