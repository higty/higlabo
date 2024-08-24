using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roledefinitions?view=graph-rest-1.0
    /// </summary>
    public partial class RbacApplicationListRoleDefinitionsParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class RbacApplicationListRoleDefinitionsResponse : RestApiResponse<UnifiedRoleDefinition>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roledefinitions?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roledefinitions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacApplicationListRoleDefinitionsResponse> RbacApplicationListRoleDefinitionsAsync()
        {
            var p = new RbacApplicationListRoleDefinitionsParameter();
            return await this.SendAsync<RbacApplicationListRoleDefinitionsParameter, RbacApplicationListRoleDefinitionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roledefinitions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacApplicationListRoleDefinitionsResponse> RbacApplicationListRoleDefinitionsAsync(CancellationToken cancellationToken)
        {
            var p = new RbacApplicationListRoleDefinitionsParameter();
            return await this.SendAsync<RbacApplicationListRoleDefinitionsParameter, RbacApplicationListRoleDefinitionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roledefinitions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacApplicationListRoleDefinitionsResponse> RbacApplicationListRoleDefinitionsAsync(RbacApplicationListRoleDefinitionsParameter parameter)
        {
            return await this.SendAsync<RbacApplicationListRoleDefinitionsParameter, RbacApplicationListRoleDefinitionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roledefinitions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacApplicationListRoleDefinitionsResponse> RbacApplicationListRoleDefinitionsAsync(RbacApplicationListRoleDefinitionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RbacApplicationListRoleDefinitionsParameter, RbacApplicationListRoleDefinitionsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roledefinitions?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<UnifiedRoleDefinition> RbacApplicationListRoleDefinitionsEnumerateAsync(RbacApplicationListRoleDefinitionsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<RbacApplicationListRoleDefinitionsParameter, RbacApplicationListRoleDefinitionsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<UnifiedRoleDefinition>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
