using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneWipWindowsinformationprotectionnetworklearningsummaryListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class IntuneWipWindowsinformationprotectionnetworklearningsummaryListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-wip-windowsinformationprotectionnetworklearningsummary?view=graph-rest-1.0
        /// </summary>
        public partial class WindowsInformationProtectionNetworkLearningSummary
        {
            public string? Id { get; set; }
            public string? Url { get; set; }
            public Int32? DeviceCount { get; set; }
        }

        public WindowsInformationProtectionNetworkLearningSummary[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-wip-windowsinformationprotectionnetworklearningsummary-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneWipWindowsinformationprotectionnetworklearningsummaryListResponse> IntuneWipWindowsinformationprotectionnetworklearningsummaryListAsync()
        {
            var p = new IntuneWipWindowsinformationprotectionnetworklearningsummaryListParameter();
            return await this.SendAsync<IntuneWipWindowsinformationprotectionnetworklearningsummaryListParameter, IntuneWipWindowsinformationprotectionnetworklearningsummaryListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-wip-windowsinformationprotectionnetworklearningsummary-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneWipWindowsinformationprotectionnetworklearningsummaryListResponse> IntuneWipWindowsinformationprotectionnetworklearningsummaryListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneWipWindowsinformationprotectionnetworklearningsummaryListParameter();
            return await this.SendAsync<IntuneWipWindowsinformationprotectionnetworklearningsummaryListParameter, IntuneWipWindowsinformationprotectionnetworklearningsummaryListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-wip-windowsinformationprotectionnetworklearningsummary-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneWipWindowsinformationprotectionnetworklearningsummaryListResponse> IntuneWipWindowsinformationprotectionnetworklearningsummaryListAsync(IntuneWipWindowsinformationprotectionnetworklearningsummaryListParameter parameter)
        {
            return await this.SendAsync<IntuneWipWindowsinformationprotectionnetworklearningsummaryListParameter, IntuneWipWindowsinformationprotectionnetworklearningsummaryListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-wip-windowsinformationprotectionnetworklearningsummary-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneWipWindowsinformationprotectionnetworklearningsummaryListResponse> IntuneWipWindowsinformationprotectionnetworklearningsummaryListAsync(IntuneWipWindowsinformationprotectionnetworklearningsummaryListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneWipWindowsinformationprotectionnetworklearningsummaryListParameter, IntuneWipWindowsinformationprotectionnetworklearningsummaryListResponse>(parameter, cancellationToken);
        }
    }
}
