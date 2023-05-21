using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-delete-scopedrolemembers?view=graph-rest-1.0
    /// </summary>
    public partial class AdministrativeunitDeleteScopedrolemembersParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? AdministrativeUnitsId { get; set; }
            public string? ScopedRoleMembersId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Directory_AdministrativeUnits_Id_ScopedRoleMembers_Id: return $"/directory/administrativeUnits/{AdministrativeUnitsId}/scopedRoleMembers/{ScopedRoleMembersId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Directory_AdministrativeUnits_Id_ScopedRoleMembers_Id,
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
    public partial class AdministrativeunitDeleteScopedrolemembersResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-delete-scopedrolemembers?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-delete-scopedrolemembers?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitDeleteScopedrolemembersResponse> AdministrativeunitDeleteScopedrolemembersAsync()
        {
            var p = new AdministrativeunitDeleteScopedrolemembersParameter();
            return await this.SendAsync<AdministrativeunitDeleteScopedrolemembersParameter, AdministrativeunitDeleteScopedrolemembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-delete-scopedrolemembers?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitDeleteScopedrolemembersResponse> AdministrativeunitDeleteScopedrolemembersAsync(CancellationToken cancellationToken)
        {
            var p = new AdministrativeunitDeleteScopedrolemembersParameter();
            return await this.SendAsync<AdministrativeunitDeleteScopedrolemembersParameter, AdministrativeunitDeleteScopedrolemembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-delete-scopedrolemembers?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitDeleteScopedrolemembersResponse> AdministrativeunitDeleteScopedrolemembersAsync(AdministrativeunitDeleteScopedrolemembersParameter parameter)
        {
            return await this.SendAsync<AdministrativeunitDeleteScopedrolemembersParameter, AdministrativeunitDeleteScopedrolemembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-delete-scopedrolemembers?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitDeleteScopedrolemembersResponse> AdministrativeunitDeleteScopedrolemembersAsync(AdministrativeunitDeleteScopedrolemembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdministrativeunitDeleteScopedrolemembersParameter, AdministrativeunitDeleteScopedrolemembersResponse>(parameter, cancellationToken);
        }
    }
}
