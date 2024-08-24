using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/peopleadminsettings?view=graph-rest-1.0
    /// </summary>
    public partial class PeopleAdminSettings
    {
        public string? Id { get; set; }
        public InsightsSettings? ItemInsights { get; set; }
        public ProfileCardProperty[]? ProfileCardProperties { get; set; }
        public PronounsSettings? Pronouns { get; set; }
    }
}
