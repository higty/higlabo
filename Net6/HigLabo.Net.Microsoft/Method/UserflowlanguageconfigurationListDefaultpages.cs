using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserflowlanguageconfigurationListDefaultpagesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Identity_B2xUserFlows_Id_Languages_Id_DefaultPages,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Identity_B2xUserFlows_Id_Languages_Id_DefaultPages: return $"/identity/b2xUserFlows/{B2xUserFlowsId}/languages/{LanguagesId}/defaultPages";
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
    }
    public partial class UserflowlanguageconfigurationListDefaultpagesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/userflowlanguagepage?view=graph-rest-1.0
        /// </summary>
        public partial class UserFlowLanguagePage
        {
            public string? Id { get; set; }
        }

        public UserFlowLanguagePage[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userflowlanguageconfiguration-list-defaultpages?view=graph-rest-1.0
        /// </summary>
        public async Task<UserflowlanguageconfigurationListDefaultpagesResponse> UserflowlanguageconfigurationListDefaultpagesAsync()
        {
            var p = new UserflowlanguageconfigurationListDefaultpagesParameter();
            return await this.SendAsync<UserflowlanguageconfigurationListDefaultpagesParameter, UserflowlanguageconfigurationListDefaultpagesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userflowlanguageconfiguration-list-defaultpages?view=graph-rest-1.0
        /// </summary>
        public async Task<UserflowlanguageconfigurationListDefaultpagesResponse> UserflowlanguageconfigurationListDefaultpagesAsync(CancellationToken cancellationToken)
        {
            var p = new UserflowlanguageconfigurationListDefaultpagesParameter();
            return await this.SendAsync<UserflowlanguageconfigurationListDefaultpagesParameter, UserflowlanguageconfigurationListDefaultpagesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userflowlanguageconfiguration-list-defaultpages?view=graph-rest-1.0
        /// </summary>
        public async Task<UserflowlanguageconfigurationListDefaultpagesResponse> UserflowlanguageconfigurationListDefaultpagesAsync(UserflowlanguageconfigurationListDefaultpagesParameter parameter)
        {
            return await this.SendAsync<UserflowlanguageconfigurationListDefaultpagesParameter, UserflowlanguageconfigurationListDefaultpagesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userflowlanguageconfiguration-list-defaultpages?view=graph-rest-1.0
        /// </summary>
        public async Task<UserflowlanguageconfigurationListDefaultpagesResponse> UserflowlanguageconfigurationListDefaultpagesAsync(UserflowlanguageconfigurationListDefaultpagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserflowlanguageconfigurationListDefaultpagesParameter, UserflowlanguageconfigurationListDefaultpagesResponse>(parameter, cancellationToken);
        }
    }
}
