using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignment-delete-rubric?view=graph-rest-1.0
    /// </summary>
    public partial class EducationAssignmentDeleteRubricParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Classes_Acdefc6b2dc64e71B1e96d9810ab1793_Assignments_Cf6005fc9e1344a2A6acA53322006454_Rubric_ref: return $"/education/classes/acdefc6b-2dc6-4e71-b1e9-6d9810ab1793/assignments/cf6005fc-9e13-44a2-a6ac-a53322006454/rubric/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Education_Classes_Acdefc6b2dc64e71B1e96d9810ab1793_Assignments_Cf6005fc9e1344a2A6acA53322006454_Rubric_ref,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class EducationAssignmentDeleteRubricResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignment-delete-rubric?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-delete-rubric?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationAssignmentDeleteRubricResponse> EducationAssignmentDeleteRubricAsync()
        {
            var p = new EducationAssignmentDeleteRubricParameter();
            return await this.SendAsync<EducationAssignmentDeleteRubricParameter, EducationAssignmentDeleteRubricResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-delete-rubric?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationAssignmentDeleteRubricResponse> EducationAssignmentDeleteRubricAsync(CancellationToken cancellationToken)
        {
            var p = new EducationAssignmentDeleteRubricParameter();
            return await this.SendAsync<EducationAssignmentDeleteRubricParameter, EducationAssignmentDeleteRubricResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-delete-rubric?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationAssignmentDeleteRubricResponse> EducationAssignmentDeleteRubricAsync(EducationAssignmentDeleteRubricParameter parameter)
        {
            return await this.SendAsync<EducationAssignmentDeleteRubricParameter, EducationAssignmentDeleteRubricResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-delete-rubric?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationAssignmentDeleteRubricResponse> EducationAssignmentDeleteRubricAsync(EducationAssignmentDeleteRubricParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationAssignmentDeleteRubricParameter, EducationAssignmentDeleteRubricResponse>(parameter, cancellationToken);
        }
    }
}
