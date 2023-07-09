using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/employeeexperience-list-learningproviders?view=graph-rest-1.0
    /// </summary>
    public partial class EmployeeexperienceListLearningprovidersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.EmployeeExperience_LearningProviders: return $"/employeeExperience/learningProviders";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            DisplayName,
            Id,
            LoginWebUrl,
            LongLogoWebUrlForDarkTheme,
            LongLogoWebUrlForLightTheme,
            SquareLogoWebUrlForDarkTheme,
            SquareLogoWebUrlForLightTheme,
            LearningContents,
        }
        public enum ApiPath
        {
            EmployeeExperience_LearningProviders,
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
    public partial class EmployeeexperienceListLearningprovidersResponse : RestApiResponse
    {
        public LearningProvider[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/employeeexperience-list-learningproviders?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/employeeexperience-list-learningproviders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EmployeeexperienceListLearningprovidersResponse> EmployeeexperienceListLearningprovidersAsync()
        {
            var p = new EmployeeexperienceListLearningprovidersParameter();
            return await this.SendAsync<EmployeeexperienceListLearningprovidersParameter, EmployeeexperienceListLearningprovidersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/employeeexperience-list-learningproviders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EmployeeexperienceListLearningprovidersResponse> EmployeeexperienceListLearningprovidersAsync(CancellationToken cancellationToken)
        {
            var p = new EmployeeexperienceListLearningprovidersParameter();
            return await this.SendAsync<EmployeeexperienceListLearningprovidersParameter, EmployeeexperienceListLearningprovidersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/employeeexperience-list-learningproviders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EmployeeexperienceListLearningprovidersResponse> EmployeeexperienceListLearningprovidersAsync(EmployeeexperienceListLearningprovidersParameter parameter)
        {
            return await this.SendAsync<EmployeeexperienceListLearningprovidersParameter, EmployeeexperienceListLearningprovidersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/employeeexperience-list-learningproviders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EmployeeexperienceListLearningprovidersResponse> EmployeeexperienceListLearningprovidersAsync(EmployeeexperienceListLearningprovidersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EmployeeexperienceListLearningprovidersParameter, EmployeeexperienceListLearningprovidersResponse>(parameter, cancellationToken);
        }
    }
}
