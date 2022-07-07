using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SubjectrightsrequestGetfinalattachmentParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Privacy_SubjectRightsRequests_SubjectRightsRequestId_GetFinalAttachment,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Privacy_SubjectRightsRequests_SubjectRightsRequestId_GetFinalAttachment: return $"/privacy/subjectRightsRequests/{SubjectRightsRequestId}/getFinalAttachment";
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
    public partial class SubjectrightsrequestGetfinalattachmentResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subjectrightsrequest-getfinalattachment?view=graph-rest-1.0
        /// </summary>
        public async Task<SubjectrightsrequestGetfinalattachmentResponse> SubjectrightsrequestGetfinalattachmentAsync()
        {
            var p = new SubjectrightsrequestGetfinalattachmentParameter();
            return await this.SendAsync<SubjectrightsrequestGetfinalattachmentParameter, SubjectrightsrequestGetfinalattachmentResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subjectrightsrequest-getfinalattachment?view=graph-rest-1.0
        /// </summary>
        public async Task<SubjectrightsrequestGetfinalattachmentResponse> SubjectrightsrequestGetfinalattachmentAsync(CancellationToken cancellationToken)
        {
            var p = new SubjectrightsrequestGetfinalattachmentParameter();
            return await this.SendAsync<SubjectrightsrequestGetfinalattachmentParameter, SubjectrightsrequestGetfinalattachmentResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subjectrightsrequest-getfinalattachment?view=graph-rest-1.0
        /// </summary>
        public async Task<SubjectrightsrequestGetfinalattachmentResponse> SubjectrightsrequestGetfinalattachmentAsync(SubjectrightsrequestGetfinalattachmentParameter parameter)
        {
            return await this.SendAsync<SubjectrightsrequestGetfinalattachmentParameter, SubjectrightsrequestGetfinalattachmentResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subjectrightsrequest-getfinalattachment?view=graph-rest-1.0
        /// </summary>
        public async Task<SubjectrightsrequestGetfinalattachmentResponse> SubjectrightsrequestGetfinalattachmentAsync(SubjectrightsrequestGetfinalattachmentParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SubjectrightsrequestGetfinalattachmentParameter, SubjectrightsrequestGetfinalattachmentResponse>(parameter, cancellationToken);
        }
    }
}
