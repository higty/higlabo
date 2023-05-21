using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/learningprovider-delete-learningcontents?view=graph-rest-1.0
    /// </summary>
    public partial class LearningproviderDeleteLearningContentsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? LearningProviderId { get; set; }
            public string? LearningContentId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.EmployeeExperience_LearningProviders_LearningProviderId_LearningContents_LearningContentId_ref: return $"/employeeExperience/learningProviders/{LearningProviderId}/learningContents/{LearningContentId}/$ref";
                    case ApiPath.EmployeeExperience_LearningProviders_LearningProviderId_LearningContents: return $"/employeeExperience/learningProviders/{LearningProviderId}/learningContents";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            EmployeeExperience_LearningProviders_LearningProviderId_LearningContents_LearningContentId_ref,
            EmployeeExperience_LearningProviders_LearningProviderId_LearningContents,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class LearningproviderDeleteLearningContentsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/learningprovider-delete-learningcontents?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/learningprovider-delete-learningcontents?view=graph-rest-1.0
        /// </summary>
        public async Task<LearningproviderDeleteLearningContentsResponse> LearningproviderDeleteLearningContentsAsync()
        {
            var p = new LearningproviderDeleteLearningContentsParameter();
            return await this.SendAsync<LearningproviderDeleteLearningContentsParameter, LearningproviderDeleteLearningContentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/learningprovider-delete-learningcontents?view=graph-rest-1.0
        /// </summary>
        public async Task<LearningproviderDeleteLearningContentsResponse> LearningproviderDeleteLearningContentsAsync(CancellationToken cancellationToken)
        {
            var p = new LearningproviderDeleteLearningContentsParameter();
            return await this.SendAsync<LearningproviderDeleteLearningContentsParameter, LearningproviderDeleteLearningContentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/learningprovider-delete-learningcontents?view=graph-rest-1.0
        /// </summary>
        public async Task<LearningproviderDeleteLearningContentsResponse> LearningproviderDeleteLearningContentsAsync(LearningproviderDeleteLearningContentsParameter parameter)
        {
            return await this.SendAsync<LearningproviderDeleteLearningContentsParameter, LearningproviderDeleteLearningContentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/learningprovider-delete-learningcontents?view=graph-rest-1.0
        /// </summary>
        public async Task<LearningproviderDeleteLearningContentsResponse> LearningproviderDeleteLearningContentsAsync(LearningproviderDeleteLearningContentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<LearningproviderDeleteLearningContentsParameter, LearningproviderDeleteLearningContentsResponse>(parameter, cancellationToken);
        }
    }
}
