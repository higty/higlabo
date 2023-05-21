using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadminaccessassignment-delete?view=graph-rest-1.0
    /// </summary>
    public partial class DelegatedadminAccessAssignmentDeleteParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class DelegatedadminAccessAssignmentDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadminaccessassignment-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminaccessassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<DelegatedadminAccessAssignmentDeleteResponse> DelegatedadminAccessAssignmentDeleteAsync()
        {
            var p = new DelegatedadminAccessAssignmentDeleteParameter();
            return await this.SendAsync<DelegatedadminAccessAssignmentDeleteParameter, DelegatedadminAccessAssignmentDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminaccessassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<DelegatedadminAccessAssignmentDeleteResponse> DelegatedadminAccessAssignmentDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new DelegatedadminAccessAssignmentDeleteParameter();
            return await this.SendAsync<DelegatedadminAccessAssignmentDeleteParameter, DelegatedadminAccessAssignmentDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminaccessassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<DelegatedadminAccessAssignmentDeleteResponse> DelegatedadminAccessAssignmentDeleteAsync(DelegatedadminAccessAssignmentDeleteParameter parameter)
        {
            return await this.SendAsync<DelegatedadminAccessAssignmentDeleteParameter, DelegatedadminAccessAssignmentDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminaccessassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<DelegatedadminAccessAssignmentDeleteResponse> DelegatedadminAccessAssignmentDeleteAsync(DelegatedadminAccessAssignmentDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DelegatedadminAccessAssignmentDeleteParameter, DelegatedadminAccessAssignmentDeleteResponse>(parameter, cancellationToken);
        }
    }
}
