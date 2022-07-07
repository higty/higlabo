using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationassignmentPostCategoriesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Education_Classes_Id_Assignments_Id_Categories_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Classes_Id_Assignments_Id_Categories_ref: return $"/education/classes/{ClassesId}/assignments/{AssignmentsId}/categories/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string ClassesId { get; set; }
        public string AssignmentsId { get; set; }
    }
    public partial class EducationassignmentPostCategoriesResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-post-categories?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentPostCategoriesResponse> EducationassignmentPostCategoriesAsync()
        {
            var p = new EducationassignmentPostCategoriesParameter();
            return await this.SendAsync<EducationassignmentPostCategoriesParameter, EducationassignmentPostCategoriesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-post-categories?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentPostCategoriesResponse> EducationassignmentPostCategoriesAsync(CancellationToken cancellationToken)
        {
            var p = new EducationassignmentPostCategoriesParameter();
            return await this.SendAsync<EducationassignmentPostCategoriesParameter, EducationassignmentPostCategoriesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-post-categories?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentPostCategoriesResponse> EducationassignmentPostCategoriesAsync(EducationassignmentPostCategoriesParameter parameter)
        {
            return await this.SendAsync<EducationassignmentPostCategoriesParameter, EducationassignmentPostCategoriesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-post-categories?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentPostCategoriesResponse> EducationassignmentPostCategoriesAsync(EducationassignmentPostCategoriesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationassignmentPostCategoriesParameter, EducationassignmentPostCategoriesResponse>(parameter, cancellationToken);
        }
    }
}
