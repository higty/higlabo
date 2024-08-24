using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/employeeexperience-list-learningproviders?view=graph-rest-1.0
    /// </summary>
    public partial class EmployeeexperienceListLearningProvidersParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class EmployeeexperienceListLearningProvidersResponse : RestApiResponse<LearningProvider>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/employeeexperience-list-learningproviders?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/employeeexperience-list-learningproviders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EmployeeexperienceListLearningProvidersResponse> EmployeeexperienceListLearningProvidersAsync()
        {
            var p = new EmployeeexperienceListLearningProvidersParameter();
            return await this.SendAsync<EmployeeexperienceListLearningProvidersParameter, EmployeeexperienceListLearningProvidersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/employeeexperience-list-learningproviders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EmployeeexperienceListLearningProvidersResponse> EmployeeexperienceListLearningProvidersAsync(CancellationToken cancellationToken)
        {
            var p = new EmployeeexperienceListLearningProvidersParameter();
            return await this.SendAsync<EmployeeexperienceListLearningProvidersParameter, EmployeeexperienceListLearningProvidersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/employeeexperience-list-learningproviders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EmployeeexperienceListLearningProvidersResponse> EmployeeexperienceListLearningProvidersAsync(EmployeeexperienceListLearningProvidersParameter parameter)
        {
            return await this.SendAsync<EmployeeexperienceListLearningProvidersParameter, EmployeeexperienceListLearningProvidersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/employeeexperience-list-learningproviders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EmployeeexperienceListLearningProvidersResponse> EmployeeexperienceListLearningProvidersAsync(EmployeeexperienceListLearningProvidersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EmployeeexperienceListLearningProvidersParameter, EmployeeexperienceListLearningProvidersResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/employeeexperience-list-learningproviders?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<LearningProvider> EmployeeexperienceListLearningProvidersEnumerateAsync(EmployeeexperienceListLearningProvidersParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<EmployeeexperienceListLearningProvidersParameter, EmployeeexperienceListLearningProvidersResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<LearningProvider>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
