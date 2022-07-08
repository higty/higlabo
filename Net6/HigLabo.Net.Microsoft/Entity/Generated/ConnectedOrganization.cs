using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/connectedorganization?view=graph-rest-1.0
    /// </summary>
    public partial class ConnectedOrganization
    {
        public enum ConnectedOrganizationConnectedOrganizationState
        {
            AllConfiguredConnectedOrganizationSubjects,
            Configured,
            Proposed,
            UnknownFutureValue,
        }

        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public IdentitySource[]? IdentitySources { get; set; }
        public DateTimeOffset? ModifiedDateTime { get; set; }
        public ConnectedOrganizationConnectedOrganizationState State { get; set; }
        public DirectoryObject[]? ExternalSponsors { get; set; }
        public DirectoryObject[]? InternalSponsors { get; set; }
    }
}
