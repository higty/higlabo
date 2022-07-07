using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SubjectrightsrequestListNotesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
    public partial class SubjectrightsrequestListNotesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/authorednote?view=graph-rest-1.0
        /// </summary>
        public partial class AuthoredNote
        {
            public Identity? Author { get; set; }
            public ItemBody? Content { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
        }

        public AuthoredNote[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subjectrightsrequest-list-notes?view=graph-rest-1.0
        /// </summary>
        public async Task<SubjectrightsrequestListNotesResponse> SubjectrightsrequestListNotesAsync()
        {
            var p = new SubjectrightsrequestListNotesParameter();
            return await this.SendAsync<SubjectrightsrequestListNotesParameter, SubjectrightsrequestListNotesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subjectrightsrequest-list-notes?view=graph-rest-1.0
        /// </summary>
        public async Task<SubjectrightsrequestListNotesResponse> SubjectrightsrequestListNotesAsync(CancellationToken cancellationToken)
        {
            var p = new SubjectrightsrequestListNotesParameter();
            return await this.SendAsync<SubjectrightsrequestListNotesParameter, SubjectrightsrequestListNotesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subjectrightsrequest-list-notes?view=graph-rest-1.0
        /// </summary>
        public async Task<SubjectrightsrequestListNotesResponse> SubjectrightsrequestListNotesAsync(SubjectrightsrequestListNotesParameter parameter)
        {
            return await this.SendAsync<SubjectrightsrequestListNotesParameter, SubjectrightsrequestListNotesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subjectrightsrequest-list-notes?view=graph-rest-1.0
        /// </summary>
        public async Task<SubjectrightsrequestListNotesResponse> SubjectrightsrequestListNotesAsync(SubjectrightsrequestListNotesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SubjectrightsrequestListNotesParameter, SubjectrightsrequestListNotesResponse>(parameter, cancellationToken);
        }
    }
}
