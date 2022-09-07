﻿using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SubscriptionDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SubscriptionId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Subscriptions_SubscriptionId: return $"/subscriptions/{SubscriptionId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Subscriptions_SubscriptionId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class SubscriptionDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subscription-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<SubscriptionDeleteResponse> SubscriptionDeleteAsync()
        {
            var p = new SubscriptionDeleteParameter();
            return await this.SendAsync<SubscriptionDeleteParameter, SubscriptionDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subscription-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<SubscriptionDeleteResponse> SubscriptionDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new SubscriptionDeleteParameter();
            return await this.SendAsync<SubscriptionDeleteParameter, SubscriptionDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subscription-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<SubscriptionDeleteResponse> SubscriptionDeleteAsync(SubscriptionDeleteParameter parameter)
        {
            return await this.SendAsync<SubscriptionDeleteParameter, SubscriptionDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/subscription-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<SubscriptionDeleteResponse> SubscriptionDeleteAsync(SubscriptionDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SubscriptionDeleteParameter, SubscriptionDeleteResponse>(parameter, cancellationToken);
        }
    }
}