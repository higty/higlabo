using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationclass-post-category?view=graph-rest-1.0
    /// </summary>
    public partial class EducationclassPostCategoryParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Classes_Id_AssignmentCategories: return $"/education/classes/{Id}/assignmentCategories";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Education_Classes_Id_AssignmentCategories,
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
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
    }
    public partial class EducationclassPostCategoryResponse : RestApiResponse
    {
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationclass-post-category?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-post-category?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassPostCategoryResponse> EducationclassPostCategoryAsync()
        {
            var p = new EducationclassPostCategoryParameter();
            return await this.SendAsync<EducationclassPostCategoryParameter, EducationclassPostCategoryResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-post-category?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassPostCategoryResponse> EducationclassPostCategoryAsync(CancellationToken cancellationToken)
        {
            var p = new EducationclassPostCategoryParameter();
            return await this.SendAsync<EducationclassPostCategoryParameter, EducationclassPostCategoryResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-post-category?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassPostCategoryResponse> EducationclassPostCategoryAsync(EducationclassPostCategoryParameter parameter)
        {
            return await this.SendAsync<EducationclassPostCategoryParameter, EducationclassPostCategoryResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-post-category?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassPostCategoryResponse> EducationclassPostCategoryAsync(EducationclassPostCategoryParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationclassPostCategoryParameter, EducationclassPostCategoryResponse>(parameter, cancellationToken);
        }
    }
}
