using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/subscription-post-subscriptions?view=graph-rest-1.0
    /// </summary>
    public partial class SubscriptionPostSubscriptionsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Subscriptions: return $"/subscriptions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Subscriptions,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
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
    public partial class SubscriptionPostSubscriptionsResponse : RestApiResponse
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
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/subscription-post-subscriptions?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/subscription-post-subscriptions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SubscriptionPostSubscriptionsResponse> SubscriptionPostSubscriptionsAsync()
        {
            var p = new SubscriptionPostSubscriptionsParameter();
            return await this.SendAsync<SubscriptionPostSubscriptionsParameter, SubscriptionPostSubscriptionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/subscription-post-subscriptions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SubscriptionPostSubscriptionsResponse> SubscriptionPostSubscriptionsAsync(CancellationToken cancellationToken)
        {
            var p = new SubscriptionPostSubscriptionsParameter();
            return await this.SendAsync<SubscriptionPostSubscriptionsParameter, SubscriptionPostSubscriptionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/subscription-post-subscriptions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SubscriptionPostSubscriptionsResponse> SubscriptionPostSubscriptionsAsync(SubscriptionPostSubscriptionsParameter parameter)
        {
            return await this.SendAsync<SubscriptionPostSubscriptionsParameter, SubscriptionPostSubscriptionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/subscription-post-subscriptions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SubscriptionPostSubscriptionsResponse> SubscriptionPostSubscriptionsAsync(SubscriptionPostSubscriptionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SubscriptionPostSubscriptionsParameter, SubscriptionPostSubscriptionsResponse>(parameter, cancellationToken);
        }
    }
}
