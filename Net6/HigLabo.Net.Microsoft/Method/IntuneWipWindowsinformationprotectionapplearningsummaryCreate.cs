using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneWipWindowsinformationprotectionapplearningsummaryCreateParameter : IRestApiParameter
    {
        public enum IntuneWipWindowsinformationprotectionapplearningsummaryCreateParameterApplicationType
        {
            Universal,
            Desktop,
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? ApplicationName { get; set; }
        public IntuneWipWindowsinformationprotectionapplearningsummaryCreateParameterApplicationType ApplicationType { get; set; }
        public Int32? DeviceCount { get; set; }
    }
    public partial class IntuneWipWindowsinformationprotectionapplearningsummaryCreateResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-wip-windowsinformationprotectionapplearningsummary-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneWipWindowsinformationprotectionapplearningsummaryCreateResponse> IntuneWipWindowsinformationprotectionapplearningsummaryCreateAsync()
        {
            var p = new IntuneWipWindowsinformationprotectionapplearningsummaryCreateParameter();
            return await this.SendAsync<IntuneWipWindowsinformationprotectionapplearningsummaryCreateParameter, IntuneWipWindowsinformationprotectionapplearningsummaryCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-wip-windowsinformationprotectionapplearningsummary-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneWipWindowsinformationprotectionapplearningsummaryCreateResponse> IntuneWipWindowsinformationprotectionapplearningsummaryCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneWipWindowsinformationprotectionapplearningsummaryCreateParameter();
            return await this.SendAsync<IntuneWipWindowsinformationprotectionapplearningsummaryCreateParameter, IntuneWipWindowsinformationprotectionapplearningsummaryCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-wip-windowsinformationprotectionapplearningsummary-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneWipWindowsinformationprotectionapplearningsummaryCreateResponse> IntuneWipWindowsinformationprotectionapplearningsummaryCreateAsync(IntuneWipWindowsinformationprotectionapplearningsummaryCreateParameter parameter)
        {
            return await this.SendAsync<IntuneWipWindowsinformationprotectionapplearningsummaryCreateParameter, IntuneWipWindowsinformationprotectionapplearningsummaryCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-wip-windowsinformationprotectionapplearningsummary-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneWipWindowsinformationprotectionapplearningsummaryCreateResponse> IntuneWipWindowsinformationprotectionapplearningsummaryCreateAsync(IntuneWipWindowsinformationprotectionapplearningsummaryCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneWipWindowsinformationprotectionapplearningsummaryCreateParameter, IntuneWipWindowsinformationprotectionapplearningsummaryCreateResponse>(parameter, cancellationToken);
        }
    }
}
