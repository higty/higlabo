using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-delete?view=graph-rest-1.0
    /// </summary>
    public partial class AppManagementPolicyDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_AppManagementPolicies_Id: return $"/policies/appManagementPolicies/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Policies_AppManagementPolicies_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class AppManagementPolicyDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AppManagementPolicyDeleteResponse> AppManagementPolicyDeleteAsync()
        {
            var p = new AppManagementPolicyDeleteParameter();
            return await this.SendAsync<AppManagementPolicyDeleteParameter, AppManagementPolicyDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AppManagementPolicyDeleteResponse> AppManagementPolicyDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new AppManagementPolicyDeleteParameter();
            return await this.SendAsync<AppManagementPolicyDeleteParameter, AppManagementPolicyDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AppManagementPolicyDeleteResponse> AppManagementPolicyDeleteAsync(AppManagementPolicyDeleteParameter parameter)
        {
            return await this.SendAsync<AppManagementPolicyDeleteParameter, AppManagementPolicyDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AppManagementPolicyDeleteResponse> AppManagementPolicyDeleteAsync(AppManagementPolicyDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppManagementPolicyDeleteParameter, AppManagementPolicyDeleteResponse>(parameter, cancellationToken);
        }
    }
}
