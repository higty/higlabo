using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OutlookuserSupportedlanguagesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Outlook_SupportedLanguages,
            Users_IdOruserPrincipalName_Outlook_SupportedLanguages,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Outlook_SupportedLanguages: return $"/me/outlook/supportedLanguages";
                    case ApiPath.Users_IdOruserPrincipalName_Outlook_SupportedLanguages: return $"/users/{IdOrUserPrincipalName}/outlook/supportedLanguages";
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
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class OutlookuserSupportedlanguagesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/localeinfo?view=graph-rest-1.0
        /// </summary>
        public partial class LocaleInfo
        {
            public string? Locale { get; set; }
            public string? DisplayName { get; set; }
        }

        public LocaleInfo[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/outlookuser-supportedlanguages?view=graph-rest-1.0
        /// </summary>
        public async Task<OutlookuserSupportedlanguagesResponse> OutlookuserSupportedlanguagesAsync()
        {
            var p = new OutlookuserSupportedlanguagesParameter();
            return await this.SendAsync<OutlookuserSupportedlanguagesParameter, OutlookuserSupportedlanguagesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/outlookuser-supportedlanguages?view=graph-rest-1.0
        /// </summary>
        public async Task<OutlookuserSupportedlanguagesResponse> OutlookuserSupportedlanguagesAsync(CancellationToken cancellationToken)
        {
            var p = new OutlookuserSupportedlanguagesParameter();
            return await this.SendAsync<OutlookuserSupportedlanguagesParameter, OutlookuserSupportedlanguagesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/outlookuser-supportedlanguages?view=graph-rest-1.0
        /// </summary>
        public async Task<OutlookuserSupportedlanguagesResponse> OutlookuserSupportedlanguagesAsync(OutlookuserSupportedlanguagesParameter parameter)
        {
            return await this.SendAsync<OutlookuserSupportedlanguagesParameter, OutlookuserSupportedlanguagesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/outlookuser-supportedlanguages?view=graph-rest-1.0
        /// </summary>
        public async Task<OutlookuserSupportedlanguagesResponse> OutlookuserSupportedlanguagesAsync(OutlookuserSupportedlanguagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OutlookuserSupportedlanguagesParameter, OutlookuserSupportedlanguagesResponse>(parameter, cancellationToken);
        }
    }
}
