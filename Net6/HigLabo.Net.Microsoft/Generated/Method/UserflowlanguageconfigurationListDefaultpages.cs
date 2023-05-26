using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/userflowlanguageconfiguration-list-defaultpages?view=graph-rest-1.0
    /// </summary>
    public partial class UserflowlanguageConfigurationListDefaultpagesParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.Identity_B2xUserFlows_Id_Languages_Id_DefaultPages: return $"/identity/b2xUserFlows/{B2xUserFlowsId}/languages/{LanguagesId}/defaultPages";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Id,
        }
        public enum ApiPath
        {
            Identity_B2xUserFlows_Id_Languages_Id_DefaultPages,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    }
    public partial class UserflowlanguageConfigurationListDefaultpagesResponse : RestApiResponse
    {
        public UserFlowLanguagePage[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/userflowlanguageconfiguration-list-defaultpages?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userflowlanguageconfiguration-list-defaultpages?view=graph-rest-1.0
        /// </summary>
        public async Task<UserflowlanguageConfigurationListDefaultpagesResponse> UserflowlanguageConfigurationListDefaultpagesAsync()
        {
            var p = new UserflowlanguageConfigurationListDefaultpagesParameter();
            return await this.SendAsync<UserflowlanguageConfigurationListDefaultpagesParameter, UserflowlanguageConfigurationListDefaultpagesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userflowlanguageconfiguration-list-defaultpages?view=graph-rest-1.0
        /// </summary>
        public async Task<UserflowlanguageConfigurationListDefaultpagesResponse> UserflowlanguageConfigurationListDefaultpagesAsync(CancellationToken cancellationToken)
        {
            var p = new UserflowlanguageConfigurationListDefaultpagesParameter();
            return await this.SendAsync<UserflowlanguageConfigurationListDefaultpagesParameter, UserflowlanguageConfigurationListDefaultpagesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userflowlanguageconfiguration-list-defaultpages?view=graph-rest-1.0
        /// </summary>
        public async Task<UserflowlanguageConfigurationListDefaultpagesResponse> UserflowlanguageConfigurationListDefaultpagesAsync(UserflowlanguageConfigurationListDefaultpagesParameter parameter)
        {
            return await this.SendAsync<UserflowlanguageConfigurationListDefaultpagesParameter, UserflowlanguageConfigurationListDefaultpagesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userflowlanguageconfiguration-list-defaultpages?view=graph-rest-1.0
        /// </summary>
        public async Task<UserflowlanguageConfigurationListDefaultpagesResponse> UserflowlanguageConfigurationListDefaultpagesAsync(UserflowlanguageConfigurationListDefaultpagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserflowlanguageConfigurationListDefaultpagesParameter, UserflowlanguageConfigurationListDefaultpagesResponse>(parameter, cancellationToken);
        }
    }
}
