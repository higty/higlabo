using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationclassListCategoriesParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
            Id,
            DisplayName,
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
    public partial class EducationclassListCategoriesResponse : RestApiResponse
    {
        public EducationCategory[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationclass-list-categories?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassListCategoriesResponse> EducationclassListCategoriesAsync()
        {
            var p = new EducationclassListCategoriesParameter();
            return await this.SendAsync<EducationclassListCategoriesParameter, EducationclassListCategoriesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationclass-list-categories?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassListCategoriesResponse> EducationclassListCategoriesAsync(CancellationToken cancellationToken)
        {
            var p = new EducationclassListCategoriesParameter();
            return await this.SendAsync<EducationclassListCategoriesParameter, EducationclassListCategoriesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationclass-list-categories?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassListCategoriesResponse> EducationclassListCategoriesAsync(EducationclassListCategoriesParameter parameter)
        {
            return await this.SendAsync<EducationclassListCategoriesParameter, EducationclassListCategoriesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationclass-list-categories?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassListCategoriesResponse> EducationclassListCategoriesAsync(EducationclassListCategoriesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationclassListCategoriesParameter, EducationclassListCategoriesResponse>(parameter, cancellationToken);
        }
    }
}
