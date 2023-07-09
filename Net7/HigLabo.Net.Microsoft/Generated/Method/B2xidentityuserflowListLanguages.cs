using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-languages?view=graph-rest-1.0
    /// </summary>
    public partial class B2xidentityUserflowListLanguagesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Identity_B2xUserFlows_Id_Languages: return $"/identity/b2xUserFlows/{Id}/languages";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            DisplayName,
            Id,
            IsEnabled,
            DefaultPages,
            OverridesPages,
        }
        public enum ApiPath
        {
            Identity_B2xUserFlows_Id_Languages,
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
    public partial class B2xidentityUserflowListLanguagesResponse : RestApiResponse
    {
        public UserFlowLanguageConfiguration[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-languages?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-languages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<B2xidentityUserflowListLanguagesResponse> B2xidentityUserflowListLanguagesAsync()
        {
            var p = new B2xidentityUserflowListLanguagesParameter();
            return await this.SendAsync<B2xidentityUserflowListLanguagesParameter, B2xidentityUserflowListLanguagesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-languages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<B2xidentityUserflowListLanguagesResponse> B2xidentityUserflowListLanguagesAsync(CancellationToken cancellationToken)
        {
            var p = new B2xidentityUserflowListLanguagesParameter();
            return await this.SendAsync<B2xidentityUserflowListLanguagesParameter, B2xidentityUserflowListLanguagesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-languages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<B2xidentityUserflowListLanguagesResponse> B2xidentityUserflowListLanguagesAsync(B2xidentityUserflowListLanguagesParameter parameter)
        {
            return await this.SendAsync<B2xidentityUserflowListLanguagesParameter, B2xidentityUserflowListLanguagesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-languages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<B2xidentityUserflowListLanguagesResponse> B2xidentityUserflowListLanguagesAsync(B2xidentityUserflowListLanguagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<B2xidentityUserflowListLanguagesParameter, B2xidentityUserflowListLanguagesResponse>(parameter, cancellationToken);
        }
    }
}
