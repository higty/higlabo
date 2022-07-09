using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationsubmissionListOutcomesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Classes_Acdefc6b2dc64e71B1e96d9810ab1793_Assignments_Cf6005fc9e1344a2A6acA53322006454_Submissions_D1bee293D8bb48d4Af3eC8cb0e3c7fe7_Outcomes: return $"/education/classes/acdefc6b-2dc6-4e71-b1e9-6d9810ab1793/assignments/cf6005fc-9e13-44a2-a6ac-a53322006454/submissions/d1bee293-d8bb-48d4-af3e-c8cb0e3c7fe7/outcomes";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Id,
            LastModifiedBy,
            LastModifiedDateTime,
        }
        public enum ApiPath
        {
            Education_Classes_Acdefc6b2dc64e71B1e96d9810ab1793_Assignments_Cf6005fc9e1344a2A6acA53322006454_Submissions_D1bee293D8bb48d4Af3eC8cb0e3c7fe7_Outcomes,
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
    public partial class EducationsubmissionListOutcomesResponse : RestApiResponse
    {
        public EducationOutcome[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmission-list-outcomes?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionListOutcomesResponse> EducationsubmissionListOutcomesAsync()
        {
            var p = new EducationsubmissionListOutcomesParameter();
            return await this.SendAsync<EducationsubmissionListOutcomesParameter, EducationsubmissionListOutcomesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmission-list-outcomes?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionListOutcomesResponse> EducationsubmissionListOutcomesAsync(CancellationToken cancellationToken)
        {
            var p = new EducationsubmissionListOutcomesParameter();
            return await this.SendAsync<EducationsubmissionListOutcomesParameter, EducationsubmissionListOutcomesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmission-list-outcomes?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionListOutcomesResponse> EducationsubmissionListOutcomesAsync(EducationsubmissionListOutcomesParameter parameter)
        {
            return await this.SendAsync<EducationsubmissionListOutcomesParameter, EducationsubmissionListOutcomesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmission-list-outcomes?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionListOutcomesResponse> EducationsubmissionListOutcomesAsync(EducationsubmissionListOutcomesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationsubmissionListOutcomesParameter, EducationsubmissionListOutcomesResponse>(parameter, cancellationToken);
        }
    }
}
