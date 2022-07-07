using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationassignmentListCategoriesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Education_Classes_Id_Assignments_Id_Categories,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Classes_Id_Assignments_Id_Categories: return $"/education/classes/{ClassesId}/assignments/{AssignmentsId}/categories";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string ClassesId { get; set; }
        public string AssignmentsId { get; set; }
    }
    public partial class EducationassignmentListCategoriesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/educationcategory?view=graph-rest-1.0
        /// </summary>
        public partial class EducationCategory
        {
            public string? Id { get; set; }
            public string? DisplayName { get; set; }
        }

        public EducationCategory[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-list-categories?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentListCategoriesResponse> EducationassignmentListCategoriesAsync()
        {
            var p = new EducationassignmentListCategoriesParameter();
            return await this.SendAsync<EducationassignmentListCategoriesParameter, EducationassignmentListCategoriesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-list-categories?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentListCategoriesResponse> EducationassignmentListCategoriesAsync(CancellationToken cancellationToken)
        {
            var p = new EducationassignmentListCategoriesParameter();
            return await this.SendAsync<EducationassignmentListCategoriesParameter, EducationassignmentListCategoriesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-list-categories?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentListCategoriesResponse> EducationassignmentListCategoriesAsync(EducationassignmentListCategoriesParameter parameter)
        {
            return await this.SendAsync<EducationassignmentListCategoriesParameter, EducationassignmentListCategoriesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-list-categories?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentListCategoriesResponse> EducationassignmentListCategoriesAsync(EducationassignmentListCategoriesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationassignmentListCategoriesParameter, EducationassignmentListCategoriesResponse>(parameter, cancellationToken);
        }
    }
}
