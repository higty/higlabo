using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/userflowlanguagepage-get?view=graph-rest-1.0
    /// </summary>
    public partial class UserflowlanguagepageGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? B2xUserFlowsId { get; set; }
            public string? LanguagesId { get; set; }
            public string? DefaultPagesId { get; set; }
            public string? OverridesPagesId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Identity_B2xUserFlows_Id_Languages_Id_DefaultPages_Id_value: return $"/identity/b2xUserFlows/{B2xUserFlowsId}/languages/{LanguagesId}/defaultPages/{DefaultPagesId}/$value";
                    case ApiPath.Identity_B2xUserFlows_Id_Languages_Id_OverridesPages_Id_value: return $"/identity/b2xUserFlows/{B2xUserFlowsId}/languages/{LanguagesId}/overridesPages/{OverridesPagesId}/$value";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Identity_B2xUserFlows_Id_Languages_Id_DefaultPages_Id_value,
            Identity_B2xUserFlows_Id_Languages_Id_OverridesPages_Id_value,
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
    public partial class UserflowlanguagepageGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/userflowlanguagepage-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userflowlanguagepage-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UserflowlanguagepageGetResponse> UserflowlanguagepageGetAsync()
        {
            var p = new UserflowlanguagepageGetParameter();
            return await this.SendAsync<UserflowlanguagepageGetParameter, UserflowlanguagepageGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userflowlanguagepage-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UserflowlanguagepageGetResponse> UserflowlanguagepageGetAsync(CancellationToken cancellationToken)
        {
            var p = new UserflowlanguagepageGetParameter();
            return await this.SendAsync<UserflowlanguagepageGetParameter, UserflowlanguagepageGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userflowlanguagepage-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UserflowlanguagepageGetResponse> UserflowlanguagepageGetAsync(UserflowlanguagepageGetParameter parameter)
        {
            return await this.SendAsync<UserflowlanguagepageGetParameter, UserflowlanguagepageGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userflowlanguagepage-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UserflowlanguagepageGetResponse> UserflowlanguagepageGetAsync(UserflowlanguagepageGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserflowlanguagepageGetParameter, UserflowlanguagepageGetResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userflowlanguagepage-get?view=graph-rest-1.0
        /// </summary>
        public async Task<Stream> UserflowlanguagepageGetStreamAsync(UserflowlanguagepageGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.DownloadStreamAsync(parameter, cancellationToken);
        }
    }
}
