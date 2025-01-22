using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/subscription-reauthorize?view=graph-rest-1.0
/// </summary>
public partial class SubscriptionReauthorizeParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? SubscriptionsId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Subscriptions_SubscriptionsId_Reauthorize: return $"/subscriptions/{SubscriptionsId}/reauthorize";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Subscriptions_SubscriptionsId_Reauthorize,
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
}
public partial class SubscriptionReauthorizeResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/subscription-reauthorize?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/subscription-reauthorize?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SubscriptionReauthorizeResponse> SubscriptionReauthorizeAsync()
    {
        var p = new SubscriptionReauthorizeParameter();
        return await this.SendAsync<SubscriptionReauthorizeParameter, SubscriptionReauthorizeResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/subscription-reauthorize?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SubscriptionReauthorizeResponse> SubscriptionReauthorizeAsync(CancellationToken cancellationToken)
    {
        var p = new SubscriptionReauthorizeParameter();
        return await this.SendAsync<SubscriptionReauthorizeParameter, SubscriptionReauthorizeResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/subscription-reauthorize?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SubscriptionReauthorizeResponse> SubscriptionReauthorizeAsync(SubscriptionReauthorizeParameter parameter)
    {
        return await this.SendAsync<SubscriptionReauthorizeParameter, SubscriptionReauthorizeResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/subscription-reauthorize?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SubscriptionReauthorizeResponse> SubscriptionReauthorizeAsync(SubscriptionReauthorizeParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SubscriptionReauthorizeParameter, SubscriptionReauthorizeResponse>(parameter, cancellationToken);
    }
}
