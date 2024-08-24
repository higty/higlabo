using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/externalconnectors-displaytemplate?view=graph-rest-1.0
    /// </summary>
    public partial class ExternalConnectorsDisplayTemplate
    {
        public string? Id { get; set; }
        public Json? Layout { get; set; }
        public Int32? Priority { get; set; }
        public ExternalConnectorsPropertyrule[]? Rules { get; set; }
    }
}
