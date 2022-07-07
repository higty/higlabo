using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamDefaultmanagedappprotectionDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_DefaultManagedAppProtections_DefaultManagedAppProtectionId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_DefaultManagedAppProtections_DefaultManagedAppProtectionId: return $"/deviceAppManagement/defaultManagedAppProtections/{DefaultManagedAppProtectionId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string DefaultManagedAppProtectionId { get; set; }
    }
    public partial class IntuneMamDefaultmanagedappprotectionDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-defaultmanagedappprotection-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamDefaultmanagedappprotectionDeleteResponse> IntuneMamDefaultmanagedappprotectionDeleteAsync()
        {
            var p = new IntuneMamDefaultmanagedappprotectionDeleteParameter();
            return await this.SendAsync<IntuneMamDefaultmanagedappprotectionDeleteParameter, IntuneMamDefaultmanagedappprotectionDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-defaultmanagedappprotection-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamDefaultmanagedappprotectionDeleteResponse> IntuneMamDefaultmanagedappprotectionDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamDefaultmanagedappprotectionDeleteParameter();
            return await this.SendAsync<IntuneMamDefaultmanagedappprotectionDeleteParameter, IntuneMamDefaultmanagedappprotectionDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-defaultmanagedappprotection-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamDefaultmanagedappprotectionDeleteResponse> IntuneMamDefaultmanagedappprotectionDeleteAsync(IntuneMamDefaultmanagedappprotectionDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneMamDefaultmanagedappprotectionDeleteParameter, IntuneMamDefaultmanagedappprotectionDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-defaultmanagedappprotection-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamDefaultmanagedappprotectionDeleteResponse> IntuneMamDefaultmanagedappprotectionDeleteAsync(IntuneMamDefaultmanagedappprotectionDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamDefaultmanagedappprotectionDeleteParameter, IntuneMamDefaultmanagedappprotectionDeleteResponse>(parameter, cancellationToken);
        }
    }
}
