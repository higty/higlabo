using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class B2xidentityuserflowListLanguagesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Identity_B2xUserFlows_Id_Languages,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Identity_B2xUserFlows_Id_Languages: return $"/identity/b2xUserFlows/{Id}/languages";
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
        public string Id { get; set; }
    }
    public partial class B2xidentityuserflowListLanguagesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/userflowlanguageconfiguration?view=graph-rest-1.0
        /// </summary>
        public partial class UserFlowLanguageConfiguration
        {
            public string? Id { get; set; }
            public bool? IsEnabled { get; set; }
            public string? DisplayName { get; set; }
        }

        public UserFlowLanguageConfiguration[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-languages?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowListLanguagesResponse> B2xidentityuserflowListLanguagesAsync()
        {
            var p = new B2xidentityuserflowListLanguagesParameter();
            return await this.SendAsync<B2xidentityuserflowListLanguagesParameter, B2xidentityuserflowListLanguagesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-languages?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowListLanguagesResponse> B2xidentityuserflowListLanguagesAsync(CancellationToken cancellationToken)
        {
            var p = new B2xidentityuserflowListLanguagesParameter();
            return await this.SendAsync<B2xidentityuserflowListLanguagesParameter, B2xidentityuserflowListLanguagesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-languages?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowListLanguagesResponse> B2xidentityuserflowListLanguagesAsync(B2xidentityuserflowListLanguagesParameter parameter)
        {
            return await this.SendAsync<B2xidentityuserflowListLanguagesParameter, B2xidentityuserflowListLanguagesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-languages?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowListLanguagesResponse> B2xidentityuserflowListLanguagesAsync(B2xidentityuserflowListLanguagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<B2xidentityuserflowListLanguagesParameter, B2xidentityuserflowListLanguagesResponse>(parameter, cancellationToken);
        }
    }
}
