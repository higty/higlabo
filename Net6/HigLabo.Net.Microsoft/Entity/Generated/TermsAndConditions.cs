using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-companyterms-termsandconditions?view=graph-rest-1.0
    /// </summary>
    public partial class TermsAndConditions
    {
        public string Id { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public DateTimeOffset LastModifiedDateTime { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string BodyText { get; set; }
        public string AcceptanceStatement { get; set; }
        public Int32? Version { get; set; }
    }
}
