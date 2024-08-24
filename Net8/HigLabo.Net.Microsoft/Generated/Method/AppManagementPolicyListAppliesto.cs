using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-list-appliesto?view=graph-rest-1.0
    /// </summary>
    public partial class AppManagementPolicyListAppliestoParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_AppManagementPolicies_Id_AppliesTo: return $"/policies/appManagementPolicies/{Id}/appliesTo";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Policies_AppManagementPolicies_Id_AppliesTo,
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
    public partial class AppManagementPolicyListAppliestoResponse : RestApiResponse<AppManagementPolicy>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-list-appliesto?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AppManagementPolicyListAppliestoResponse> AppManagementPolicyListAppliestoAsync()
        {
            var p = new AppManagementPolicyListAppliestoParameter();
            return await this.SendAsync<AppManagementPolicyListAppliestoParameter, AppManagementPolicyListAppliestoResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AppManagementPolicyListAppliestoResponse> AppManagementPolicyListAppliestoAsync(CancellationToken cancellationToken)
        {
            var p = new AppManagementPolicyListAppliestoParameter();
            return await this.SendAsync<AppManagementPolicyListAppliestoParameter, AppManagementPolicyListAppliestoResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AppManagementPolicyListAppliestoResponse> AppManagementPolicyListAppliestoAsync(AppManagementPolicyListAppliestoParameter parameter)
        {
            return await this.SendAsync<AppManagementPolicyListAppliestoParameter, AppManagementPolicyListAppliestoResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AppManagementPolicyListAppliestoResponse> AppManagementPolicyListAppliestoAsync(AppManagementPolicyListAppliestoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppManagementPolicyListAppliestoParameter, AppManagementPolicyListAppliestoResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<AppManagementPolicy> AppManagementPolicyListAppliestoEnumerateAsync(AppManagementPolicyListAppliestoParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<AppManagementPolicyListAppliestoParameter, AppManagementPolicyListAppliestoResponse>(parameter, cancellationToken);
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
