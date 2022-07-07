using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneWipWindowsinformationprotectionnetworklearningsummaryDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_WindowsInformationProtectionNetworkLearningSummaries_WindowsInformationProtectionNetworkLearningSummaryId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_WindowsInformationProtectionNetworkLearningSummaries_WindowsInformationProtectionNetworkLearningSummaryId: return $"/deviceManagement/windowsInformationProtectionNetworkLearningSummaries/{WindowsInformationProtectionNetworkLearningSummaryId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string WindowsInformationProtectionNetworkLearningSummaryId { get; set; }
    }
    public partial class IntuneWipWindowsinformationprotectionnetworklearningsummaryDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-wip-windowsinformationprotectionnetworklearningsummary-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneWipWindowsinformationprotectionnetworklearningsummaryDeleteResponse> IntuneWipWindowsinformationprotectionnetworklearningsummaryDeleteAsync()
        {
            var p = new IntuneWipWindowsinformationprotectionnetworklearningsummaryDeleteParameter();
            return await this.SendAsync<IntuneWipWindowsinformationprotectionnetworklearningsummaryDeleteParameter, IntuneWipWindowsinformationprotectionnetworklearningsummaryDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-wip-windowsinformationprotectionnetworklearningsummary-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneWipWindowsinformationprotectionnetworklearningsummaryDeleteResponse> IntuneWipWindowsinformationprotectionnetworklearningsummaryDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneWipWindowsinformationprotectionnetworklearningsummaryDeleteParameter();
            return await this.SendAsync<IntuneWipWindowsinformationprotectionnetworklearningsummaryDeleteParameter, IntuneWipWindowsinformationprotectionnetworklearningsummaryDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-wip-windowsinformationprotectionnetworklearningsummary-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneWipWindowsinformationprotectionnetworklearningsummaryDeleteResponse> IntuneWipWindowsinformationprotectionnetworklearningsummaryDeleteAsync(IntuneWipWindowsinformationprotectionnetworklearningsummaryDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneWipWindowsinformationprotectionnetworklearningsummaryDeleteParameter, IntuneWipWindowsinformationprotectionnetworklearningsummaryDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-wip-windowsinformationprotectionnetworklearningsummary-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneWipWindowsinformationprotectionnetworklearningsummaryDeleteResponse> IntuneWipWindowsinformationprotectionnetworklearningsummaryDeleteAsync(IntuneWipWindowsinformationprotectionnetworklearningsummaryDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneWipWindowsinformationprotectionnetworklearningsummaryDeleteParameter, IntuneWipWindowsinformationprotectionnetworklearningsummaryDeleteResponse>(parameter, cancellationToken);
        }
    }
}
