using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/educationclass?view=graph-rest-1.0
    /// </summary>
    public partial class EducationClass
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string MailNickname { get; set; }
        public string Description { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public string ClassCode { get; set; }
        public string ExternalName { get; set; }
        public string ExternalId { get; set; }
        public EducationClassEducationExternalSource ExternalSource { get; set; }
        public string ExternalSourceDetail { get; set; }
        public string Grade { get; set; }
        public EducationTerm? Term { get; set; }
    }
}
