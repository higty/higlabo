using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignment-post-resource?view=graph-rest-1.0
    /// </summary>
    public partial class EducationAssignmentPostResourceParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ClassId { get; set; }
            public string? AssignmentId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Classes_ClassId_Assignments_AssignmentId_Resources: return $"/education/classes/{ClassId}/assignments/{AssignmentId}/resources";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Education_Classes_ClassId_Assignments_AssignmentId_Resources,
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
        public bool? DistributeForStudentWork { get; set; }
        public string? Id { get; set; }
        public EducationResource? Resource { get; set; }
    }
    public partial class EducationAssignmentPostResourceResponse : RestApiResponse
    {
        public bool? DistributeForStudentWork { get; set; }
        public string? Id { get; set; }
        public EducationResource? Resource { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignment-post-resource?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-post-resource?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationAssignmentPostResourceResponse> EducationAssignmentPostResourceAsync()
        {
            var p = new EducationAssignmentPostResourceParameter();
            return await this.SendAsync<EducationAssignmentPostResourceParameter, EducationAssignmentPostResourceResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-post-resource?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationAssignmentPostResourceResponse> EducationAssignmentPostResourceAsync(CancellationToken cancellationToken)
        {
            var p = new EducationAssignmentPostResourceParameter();
            return await this.SendAsync<EducationAssignmentPostResourceParameter, EducationAssignmentPostResourceResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-post-resource?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationAssignmentPostResourceResponse> EducationAssignmentPostResourceAsync(EducationAssignmentPostResourceParameter parameter)
        {
            return await this.SendAsync<EducationAssignmentPostResourceParameter, EducationAssignmentPostResourceResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-post-resource?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationAssignmentPostResourceResponse> EducationAssignmentPostResourceAsync(EducationAssignmentPostResourceParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationAssignmentPostResourceParameter, EducationAssignmentPostResourceResponse>(parameter, cancellationToken);
        }
    }
}
