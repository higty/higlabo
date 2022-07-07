using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AdministrativeunitListScopedrolemembersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string Id { get; set; }
    }
    public partial class AdministrativeunitListScopedrolemembersResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/scopedrolemembership?view=graph-rest-1.0
        /// </summary>
        public partial class ScopedRoleMembership
        {
            public string? AdministrativeUnitId { get; set; }
            public string? Id { get; set; }
            public string? RoleId { get; set; }
            public Identity? RoleMemberInfo { get; set; }
        }

        public ScopedRoleMembership[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/administrativeunit-list-scopedrolemembers?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitListScopedrolemembersResponse> AdministrativeunitListScopedrolemembersAsync()
        {
            var p = new AdministrativeunitListScopedrolemembersParameter();
            return await this.SendAsync<AdministrativeunitListScopedrolemembersParameter, AdministrativeunitListScopedrolemembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/administrativeunit-list-scopedrolemembers?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitListScopedrolemembersResponse> AdministrativeunitListScopedrolemembersAsync(CancellationToken cancellationToken)
        {
            var p = new AdministrativeunitListScopedrolemembersParameter();
            return await this.SendAsync<AdministrativeunitListScopedrolemembersParameter, AdministrativeunitListScopedrolemembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/administrativeunit-list-scopedrolemembers?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitListScopedrolemembersResponse> AdministrativeunitListScopedrolemembersAsync(AdministrativeunitListScopedrolemembersParameter parameter)
        {
            return await this.SendAsync<AdministrativeunitListScopedrolemembersParameter, AdministrativeunitListScopedrolemembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/administrativeunit-list-scopedrolemembers?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitListScopedrolemembersResponse> AdministrativeunitListScopedrolemembersAsync(AdministrativeunitListScopedrolemembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdministrativeunitListScopedrolemembersParameter, AdministrativeunitListScopedrolemembersResponse>(parameter, cancellationToken);
        }
    }
}
