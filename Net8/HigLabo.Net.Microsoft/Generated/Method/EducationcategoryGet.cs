using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationcategory-get?view=graph-rest-1.0
    /// </summary>
    public partial class EducationcategoryGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ClassesId { get; set; }
            public string? AssignmentCategoriesId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Classes_Id_AssignmentCategories_Id: return $"/education/classes/{ClassesId}/assignmentCategories/{AssignmentCategoriesId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Education_Classes_Id_AssignmentCategories_Id,
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
    public partial class EducationcategoryGetResponse : RestApiResponse
    {
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationcategory-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationcategory-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationcategoryGetResponse> EducationcategoryGetAsync()
        {
            var p = new EducationcategoryGetParameter();
            return await this.SendAsync<EducationcategoryGetParameter, EducationcategoryGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationcategory-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationcategoryGetResponse> EducationcategoryGetAsync(CancellationToken cancellationToken)
        {
            var p = new EducationcategoryGetParameter();
            return await this.SendAsync<EducationcategoryGetParameter, EducationcategoryGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationcategory-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationcategoryGetResponse> EducationcategoryGetAsync(EducationcategoryGetParameter parameter)
        {
            return await this.SendAsync<EducationcategoryGetParameter, EducationcategoryGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationcategory-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationcategoryGetResponse> EducationcategoryGetAsync(EducationcategoryGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationcategoryGetParameter, EducationcategoryGetResponse>(parameter, cancellationToken);
        }
    }
}
