using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ThreatassessmentrequestGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            InformationProtection_ThreatAssessmentRequests_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.InformationProtection_ThreatAssessmentRequests_Id: return $"/informationProtection/threatAssessmentRequests/{Id}";
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
        public string Id { get; set; }
    }
    public partial class ThreatassessmentrequestGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/threatassessmentrequest-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ThreatassessmentrequestGetResponse> ThreatassessmentrequestGetAsync()
        {
            var p = new ThreatassessmentrequestGetParameter();
            return await this.SendAsync<ThreatassessmentrequestGetParameter, ThreatassessmentrequestGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/threatassessmentrequest-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ThreatassessmentrequestGetResponse> ThreatassessmentrequestGetAsync(CancellationToken cancellationToken)
        {
            var p = new ThreatassessmentrequestGetParameter();
            return await this.SendAsync<ThreatassessmentrequestGetParameter, ThreatassessmentrequestGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/threatassessmentrequest-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ThreatassessmentrequestGetResponse> ThreatassessmentrequestGetAsync(ThreatassessmentrequestGetParameter parameter)
        {
            return await this.SendAsync<ThreatassessmentrequestGetParameter, ThreatassessmentrequestGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/threatassessmentrequest-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ThreatassessmentrequestGetResponse> ThreatassessmentrequestGetAsync(ThreatassessmentrequestGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ThreatassessmentrequestGetParameter, ThreatassessmentrequestGetResponse>(parameter, cancellationToken);
        }
    }
}
