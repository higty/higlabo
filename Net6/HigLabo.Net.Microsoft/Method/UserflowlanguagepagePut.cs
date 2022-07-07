using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserflowlanguagepagePutParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Identity_B2xUserFlows_Id_Languages_Id_OverridesPages_Id_value,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Identity_B2xUserFlows_Id_Languages_Id_OverridesPages_Id_value: return $"/identity/b2xUserFlows/{B2xUserFlowsId}/languages/{LanguagesId}/overridesPages/{OverridesPagesId}/$value";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PUT";
        public string B2xUserFlowsId { get; set; }
        public string LanguagesId { get; set; }
        public string OverridesPagesId { get; set; }
    }
    public partial class UserflowlanguagepagePutResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userflowlanguagepage-put?view=graph-rest-1.0
        /// </summary>
        public async Task<UserflowlanguagepagePutResponse> UserflowlanguagepagePutAsync()
        {
            var p = new UserflowlanguagepagePutParameter();
            return await this.SendAsync<UserflowlanguagepagePutParameter, UserflowlanguagepagePutResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userflowlanguagepage-put?view=graph-rest-1.0
        /// </summary>
        public async Task<UserflowlanguagepagePutResponse> UserflowlanguagepagePutAsync(CancellationToken cancellationToken)
        {
            var p = new UserflowlanguagepagePutParameter();
            return await this.SendAsync<UserflowlanguagepagePutParameter, UserflowlanguagepagePutResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userflowlanguagepage-put?view=graph-rest-1.0
        /// </summary>
        public async Task<UserflowlanguagepagePutResponse> UserflowlanguagepagePutAsync(UserflowlanguagepagePutParameter parameter)
        {
            return await this.SendAsync<UserflowlanguagepagePutParameter, UserflowlanguagepagePutResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userflowlanguagepage-put?view=graph-rest-1.0
        /// </summary>
        public async Task<UserflowlanguagepagePutResponse> UserflowlanguagepagePutAsync(UserflowlanguagepagePutParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserflowlanguagepagePutParameter, UserflowlanguagepagePutResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userflowlanguagepage-put?view=graph-rest-1.0
        /// </summary>
        public async Task<Stream> UserflowlanguagepagePutStreamAsync(UserflowlanguagepagePutParameter parameter, CancellationToken cancellationToken)
        {
            return await this.DownloadStreamAsync(parameter, cancellationToken);
        }
    }
}
