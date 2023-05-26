using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-post-accessassignments?view=graph-rest-1.0
    /// </summary>
    public partial class DelegatedadminrelationshipPostAccessAssignmentsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? DelegatedAdminRelationshipId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.TenantRelationships_DelegatedAdminRelationships_DelegatedAdminRelationshipId_AccessAssignments: return $"/tenantRelationships/delegatedAdminRelationships/{DelegatedAdminRelationshipId}/accessAssignments";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum DelegatedAdminAccessAssignmentDelegatedAdminAccessAssignmentStatus
        {
            Pending,
            Active,
            Deleting,
            Deleted,
            Error,
            UnknownFutureValue,
        }
        public enum ApiPath
        {
            TenantRelationships_DelegatedAdminRelationships_DelegatedAdminRelationshipId_AccessAssignments,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public DelegatedAdminAccessContainer? AccessContainer { get; set; }
        public DelegatedAdminAccessDetails? AccessDetails { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DelegatedAdminAccessAssignmentDelegatedAdminAccessAssignmentStatus Status { get; set; }
    }
    public partial class DelegatedadminrelationshipPostAccessAssignmentsResponse : RestApiResponse
    {
        public enum DelegatedAdminAccessAssignmentDelegatedAdminAccessAssignmentStatus
        {
            Pending,
            Active,
            Deleting,
            Deleted,
            Error,
            UnknownFutureValue,
        }

        public DelegatedAdminAccessContainer? AccessContainer { get; set; }
        public DelegatedAdminAccessDetails? AccessDetails { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DelegatedAdminAccessAssignmentDelegatedAdminAccessAssignmentStatus Status { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-post-accessassignments?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-post-accessassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<DelegatedadminrelationshipPostAccessAssignmentsResponse> DelegatedadminrelationshipPostAccessAssignmentsAsync()
        {
            var p = new DelegatedadminrelationshipPostAccessAssignmentsParameter();
            return await this.SendAsync<DelegatedadminrelationshipPostAccessAssignmentsParameter, DelegatedadminrelationshipPostAccessAssignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-post-accessassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<DelegatedadminrelationshipPostAccessAssignmentsResponse> DelegatedadminrelationshipPostAccessAssignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new DelegatedadminrelationshipPostAccessAssignmentsParameter();
            return await this.SendAsync<DelegatedadminrelationshipPostAccessAssignmentsParameter, DelegatedadminrelationshipPostAccessAssignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-post-accessassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<DelegatedadminrelationshipPostAccessAssignmentsResponse> DelegatedadminrelationshipPostAccessAssignmentsAsync(DelegatedadminrelationshipPostAccessAssignmentsParameter parameter)
        {
            return await this.SendAsync<DelegatedadminrelationshipPostAccessAssignmentsParameter, DelegatedadminrelationshipPostAccessAssignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-post-accessassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<DelegatedadminrelationshipPostAccessAssignmentsResponse> DelegatedadminrelationshipPostAccessAssignmentsAsync(DelegatedadminrelationshipPostAccessAssignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DelegatedadminrelationshipPostAccessAssignmentsParameter, DelegatedadminrelationshipPostAccessAssignmentsResponse>(parameter, cancellationToken);
        }
    }
}
