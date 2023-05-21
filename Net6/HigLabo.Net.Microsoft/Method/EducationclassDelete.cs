using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationclass-delete?view=graph-rest-1.0
    /// </summary>
    public partial class EducationclassDeleteParameter : IRestApiParameter
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
    public partial class EducationclassDeleteResponse : RestApiResponse
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
        public async Task<EducationclassDeleteResponse> EducationclassDeleteAsync()
        {
            var p = new EducationclassDeleteParameter();
            return await this.SendAsync<EducationclassDeleteParameter, EducationclassDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassDeleteResponse> EducationclassDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new EducationclassDeleteParameter();
            return await this.SendAsync<EducationclassDeleteParameter, EducationclassDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassDeleteResponse> EducationclassDeleteAsync(EducationclassDeleteParameter parameter)
        {
            return await this.SendAsync<EducationclassDeleteParameter, EducationclassDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassDeleteResponse> EducationclassDeleteAsync(EducationclassDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationclassDeleteParameter, EducationclassDeleteResponse>(parameter, cancellationToken);
        }
    }
}
