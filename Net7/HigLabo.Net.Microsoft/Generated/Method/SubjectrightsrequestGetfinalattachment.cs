using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-getfinalattachment?view=graph-rest-1.0
    /// </summary>
    public partial class SubjectrightsrequestGetfinalattachmentParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SubjectRightsRequestId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Privacy_SubjectRightsRequests_SubjectRightsRequestId_GetFinalAttachment: return $"/privacy/subjectRightsRequests/{SubjectRightsRequestId}/getFinalAttachment";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Privacy_SubjectRightsRequests_SubjectRightsRequestId_GetFinalAttachment,
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
    public partial class SubjectrightsrequestGetfinalattachmentResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-getfinalattachment?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-getfinalattachment?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SubjectrightsrequestGetfinalattachmentResponse> SubjectrightsrequestGetfinalattachmentAsync()
        {
            var p = new SubjectrightsrequestGetfinalattachmentParameter();
            return await this.SendAsync<SubjectrightsrequestGetfinalattachmentParameter, SubjectrightsrequestGetfinalattachmentResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-getfinalattachment?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SubjectrightsrequestGetfinalattachmentResponse> SubjectrightsrequestGetfinalattachmentAsync(CancellationToken cancellationToken)
        {
            var p = new SubjectrightsrequestGetfinalattachmentParameter();
            return await this.SendAsync<SubjectrightsrequestGetfinalattachmentParameter, SubjectrightsrequestGetfinalattachmentResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-getfinalattachment?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SubjectrightsrequestGetfinalattachmentResponse> SubjectrightsrequestGetfinalattachmentAsync(SubjectrightsrequestGetfinalattachmentParameter parameter)
        {
            return await this.SendAsync<SubjectrightsrequestGetfinalattachmentParameter, SubjectrightsrequestGetfinalattachmentResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-getfinalattachment?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SubjectrightsrequestGetfinalattachmentResponse> SubjectrightsrequestGetfinalattachmentAsync(SubjectrightsrequestGetfinalattachmentParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SubjectrightsrequestGetfinalattachmentParameter, SubjectrightsrequestGetfinalattachmentResponse>(parameter, cancellationToken);
        }
    }
}
