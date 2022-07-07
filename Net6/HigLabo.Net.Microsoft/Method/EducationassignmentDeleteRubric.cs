using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationassignmentDeleteRubricParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Education_Classes_Acdefc6b2dc64e71B1e96d9810ab1793_Assignments_Cf6005fc9e1344a2A6acA53322006454_Rubric_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Classes_Acdefc6b2dc64e71B1e96d9810ab1793_Assignments_Cf6005fc9e1344a2A6acA53322006454_Rubric_ref: return $"/education/classes/acdefc6b-2dc6-4e71-b1e9-6d9810ab1793/assignments/cf6005fc-9e13-44a2-a6ac-a53322006454/rubric/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class EducationassignmentDeleteRubricResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-delete-rubric?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentDeleteRubricResponse> EducationassignmentDeleteRubricAsync()
        {
            var p = new EducationassignmentDeleteRubricParameter();
            return await this.SendAsync<EducationassignmentDeleteRubricParameter, EducationassignmentDeleteRubricResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-delete-rubric?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentDeleteRubricResponse> EducationassignmentDeleteRubricAsync(CancellationToken cancellationToken)
        {
            var p = new EducationassignmentDeleteRubricParameter();
            return await this.SendAsync<EducationassignmentDeleteRubricParameter, EducationassignmentDeleteRubricResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-delete-rubric?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentDeleteRubricResponse> EducationassignmentDeleteRubricAsync(EducationassignmentDeleteRubricParameter parameter)
        {
            return await this.SendAsync<EducationassignmentDeleteRubricParameter, EducationassignmentDeleteRubricResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-delete-rubric?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentDeleteRubricResponse> EducationassignmentDeleteRubricAsync(EducationassignmentDeleteRubricParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationassignmentDeleteRubricParameter, EducationassignmentDeleteRubricResponse>(parameter, cancellationToken);
        }
    }
}
