using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-update?view=graph-rest-1.0
    /// </summary>
    public partial class SubjectrightsRequestUpdateParameter : IRestApiParameter
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
    public partial class SubjectrightsRequestUpdateResponse : RestApiResponse
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
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SubjectrightsRequestUpdateResponse> SubjectrightsRequestUpdateAsync()
        {
            var p = new SubjectrightsRequestUpdateParameter();
            return await this.SendAsync<SubjectrightsRequestUpdateParameter, SubjectrightsRequestUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SubjectrightsRequestUpdateResponse> SubjectrightsRequestUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new SubjectrightsRequestUpdateParameter();
            return await this.SendAsync<SubjectrightsRequestUpdateParameter, SubjectrightsRequestUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SubjectrightsRequestUpdateResponse> SubjectrightsRequestUpdateAsync(SubjectrightsRequestUpdateParameter parameter)
        {
            return await this.SendAsync<SubjectrightsRequestUpdateParameter, SubjectrightsRequestUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SubjectrightsRequestUpdateResponse> SubjectrightsRequestUpdateAsync(SubjectrightsRequestUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SubjectrightsRequestUpdateParameter, SubjectrightsRequestUpdateResponse>(parameter, cancellationToken);
        }
    }
}
