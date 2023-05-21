using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/accesspackagesubject?view=graph-rest-1.0
    /// </summary>
    public partial class AccessPackageSubject
    {
        public enum AccessPackageSubjectAccessPackageSubjectType
        {
            NotSpecified,
            User,
            ServicePrincipal,
            UnknownFutureValue,
        }

        public string? DisplayName { get; set; }
        public string? Email { get; set; }
        public string? Id { get; set; }
        public string? ObjectId { get; set; }
        public string? OnPremisesSecurityIdentifier { get; set; }
        public string? PrincipalName { get; set; }
        public AccessPackageSubjectAccessPackageSubjectType SubjectType { get; set; }
        public ConnectedOrganization? ConnectedOrganization { get; set; }
    }
}
