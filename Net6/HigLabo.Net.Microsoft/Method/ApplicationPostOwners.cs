using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ApplicationPostOwnersParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Applications_Id_Owners_ref: return $"/applications/{Id}/owners/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Applications_Id_Owners_ref,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class ApplicationPostOwnersResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-post-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostOwnersResponse> ApplicationPostOwnersAsync()
        {
            var p = new ApplicationPostOwnersParameter();
            return await this.SendAsync<ApplicationPostOwnersParameter, ApplicationPostOwnersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-post-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostOwnersResponse> ApplicationPostOwnersAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationPostOwnersParameter();
            return await this.SendAsync<ApplicationPostOwnersParameter, ApplicationPostOwnersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-post-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostOwnersResponse> ApplicationPostOwnersAsync(ApplicationPostOwnersParameter parameter)
        {
            return await this.SendAsync<ApplicationPostOwnersParameter, ApplicationPostOwnersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-post-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostOwnersResponse> ApplicationPostOwnersAsync(ApplicationPostOwnersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationPostOwnersParameter, ApplicationPostOwnersResponse>(parameter, cancellationToken);
        }
    }
}
