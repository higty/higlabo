using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserflowlanguagepageDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Identity_B2xUserFlows_Id_Languages_Id_OverridesPages_value,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Identity_B2xUserFlows_Id_Languages_Id_OverridesPages_value: return $"/identity/b2xUserFlows/{B2xUserFlowsId}/languages/{LanguagesId}/overridesPages/$value";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string B2xUserFlowsId { get; set; }
        public string LanguagesId { get; set; }
    }
    public partial class UserflowlanguagepageDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userflowlanguagepage-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<UserflowlanguagepageDeleteResponse> UserflowlanguagepageDeleteAsync()
        {
            var p = new UserflowlanguagepageDeleteParameter();
            return await this.SendAsync<UserflowlanguagepageDeleteParameter, UserflowlanguagepageDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userflowlanguagepage-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<UserflowlanguagepageDeleteResponse> UserflowlanguagepageDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new UserflowlanguagepageDeleteParameter();
            return await this.SendAsync<UserflowlanguagepageDeleteParameter, UserflowlanguagepageDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userflowlanguagepage-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<UserflowlanguagepageDeleteResponse> UserflowlanguagepageDeleteAsync(UserflowlanguagepageDeleteParameter parameter)
        {
            return await this.SendAsync<UserflowlanguagepageDeleteParameter, UserflowlanguagepageDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userflowlanguagepage-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<UserflowlanguagepageDeleteResponse> UserflowlanguagepageDeleteAsync(UserflowlanguagepageDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserflowlanguagepageDeleteParameter, UserflowlanguagepageDeleteResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userflowlanguagepage-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<Stream> UserflowlanguagepageDeleteStreamAsync(UserflowlanguagepageDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.DownloadStreamAsync(parameter, cancellationToken);
        }
    }
}
