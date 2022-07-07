using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SubjectrightsrequestGetfinalreportParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Privacy_SubjectRightsRequestsSubjectRightsRequestId_GetFinalReport,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Privacy_SubjectRightsRequestsSubjectRightsRequestId_GetFinalReport: return $"/privacy/subjectRightsRequests{SubjectRightsRequestId}/getFinalReport";
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
        public string SubjectRightsRequestId { get; set; }
    }
    public partial class SubjectrightsrequestGetfinalreportResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subjectrightsrequest-getfinalreport?view=graph-rest-1.0
        /// </summary>
        public async Task<SubjectrightsrequestGetfinalreportResponse> SubjectrightsrequestGetfinalreportAsync()
        {
            var p = new SubjectrightsrequestGetfinalreportParameter();
            return await this.SendAsync<SubjectrightsrequestGetfinalreportParameter, SubjectrightsrequestGetfinalreportResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subjectrightsrequest-getfinalreport?view=graph-rest-1.0
        /// </summary>
        public async Task<SubjectrightsrequestGetfinalreportResponse> SubjectrightsrequestGetfinalreportAsync(CancellationToken cancellationToken)
        {
            var p = new SubjectrightsrequestGetfinalreportParameter();
            return await this.SendAsync<SubjectrightsrequestGetfinalreportParameter, SubjectrightsrequestGetfinalreportResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subjectrightsrequest-getfinalreport?view=graph-rest-1.0
        /// </summary>
        public async Task<SubjectrightsrequestGetfinalreportResponse> SubjectrightsrequestGetfinalreportAsync(SubjectrightsrequestGetfinalreportParameter parameter)
        {
            return await this.SendAsync<SubjectrightsrequestGetfinalreportParameter, SubjectrightsrequestGetfinalreportResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subjectrightsrequest-getfinalreport?view=graph-rest-1.0
        /// </summary>
        public async Task<SubjectrightsrequestGetfinalreportResponse> SubjectrightsrequestGetfinalreportAsync(SubjectrightsrequestGetfinalreportParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SubjectrightsrequestGetfinalreportParameter, SubjectrightsrequestGetfinalreportResponse>(parameter, cancellationToken);
        }
    }
}
