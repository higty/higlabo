using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadminaccessassignment-update?view=graph-rest-1.0
    /// </summary>
    public partial class DelegatedadminAccessAssignmentUpdateParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public DelegatedAdminAccessDetails? AccessDetails { get; set; }
    }
    public partial class DelegatedadminAccessAssignmentUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadminaccessassignment-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminaccessassignment-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DelegatedadminAccessAssignmentUpdateResponse> DelegatedadminAccessAssignmentUpdateAsync()
        {
            var p = new DelegatedadminAccessAssignmentUpdateParameter();
            return await this.SendAsync<DelegatedadminAccessAssignmentUpdateParameter, DelegatedadminAccessAssignmentUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminaccessassignment-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DelegatedadminAccessAssignmentUpdateResponse> DelegatedadminAccessAssignmentUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new DelegatedadminAccessAssignmentUpdateParameter();
            return await this.SendAsync<DelegatedadminAccessAssignmentUpdateParameter, DelegatedadminAccessAssignmentUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminaccessassignment-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DelegatedadminAccessAssignmentUpdateResponse> DelegatedadminAccessAssignmentUpdateAsync(DelegatedadminAccessAssignmentUpdateParameter parameter)
        {
            return await this.SendAsync<DelegatedadminAccessAssignmentUpdateParameter, DelegatedadminAccessAssignmentUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminaccessassignment-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DelegatedadminAccessAssignmentUpdateResponse> DelegatedadminAccessAssignmentUpdateAsync(DelegatedadminAccessAssignmentUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DelegatedadminAccessAssignmentUpdateParameter, DelegatedadminAccessAssignmentUpdateResponse>(parameter, cancellationToken);
        }
    }
}
