using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-delete-appliesto?view=graph-rest-1.0
    /// </summary>
    public partial class AppManagementPolicyDeleteAppliestoParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ApplicationObjectId { get; set; }
            public string? AppManagementPolicyId { get; set; }
            public string? ServicePrincipalObjectId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Applications_ApplicationObjectId_AppManagementPolicies_AppManagementPolicyId_ref: return $"/applications/{ApplicationObjectId}/appManagementPolicies/{AppManagementPolicyId}/$ref";
                    case ApiPath.ServicePrincipals_ServicePrincipalObjectId_AppManagementPolicies_AppManagementPolicyId_ref: return $"/servicePrincipals/{ServicePrincipalObjectId}/appManagementPolicies/{AppManagementPolicyId}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Applications_ApplicationObjectId_AppManagementPolicies_AppManagementPolicyId_ref,
            ServicePrincipals_ServicePrincipalObjectId_AppManagementPolicies_AppManagementPolicyId_ref,
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
    public partial class AppManagementPolicyDeleteAppliestoResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-delete-appliesto?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-delete-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<AppManagementPolicyDeleteAppliestoResponse> AppManagementPolicyDeleteAppliestoAsync()
        {
            var p = new AppManagementPolicyDeleteAppliestoParameter();
            return await this.SendAsync<AppManagementPolicyDeleteAppliestoParameter, AppManagementPolicyDeleteAppliestoResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-delete-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<AppManagementPolicyDeleteAppliestoResponse> AppManagementPolicyDeleteAppliestoAsync(CancellationToken cancellationToken)
        {
            var p = new AppManagementPolicyDeleteAppliestoParameter();
            return await this.SendAsync<AppManagementPolicyDeleteAppliestoParameter, AppManagementPolicyDeleteAppliestoResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-delete-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<AppManagementPolicyDeleteAppliestoResponse> AppManagementPolicyDeleteAppliestoAsync(AppManagementPolicyDeleteAppliestoParameter parameter)
        {
            return await this.SendAsync<AppManagementPolicyDeleteAppliestoParameter, AppManagementPolicyDeleteAppliestoResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-delete-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<AppManagementPolicyDeleteAppliestoResponse> AppManagementPolicyDeleteAppliestoAsync(AppManagementPolicyDeleteAppliestoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppManagementPolicyDeleteAppliestoParameter, AppManagementPolicyDeleteAppliestoResponse>(parameter, cancellationToken);
        }
    }
}
