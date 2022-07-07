using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationclassPostCategoryParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Education_Classes_Id_AssignmentCategories,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Classes_Id_AssignmentCategories: return $"/education/classes/{Id}/assignmentCategories";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
    }
    public partial class EducationclassPostCategoryResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationclass-post-category?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassPostCategoryResponse> EducationclassPostCategoryAsync()
        {
            var p = new EducationclassPostCategoryParameter();
            return await this.SendAsync<EducationclassPostCategoryParameter, EducationclassPostCategoryResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationclass-post-category?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassPostCategoryResponse> EducationclassPostCategoryAsync(CancellationToken cancellationToken)
        {
            var p = new EducationclassPostCategoryParameter();
            return await this.SendAsync<EducationclassPostCategoryParameter, EducationclassPostCategoryResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationclass-post-category?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassPostCategoryResponse> EducationclassPostCategoryAsync(EducationclassPostCategoryParameter parameter)
        {
            return await this.SendAsync<EducationclassPostCategoryParameter, EducationclassPostCategoryResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationclass-post-category?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassPostCategoryResponse> EducationclassPostCategoryAsync(EducationclassPostCategoryParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationclassPostCategoryParameter, EducationclassPostCategoryResponse>(parameter, cancellationToken);
        }
    }
}
