using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationclass-post-category?view=graph-rest-1.0
    /// </summary>
    public partial class EducationClassPostCategoryParameter : IRestApiParameter
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
    public partial class EducationClassPostCategoryResponse : RestApiResponse
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
        public async ValueTask<EducationClassPostCategoryResponse> EducationClassPostCategoryAsync()
        {
            var p = new EducationClassPostCategoryParameter();
            return await this.SendAsync<EducationClassPostCategoryParameter, EducationClassPostCategoryResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-post-category?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationClassPostCategoryResponse> EducationClassPostCategoryAsync(CancellationToken cancellationToken)
        {
            var p = new EducationClassPostCategoryParameter();
            return await this.SendAsync<EducationClassPostCategoryParameter, EducationClassPostCategoryResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-post-category?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationClassPostCategoryResponse> EducationClassPostCategoryAsync(EducationClassPostCategoryParameter parameter)
        {
            return await this.SendAsync<EducationClassPostCategoryParameter, EducationClassPostCategoryResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-post-category?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationClassPostCategoryResponse> EducationClassPostCategoryAsync(EducationClassPostCategoryParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationClassPostCategoryParameter, EducationClassPostCategoryResponse>(parameter, cancellationToken);
        }
    }
}
