using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ApplicationDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Applications_Id: return $"/applications/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Applications_Id,
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
    public partial class ApplicationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationDeleteResponse> ApplicationDeleteAsync()
        {
            var p = new ApplicationDeleteParameter();
            return await this.SendAsync<ApplicationDeleteParameter, ApplicationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationDeleteResponse> ApplicationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationDeleteParameter();
            return await this.SendAsync<ApplicationDeleteParameter, ApplicationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationDeleteResponse> ApplicationDeleteAsync(ApplicationDeleteParameter parameter)
        {
            return await this.SendAsync<ApplicationDeleteParameter, ApplicationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationDeleteResponse> ApplicationDeleteAsync(ApplicationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationDeleteParameter, ApplicationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
