using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-post?view=graph-rest-1.0
    /// </summary>
    public partial class AppManagementPolicyPostParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public bool? IsEnabled { get; set; }
        public AppManagementConfiguration? Restrictions { get; set; }
        public string? Id { get; set; }
        public DirectoryObject? AppliesTo { get; set; }
    }
    public partial class AppManagementPolicyPostResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public bool? IsEnabled { get; set; }
        public AppManagementConfiguration? Restrictions { get; set; }
        public DirectoryObject? AppliesTo { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-post?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-post?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AppManagementPolicyPostResponse> AppManagementPolicyPostAsync()
        {
            var p = new AppManagementPolicyPostParameter();
            return await this.SendAsync<AppManagementPolicyPostParameter, AppManagementPolicyPostResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-post?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AppManagementPolicyPostResponse> AppManagementPolicyPostAsync(CancellationToken cancellationToken)
        {
            var p = new AppManagementPolicyPostParameter();
            return await this.SendAsync<AppManagementPolicyPostParameter, AppManagementPolicyPostResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-post?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AppManagementPolicyPostResponse> AppManagementPolicyPostAsync(AppManagementPolicyPostParameter parameter)
        {
            return await this.SendAsync<AppManagementPolicyPostParameter, AppManagementPolicyPostResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-post?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AppManagementPolicyPostResponse> AppManagementPolicyPostAsync(AppManagementPolicyPostParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppManagementPolicyPostParameter, AppManagementPolicyPostResponse>(parameter, cancellationToken);
        }
    }
}
