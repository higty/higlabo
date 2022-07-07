using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SubjectrightsrequestPostNotesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Privacy_SubjectRightsRequests_SubjectRightsRequestId_Notes,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Privacy_SubjectRightsRequests_SubjectRightsRequestId_Notes: return $"/privacy/subjectRightsRequests/{SubjectRightsRequestId}/notes";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public ItemBody? Content { get; set; }
        public string SubjectRightsRequestId { get; set; }
    }
    public partial class SubjectrightsrequestPostNotesResponse : RestApiResponse
    {
        public Identity? Author { get; set; }
        public ItemBody? Content { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subjectrightsrequest-post-notes?view=graph-rest-1.0
        /// </summary>
        public async Task<SubjectrightsrequestPostNotesResponse> SubjectrightsrequestPostNotesAsync()
        {
            var p = new SubjectrightsrequestPostNotesParameter();
            return await this.SendAsync<SubjectrightsrequestPostNotesParameter, SubjectrightsrequestPostNotesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subjectrightsrequest-post-notes?view=graph-rest-1.0
        /// </summary>
        public async Task<SubjectrightsrequestPostNotesResponse> SubjectrightsrequestPostNotesAsync(CancellationToken cancellationToken)
        {
            var p = new SubjectrightsrequestPostNotesParameter();
            return await this.SendAsync<SubjectrightsrequestPostNotesParameter, SubjectrightsrequestPostNotesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subjectrightsrequest-post-notes?view=graph-rest-1.0
        /// </summary>
        public async Task<SubjectrightsrequestPostNotesResponse> SubjectrightsrequestPostNotesAsync(SubjectrightsrequestPostNotesParameter parameter)
        {
            return await this.SendAsync<SubjectrightsrequestPostNotesParameter, SubjectrightsrequestPostNotesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subjectrightsrequest-post-notes?view=graph-rest-1.0
        /// </summary>
        public async Task<SubjectrightsrequestPostNotesResponse> SubjectrightsrequestPostNotesAsync(SubjectrightsrequestPostNotesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SubjectrightsrequestPostNotesParameter, SubjectrightsrequestPostNotesResponse>(parameter, cancellationToken);
        }
    }
}
