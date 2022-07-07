using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamIosmanagedappprotectionDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_IosManagedAppProtections_IosManagedAppProtectionId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_IosManagedAppProtections_IosManagedAppProtectionId: return $"/deviceAppManagement/iosManagedAppProtections/{IosManagedAppProtectionId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string IosManagedAppProtectionId { get; set; }
    }
    public partial class IntuneMamIosmanagedappprotectionDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-iosmanagedappprotection-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamIosmanagedappprotectionDeleteResponse> IntuneMamIosmanagedappprotectionDeleteAsync()
        {
            var p = new IntuneMamIosmanagedappprotectionDeleteParameter();
            return await this.SendAsync<IntuneMamIosmanagedappprotectionDeleteParameter, IntuneMamIosmanagedappprotectionDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-iosmanagedappprotection-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamIosmanagedappprotectionDeleteResponse> IntuneMamIosmanagedappprotectionDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamIosmanagedappprotectionDeleteParameter();
            return await this.SendAsync<IntuneMamIosmanagedappprotectionDeleteParameter, IntuneMamIosmanagedappprotectionDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-iosmanagedappprotection-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamIosmanagedappprotectionDeleteResponse> IntuneMamIosmanagedappprotectionDeleteAsync(IntuneMamIosmanagedappprotectionDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneMamIosmanagedappprotectionDeleteParameter, IntuneMamIosmanagedappprotectionDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-iosmanagedappprotection-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamIosmanagedappprotectionDeleteResponse> IntuneMamIosmanagedappprotectionDeleteAsync(IntuneMamIosmanagedappprotectionDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamIosmanagedappprotectionDeleteParameter, IntuneMamIosmanagedappprotectionDeleteResponse>(parameter, cancellationToken);
        }
    }
}
