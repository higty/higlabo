using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationrubric-delete?view=graph-rest-1.0
    /// </summary>
    public partial class EducationrubricDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Me_Rubrics_Ceb3863e69124ea9Ac413c2bb7b6672d: return $"/education/me/rubrics/ceb3863e-6912-4ea9-ac41-3c2bb7b6672d";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Education_Me_Rubrics_Ceb3863e69124ea9Ac413c2bb7b6672d,
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
    public partial class EducationrubricDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationrubric-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationrubric-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationrubricDeleteResponse> EducationrubricDeleteAsync()
        {
            var p = new EducationrubricDeleteParameter();
            return await this.SendAsync<EducationrubricDeleteParameter, EducationrubricDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationrubric-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationrubricDeleteResponse> EducationrubricDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new EducationrubricDeleteParameter();
            return await this.SendAsync<EducationrubricDeleteParameter, EducationrubricDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationrubric-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationrubricDeleteResponse> EducationrubricDeleteAsync(EducationrubricDeleteParameter parameter)
        {
            return await this.SendAsync<EducationrubricDeleteParameter, EducationrubricDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationrubric-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationrubricDeleteResponse> EducationrubricDeleteAsync(EducationrubricDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationrubricDeleteParameter, EducationrubricDeleteResponse>(parameter, cancellationToken);
        }
    }
}
