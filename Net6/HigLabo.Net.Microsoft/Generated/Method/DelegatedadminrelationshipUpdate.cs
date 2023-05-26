using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-update?view=graph-rest-1.0
    /// </summary>
    public partial class DelegatedadminrelationshipUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? DelegatedAdminRelationshipId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.TenantRelationships_DelegatedAdminRelationships_DelegatedAdminRelationshipId: return $"/tenantRelationships/delegatedAdminRelationships/{DelegatedAdminRelationshipId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            TenantRelationships_DelegatedAdminRelationships_DelegatedAdminRelationshipId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public DelegatedAdminAccessDetails? AccessDetails { get; set; }
        public DelegatedAdminRelationshipCustomerParticipant? Customer { get; set; }
        public string? DisplayName { get; set; }
        public string? Duration { get; set; }
    }
    public partial class DelegatedadminrelationshipUpdateResponse : RestApiResponse
    {
        public enum DelegatedAdminRelationshipDelegatedAdminRelationshipStatus
        {
            Activating,
            Active,
            ApprovalPending,
            Approved,
            Created,
            Expired,
            Expiring,
            Terminated,
            Terminating,
            TerminationRequested,
            UnknownFutureValue,
        }

        public DelegatedAdminAccessDetails? AccessDetails { get; set; }
        public DateTimeOffset? ActivatedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DelegatedAdminRelationshipCustomerParticipant? Customer { get; set; }
        public string? DisplayName { get; set; }
        public string? Duration { get; set; }
        public DateTimeOffset? EndDateTime { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DelegatedAdminRelationshipDelegatedAdminRelationshipStatus Status { get; set; }
        public DelegatedAdminAccessAssignment[]? AccessAssignments { get; set; }
        public DelegatedAdminRelationshipOperation[]? Operations { get; set; }
        public DelegatedAdminRelationshipRequest[]? Requests { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-update?view=graph-rest-1.0
        /// </summary>
        public async Task<DelegatedadminrelationshipUpdateResponse> DelegatedadminrelationshipUpdateAsync()
        {
            var p = new DelegatedadminrelationshipUpdateParameter();
            return await this.SendAsync<DelegatedadminrelationshipUpdateParameter, DelegatedadminrelationshipUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-update?view=graph-rest-1.0
        /// </summary>
        public async Task<DelegatedadminrelationshipUpdateResponse> DelegatedadminrelationshipUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new DelegatedadminrelationshipUpdateParameter();
            return await this.SendAsync<DelegatedadminrelationshipUpdateParameter, DelegatedadminrelationshipUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-update?view=graph-rest-1.0
        /// </summary>
        public async Task<DelegatedadminrelationshipUpdateResponse> DelegatedadminrelationshipUpdateAsync(DelegatedadminrelationshipUpdateParameter parameter)
        {
            return await this.SendAsync<DelegatedadminrelationshipUpdateParameter, DelegatedadminrelationshipUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-update?view=graph-rest-1.0
        /// </summary>
        public async Task<DelegatedadminrelationshipUpdateResponse> DelegatedadminrelationshipUpdateAsync(DelegatedadminrelationshipUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DelegatedadminrelationshipUpdateParameter, DelegatedadminrelationshipUpdateResponse>(parameter, cancellationToken);
        }
    }
}
