using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneWipWindowsinformationprotectionapplearningsummaryGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string WindowsInformationProtectionAppLearningSummaryId { get; set; }
    }
    public partial class IntuneWipWindowsinformationprotectionapplearningsummaryGetResponse : RestApiResponse
    {
        public enum WindowsInformationProtectionAppLearningSummaryApplicationType
        {
            Universal,
            Desktop,
        }

        public string? Id { get; set; }
        public string? ApplicationName { get; set; }
        public ApplicationType? ApplicationType { get; set; }
        public Int32? DeviceCount { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-wip-windowsinformationprotectionapplearningsummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneWipWindowsinformationprotectionapplearningsummaryGetResponse> IntuneWipWindowsinformationprotectionapplearningsummaryGetAsync()
        {
            var p = new IntuneWipWindowsinformationprotectionapplearningsummaryGetParameter();
            return await this.SendAsync<IntuneWipWindowsinformationprotectionapplearningsummaryGetParameter, IntuneWipWindowsinformationprotectionapplearningsummaryGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-wip-windowsinformationprotectionapplearningsummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneWipWindowsinformationprotectionapplearningsummaryGetResponse> IntuneWipWindowsinformationprotectionapplearningsummaryGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneWipWindowsinformationprotectionapplearningsummaryGetParameter();
            return await this.SendAsync<IntuneWipWindowsinformationprotectionapplearningsummaryGetParameter, IntuneWipWindowsinformationprotectionapplearningsummaryGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-wip-windowsinformationprotectionapplearningsummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneWipWindowsinformationprotectionapplearningsummaryGetResponse> IntuneWipWindowsinformationprotectionapplearningsummaryGetAsync(IntuneWipWindowsinformationprotectionapplearningsummaryGetParameter parameter)
        {
            return await this.SendAsync<IntuneWipWindowsinformationprotectionapplearningsummaryGetParameter, IntuneWipWindowsinformationprotectionapplearningsummaryGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-wip-windowsinformationprotectionapplearningsummary-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneWipWindowsinformationprotectionapplearningsummaryGetResponse> IntuneWipWindowsinformationprotectionapplearningsummaryGetAsync(IntuneWipWindowsinformationprotectionapplearningsummaryGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneWipWindowsinformationprotectionapplearningsummaryGetParameter, IntuneWipWindowsinformationprotectionapplearningsummaryGetResponse>(parameter, cancellationToken);
        }
    }
}
