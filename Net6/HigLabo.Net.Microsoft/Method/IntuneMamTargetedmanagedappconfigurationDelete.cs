using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamTargetedmanagedappconfigurationDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_TargetedManagedAppConfigurations_TargetedManagedAppConfigurationId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_TargetedManagedAppConfigurations_TargetedManagedAppConfigurationId: return $"/deviceAppManagement/targetedManagedAppConfigurations/{TargetedManagedAppConfigurationId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string TargetedManagedAppConfigurationId { get; set; }
    }
    public partial class IntuneMamTargetedmanagedappconfigurationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-targetedmanagedappconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamTargetedmanagedappconfigurationDeleteResponse> IntuneMamTargetedmanagedappconfigurationDeleteAsync()
        {
            var p = new IntuneMamTargetedmanagedappconfigurationDeleteParameter();
            return await this.SendAsync<IntuneMamTargetedmanagedappconfigurationDeleteParameter, IntuneMamTargetedmanagedappconfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-targetedmanagedappconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamTargetedmanagedappconfigurationDeleteResponse> IntuneMamTargetedmanagedappconfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamTargetedmanagedappconfigurationDeleteParameter();
            return await this.SendAsync<IntuneMamTargetedmanagedappconfigurationDeleteParameter, IntuneMamTargetedmanagedappconfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-targetedmanagedappconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamTargetedmanagedappconfigurationDeleteResponse> IntuneMamTargetedmanagedappconfigurationDeleteAsync(IntuneMamTargetedmanagedappconfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneMamTargetedmanagedappconfigurationDeleteParameter, IntuneMamTargetedmanagedappconfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-targetedmanagedappconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamTargetedmanagedappconfigurationDeleteResponse> IntuneMamTargetedmanagedappconfigurationDeleteAsync(IntuneMamTargetedmanagedappconfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamTargetedmanagedappconfigurationDeleteParameter, IntuneMamTargetedmanagedappconfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
