using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class InformationProtectionPostThreatassessmentrequestsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.InformationProtection_ThreatAssessmentRequests: return $"/informationProtection/threatAssessmentRequests";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ThreatAssessmentRequestThreatCategory
        {
            Spam,
            Phishing,
            Malware,
        }
        public enum ThreatAssessmentRequestThreatAssessmentContentType
        {
            Mail,
            Url,
            File,
        }
        public enum ThreatAssessmentRequestThreatExpectedAssessment
        {
            Block,
            Unblock,
        }
        public enum ThreatAssessmentRequestThreatAssessmentRequestSource
        {
            Administrator,
        }
        public enum ThreatAssessmentRequestThreatAssessmentStatus
        {
            Pending,
            Completed,
        }
        public enum ApiPath
        {
            InformationProtection_ThreatAssessmentRequests,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public ThreatAssessmentRequestThreatCategory Category { get; set; }
        public ThreatAssessmentRequestThreatAssessmentContentType ContentType { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public ThreatAssessmentRequestThreatExpectedAssessment ExpectedAssessment { get; set; }
        public string? Id { get; set; }
        public ThreatAssessmentRequestThreatAssessmentRequestSource RequestSource { get; set; }
        public ThreatAssessmentRequestThreatAssessmentStatus Status { get; set; }
        public ThreatAssessmentResult[]? Results { get; set; }
    }
    public partial class InformationProtectionPostThreatassessmentrequestsResponse : RestApiResponse
    {
        public enum ThreatAssessmentRequestThreatCategory
        {
            Spam,
            Phishing,
            Malware,
        }
        public enum ThreatAssessmentRequestThreatAssessmentContentType
        {
            Mail,
            Url,
            File,
        }
        public enum ThreatAssessmentRequestThreatExpectedAssessment
        {
            Block,
            Unblock,
        }
        public enum ThreatAssessmentRequestThreatAssessmentRequestSource
        {
            Administrator,
        }
        public enum ThreatAssessmentRequestThreatAssessmentStatus
        {
            Pending,
            Completed,
        }

        public ThreatAssessmentRequestThreatCategory Category { get; set; }
        public ThreatAssessmentRequestThreatAssessmentContentType ContentType { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public ThreatAssessmentRequestThreatExpectedAssessment ExpectedAssessment { get; set; }
        public string? Id { get; set; }
        public ThreatAssessmentRequestThreatAssessmentRequestSource RequestSource { get; set; }
        public ThreatAssessmentRequestThreatAssessmentStatus Status { get; set; }
        public ThreatAssessmentResult[]? Results { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/informationprotection-post-threatassessmentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<InformationProtectionPostThreatassessmentrequestsResponse> InformationProtectionPostThreatassessmentrequestsAsync()
        {
            var p = new InformationProtectionPostThreatassessmentrequestsParameter();
            return await this.SendAsync<InformationProtectionPostThreatassessmentrequestsParameter, InformationProtectionPostThreatassessmentrequestsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/informationprotection-post-threatassessmentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<InformationProtectionPostThreatassessmentrequestsResponse> InformationProtectionPostThreatassessmentrequestsAsync(CancellationToken cancellationToken)
        {
            var p = new InformationProtectionPostThreatassessmentrequestsParameter();
            return await this.SendAsync<InformationProtectionPostThreatassessmentrequestsParameter, InformationProtectionPostThreatassessmentrequestsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/informationprotection-post-threatassessmentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<InformationProtectionPostThreatassessmentrequestsResponse> InformationProtectionPostThreatassessmentrequestsAsync(InformationProtectionPostThreatassessmentrequestsParameter parameter)
        {
            return await this.SendAsync<InformationProtectionPostThreatassessmentrequestsParameter, InformationProtectionPostThreatassessmentrequestsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/informationprotection-post-threatassessmentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<InformationProtectionPostThreatassessmentrequestsResponse> InformationProtectionPostThreatassessmentrequestsAsync(InformationProtectionPostThreatassessmentrequestsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<InformationProtectionPostThreatassessmentrequestsParameter, InformationProtectionPostThreatassessmentrequestsResponse>(parameter, cancellationToken);
        }
    }
}
