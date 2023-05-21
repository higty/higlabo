using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-getfinalreport?view=graph-rest-1.0
    /// </summary>
    public partial class SubjectrightsrequestGetfinalreportParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SubjectRightsRequestId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Privacy_SubjectRightsRequestsSubjectRightsRequestId_GetFinalReport: return $"/privacy/subjectRightsRequests{SubjectRightsRequestId}/getFinalReport";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Privacy_SubjectRightsRequestsSubjectRightsRequestId_GetFinalReport,
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
    public partial class SubjectrightsrequestGetfinalreportResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-getfinalreport?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-getfinalreport?view=graph-rest-1.0
        /// </summary>
        public async Task<SubjectrightsrequestGetfinalreportResponse> SubjectrightsrequestGetfinalreportAsync()
        {
            var p = new SubjectrightsrequestGetfinalreportParameter();
            return await this.SendAsync<SubjectrightsrequestGetfinalreportParameter, SubjectrightsrequestGetfinalreportResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-getfinalreport?view=graph-rest-1.0
        /// </summary>
        public async Task<SubjectrightsrequestGetfinalreportResponse> SubjectrightsrequestGetfinalreportAsync(CancellationToken cancellationToken)
        {
            var p = new SubjectrightsrequestGetfinalreportParameter();
            return await this.SendAsync<SubjectrightsrequestGetfinalreportParameter, SubjectrightsrequestGetfinalreportResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-getfinalreport?view=graph-rest-1.0
        /// </summary>
        public async Task<SubjectrightsrequestGetfinalreportResponse> SubjectrightsrequestGetfinalreportAsync(SubjectrightsrequestGetfinalreportParameter parameter)
        {
            return await this.SendAsync<SubjectrightsrequestGetfinalreportParameter, SubjectrightsrequestGetfinalreportResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-getfinalreport?view=graph-rest-1.0
        /// </summary>
        public async Task<SubjectrightsrequestGetfinalreportResponse> SubjectrightsrequestGetfinalreportAsync(SubjectrightsrequestGetfinalreportParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SubjectrightsrequestGetfinalreportParameter, SubjectrightsrequestGetfinalreportResponse>(parameter, cancellationToken);
        }
    }
}
