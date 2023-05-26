using HigLabo.Net.OAuth;

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
            Id,
            DisplayName,
            Description,
            IsEnabled,
            Restrictions,
            AppliesTo,
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
    public partial class AppManagementPolicyListAppliestoResponse : RestApiResponse
    {
        public AppManagementPolicy[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-list-appliesto?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<AppManagementPolicyListAppliestoResponse> AppManagementPolicyListAppliestoAsync()
        {
            var p = new AppManagementPolicyListAppliestoParameter();
            return await this.SendAsync<AppManagementPolicyListAppliestoParameter, AppManagementPolicyListAppliestoResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<AppManagementPolicyListAppliestoResponse> AppManagementPolicyListAppliestoAsync(CancellationToken cancellationToken)
        {
            var p = new AppManagementPolicyListAppliestoParameter();
            return await this.SendAsync<AppManagementPolicyListAppliestoParameter, AppManagementPolicyListAppliestoResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<AppManagementPolicyListAppliestoResponse> AppManagementPolicyListAppliestoAsync(AppManagementPolicyListAppliestoParameter parameter)
        {
            return await this.SendAsync<AppManagementPolicyListAppliestoParameter, AppManagementPolicyListAppliestoResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-list-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<AppManagementPolicyListAppliestoResponse> AppManagementPolicyListAppliestoAsync(AppManagementPolicyListAppliestoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppManagementPolicyListAppliestoParameter, AppManagementPolicyListAppliestoResponse>(parameter, cancellationToken);
        }
    }
}
