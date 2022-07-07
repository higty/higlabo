using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserflowlanguageconfigurationListOverridespagesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Identity_B2xUserFlows_Id_Languages_Id_OverridesPages,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Identity_B2xUserFlows_Id_Languages_Id_OverridesPages: return $"/identity/b2xUserFlows/{B2xUserFlowsId}/languages/{LanguagesId}/overridesPages";
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
    public partial class UserflowlanguageconfigurationListOverridespagesResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/userflowlanguageconfiguration-list-overridespages?view=graph-rest-1.0
        /// </summary>
        public async Task<UserflowlanguageconfigurationListOverridespagesResponse> UserflowlanguageconfigurationListOverridespagesAsync()
        {
            var p = new UserflowlanguageconfigurationListOverridespagesParameter();
            return await this.SendAsync<UserflowlanguageconfigurationListOverridespagesParameter, UserflowlanguageconfigurationListOverridespagesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userflowlanguageconfiguration-list-overridespages?view=graph-rest-1.0
        /// </summary>
        public async Task<UserflowlanguageconfigurationListOverridespagesResponse> UserflowlanguageconfigurationListOverridespagesAsync(CancellationToken cancellationToken)
        {
            var p = new UserflowlanguageconfigurationListOverridespagesParameter();
            return await this.SendAsync<UserflowlanguageconfigurationListOverridespagesParameter, UserflowlanguageconfigurationListOverridespagesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userflowlanguageconfiguration-list-overridespages?view=graph-rest-1.0
        /// </summary>
        public async Task<UserflowlanguageconfigurationListOverridespagesResponse> UserflowlanguageconfigurationListOverridespagesAsync(UserflowlanguageconfigurationListOverridespagesParameter parameter)
        {
            return await this.SendAsync<UserflowlanguageconfigurationListOverridespagesParameter, UserflowlanguageconfigurationListOverridespagesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userflowlanguageconfiguration-list-overridespages?view=graph-rest-1.0
        /// </summary>
        public async Task<UserflowlanguageconfigurationListOverridespagesResponse> UserflowlanguageconfigurationListOverridespagesAsync(UserflowlanguageconfigurationListOverridespagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserflowlanguageconfigurationListOverridespagesParameter, UserflowlanguageconfigurationListOverridespagesResponse>(parameter, cancellationToken);
        }
    }
}
