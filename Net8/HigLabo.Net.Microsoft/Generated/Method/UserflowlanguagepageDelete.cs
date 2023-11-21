using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/userflowlanguagepage-delete?view=graph-rest-1.0
    /// </summary>
    public partial class UserflowlanguagepageDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? B2xUserFlowsId { get; set; }
            public string? LanguagesId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Identity_B2xUserFlows_Id_Languages_Id_OverridesPages_value: return $"/identity/b2xUserFlows/{B2xUserFlowsId}/languages/{LanguagesId}/overridesPages/$value";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Identity_B2xUserFlows_Id_Languages_Id_OverridesPages_value,
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
    public partial class UserflowlanguagepageDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/userflowlanguagepage-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userflowlanguagepage-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserflowlanguagepageDeleteResponse> UserflowlanguagepageDeleteAsync()
        {
            var p = new UserflowlanguagepageDeleteParameter();
            return await this.SendAsync<UserflowlanguagepageDeleteParameter, UserflowlanguagepageDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userflowlanguagepage-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserflowlanguagepageDeleteResponse> UserflowlanguagepageDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new UserflowlanguagepageDeleteParameter();
            return await this.SendAsync<UserflowlanguagepageDeleteParameter, UserflowlanguagepageDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userflowlanguagepage-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserflowlanguagepageDeleteResponse> UserflowlanguagepageDeleteAsync(UserflowlanguagepageDeleteParameter parameter)
        {
            return await this.SendAsync<UserflowlanguagepageDeleteParameter, UserflowlanguagepageDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userflowlanguagepage-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserflowlanguagepageDeleteResponse> UserflowlanguagepageDeleteAsync(UserflowlanguagepageDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserflowlanguagepageDeleteParameter, UserflowlanguagepageDeleteResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userflowlanguagepage-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<Stream> UserflowlanguagepageDeleteStreamAsync(UserflowlanguagepageDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.DownloadStreamAsync(parameter, cancellationToken);
        }
    }
}
