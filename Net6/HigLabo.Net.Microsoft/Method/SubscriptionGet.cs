using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SubscriptionGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Subscriptions_Id: return $"/subscriptions/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            ApplicationId,
            ChangeType,
            ClientState,
            CreatorId,
            EncryptionCertificate,
            EncryptionCertificateId,
            ExpirationDateTime,
            Id,
            IncludeResourceData,
            LatestSupportedTlsVersion,
            LifecycleNotificationUrl,
            NotificationQueryOptions,
            NotificationUrl,
            NotificationUrlAppId,
            Resource,
        }
        public enum ApiPath
        {
            Subscriptions_Id,
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
    public partial class SubscriptionGetResponse : RestApiResponse
    {
        public string? ApplicationId { get; set; }
        public string? ChangeType { get; set; }
        public string? ClientState { get; set; }
        public string? CreatorId { get; set; }
        public string? EncryptionCertificate { get; set; }
        public string? EncryptionCertificateId { get; set; }
        public DateTimeOffset? ExpirationDateTime { get; set; }
        public string? Id { get; set; }
        public bool? IncludeResourceData { get; set; }
        public string? LatestSupportedTlsVersion { get; set; }
        public string? LifecycleNotificationUrl { get; set; }
        public string? NotificationQueryOptions { get; set; }
        public string? NotificationUrl { get; set; }
        public string? NotificationUrlAppId { get; set; }
        public string? Resource { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subscription-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SubscriptionGetResponse> SubscriptionGetAsync()
        {
            var p = new SubscriptionGetParameter();
            return await this.SendAsync<SubscriptionGetParameter, SubscriptionGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subscription-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SubscriptionGetResponse> SubscriptionGetAsync(CancellationToken cancellationToken)
        {
            var p = new SubscriptionGetParameter();
            return await this.SendAsync<SubscriptionGetParameter, SubscriptionGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subscription-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SubscriptionGetResponse> SubscriptionGetAsync(SubscriptionGetParameter parameter)
        {
            return await this.SendAsync<SubscriptionGetParameter, SubscriptionGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subscription-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SubscriptionGetResponse> SubscriptionGetAsync(SubscriptionGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SubscriptionGetParameter, SubscriptionGetResponse>(parameter, cancellationToken);
        }
    }
}
