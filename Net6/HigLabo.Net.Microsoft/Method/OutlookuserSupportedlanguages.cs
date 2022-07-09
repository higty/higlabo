using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OutlookUserSupportedlanguagesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Outlook_SupportedLanguages: return $"/me/outlook/supportedLanguages";
                    case ApiPath.Users_IdOruserPrincipalName_Outlook_SupportedLanguages: return $"/users/{IdOrUserPrincipalName}/outlook/supportedLanguages";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Outlook_SupportedLanguages,
            Users_IdOruserPrincipalName_Outlook_SupportedLanguages,
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
    public partial class OutlookUserSupportedlanguagesResponse : RestApiResponse
    {
        public LocaleInfo[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/outlookuser-supportedlanguages?view=graph-rest-1.0
        /// </summary>
        public async Task<OutlookUserSupportedlanguagesResponse> OutlookUserSupportedlanguagesAsync()
        {
            var p = new OutlookUserSupportedlanguagesParameter();
            return await this.SendAsync<OutlookUserSupportedlanguagesParameter, OutlookUserSupportedlanguagesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/outlookuser-supportedlanguages?view=graph-rest-1.0
        /// </summary>
        public async Task<OutlookUserSupportedlanguagesResponse> OutlookUserSupportedlanguagesAsync(CancellationToken cancellationToken)
        {
            var p = new OutlookUserSupportedlanguagesParameter();
            return await this.SendAsync<OutlookUserSupportedlanguagesParameter, OutlookUserSupportedlanguagesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/outlookuser-supportedlanguages?view=graph-rest-1.0
        /// </summary>
        public async Task<OutlookUserSupportedlanguagesResponse> OutlookUserSupportedlanguagesAsync(OutlookUserSupportedlanguagesParameter parameter)
        {
            return await this.SendAsync<OutlookUserSupportedlanguagesParameter, OutlookUserSupportedlanguagesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/outlookuser-supportedlanguages?view=graph-rest-1.0
        /// </summary>
        public async Task<OutlookUserSupportedlanguagesResponse> OutlookUserSupportedlanguagesAsync(OutlookUserSupportedlanguagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OutlookUserSupportedlanguagesParameter, OutlookUserSupportedlanguagesResponse>(parameter, cancellationToken);
        }
    }
}
