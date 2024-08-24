using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/userflowlanguageconfiguration-list-defaultpages?view=graph-rest-1.0
    /// </summary>
    public partial class UserflowlanguageConfigurationListDefaultPagesParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class UserflowlanguageConfigurationListDefaultPagesResponse : RestApiResponse<UserFlowLanguagePage>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/userflowlanguageconfiguration-list-defaultpages?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userflowlanguageconfiguration-list-defaultpages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserflowlanguageConfigurationListDefaultPagesResponse> UserflowlanguageConfigurationListDefaultPagesAsync()
        {
            var p = new UserflowlanguageConfigurationListDefaultPagesParameter();
            return await this.SendAsync<UserflowlanguageConfigurationListDefaultPagesParameter, UserflowlanguageConfigurationListDefaultPagesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userflowlanguageconfiguration-list-defaultpages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserflowlanguageConfigurationListDefaultPagesResponse> UserflowlanguageConfigurationListDefaultPagesAsync(CancellationToken cancellationToken)
        {
            var p = new UserflowlanguageConfigurationListDefaultPagesParameter();
            return await this.SendAsync<UserflowlanguageConfigurationListDefaultPagesParameter, UserflowlanguageConfigurationListDefaultPagesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userflowlanguageconfiguration-list-defaultpages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserflowlanguageConfigurationListDefaultPagesResponse> UserflowlanguageConfigurationListDefaultPagesAsync(UserflowlanguageConfigurationListDefaultPagesParameter parameter)
        {
            return await this.SendAsync<UserflowlanguageConfigurationListDefaultPagesParameter, UserflowlanguageConfigurationListDefaultPagesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userflowlanguageconfiguration-list-defaultpages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserflowlanguageConfigurationListDefaultPagesResponse> UserflowlanguageConfigurationListDefaultPagesAsync(UserflowlanguageConfigurationListDefaultPagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserflowlanguageConfigurationListDefaultPagesParameter, UserflowlanguageConfigurationListDefaultPagesResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userflowlanguageconfiguration-list-defaultpages?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<UserFlowLanguagePage> UserflowlanguageConfigurationListDefaultPagesEnumerateAsync(UserflowlanguageConfigurationListDefaultPagesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<UserflowlanguageConfigurationListDefaultPagesParameter, UserflowlanguageConfigurationListDefaultPagesResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<UserFlowLanguagePage>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
