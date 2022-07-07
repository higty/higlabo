using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AdministrativeunitDeleteScopedrolemembersParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Directory_AdministrativeUnits_Id_ScopedRoleMembers_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Directory_AdministrativeUnits_Id_ScopedRoleMembers_Id: return $"/directory/administrativeUnits/{AdministrativeUnitsId}/scopedRoleMembers/{ScopedRoleMembersId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string AdministrativeUnitsId { get; set; }
        public string ScopedRoleMembersId { get; set; }
    }
    public partial class AdministrativeunitDeleteScopedrolemembersResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/administrativeunit-delete-scopedrolemembers?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitDeleteScopedrolemembersResponse> AdministrativeunitDeleteScopedrolemembersAsync()
        {
            var p = new AdministrativeunitDeleteScopedrolemembersParameter();
            return await this.SendAsync<AdministrativeunitDeleteScopedrolemembersParameter, AdministrativeunitDeleteScopedrolemembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/administrativeunit-delete-scopedrolemembers?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitDeleteScopedrolemembersResponse> AdministrativeunitDeleteScopedrolemembersAsync(CancellationToken cancellationToken)
        {
            var p = new AdministrativeunitDeleteScopedrolemembersParameter();
            return await this.SendAsync<AdministrativeunitDeleteScopedrolemembersParameter, AdministrativeunitDeleteScopedrolemembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/administrativeunit-delete-scopedrolemembers?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitDeleteScopedrolemembersResponse> AdministrativeunitDeleteScopedrolemembersAsync(AdministrativeunitDeleteScopedrolemembersParameter parameter)
        {
            return await this.SendAsync<AdministrativeunitDeleteScopedrolemembersParameter, AdministrativeunitDeleteScopedrolemembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/administrativeunit-delete-scopedrolemembers?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitDeleteScopedrolemembersResponse> AdministrativeunitDeleteScopedrolemembersAsync(AdministrativeunitDeleteScopedrolemembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdministrativeunitDeleteScopedrolemembersParameter, AdministrativeunitDeleteScopedrolemembersResponse>(parameter, cancellationToken);
        }
    }
}
