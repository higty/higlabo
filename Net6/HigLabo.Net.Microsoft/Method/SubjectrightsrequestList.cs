using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SubjectrightsrequestListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
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
    public partial class SubjectrightsrequestListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/subjectrightsrequest?view=graph-rest-1.0
        /// </summary>
        public partial class SubjectRightsRequest
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

        public SubjectRightsRequest[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subjectrightsrequest-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SubjectrightsrequestListResponse> SubjectrightsrequestListAsync()
        {
            var p = new SubjectrightsrequestListParameter();
            return await this.SendAsync<SubjectrightsrequestListParameter, SubjectrightsrequestListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subjectrightsrequest-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SubjectrightsrequestListResponse> SubjectrightsrequestListAsync(CancellationToken cancellationToken)
        {
            var p = new SubjectrightsrequestListParameter();
            return await this.SendAsync<SubjectrightsrequestListParameter, SubjectrightsrequestListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subjectrightsrequest-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SubjectrightsrequestListResponse> SubjectrightsrequestListAsync(SubjectrightsrequestListParameter parameter)
        {
            return await this.SendAsync<SubjectrightsrequestListParameter, SubjectrightsrequestListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subjectrightsrequest-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SubjectrightsrequestListResponse> SubjectrightsrequestListAsync(SubjectrightsrequestListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SubjectrightsrequestListParameter, SubjectrightsrequestListResponse>(parameter, cancellationToken);
        }
    }
}
