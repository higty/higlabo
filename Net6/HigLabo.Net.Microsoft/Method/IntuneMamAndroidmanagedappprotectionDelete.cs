using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamAndroidmanagedappprotectionDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_AndroidManagedAppProtections_AndroidManagedAppProtectionId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_AndroidManagedAppProtections_AndroidManagedAppProtectionId: return $"/deviceAppManagement/androidManagedAppProtections/{AndroidManagedAppProtectionId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string AndroidManagedAppProtectionId { get; set; }
    }
    public partial class IntuneMamAndroidmanagedappprotectionDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-androidmanagedappprotection-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamAndroidmanagedappprotectionDeleteResponse> IntuneMamAndroidmanagedappprotectionDeleteAsync()
        {
            var p = new IntuneMamAndroidmanagedappprotectionDeleteParameter();
            return await this.SendAsync<IntuneMamAndroidmanagedappprotectionDeleteParameter, IntuneMamAndroidmanagedappprotectionDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-androidmanagedappprotection-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamAndroidmanagedappprotectionDeleteResponse> IntuneMamAndroidmanagedappprotectionDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamAndroidmanagedappprotectionDeleteParameter();
            return await this.SendAsync<IntuneMamAndroidmanagedappprotectionDeleteParameter, IntuneMamAndroidmanagedappprotectionDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-androidmanagedappprotection-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamAndroidmanagedappprotectionDeleteResponse> IntuneMamAndroidmanagedappprotectionDeleteAsync(IntuneMamAndroidmanagedappprotectionDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneMamAndroidmanagedappprotectionDeleteParameter, IntuneMamAndroidmanagedappprotectionDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-androidmanagedappprotection-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamAndroidmanagedappprotectionDeleteResponse> IntuneMamAndroidmanagedappprotectionDeleteAsync(IntuneMamAndroidmanagedappprotectionDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamAndroidmanagedappprotectionDeleteParameter, IntuneMamAndroidmanagedappprotectionDeleteResponse>(parameter, cancellationToken);
        }
    }
}
