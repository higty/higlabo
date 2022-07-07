using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SubjectrightsrequestPostParameter : IRestApiParameter
    {
        public enum SubjectrightsrequestPostParameterDataSubjectType
        {
            Customer,
            CurrentEmployee,
            FormerEmployee,
            ProspectiveEmployee,
            Student,
            Teacher,
            Faculty,
            Other,
            UnknownFutureValue,
        }
        public enum SubjectrightsrequestPostParameterSubjectRightsRequestType
        {
            Export,
            Delete,
            Access,
            TagForAction,
            UnknownFutureValue,
        }
        public enum ApiPath
        {
            Privacy_SubjectRightsRequests,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Privacy_SubjectRightsRequests: return $"/privacy/subjectRightsRequests";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public DataSubject? DataSubject { get; set; }
        public SubjectrightsrequestPostParameterDataSubjectType DataSubjectType { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public DateTimeOffset? InternalDueDateTime { get; set; }
        public String[]? Regulations { get; set; }
        public SubjectrightsrequestPostParameterSubjectRightsRequestType Type { get; set; }
    }
    public partial class SubjectrightsrequestPostResponse : RestApiResponse
    {
        public enum SubjectRightsRequestDataSubjectType
        {
            Customer,
            CurrentEmployee,
            FormerEmployee,
            ProspectiveEmployee,
            Student,
            Teacher,
            Faculty,
            Other,
            UnknownFutureValue,
        }
        public enum SubjectRightsRequestSubjectRightsRequestStatus
        {
            Active,
            Closed,
            UnknownFutureValue,
        }
        public enum SubjectRightsRequestSubjectRightsRequestType
        {
            Export,
            Delete,
            Access,
            TagForAction,
            UnknownFutureValue,
        }

        public Identity? AssignedTo { get; set; }
        public DateTimeOffset? ClosedDateTime { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DataSubject? DataSubject { get; set; }
        public SubjectRightsRequestDataSubjectType DataSubjectType { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public SubjectRightsRequestHistory[]? History { get; set; }
        public SubjectRightsRequestDetail? Insight { get; set; }
        public DateTimeOffset? InternalDueDateTime { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public String[]? Regulations { get; set; }
        public SubjectRightsRequestStageDetail[]? Stages { get; set; }
        public SubjectRightsRequestSubjectRightsRequestStatus Status { get; set; }
        public SubjectRightsRequestSubjectRightsRequestType Type { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subjectrightsrequest-post?view=graph-rest-1.0
        /// </summary>
        public async Task<SubjectrightsrequestPostResponse> SubjectrightsrequestPostAsync()
        {
            var p = new SubjectrightsrequestPostParameter();
            return await this.SendAsync<SubjectrightsrequestPostParameter, SubjectrightsrequestPostResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subjectrightsrequest-post?view=graph-rest-1.0
        /// </summary>
        public async Task<SubjectrightsrequestPostResponse> SubjectrightsrequestPostAsync(CancellationToken cancellationToken)
        {
            var p = new SubjectrightsrequestPostParameter();
            return await this.SendAsync<SubjectrightsrequestPostParameter, SubjectrightsrequestPostResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subjectrightsrequest-post?view=graph-rest-1.0
        /// </summary>
        public async Task<SubjectrightsrequestPostResponse> SubjectrightsrequestPostAsync(SubjectrightsrequestPostParameter parameter)
        {
            return await this.SendAsync<SubjectrightsrequestPostParameter, SubjectrightsrequestPostResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subjectrightsrequest-post?view=graph-rest-1.0
        /// </summary>
        public async Task<SubjectrightsrequestPostResponse> SubjectrightsrequestPostAsync(SubjectrightsrequestPostParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SubjectrightsrequestPostParameter, SubjectrightsrequestPostResponse>(parameter, cancellationToken);
        }
    }
}
