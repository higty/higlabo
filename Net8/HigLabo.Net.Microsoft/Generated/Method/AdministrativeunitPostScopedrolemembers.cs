using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-post-scopedrolemembers?view=graph-rest-1.0
    /// </summary>
    public partial class AdministrativeunitPostScopedroleMembersParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Directory_AdministrativeUnits_Id_ScopedRoleMembers: return $"/directory/administrativeUnits/{Id}/scopedRoleMembers";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Directory_AdministrativeUnits_Id_ScopedRoleMembers,
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
        public string? AdministrativeUnitId { get; set; }
        public string? Id { get; set; }
        public string? RoleId { get; set; }
        public Identity? RoleMemberInfo { get; set; }
    }
    public partial class AdministrativeunitPostScopedroleMembersResponse : RestApiResponse
    {
        public string? AdministrativeUnitId { get; set; }
        public string? Id { get; set; }
        public string? RoleId { get; set; }
        public Identity? RoleMemberInfo { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-post-scopedrolemembers?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-post-scopedrolemembers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AdministrativeunitPostScopedroleMembersResponse> AdministrativeunitPostScopedroleMembersAsync()
        {
            var p = new AdministrativeunitPostScopedroleMembersParameter();
            return await this.SendAsync<AdministrativeunitPostScopedroleMembersParameter, AdministrativeunitPostScopedroleMembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-post-scopedrolemembers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AdministrativeunitPostScopedroleMembersResponse> AdministrativeunitPostScopedroleMembersAsync(CancellationToken cancellationToken)
        {
            var p = new AdministrativeunitPostScopedroleMembersParameter();
            return await this.SendAsync<AdministrativeunitPostScopedroleMembersParameter, AdministrativeunitPostScopedroleMembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-post-scopedrolemembers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AdministrativeunitPostScopedroleMembersResponse> AdministrativeunitPostScopedroleMembersAsync(AdministrativeunitPostScopedroleMembersParameter parameter)
        {
            return await this.SendAsync<AdministrativeunitPostScopedroleMembersParameter, AdministrativeunitPostScopedroleMembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-post-scopedrolemembers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AdministrativeunitPostScopedroleMembersResponse> AdministrativeunitPostScopedroleMembersAsync(AdministrativeunitPostScopedroleMembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdministrativeunitPostScopedroleMembersParameter, AdministrativeunitPostScopedroleMembersResponse>(parameter, cancellationToken);
        }
    }
}
