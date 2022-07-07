using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneWipWindowsinformationprotectionnetworklearningsummaryGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string WindowsInformationProtectionNetworkLearningSummaryId { get; set; }
    }
    public partial class IntuneWipWindowsinformationprotectionnetworklearningsummaryGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? Url { get; set; }
        public Int32? DeviceCount { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-wip-windowsinformationprotectionnetworklearningsummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneWipWindowsinformationprotectionnetworklearningsummaryGetResponse> IntuneWipWindowsinformationprotectionnetworklearningsummaryGetAsync()
        {
            var p = new IntuneWipWindowsinformationprotectionnetworklearningsummaryGetParameter();
            return await this.SendAsync<IntuneWipWindowsinformationprotectionnetworklearningsummaryGetParameter, IntuneWipWindowsinformationprotectionnetworklearningsummaryGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-wip-windowsinformationprotectionnetworklearningsummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneWipWindowsinformationprotectionnetworklearningsummaryGetResponse> IntuneWipWindowsinformationprotectionnetworklearningsummaryGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneWipWindowsinformationprotectionnetworklearningsummaryGetParameter();
            return await this.SendAsync<IntuneWipWindowsinformationprotectionnetworklearningsummaryGetParameter, IntuneWipWindowsinformationprotectionnetworklearningsummaryGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-wip-windowsinformationprotectionnetworklearningsummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneWipWindowsinformationprotectionnetworklearningsummaryGetResponse> IntuneWipWindowsinformationprotectionnetworklearningsummaryGetAsync(IntuneWipWindowsinformationprotectionnetworklearningsummaryGetParameter parameter)
        {
            return await this.SendAsync<IntuneWipWindowsinformationprotectionnetworklearningsummaryGetParameter, IntuneWipWindowsinformationprotectionnetworklearningsummaryGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-wip-windowsinformationprotectionnetworklearningsummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneWipWindowsinformationprotectionnetworklearningsummaryGetResponse> IntuneWipWindowsinformationprotectionnetworklearningsummaryGetAsync(IntuneWipWindowsinformationprotectionnetworklearningsummaryGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneWipWindowsinformationprotectionnetworklearningsummaryGetParameter, IntuneWipWindowsinformationprotectionnetworklearningsummaryGetResponse>(parameter, cancellationToken);
        }
    }
}
