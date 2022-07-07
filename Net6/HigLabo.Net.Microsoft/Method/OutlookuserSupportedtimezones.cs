using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OutlookuserSupportedtimezonesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Outlook_SupportedTimeZones,
            Users_IdOruserPrincipalName_Outlook_SupportedTimeZones,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Outlook_SupportedTimeZones: return $"/me/outlook/supportedTimeZones";
                    case ApiPath.Users_IdOruserPrincipalName_Outlook_SupportedTimeZones: return $"/users/{IdOrUserPrincipalName}/outlook/supportedTimeZones";
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
    public partial class OutlookuserSupportedtimezonesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/timezoneinformation?view=graph-rest-1.0
        /// </summary>
        public partial class TimeZoneInformation
        {
            public string? Alias { get; set; }
            public string? DisplayName { get; set; }
        }

        public TimeZoneInformation[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/outlookuser-supportedtimezones?view=graph-rest-1.0
        /// </summary>
        public async Task<OutlookuserSupportedtimezonesResponse> OutlookuserSupportedtimezonesAsync()
        {
            var p = new OutlookuserSupportedtimezonesParameter();
            return await this.SendAsync<OutlookuserSupportedtimezonesParameter, OutlookuserSupportedtimezonesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/outlookuser-supportedtimezones?view=graph-rest-1.0
        /// </summary>
        public async Task<OutlookuserSupportedtimezonesResponse> OutlookuserSupportedtimezonesAsync(CancellationToken cancellationToken)
        {
            var p = new OutlookuserSupportedtimezonesParameter();
            return await this.SendAsync<OutlookuserSupportedtimezonesParameter, OutlookuserSupportedtimezonesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/outlookuser-supportedtimezones?view=graph-rest-1.0
        /// </summary>
        public async Task<OutlookuserSupportedtimezonesResponse> OutlookuserSupportedtimezonesAsync(OutlookuserSupportedtimezonesParameter parameter)
        {
            return await this.SendAsync<OutlookuserSupportedtimezonesParameter, OutlookuserSupportedtimezonesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/outlookuser-supportedtimezones?view=graph-rest-1.0
        /// </summary>
        public async Task<OutlookuserSupportedtimezonesResponse> OutlookuserSupportedtimezonesAsync(OutlookuserSupportedtimezonesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OutlookuserSupportedtimezonesParameter, OutlookuserSupportedtimezonesResponse>(parameter, cancellationToken);
        }
    }
}
