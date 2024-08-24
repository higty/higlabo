using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationclass-delete?view=graph-rest-1.0
    /// </summary>
    public partial class EducationClassDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Classes_Id: return $"/education/classes/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Education_Classes_Id,
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
    public partial class EducationClassDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationclass-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationClassDeleteResponse> EducationClassDeleteAsync()
        {
            var p = new EducationClassDeleteParameter();
            return await this.SendAsync<EducationClassDeleteParameter, EducationClassDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationClassDeleteResponse> EducationClassDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new EducationClassDeleteParameter();
            return await this.SendAsync<EducationClassDeleteParameter, EducationClassDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationClassDeleteResponse> EducationClassDeleteAsync(EducationClassDeleteParameter parameter)
        {
            return await this.SendAsync<EducationClassDeleteParameter, EducationClassDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationClassDeleteResponse> EducationClassDeleteAsync(EducationClassDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationClassDeleteParameter, EducationClassDeleteResponse>(parameter, cancellationToken);
        }
    }
}
