using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationoutcome-update?view=graph-rest-1.0
    /// </summary>
    public partial class EducationoutcomeUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Classes_Acdefc6b2dc64e71B1e96d9810ab1793_Assignments_Cf6005fc9e1344a2A6acA53322006454_Submissions_D1bee293D8bb48d4Af3eC8cb0e3c7fe7_Outcomes_9c0f2850Ff8f4fd6B3acE23077b59141: return $"/education/classes/acdefc6b-2dc6-4e71-b1e9-6d9810ab1793/assignments/cf6005fc-9e13-44a2-a6ac-a53322006454/submissions/d1bee293-d8bb-48d4-af3e-c8cb0e3c7fe7/outcomes/9c0f2850-ff8f-4fd6-b3ac-e23077b59141";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Education_Classes_Acdefc6b2dc64e71B1e96d9810ab1793_Assignments_Cf6005fc9e1344a2A6acA53322006454_Submissions_D1bee293D8bb48d4Af3eC8cb0e3c7fe7_Outcomes_9c0f2850Ff8f4fd6B3acE23077b59141,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
    }
    public partial class EducationoutcomeUpdateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationoutcome-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationoutcome-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationoutcomeUpdateResponse> EducationoutcomeUpdateAsync()
        {
            var p = new EducationoutcomeUpdateParameter();
            return await this.SendAsync<EducationoutcomeUpdateParameter, EducationoutcomeUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationoutcome-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationoutcomeUpdateResponse> EducationoutcomeUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new EducationoutcomeUpdateParameter();
            return await this.SendAsync<EducationoutcomeUpdateParameter, EducationoutcomeUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationoutcome-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationoutcomeUpdateResponse> EducationoutcomeUpdateAsync(EducationoutcomeUpdateParameter parameter)
        {
            return await this.SendAsync<EducationoutcomeUpdateParameter, EducationoutcomeUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationoutcome-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationoutcomeUpdateResponse> EducationoutcomeUpdateAsync(EducationoutcomeUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationoutcomeUpdateParameter, EducationoutcomeUpdateResponse>(parameter, cancellationToken);
        }
    }
}
