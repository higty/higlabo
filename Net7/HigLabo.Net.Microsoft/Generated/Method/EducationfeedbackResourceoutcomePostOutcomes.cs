using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationfeedbackresourceoutcome-post-outcomes?view=graph-rest-1.0
    /// </summary>
    public partial class EducationfeedbackResourceoutcomePostOutcomesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ClassId { get; set; }
            public string? AssignmentId { get; set; }
            public string? SubmissionId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Classes_ClassId_Assignments_AssignmentId_Submissions_SubmissionId_Outcomes: return $"/education/classes/{ClassId}/assignments/{AssignmentId}/submissions/{SubmissionId}/outcomes";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum EducationFeedbackResourceOutcomeEducationFeedbackResourceOutcomeStatus
        {
            NotPublished,
            PendingPublish,
            Published,
            FailedPublish,
            UnknownFutureValue,
        }
        public enum ApiPath
        {
            Education_Classes_ClassId_Assignments_AssignmentId_Submissions_SubmissionId_Outcomes,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public EducationResource? FeedbackResource { get; set; }
        public string? Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public EducationFeedbackResourceOutcomeEducationFeedbackResourceOutcomeStatus ResourceStatus { get; set; }
    }
    public partial class EducationfeedbackResourceoutcomePostOutcomesResponse : RestApiResponse
    {
        public enum EducationFeedbackResourceOutcomeEducationFeedbackResourceOutcomeStatus
        {
            NotPublished,
            PendingPublish,
            Published,
            FailedPublish,
            UnknownFutureValue,
        }

        public EducationResource? FeedbackResource { get; set; }
        public string? Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public EducationFeedbackResourceOutcomeEducationFeedbackResourceOutcomeStatus ResourceStatus { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationfeedbackresourceoutcome-post-outcomes?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationfeedbackresourceoutcome-post-outcomes?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationfeedbackResourceoutcomePostOutcomesResponse> EducationfeedbackResourceoutcomePostOutcomesAsync()
        {
            var p = new EducationfeedbackResourceoutcomePostOutcomesParameter();
            return await this.SendAsync<EducationfeedbackResourceoutcomePostOutcomesParameter, EducationfeedbackResourceoutcomePostOutcomesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationfeedbackresourceoutcome-post-outcomes?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationfeedbackResourceoutcomePostOutcomesResponse> EducationfeedbackResourceoutcomePostOutcomesAsync(CancellationToken cancellationToken)
        {
            var p = new EducationfeedbackResourceoutcomePostOutcomesParameter();
            return await this.SendAsync<EducationfeedbackResourceoutcomePostOutcomesParameter, EducationfeedbackResourceoutcomePostOutcomesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationfeedbackresourceoutcome-post-outcomes?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationfeedbackResourceoutcomePostOutcomesResponse> EducationfeedbackResourceoutcomePostOutcomesAsync(EducationfeedbackResourceoutcomePostOutcomesParameter parameter)
        {
            return await this.SendAsync<EducationfeedbackResourceoutcomePostOutcomesParameter, EducationfeedbackResourceoutcomePostOutcomesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationfeedbackresourceoutcome-post-outcomes?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationfeedbackResourceoutcomePostOutcomesResponse> EducationfeedbackResourceoutcomePostOutcomesAsync(EducationfeedbackResourceoutcomePostOutcomesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationfeedbackResourceoutcomePostOutcomesParameter, EducationfeedbackResourceoutcomePostOutcomesResponse>(parameter, cancellationToken);
        }
    }
}
