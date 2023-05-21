using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationshiprequest-get?view=graph-rest-1.0
    /// </summary>
    public partial class DelegatedadminrelationshiprequestGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? DelegatedAdminRelationshipId { get; set; }
            public string? DelegatedAdminRelationshipRequestId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.TenantRelationships_DelegatedAdminRelationships_DelegatedAdminRelationshipId_Requests_DelegatedAdminRelationshipRequestId: return $"/tenantRelationships/delegatedAdminRelationships/{DelegatedAdminRelationshipId}/requests/{DelegatedAdminRelationshipRequestId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            TenantRelationships_DelegatedAdminRelationships_DelegatedAdminRelationshipId_Requests_DelegatedAdminRelationshipRequestId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class DelegatedadminrelationshiprequestGetResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationshiprequest-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationshiprequest-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DelegatedadminrelationshiprequestGetResponse> DelegatedadminrelationshiprequestGetAsync()
        {
            var p = new DelegatedadminrelationshiprequestGetParameter();
            return await this.SendAsync<DelegatedadminrelationshiprequestGetParameter, DelegatedadminrelationshiprequestGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationshiprequest-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DelegatedadminrelationshiprequestGetResponse> DelegatedadminrelationshiprequestGetAsync(CancellationToken cancellationToken)
        {
            var p = new DelegatedadminrelationshiprequestGetParameter();
            return await this.SendAsync<DelegatedadminrelationshiprequestGetParameter, DelegatedadminrelationshiprequestGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationshiprequest-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DelegatedadminrelationshiprequestGetResponse> DelegatedadminrelationshiprequestGetAsync(DelegatedadminrelationshiprequestGetParameter parameter)
        {
            return await this.SendAsync<DelegatedadminrelationshiprequestGetParameter, DelegatedadminrelationshiprequestGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationshiprequest-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DelegatedadminrelationshiprequestGetResponse> DelegatedadminrelationshiprequestGetAsync(DelegatedadminrelationshiprequestGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DelegatedadminrelationshiprequestGetParameter, DelegatedadminrelationshiprequestGetResponse>(parameter, cancellationToken);
        }
    }
}
