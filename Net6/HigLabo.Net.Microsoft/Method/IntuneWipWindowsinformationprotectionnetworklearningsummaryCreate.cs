using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneWipWindowsinformationprotectionnetworklearningsummaryCreateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_WindowsInformationProtectionNetworkLearningSummaries,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_WindowsInformationProtectionNetworkLearningSummaries: return $"/deviceManagement/windowsInformationProtectionNetworkLearningSummaries";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? Url { get; set; }
        public Int32? DeviceCount { get; set; }
    }
    public partial class IntuneWipWindowsinformationprotectionnetworklearningsummaryCreateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? Url { get; set; }
        public Int32? DeviceCount { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-wip-windowsinformationprotectionnetworklearningsummary-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneWipWindowsinformationprotectionnetworklearningsummaryCreateResponse> IntuneWipWindowsinformationprotectionnetworklearningsummaryCreateAsync()
        {
            var p = new IntuneWipWindowsinformationprotectionnetworklearningsummaryCreateParameter();
            return await this.SendAsync<IntuneWipWindowsinformationprotectionnetworklearningsummaryCreateParameter, IntuneWipWindowsinformationprotectionnetworklearningsummaryCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-wip-windowsinformationprotectionnetworklearningsummary-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneWipWindowsinformationprotectionnetworklearningsummaryCreateResponse> IntuneWipWindowsinformationprotectionnetworklearningsummaryCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneWipWindowsinformationprotectionnetworklearningsummaryCreateParameter();
            return await this.SendAsync<IntuneWipWindowsinformationprotectionnetworklearningsummaryCreateParameter, IntuneWipWindowsinformationprotectionnetworklearningsummaryCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-wip-windowsinformationprotectionnetworklearningsummary-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneWipWindowsinformationprotectionnetworklearningsummaryCreateResponse> IntuneWipWindowsinformationprotectionnetworklearningsummaryCreateAsync(IntuneWipWindowsinformationprotectionnetworklearningsummaryCreateParameter parameter)
        {
            return await this.SendAsync<IntuneWipWindowsinformationprotectionnetworklearningsummaryCreateParameter, IntuneWipWindowsinformationprotectionnetworklearningsummaryCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-wip-windowsinformationprotectionnetworklearningsummary-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneWipWindowsinformationprotectionnetworklearningsummaryCreateResponse> IntuneWipWindowsinformationprotectionnetworklearningsummaryCreateAsync(IntuneWipWindowsinformationprotectionnetworklearningsummaryCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneWipWindowsinformationprotectionnetworklearningsummaryCreateParameter, IntuneWipWindowsinformationprotectionnetworklearningsummaryCreateResponse>(parameter, cancellationToken);
        }
    }
}
