using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneWipWindowsinformationprotectionapplearningsummaryDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_WindowsInformationProtectionAppLearningSummaries_WindowsInformationProtectionAppLearningSummaryId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_WindowsInformationProtectionAppLearningSummaries_WindowsInformationProtectionAppLearningSummaryId: return $"/deviceManagement/windowsInformationProtectionAppLearningSummaries/{WindowsInformationProtectionAppLearningSummaryId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string WindowsInformationProtectionAppLearningSummaryId { get; set; }
    }
    public partial class IntuneWipWindowsinformationprotectionapplearningsummaryDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-wip-windowsinformationprotectionapplearningsummary-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneWipWindowsinformationprotectionapplearningsummaryDeleteResponse> IntuneWipWindowsinformationprotectionapplearningsummaryDeleteAsync()
        {
            var p = new IntuneWipWindowsinformationprotectionapplearningsummaryDeleteParameter();
            return await this.SendAsync<IntuneWipWindowsinformationprotectionapplearningsummaryDeleteParameter, IntuneWipWindowsinformationprotectionapplearningsummaryDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-wip-windowsinformationprotectionapplearningsummary-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneWipWindowsinformationprotectionapplearningsummaryDeleteResponse> IntuneWipWindowsinformationprotectionapplearningsummaryDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneWipWindowsinformationprotectionapplearningsummaryDeleteParameter();
            return await this.SendAsync<IntuneWipWindowsinformationprotectionapplearningsummaryDeleteParameter, IntuneWipWindowsinformationprotectionapplearningsummaryDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-wip-windowsinformationprotectionapplearningsummary-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneWipWindowsinformationprotectionapplearningsummaryDeleteResponse> IntuneWipWindowsinformationprotectionapplearningsummaryDeleteAsync(IntuneWipWindowsinformationprotectionapplearningsummaryDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneWipWindowsinformationprotectionapplearningsummaryDeleteParameter, IntuneWipWindowsinformationprotectionapplearningsummaryDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-wip-windowsinformationprotectionapplearningsummary-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneWipWindowsinformationprotectionapplearningsummaryDeleteResponse> IntuneWipWindowsinformationprotectionapplearningsummaryDeleteAsync(IntuneWipWindowsinformationprotectionapplearningsummaryDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneWipWindowsinformationprotectionapplearningsummaryDeleteParameter, IntuneWipWindowsinformationprotectionapplearningsummaryDeleteResponse>(parameter, cancellationToken);
        }
    }
}
