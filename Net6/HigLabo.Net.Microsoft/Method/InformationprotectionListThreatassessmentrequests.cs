using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class InformationprotectionListThreatassessmentrequestsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
    public partial class InformationprotectionListThreatassessmentrequestsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/threatassessmentrequest?view=graph-rest-1.0
        /// </summary>
        public partial class ThreatAssessmentRequest
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

        public ThreatAssessmentRequest[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/informationprotection-list-threatassessmentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<InformationprotectionListThreatassessmentrequestsResponse> InformationprotectionListThreatassessmentrequestsAsync()
        {
            var p = new InformationprotectionListThreatassessmentrequestsParameter();
            return await this.SendAsync<InformationprotectionListThreatassessmentrequestsParameter, InformationprotectionListThreatassessmentrequestsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/informationprotection-list-threatassessmentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<InformationprotectionListThreatassessmentrequestsResponse> InformationprotectionListThreatassessmentrequestsAsync(CancellationToken cancellationToken)
        {
            var p = new InformationprotectionListThreatassessmentrequestsParameter();
            return await this.SendAsync<InformationprotectionListThreatassessmentrequestsParameter, InformationprotectionListThreatassessmentrequestsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/informationprotection-list-threatassessmentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<InformationprotectionListThreatassessmentrequestsResponse> InformationprotectionListThreatassessmentrequestsAsync(InformationprotectionListThreatassessmentrequestsParameter parameter)
        {
            return await this.SendAsync<InformationprotectionListThreatassessmentrequestsParameter, InformationprotectionListThreatassessmentrequestsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/informationprotection-list-threatassessmentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<InformationprotectionListThreatassessmentrequestsResponse> InformationprotectionListThreatassessmentrequestsAsync(InformationprotectionListThreatassessmentrequestsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<InformationprotectionListThreatassessmentrequestsParameter, InformationprotectionListThreatassessmentrequestsResponse>(parameter, cancellationToken);
        }
    }
}
