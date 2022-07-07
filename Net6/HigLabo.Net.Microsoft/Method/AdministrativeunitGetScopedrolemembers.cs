using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AdministrativeunitGetScopedrolemembersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string AdministrativeUnitsId { get; set; }
        public string ScopedRoleMembersId { get; set; }
    }
    public partial class AdministrativeunitGetScopedrolemembersResponse : RestApiResponse
    {
        public string? AdministrativeUnitId { get; set; }
        public string? Id { get; set; }
        public string? RoleId { get; set; }
        public Identity? RoleMemberInfo { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/administrativeunit-get-scopedrolemembers?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitGetScopedrolemembersResponse> AdministrativeunitGetScopedrolemembersAsync()
        {
            var p = new AdministrativeunitGetScopedrolemembersParameter();
            return await this.SendAsync<AdministrativeunitGetScopedrolemembersParameter, AdministrativeunitGetScopedrolemembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/administrativeunit-get-scopedrolemembers?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitGetScopedrolemembersResponse> AdministrativeunitGetScopedrolemembersAsync(CancellationToken cancellationToken)
        {
            var p = new AdministrativeunitGetScopedrolemembersParameter();
            return await this.SendAsync<AdministrativeunitGetScopedrolemembersParameter, AdministrativeunitGetScopedrolemembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/administrativeunit-get-scopedrolemembers?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitGetScopedrolemembersResponse> AdministrativeunitGetScopedrolemembersAsync(AdministrativeunitGetScopedrolemembersParameter parameter)
        {
            return await this.SendAsync<AdministrativeunitGetScopedrolemembersParameter, AdministrativeunitGetScopedrolemembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/administrativeunit-get-scopedrolemembers?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitGetScopedrolemembersResponse> AdministrativeunitGetScopedrolemembersAsync(AdministrativeunitGetScopedrolemembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdministrativeunitGetScopedrolemembersParameter, AdministrativeunitGetScopedrolemembersResponse>(parameter, cancellationToken);
        }
    }
}
