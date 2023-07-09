using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-list-requests?view=graph-rest-1.0
    /// </summary>
    public partial class DelegatedadminrelationshipListRequestsParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
            Action,
            CreatedDateTime,
            Id,
            LastModifiedDateTime,
            Status,
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
    public partial class DelegatedadminrelationshipListRequestsResponse : RestApiResponse
    {
        public DelegatedAdminRelationshipRequest[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-list-requests?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-list-requests?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DelegatedadminrelationshipListRequestsResponse> DelegatedadminrelationshipListRequestsAsync()
        {
            var p = new DelegatedadminrelationshipListRequestsParameter();
            return await this.SendAsync<DelegatedadminrelationshipListRequestsParameter, DelegatedadminrelationshipListRequestsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-list-requests?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DelegatedadminrelationshipListRequestsResponse> DelegatedadminrelationshipListRequestsAsync(CancellationToken cancellationToken)
        {
            var p = new DelegatedadminrelationshipListRequestsParameter();
            return await this.SendAsync<DelegatedadminrelationshipListRequestsParameter, DelegatedadminrelationshipListRequestsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-list-requests?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DelegatedadminrelationshipListRequestsResponse> DelegatedadminrelationshipListRequestsAsync(DelegatedadminrelationshipListRequestsParameter parameter)
        {
            return await this.SendAsync<DelegatedadminrelationshipListRequestsParameter, DelegatedadminrelationshipListRequestsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-list-requests?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DelegatedadminrelationshipListRequestsResponse> DelegatedadminrelationshipListRequestsAsync(DelegatedadminrelationshipListRequestsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DelegatedadminrelationshipListRequestsParameter, DelegatedadminrelationshipListRequestsResponse>(parameter, cancellationToken);
        }
    }
}
