using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/outlookuser-supportedtimezones?view=graph-rest-1.0
    /// </summary>
    public partial class OutlookUserSupportedtimezonesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Outlook_SupportedTimeZones: return $"/me/outlook/supportedTimeZones";
                    case ApiPath.Users_IdOruserPrincipalName_Outlook_SupportedTimeZones: return $"/users/{IdOrUserPrincipalName}/outlook/supportedTimeZones";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Outlook_SupportedTimeZones,
            Users_IdOruserPrincipalName_Outlook_SupportedTimeZones,
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
    public partial class OutlookUserSupportedtimezonesResponse : RestApiResponse<TimeZoneInformation>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/outlookuser-supportedtimezones?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/outlookuser-supportedtimezones?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OutlookUserSupportedtimezonesResponse> OutlookUserSupportedtimezonesAsync()
        {
            var p = new OutlookUserSupportedtimezonesParameter();
            return await this.SendAsync<OutlookUserSupportedtimezonesParameter, OutlookUserSupportedtimezonesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/outlookuser-supportedtimezones?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OutlookUserSupportedtimezonesResponse> OutlookUserSupportedtimezonesAsync(CancellationToken cancellationToken)
        {
            var p = new OutlookUserSupportedtimezonesParameter();
            return await this.SendAsync<OutlookUserSupportedtimezonesParameter, OutlookUserSupportedtimezonesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/outlookuser-supportedtimezones?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OutlookUserSupportedtimezonesResponse> OutlookUserSupportedtimezonesAsync(OutlookUserSupportedtimezonesParameter parameter)
        {
            return await this.SendAsync<OutlookUserSupportedtimezonesParameter, OutlookUserSupportedtimezonesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/outlookuser-supportedtimezones?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OutlookUserSupportedtimezonesResponse> OutlookUserSupportedtimezonesAsync(OutlookUserSupportedtimezonesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OutlookUserSupportedtimezonesParameter, OutlookUserSupportedtimezonesResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/outlookuser-supportedtimezones?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<TimeZoneInformation> OutlookUserSupportedtimezonesEnumerateAsync(OutlookUserSupportedtimezonesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<OutlookUserSupportedtimezonesParameter, OutlookUserSupportedtimezonesResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<TimeZoneInformation>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
