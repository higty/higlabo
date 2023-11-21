using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roledefinitions?view=graph-rest-1.0
    /// </summary>
    public partial class RbacapplicationListRoledefinitionsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.RoleManagement_Directory_RoleDefinitions: return $"/roleManagement/directory/roleDefinitions";
                    case ApiPath.RoleManagement_EntitlementManagement_RoleDefinitions: return $"/roleManagement/entitlementManagement/roleDefinitions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Description,
            DisplayName,
            Id,
            IsBuiltIn,
            IsEnabled,
            ResourceScopes,
            RolePermissions,
            TemplateId,
            Version,
            InheritsPermissionsFrom,
        }
        public enum ApiPath
        {
            RoleManagement_Directory_RoleDefinitions,
            RoleManagement_EntitlementManagement_RoleDefinitions,
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
    public partial class RbacapplicationListRoledefinitionsResponse : RestApiResponse
    {
        public UnifiedRoleDefinition[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roledefinitions?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roledefinitions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacapplicationListRoledefinitionsResponse> RbacapplicationListRoledefinitionsAsync()
        {
            var p = new RbacapplicationListRoledefinitionsParameter();
            return await this.SendAsync<RbacapplicationListRoledefinitionsParameter, RbacapplicationListRoledefinitionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roledefinitions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacapplicationListRoledefinitionsResponse> RbacapplicationListRoledefinitionsAsync(CancellationToken cancellationToken)
        {
            var p = new RbacapplicationListRoledefinitionsParameter();
            return await this.SendAsync<RbacapplicationListRoledefinitionsParameter, RbacapplicationListRoledefinitionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roledefinitions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacapplicationListRoledefinitionsResponse> RbacapplicationListRoledefinitionsAsync(RbacapplicationListRoledefinitionsParameter parameter)
        {
            return await this.SendAsync<RbacapplicationListRoledefinitionsParameter, RbacapplicationListRoledefinitionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roledefinitions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacapplicationListRoledefinitionsResponse> RbacapplicationListRoledefinitionsAsync(RbacapplicationListRoledefinitionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RbacapplicationListRoledefinitionsParameter, RbacapplicationListRoledefinitionsResponse>(parameter, cancellationToken);
        }
    }
}
