using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserflowlanguageConfigurationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string B2xUserFlowsId { get; set; }
            public string LanguagesId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Dentity_B2xUserFlows_Id_Languages_Id: return $"/dentity/b2xUserFlows/{B2xUserFlowsId}/languages/{LanguagesId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Dentity_B2xUserFlows_Id_Languages_Id,
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
    public partial class UserflowlanguageConfigurationGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public bool? IsEnabled { get; set; }
        public string? DisplayName { get; set; }
        public UserFlowLanguagePage[]? DefaultPages { get; set; }
        public UserFlowLanguagePage[]? OverridesPages { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userflowlanguageconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UserflowlanguageConfigurationGetResponse> UserflowlanguageConfigurationGetAsync()
        {
            var p = new UserflowlanguageConfigurationGetParameter();
            return await this.SendAsync<UserflowlanguageConfigurationGetParameter, UserflowlanguageConfigurationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userflowlanguageconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UserflowlanguageConfigurationGetResponse> UserflowlanguageConfigurationGetAsync(CancellationToken cancellationToken)
        {
            var p = new UserflowlanguageConfigurationGetParameter();
            return await this.SendAsync<UserflowlanguageConfigurationGetParameter, UserflowlanguageConfigurationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userflowlanguageconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UserflowlanguageConfigurationGetResponse> UserflowlanguageConfigurationGetAsync(UserflowlanguageConfigurationGetParameter parameter)
        {
            return await this.SendAsync<UserflowlanguageConfigurationGetParameter, UserflowlanguageConfigurationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userflowlanguageconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UserflowlanguageConfigurationGetResponse> UserflowlanguageConfigurationGetAsync(UserflowlanguageConfigurationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserflowlanguageConfigurationGetParameter, UserflowlanguageConfigurationGetResponse>(parameter, cancellationToken);
        }
    }
}
