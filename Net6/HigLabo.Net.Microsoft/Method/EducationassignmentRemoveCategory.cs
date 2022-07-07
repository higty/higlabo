using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationassignmentRemoveCategoryParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Education_Classes_Id_Assignments_Id_Categories_Id_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Classes_Id_Assignments_Id_Categories_Id_ref: return $"/education/classes/{ClassesId}/assignments/{AssignmentsId}/categories/{CategoriesId}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string ClassesId { get; set; }
        public string AssignmentsId { get; set; }
        public string CategoriesId { get; set; }
    }
    public partial class EducationassignmentRemoveCategoryResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-remove-category?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentRemoveCategoryResponse> EducationassignmentRemoveCategoryAsync()
        {
            var p = new EducationassignmentRemoveCategoryParameter();
            return await this.SendAsync<EducationassignmentRemoveCategoryParameter, EducationassignmentRemoveCategoryResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-remove-category?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentRemoveCategoryResponse> EducationassignmentRemoveCategoryAsync(CancellationToken cancellationToken)
        {
            var p = new EducationassignmentRemoveCategoryParameter();
            return await this.SendAsync<EducationassignmentRemoveCategoryParameter, EducationassignmentRemoveCategoryResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-remove-category?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentRemoveCategoryResponse> EducationassignmentRemoveCategoryAsync(EducationassignmentRemoveCategoryParameter parameter)
        {
            return await this.SendAsync<EducationassignmentRemoveCategoryParameter, EducationassignmentRemoveCategoryResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-remove-category?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentRemoveCategoryResponse> EducationassignmentRemoveCategoryAsync(EducationassignmentRemoveCategoryParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationassignmentRemoveCategoryParameter, EducationassignmentRemoveCategoryResponse>(parameter, cancellationToken);
        }
    }
}
