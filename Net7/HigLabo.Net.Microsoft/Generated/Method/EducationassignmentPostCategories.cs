using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignment-post-categories?view=graph-rest-1.0
    /// </summary>
    public partial class EducationAssignmentPostCategoriesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ClassesId { get; set; }
            public string? AssignmentsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Classes_Id_Assignments_Id_Categories_ref: return $"/education/classes/{ClassesId}/assignments/{AssignmentsId}/categories/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Education_Classes_Id_Assignments_Id_Categories_ref,
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
    }
    public partial class EducationAssignmentPostCategoriesResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignment-post-categories?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-post-categories?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationAssignmentPostCategoriesResponse> EducationAssignmentPostCategoriesAsync()
        {
            var p = new EducationAssignmentPostCategoriesParameter();
            return await this.SendAsync<EducationAssignmentPostCategoriesParameter, EducationAssignmentPostCategoriesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-post-categories?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationAssignmentPostCategoriesResponse> EducationAssignmentPostCategoriesAsync(CancellationToken cancellationToken)
        {
            var p = new EducationAssignmentPostCategoriesParameter();
            return await this.SendAsync<EducationAssignmentPostCategoriesParameter, EducationAssignmentPostCategoriesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-post-categories?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationAssignmentPostCategoriesResponse> EducationAssignmentPostCategoriesAsync(EducationAssignmentPostCategoriesParameter parameter)
        {
            return await this.SendAsync<EducationAssignmentPostCategoriesParameter, EducationAssignmentPostCategoriesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-post-categories?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationAssignmentPostCategoriesResponse> EducationAssignmentPostCategoriesAsync(EducationAssignmentPostCategoriesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationAssignmentPostCategoriesParameter, EducationAssignmentPostCategoriesResponse>(parameter, cancellationToken);
        }
    }
}
