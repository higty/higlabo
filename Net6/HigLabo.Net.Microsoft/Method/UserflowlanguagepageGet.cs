using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserflowlanguagepageGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Identity_B2xUserFlows_Id_Languages_Id_DefaultPages_Id_value,
            Identity_B2xUserFlows_Id_Languages_Id_OverridesPages_Id_value,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Identity_B2xUserFlows_Id_Languages_Id_DefaultPages_Id_value: return $"/identity/b2xUserFlows/{B2xUserFlowsId}/languages/{LanguagesId}/defaultPages/{DefaultPagesId}/$value";
                    case ApiPath.Identity_B2xUserFlows_Id_Languages_Id_OverridesPages_Id_value: return $"/identity/b2xUserFlows/{B2xUserFlowsId}/languages/{LanguagesId}/overridesPages/{OverridesPagesId}/$value";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string B2xUserFlowsId { get; set; }
        public string LanguagesId { get; set; }
        public string DefaultPagesId { get; set; }
        public string OverridesPagesId { get; set; }
    }
    public partial class UserflowlanguagepageGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userflowlanguagepage-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UserflowlanguagepageGetResponse> UserflowlanguagepageGetAsync()
        {
            var p = new UserflowlanguagepageGetParameter();
            return await this.SendAsync<UserflowlanguagepageGetParameter, UserflowlanguagepageGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userflowlanguagepage-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UserflowlanguagepageGetResponse> UserflowlanguagepageGetAsync(CancellationToken cancellationToken)
        {
            var p = new UserflowlanguagepageGetParameter();
            return await this.SendAsync<UserflowlanguagepageGetParameter, UserflowlanguagepageGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userflowlanguagepage-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UserflowlanguagepageGetResponse> UserflowlanguagepageGetAsync(UserflowlanguagepageGetParameter parameter)
        {
            return await this.SendAsync<UserflowlanguagepageGetParameter, UserflowlanguagepageGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userflowlanguagepage-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UserflowlanguagepageGetResponse> UserflowlanguagepageGetAsync(UserflowlanguagepageGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserflowlanguagepageGetParameter, UserflowlanguagepageGetResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userflowlanguagepage-get?view=graph-rest-1.0
        /// </summary>
        public async Task<Stream> UserflowlanguagepageGetStreamAsync(UserflowlanguagepageGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.DownloadStreamAsync(parameter, cancellationToken);
        }
    }
}
