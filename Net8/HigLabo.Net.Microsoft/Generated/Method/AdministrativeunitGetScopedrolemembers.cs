using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-get-scopedrolemembers?view=graph-rest-1.0
    /// </summary>
    public partial class AdministrativeunitGetScopedroleMembersParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
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
    public partial class AdministrativeunitGetScopedroleMembersResponse : RestApiResponse
    {
        public string? AdministrativeUnitId { get; set; }
        public string? Id { get; set; }
        public string? RoleId { get; set; }
        public Identity? RoleMemberInfo { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-get-scopedrolemembers?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-get-scopedrolemembers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AdministrativeunitGetScopedroleMembersResponse> AdministrativeunitGetScopedroleMembersAsync()
        {
            var p = new AdministrativeunitGetScopedroleMembersParameter();
            return await this.SendAsync<AdministrativeunitGetScopedroleMembersParameter, AdministrativeunitGetScopedroleMembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-get-scopedrolemembers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AdministrativeunitGetScopedroleMembersResponse> AdministrativeunitGetScopedroleMembersAsync(CancellationToken cancellationToken)
        {
            var p = new AdministrativeunitGetScopedroleMembersParameter();
            return await this.SendAsync<AdministrativeunitGetScopedroleMembersParameter, AdministrativeunitGetScopedroleMembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-get-scopedrolemembers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AdministrativeunitGetScopedroleMembersResponse> AdministrativeunitGetScopedroleMembersAsync(AdministrativeunitGetScopedroleMembersParameter parameter)
        {
            return await this.SendAsync<AdministrativeunitGetScopedroleMembersParameter, AdministrativeunitGetScopedroleMembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-get-scopedrolemembers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AdministrativeunitGetScopedroleMembersResponse> AdministrativeunitGetScopedroleMembersAsync(AdministrativeunitGetScopedroleMembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdministrativeunitGetScopedroleMembersParameter, AdministrativeunitGetScopedroleMembersResponse>(parameter, cancellationToken);
        }
    }
}
