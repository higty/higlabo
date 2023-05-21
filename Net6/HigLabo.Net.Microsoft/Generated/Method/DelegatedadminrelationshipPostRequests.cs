using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-post-requests?view=graph-rest-1.0
    /// </summary>
    public partial class DelegatedadminrelationshipPostRequestsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? DelegatedAdminRelationshipId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.TenantRelationships_DelegatedAdminRelationships_DelegatedAdminRelationshipId_Requests: return $"/tenantRelationships/delegatedAdminRelationships/{DelegatedAdminRelationshipId}/requests";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum DelegatedadminrelationshipPostRequestsParameterDelegatedAdminRelationshipRequestAction
        {
            LockForApproval,
            Terminate,
        }
        public enum DelegatedAdminRelationshipRequestDelegatedAdminRelationshipRequestStatus
        {
            Created,
            Pending,
            Succeeded,
            Failed,
            UnknownFutureValue,
        }
        public enum ApiPath
        {
            TenantRelationships_DelegatedAdminRelationships_DelegatedAdminRelationshipId_Requests,
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
        public DelegatedadminrelationshipPostRequestsParameterDelegatedAdminRelationshipRequestAction Action { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DelegatedAdminRelationshipRequestDelegatedAdminRelationshipRequestStatus Status { get; set; }
    }
    public partial class DelegatedadminrelationshipPostRequestsResponse : RestApiResponse
    {
        public enum DelegatedAdminRelationshipRequestDelegatedAdminRelationshipRequestStatus
        {
            Created,
            Pending,
            Succeeded,
            Failed,
            UnknownFutureValue,
        }

        public DelegatedAdminRelationshipRequestAction? Action { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DelegatedAdminRelationshipRequestDelegatedAdminRelationshipRequestStatus Status { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-post-requests?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-post-requests?view=graph-rest-1.0
        /// </summary>
        public async Task<DelegatedadminrelationshipPostRequestsResponse> DelegatedadminrelationshipPostRequestsAsync()
        {
            var p = new DelegatedadminrelationshipPostRequestsParameter();
            return await this.SendAsync<DelegatedadminrelationshipPostRequestsParameter, DelegatedadminrelationshipPostRequestsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-post-requests?view=graph-rest-1.0
        /// </summary>
        public async Task<DelegatedadminrelationshipPostRequestsResponse> DelegatedadminrelationshipPostRequestsAsync(CancellationToken cancellationToken)
        {
            var p = new DelegatedadminrelationshipPostRequestsParameter();
            return await this.SendAsync<DelegatedadminrelationshipPostRequestsParameter, DelegatedadminrelationshipPostRequestsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-post-requests?view=graph-rest-1.0
        /// </summary>
        public async Task<DelegatedadminrelationshipPostRequestsResponse> DelegatedadminrelationshipPostRequestsAsync(DelegatedadminrelationshipPostRequestsParameter parameter)
        {
            return await this.SendAsync<DelegatedadminrelationshipPostRequestsParameter, DelegatedadminrelationshipPostRequestsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-post-requests?view=graph-rest-1.0
        /// </summary>
        public async Task<DelegatedadminrelationshipPostRequestsResponse> DelegatedadminrelationshipPostRequestsAsync(DelegatedadminrelationshipPostRequestsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DelegatedadminrelationshipPostRequestsParameter, DelegatedadminrelationshipPostRequestsResponse>(parameter, cancellationToken);
        }
    }
}
