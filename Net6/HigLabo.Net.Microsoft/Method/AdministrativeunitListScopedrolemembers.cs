using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AdministrativeunitListScopedrolemembersParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
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
    public partial class AdministrativeunitListScopedrolemembersResponse : RestApiResponse
    {
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
