using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/threatassessmentrequest-get?view=graph-rest-1.0
    /// </summary>
    public partial class ThreatassessmentRequestGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.InformationProtection_ThreatAssessmentRequests_Id: return $"/informationProtection/threatAssessmentRequests/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            InformationProtection_ThreatAssessmentRequests_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    public partial class ThreatassessmentRequestGetResponse : RestApiResponse
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
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/threatassessmentrequest-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/threatassessmentrequest-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ThreatassessmentRequestGetResponse> ThreatassessmentRequestGetAsync()
        {
            var p = new ThreatassessmentRequestGetParameter();
            return await this.SendAsync<ThreatassessmentRequestGetParameter, ThreatassessmentRequestGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/threatassessmentrequest-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ThreatassessmentRequestGetResponse> ThreatassessmentRequestGetAsync(CancellationToken cancellationToken)
        {
            var p = new ThreatassessmentRequestGetParameter();
            return await this.SendAsync<ThreatassessmentRequestGetParameter, ThreatassessmentRequestGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/threatassessmentrequest-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ThreatassessmentRequestGetResponse> ThreatassessmentRequestGetAsync(ThreatassessmentRequestGetParameter parameter)
        {
            return await this.SendAsync<ThreatassessmentRequestGetParameter, ThreatassessmentRequestGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/threatassessmentrequest-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ThreatassessmentRequestGetResponse> ThreatassessmentRequestGetAsync(ThreatassessmentRequestGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ThreatassessmentRequestGetParameter, ThreatassessmentRequestGetResponse>(parameter, cancellationToken);
        }
    }
}
