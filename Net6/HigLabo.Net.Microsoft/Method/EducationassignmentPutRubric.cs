using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationassignmentPutRubricParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "PUT";
    }
    public partial class EducationassignmentPutRubricResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-put-rubric?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentPutRubricResponse> EducationassignmentPutRubricAsync()
        {
            var p = new EducationassignmentPutRubricParameter();
            return await this.SendAsync<EducationassignmentPutRubricParameter, EducationassignmentPutRubricResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-put-rubric?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentPutRubricResponse> EducationassignmentPutRubricAsync(CancellationToken cancellationToken)
        {
            var p = new EducationassignmentPutRubricParameter();
            return await this.SendAsync<EducationassignmentPutRubricParameter, EducationassignmentPutRubricResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-put-rubric?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentPutRubricResponse> EducationassignmentPutRubricAsync(EducationassignmentPutRubricParameter parameter)
        {
            return await this.SendAsync<EducationassignmentPutRubricParameter, EducationassignmentPutRubricResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-put-rubric?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentPutRubricResponse> EducationassignmentPutRubricAsync(EducationassignmentPutRubricParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationassignmentPutRubricParameter, EducationassignmentPutRubricResponse>(parameter, cancellationToken);
        }
    }
}
