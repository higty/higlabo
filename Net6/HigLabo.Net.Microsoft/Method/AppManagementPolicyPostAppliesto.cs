using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-post-appliesto?view=graph-rest-1.0
    /// </summary>
    public partial class AppManagementPolicyPostAppliestoParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Applications_Id_AppManagementPolicies_ref: return $"/applications/{Id}/appManagementPolicies/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Applications_Id_AppManagementPolicies_ref,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class AppManagementPolicyPostAppliestoResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-post-appliesto?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-post-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<AppManagementPolicyPostAppliestoResponse> AppManagementPolicyPostAppliestoAsync()
        {
            var p = new AppManagementPolicyPostAppliestoParameter();
            return await this.SendAsync<AppManagementPolicyPostAppliestoParameter, AppManagementPolicyPostAppliestoResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-post-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<AppManagementPolicyPostAppliestoResponse> AppManagementPolicyPostAppliestoAsync(CancellationToken cancellationToken)
        {
            var p = new AppManagementPolicyPostAppliestoParameter();
            return await this.SendAsync<AppManagementPolicyPostAppliestoParameter, AppManagementPolicyPostAppliestoResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-post-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<AppManagementPolicyPostAppliestoResponse> AppManagementPolicyPostAppliestoAsync(AppManagementPolicyPostAppliestoParameter parameter)
        {
            return await this.SendAsync<AppManagementPolicyPostAppliestoParameter, AppManagementPolicyPostAppliestoResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-post-appliesto?view=graph-rest-1.0
        /// </summary>
        public async Task<AppManagementPolicyPostAppliestoResponse> AppManagementPolicyPostAppliestoAsync(AppManagementPolicyPostAppliestoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppManagementPolicyPostAppliestoParameter, AppManagementPolicyPostAppliestoResponse>(parameter, cancellationToken);
        }
    }
}
