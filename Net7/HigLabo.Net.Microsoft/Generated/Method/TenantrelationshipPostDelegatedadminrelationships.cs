using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tenantrelationship-post-delegatedadminrelationships?view=graph-rest-1.0
    /// </summary>
    public partial class TenantrelationshipPostDelegatedadminrelationshipsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.TenantRelationships_DelegatedAdminRelationships: return $"/tenantRelationships/delegatedAdminRelationships";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

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
        public enum ApiPath
        {
            TenantRelationships_DelegatedAdminRelationships,
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
        public DelegatedAdminAccessDetails? AccessDetails { get; set; }
        public DelegatedAdminRelationshipCustomerParticipant? Customer { get; set; }
        public string? DisplayName { get; set; }
        public string? Duration { get; set; }
        public DateTimeOffset? ActivatedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? EndDateTime { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DelegatedAdminRelationshipDelegatedAdminRelationshipStatus Status { get; set; }
        public DelegatedAdminAccessAssignment[]? AccessAssignments { get; set; }
        public DelegatedAdminRelationshipOperation[]? Operations { get; set; }
        public DelegatedAdminRelationshipRequest[]? Requests { get; set; }
    }
    public partial class TenantrelationshipPostDelegatedadminrelationshipsResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/tenantrelationship-post-delegatedadminrelationships?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tenantrelationship-post-delegatedadminrelationships?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TenantrelationshipPostDelegatedadminrelationshipsResponse> TenantrelationshipPostDelegatedadminrelationshipsAsync()
        {
            var p = new TenantrelationshipPostDelegatedadminrelationshipsParameter();
            return await this.SendAsync<TenantrelationshipPostDelegatedadminrelationshipsParameter, TenantrelationshipPostDelegatedadminrelationshipsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tenantrelationship-post-delegatedadminrelationships?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TenantrelationshipPostDelegatedadminrelationshipsResponse> TenantrelationshipPostDelegatedadminrelationshipsAsync(CancellationToken cancellationToken)
        {
            var p = new TenantrelationshipPostDelegatedadminrelationshipsParameter();
            return await this.SendAsync<TenantrelationshipPostDelegatedadminrelationshipsParameter, TenantrelationshipPostDelegatedadminrelationshipsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tenantrelationship-post-delegatedadminrelationships?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TenantrelationshipPostDelegatedadminrelationshipsResponse> TenantrelationshipPostDelegatedadminrelationshipsAsync(TenantrelationshipPostDelegatedadminrelationshipsParameter parameter)
        {
            return await this.SendAsync<TenantrelationshipPostDelegatedadminrelationshipsParameter, TenantrelationshipPostDelegatedadminrelationshipsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tenantrelationship-post-delegatedadminrelationships?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TenantrelationshipPostDelegatedadminrelationshipsResponse> TenantrelationshipPostDelegatedadminrelationshipsAsync(TenantrelationshipPostDelegatedadminrelationshipsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TenantrelationshipPostDelegatedadminrelationshipsParameter, TenantrelationshipPostDelegatedadminrelationshipsResponse>(parameter, cancellationToken);
        }
    }
}
