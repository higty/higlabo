using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamTargetedmanagedappconfigurationTargetappsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_TargetedManagedAppConfigurations_TargetedManagedAppConfigurationId_TargetApps,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_TargetedManagedAppConfigurations_TargetedManagedAppConfigurationId_TargetApps: return $"/deviceAppManagement/targetedManagedAppConfigurations/{TargetedManagedAppConfigurationId}/targetApps";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public ManagedMobileApp[]? Apps { get; set; }
        public TargetedManagedAppGroupType? AppGroupType { get; set; }
        public string TargetedManagedAppConfigurationId { get; set; }
    }
    public partial class IntuneMamTargetedmanagedappconfigurationTargetappsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-targetedmanagedappconfiguration-targetapps?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamTargetedmanagedappconfigurationTargetappsResponse> IntuneMamTargetedmanagedappconfigurationTargetappsAsync()
        {
            var p = new IntuneMamTargetedmanagedappconfigurationTargetappsParameter();
            return await this.SendAsync<IntuneMamTargetedmanagedappconfigurationTargetappsParameter, IntuneMamTargetedmanagedappconfigurationTargetappsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-targetedmanagedappconfiguration-targetapps?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamTargetedmanagedappconfigurationTargetappsResponse> IntuneMamTargetedmanagedappconfigurationTargetappsAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamTargetedmanagedappconfigurationTargetappsParameter();
            return await this.SendAsync<IntuneMamTargetedmanagedappconfigurationTargetappsParameter, IntuneMamTargetedmanagedappconfigurationTargetappsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-targetedmanagedappconfiguration-targetapps?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamTargetedmanagedappconfigurationTargetappsResponse> IntuneMamTargetedmanagedappconfigurationTargetappsAsync(IntuneMamTargetedmanagedappconfigurationTargetappsParameter parameter)
        {
            return await this.SendAsync<IntuneMamTargetedmanagedappconfigurationTargetappsParameter, IntuneMamTargetedmanagedappconfigurationTargetappsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-targetedmanagedappconfiguration-targetapps?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamTargetedmanagedappconfigurationTargetappsResponse> IntuneMamTargetedmanagedappconfigurationTargetappsAsync(IntuneMamTargetedmanagedappconfigurationTargetappsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamTargetedmanagedappconfigurationTargetappsParameter, IntuneMamTargetedmanagedappconfigurationTargetappsResponse>(parameter, cancellationToken);
        }
    }
}
