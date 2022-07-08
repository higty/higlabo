using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AdministrativeunitPostScopedrolemembersParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

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
    public partial class AdministrativeunitPostScopedrolemembersResponse : RestApiResponse
    {
        public string? AdministrativeUnitId { get; set; }
        public string? Id { get; set; }
        public string? RoleId { get; set; }
        public Identity? RoleMemberInfo { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/administrativeunit-post-scopedrolemembers?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitPostScopedrolemembersResponse> AdministrativeunitPostScopedrolemembersAsync()
        {
            var p = new AdministrativeunitPostScopedrolemembersParameter();
            return await this.SendAsync<AdministrativeunitPostScopedrolemembersParameter, AdministrativeunitPostScopedrolemembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/administrativeunit-post-scopedrolemembers?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitPostScopedrolemembersResponse> AdministrativeunitPostScopedrolemembersAsync(CancellationToken cancellationToken)
        {
            var p = new AdministrativeunitPostScopedrolemembersParameter();
            return await this.SendAsync<AdministrativeunitPostScopedrolemembersParameter, AdministrativeunitPostScopedrolemembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/administrativeunit-post-scopedrolemembers?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitPostScopedrolemembersResponse> AdministrativeunitPostScopedrolemembersAsync(AdministrativeunitPostScopedrolemembersParameter parameter)
        {
            return await this.SendAsync<AdministrativeunitPostScopedrolemembersParameter, AdministrativeunitPostScopedrolemembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/administrativeunit-post-scopedrolemembers?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitPostScopedrolemembersResponse> AdministrativeunitPostScopedrolemembersAsync(AdministrativeunitPostScopedrolemembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdministrativeunitPostScopedrolemembersParameter, AdministrativeunitPostScopedrolemembersResponse>(parameter, cancellationToken);
        }
    }
}
