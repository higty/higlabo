using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneWipWindowsinformationprotectionapplearningsummaryListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_WindowsInformationProtectionAppLearningSummaries,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_WindowsInformationProtectionAppLearningSummaries: return $"/deviceManagement/windowsInformationProtectionAppLearningSummaries";
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
    public partial class IntuneWipWindowsinformationprotectionapplearningsummaryListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-wip-windowsinformationprotectionapplearningsummary?view=graph-rest-1.0
        /// </summary>
        public partial class WindowsInformationProtectionAppLearningSummary
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

        public WindowsInformationProtectionAppLearningSummary[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-wip-windowsinformationprotectionapplearningsummary-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneWipWindowsinformationprotectionapplearningsummaryListResponse> IntuneWipWindowsinformationprotectionapplearningsummaryListAsync()
        {
            var p = new IntuneWipWindowsinformationprotectionapplearningsummaryListParameter();
            return await this.SendAsync<IntuneWipWindowsinformationprotectionapplearningsummaryListParameter, IntuneWipWindowsinformationprotectionapplearningsummaryListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-wip-windowsinformationprotectionapplearningsummary-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneWipWindowsinformationprotectionapplearningsummaryListResponse> IntuneWipWindowsinformationprotectionapplearningsummaryListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneWipWindowsinformationprotectionapplearningsummaryListParameter();
            return await this.SendAsync<IntuneWipWindowsinformationprotectionapplearningsummaryListParameter, IntuneWipWindowsinformationprotectionapplearningsummaryListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-wip-windowsinformationprotectionapplearningsummary-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneWipWindowsinformationprotectionapplearningsummaryListResponse> IntuneWipWindowsinformationprotectionapplearningsummaryListAsync(IntuneWipWindowsinformationprotectionapplearningsummaryListParameter parameter)
        {
            return await this.SendAsync<IntuneWipWindowsinformationprotectionapplearningsummaryListParameter, IntuneWipWindowsinformationprotectionapplearningsummaryListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-wip-windowsinformationprotectionapplearningsummary-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneWipWindowsinformationprotectionapplearningsummaryListResponse> IntuneWipWindowsinformationprotectionapplearningsummaryListAsync(IntuneWipWindowsinformationprotectionapplearningsummaryListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneWipWindowsinformationprotectionapplearningsummaryListParameter, IntuneWipWindowsinformationprotectionapplearningsummaryListResponse>(parameter, cancellationToken);
        }
    }
}
