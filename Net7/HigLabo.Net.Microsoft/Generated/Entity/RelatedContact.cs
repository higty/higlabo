using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/relatedcontact?view=graph-rest-1.0
    /// </summary>
    public partial class RelatedContact
    {
        public enum RelatedContactContactRelationship
        {
            Parent,
            Relative,
            Aide,
            Doctor,
            Guardian,
            Child,
            Other,
            UnknownFutureValue,
        }

        public bool? AccessConsent { get; set; }
        public string? DisplayName { get; set; }
        public string? EmailAddress { get; set; }
        public string? MobilePhone { get; set; }
        public RelatedContactContactRelationship Relationship { get; set; }
    }
}
