using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadminaccessassignment-get?view=graph-rest-1.0
    /// </summary>
    public partial class DelegatedadminAccessAssignmentGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? DelegatedAdminRelationshipId { get; set; }
            public string? DelegatedAdminAccessAssignmentId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.TenantRelationships_DelegatedAdminRelationships_DelegatedAdminRelationshipId_AccessAssignments_DelegatedAdminAccessAssignmentId: return $"/tenantRelationships/delegatedAdminRelationships/{DelegatedAdminRelationshipId}/accessAssignments/{DelegatedAdminAccessAssignmentId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            TenantRelationships_DelegatedAdminRelationships_DelegatedAdminRelationshipId_AccessAssignments_DelegatedAdminAccessAssignmentId,
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
    public partial class DelegatedadminAccessAssignmentGetResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadminaccessassignment-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminaccessassignment-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DelegatedadminAccessAssignmentGetResponse> DelegatedadminAccessAssignmentGetAsync()
        {
            var p = new DelegatedadminAccessAssignmentGetParameter();
            return await this.SendAsync<DelegatedadminAccessAssignmentGetParameter, DelegatedadminAccessAssignmentGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminaccessassignment-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DelegatedadminAccessAssignmentGetResponse> DelegatedadminAccessAssignmentGetAsync(CancellationToken cancellationToken)
        {
            var p = new DelegatedadminAccessAssignmentGetParameter();
            return await this.SendAsync<DelegatedadminAccessAssignmentGetParameter, DelegatedadminAccessAssignmentGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminaccessassignment-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DelegatedadminAccessAssignmentGetResponse> DelegatedadminAccessAssignmentGetAsync(DelegatedadminAccessAssignmentGetParameter parameter)
        {
            return await this.SendAsync<DelegatedadminAccessAssignmentGetParameter, DelegatedadminAccessAssignmentGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminaccessassignment-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DelegatedadminAccessAssignmentGetResponse> DelegatedadminAccessAssignmentGetAsync(DelegatedadminAccessAssignmentGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DelegatedadminAccessAssignmentGetParameter, DelegatedadminAccessAssignmentGetResponse>(parameter, cancellationToken);
        }
    }
}
