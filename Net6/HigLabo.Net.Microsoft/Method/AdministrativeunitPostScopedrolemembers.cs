using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AdministrativeunitPostScopedrolemembersParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Directory_AdministrativeUnits_Id_ScopedRoleMembers,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Directory_AdministrativeUnits_Id_ScopedRoleMembers: return $"/directory/administrativeUnits/{Id}/scopedRoleMembers";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
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
