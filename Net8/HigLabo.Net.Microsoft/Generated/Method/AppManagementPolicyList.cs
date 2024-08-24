using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-list?view=graph-rest-1.0
    /// </summary>
    public partial class AppManagementPolicyListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_AppManagementPolicies: return $"/policies/appManagementPolicies";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_AppManagementPolicies,
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
    public partial class AppManagementPolicyListResponse : RestApiResponse<AppManagementPolicy>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AppManagementPolicyListResponse> AppManagementPolicyListAsync()
        {
            var p = new AppManagementPolicyListParameter();
            return await this.SendAsync<AppManagementPolicyListParameter, AppManagementPolicyListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AppManagementPolicyListResponse> AppManagementPolicyListAsync(CancellationToken cancellationToken)
        {
            var p = new AppManagementPolicyListParameter();
            return await this.SendAsync<AppManagementPolicyListParameter, AppManagementPolicyListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AppManagementPolicyListResponse> AppManagementPolicyListAsync(AppManagementPolicyListParameter parameter)
        {
            return await this.SendAsync<AppManagementPolicyListParameter, AppManagementPolicyListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AppManagementPolicyListResponse> AppManagementPolicyListAsync(AppManagementPolicyListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppManagementPolicyListParameter, AppManagementPolicyListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-list?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<AppManagementPolicy> AppManagementPolicyListEnumerateAsync(AppManagementPolicyListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<AppManagementPolicyListParameter, AppManagementPolicyListResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<AppManagementPolicy>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
