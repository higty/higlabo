using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignment-list-categories?view=graph-rest-1.0
    /// </summary>
    public partial class EducationAssignmentListCategoriesParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.Education_Classes_Id_Assignments_Id_Categories: return $"/education/classes/{ClassesId}/assignments/{AssignmentsId}/categories";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            DisplayName,
            Id,
        }
        public enum ApiPath
        {
            Education_Classes_Id_Assignments_Id_Categories,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class EducationAssignmentListCategoriesResponse : RestApiResponse
    {
        public EducationCategory[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignment-list-categories?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-list-categories?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationAssignmentListCategoriesResponse> EducationAssignmentListCategoriesAsync()
        {
            var p = new EducationAssignmentListCategoriesParameter();
            return await this.SendAsync<EducationAssignmentListCategoriesParameter, EducationAssignmentListCategoriesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-list-categories?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationAssignmentListCategoriesResponse> EducationAssignmentListCategoriesAsync(CancellationToken cancellationToken)
        {
            var p = new EducationAssignmentListCategoriesParameter();
            return await this.SendAsync<EducationAssignmentListCategoriesParameter, EducationAssignmentListCategoriesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-list-categories?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationAssignmentListCategoriesResponse> EducationAssignmentListCategoriesAsync(EducationAssignmentListCategoriesParameter parameter)
        {
            return await this.SendAsync<EducationAssignmentListCategoriesParameter, EducationAssignmentListCategoriesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-list-categories?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationAssignmentListCategoriesResponse> EducationAssignmentListCategoriesAsync(EducationAssignmentListCategoriesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationAssignmentListCategoriesParameter, EducationAssignmentListCategoriesResponse>(parameter, cancellationToken);
        }
    }
}
