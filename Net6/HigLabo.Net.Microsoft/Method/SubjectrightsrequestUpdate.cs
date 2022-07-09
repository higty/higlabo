using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SubjectrightsrequestUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SubjectRightsRequestId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Privacy_SubjectRightsRequests_SubjectRightsRequestId: return $"/privacy/subjectRightsRequests/{SubjectRightsRequestId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Privacy_SubjectRightsRequests_SubjectRightsRequestId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public Identity? AssignedTo { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public DateTimeOffset? InternalDueDateTime { get; set; }
    }
    public partial class SubjectrightsrequestUpdateResponse : RestApiResponse
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
        public AuthoredNote[]? Notes { get; set; }
        public Team? Team { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subjectrightsrequest-update?view=graph-rest-1.0
        /// </summary>
        public async Task<SubjectrightsrequestUpdateResponse> SubjectrightsrequestUpdateAsync()
        {
            var p = new SubjectrightsrequestUpdateParameter();
            return await this.SendAsync<SubjectrightsrequestUpdateParameter, SubjectrightsrequestUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subjectrightsrequest-update?view=graph-rest-1.0
        /// </summary>
        public async Task<SubjectrightsrequestUpdateResponse> SubjectrightsrequestUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new SubjectrightsrequestUpdateParameter();
            return await this.SendAsync<SubjectrightsrequestUpdateParameter, SubjectrightsrequestUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subjectrightsrequest-update?view=graph-rest-1.0
        /// </summary>
        public async Task<SubjectrightsrequestUpdateResponse> SubjectrightsrequestUpdateAsync(SubjectrightsrequestUpdateParameter parameter)
        {
            return await this.SendAsync<SubjectrightsrequestUpdateParameter, SubjectrightsrequestUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subjectrightsrequest-update?view=graph-rest-1.0
        /// </summary>
        public async Task<SubjectrightsrequestUpdateResponse> SubjectrightsrequestUpdateAsync(SubjectrightsrequestUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SubjectrightsrequestUpdateParameter, SubjectrightsrequestUpdateResponse>(parameter, cancellationToken);
        }
    }
}
