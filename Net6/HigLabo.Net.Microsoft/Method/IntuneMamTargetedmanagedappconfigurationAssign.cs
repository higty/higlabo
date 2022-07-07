using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamTargetedmanagedappconfigurationAssignParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_TargetedManagedAppConfigurations_TargetedManagedAppConfigurationId_Assign,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_TargetedManagedAppConfigurations_TargetedManagedAppConfigurationId_Assign: return $"/deviceAppManagement/targetedManagedAppConfigurations/{TargetedManagedAppConfigurationId}/assign";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public TargetedManagedAppPolicyAssignment[]? Assignments { get; set; }
        public string TargetedManagedAppConfigurationId { get; set; }
    }
    public partial class IntuneMamTargetedmanagedappconfigurationAssignResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-targetedmanagedappconfiguration-assign?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamTargetedmanagedappconfigurationAssignResponse> IntuneMamTargetedmanagedappconfigurationAssignAsync()
        {
            var p = new IntuneMamTargetedmanagedappconfigurationAssignParameter();
            return await this.SendAsync<IntuneMamTargetedmanagedappconfigurationAssignParameter, IntuneMamTargetedmanagedappconfigurationAssignResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-targetedmanagedappconfiguration-assign?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamTargetedmanagedappconfigurationAssignResponse> IntuneMamTargetedmanagedappconfigurationAssignAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamTargetedmanagedappconfigurationAssignParameter();
            return await this.SendAsync<IntuneMamTargetedmanagedappconfigurationAssignParameter, IntuneMamTargetedmanagedappconfigurationAssignResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-targetedmanagedappconfiguration-assign?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamTargetedmanagedappconfigurationAssignResponse> IntuneMamTargetedmanagedappconfigurationAssignAsync(IntuneMamTargetedmanagedappconfigurationAssignParameter parameter)
        {
            return await this.SendAsync<IntuneMamTargetedmanagedappconfigurationAssignParameter, IntuneMamTargetedmanagedappconfigurationAssignResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-targetedmanagedappconfiguration-assign?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamTargetedmanagedappconfigurationAssignResponse> IntuneMamTargetedmanagedappconfigurationAssignAsync(IntuneMamTargetedmanagedappconfigurationAssignParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamTargetedmanagedappconfigurationAssignParameter, IntuneMamTargetedmanagedappconfigurationAssignResponse>(parameter, cancellationToken);
        }
    }
}
