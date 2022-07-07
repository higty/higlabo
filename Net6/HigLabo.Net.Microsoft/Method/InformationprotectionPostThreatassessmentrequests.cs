using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class InformationprotectionPostThreatassessmentrequestsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            InformationProtection_ThreatAssessmentRequests,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.InformationProtection_ThreatAssessmentRequests: return $"/informationProtection/threatAssessmentRequests";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class InformationprotectionPostThreatassessmentrequestsResponse : RestApiResponse
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

        public Enum? Category { get; set; }
        public Enum? ContentType { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public Enum? ExpectedAssessment { get; set; }
        public string? Id { get; set; }
        public Enum? RequestSource { get; set; }
        public Enum? Status { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/informationprotection-post-threatassessmentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<InformationprotectionPostThreatassessmentrequestsResponse> InformationprotectionPostThreatassessmentrequestsAsync()
        {
            var p = new InformationprotectionPostThreatassessmentrequestsParameter();
            return await this.SendAsync<InformationprotectionPostThreatassessmentrequestsParameter, InformationprotectionPostThreatassessmentrequestsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/informationprotection-post-threatassessmentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<InformationprotectionPostThreatassessmentrequestsResponse> InformationprotectionPostThreatassessmentrequestsAsync(CancellationToken cancellationToken)
        {
            var p = new InformationprotectionPostThreatassessmentrequestsParameter();
            return await this.SendAsync<InformationprotectionPostThreatassessmentrequestsParameter, InformationprotectionPostThreatassessmentrequestsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/informationprotection-post-threatassessmentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<InformationprotectionPostThreatassessmentrequestsResponse> InformationprotectionPostThreatassessmentrequestsAsync(InformationprotectionPostThreatassessmentrequestsParameter parameter)
        {
            return await this.SendAsync<InformationprotectionPostThreatassessmentrequestsParameter, InformationprotectionPostThreatassessmentrequestsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/informationprotection-post-threatassessmentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<InformationprotectionPostThreatassessmentrequestsResponse> InformationprotectionPostThreatassessmentrequestsAsync(InformationprotectionPostThreatassessmentrequestsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<InformationprotectionPostThreatassessmentrequestsParameter, InformationprotectionPostThreatassessmentrequestsResponse>(parameter, cancellationToken);
        }
    }
}
