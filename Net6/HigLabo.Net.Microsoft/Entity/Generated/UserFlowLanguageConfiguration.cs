using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/userflowlanguageconfiguration?view=graph-rest-1.0
    /// </summary>
    public partial class UserFlowLanguageConfiguration
    {
        public string? Id { get; set; }
        public bool? IsEnabled { get; set; }
        public string? DisplayName { get; set; }
    }
}
