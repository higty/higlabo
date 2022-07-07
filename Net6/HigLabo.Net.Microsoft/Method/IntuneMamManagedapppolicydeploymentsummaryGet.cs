using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamManagedapppolicydeploymentsummaryGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement_IosManagedAppProtections_IosManagedAppProtectionId_DeploymentSummary,
            DeviceAppManagement_AndroidManagedAppProtections_AndroidManagedAppProtectionId_DeploymentSummary,
            DeviceAppManagement_DefaultManagedAppProtections_DefaultManagedAppProtectionId_DeploymentSummary,
            DeviceAppManagement_TargetedManagedAppConfigurations_TargetedManagedAppConfigurationId_DeploymentSummary,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_IosManagedAppProtections_IosManagedAppProtectionId_DeploymentSummary: return $"/deviceAppManagement/iosManagedAppProtections/{IosManagedAppProtectionId}/deploymentSummary";
                    case ApiPath.DeviceAppManagement_AndroidManagedAppProtections_AndroidManagedAppProtectionId_DeploymentSummary: return $"/deviceAppManagement/androidManagedAppProtections/{AndroidManagedAppProtectionId}/deploymentSummary";
                    case ApiPath.DeviceAppManagement_DefaultManagedAppProtections_DefaultManagedAppProtectionId_DeploymentSummary: return $"/deviceAppManagement/defaultManagedAppProtections/{DefaultManagedAppProtectionId}/deploymentSummary";
                    case ApiPath.DeviceAppManagement_TargetedManagedAppConfigurations_TargetedManagedAppConfigurationId_DeploymentSummary: return $"/deviceAppManagement/targetedManagedAppConfigurations/{TargetedManagedAppConfigurationId}/deploymentSummary";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string IosManagedAppProtectionId { get; set; }
        public string AndroidManagedAppProtectionId { get; set; }
        public string DefaultManagedAppProtectionId { get; set; }
        public string TargetedManagedAppConfigurationId { get; set; }
    }
    public partial class IntuneMamManagedapppolicydeploymentsummaryGetResponse : RestApiResponse
    {
        public string? DisplayName { get; set; }
        public Int32? ConfigurationDeployedUserCount { get; set; }
        public DateTimeOffset? LastRefreshTime { get; set; }
        public ManagedAppPolicyDeploymentSummaryPerApp[]? ConfigurationDeploymentSummaryPerApp { get; set; }
        public string? Id { get; set; }
        public string? Version { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedapppolicydeploymentsummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedapppolicydeploymentsummaryGetResponse> IntuneMamManagedapppolicydeploymentsummaryGetAsync()
        {
            var p = new IntuneMamManagedapppolicydeploymentsummaryGetParameter();
            return await this.SendAsync<IntuneMamManagedapppolicydeploymentsummaryGetParameter, IntuneMamManagedapppolicydeploymentsummaryGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedapppolicydeploymentsummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedapppolicydeploymentsummaryGetResponse> IntuneMamManagedapppolicydeploymentsummaryGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamManagedapppolicydeploymentsummaryGetParameter();
            return await this.SendAsync<IntuneMamManagedapppolicydeploymentsummaryGetParameter, IntuneMamManagedapppolicydeploymentsummaryGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedapppolicydeploymentsummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedapppolicydeploymentsummaryGetResponse> IntuneMamManagedapppolicydeploymentsummaryGetAsync(IntuneMamManagedapppolicydeploymentsummaryGetParameter parameter)
        {
            return await this.SendAsync<IntuneMamManagedapppolicydeploymentsummaryGetParameter, IntuneMamManagedapppolicydeploymentsummaryGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedapppolicydeploymentsummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedapppolicydeploymentsummaryGetResponse> IntuneMamManagedapppolicydeploymentsummaryGetAsync(IntuneMamManagedapppolicydeploymentsummaryGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamManagedapppolicydeploymentsummaryGetParameter, IntuneMamManagedapppolicydeploymentsummaryGetResponse>(parameter, cancellationToken);
        }
    }
}
