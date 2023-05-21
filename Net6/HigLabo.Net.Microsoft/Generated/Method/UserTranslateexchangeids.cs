using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-translateexchangeids?view=graph-rest-1.0
    /// </summary>
    public partial class UserTranslateExchangeidsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_TranslateExchangeIds: return $"/me/translateExchangeIds";
                    case ApiPath.Users_IdOruserPrincipalName_TranslateExchangeIds: return $"/users/{IdOrUserPrincipalName}/translateExchangeIds";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_TranslateExchangeIds,
            Users_IdOruserPrincipalName_TranslateExchangeIds,
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
        public String[]? InputIds { get; set; }
        public string? SourceIdType { get; set; }
        public string? TargetIdType { get; set; }
    }
    public partial class UserTranslateExchangeidsResponse : RestApiResponse
    {
        public ConvertIdResult[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-translateexchangeids?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-translateexchangeids?view=graph-rest-1.0
        /// </summary>
        public async Task<UserTranslateExchangeidsResponse> UserTranslateExchangeidsAsync()
        {
            var p = new UserTranslateExchangeidsParameter();
            return await this.SendAsync<UserTranslateExchangeidsParameter, UserTranslateExchangeidsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-translateexchangeids?view=graph-rest-1.0
        /// </summary>
        public async Task<UserTranslateExchangeidsResponse> UserTranslateExchangeidsAsync(CancellationToken cancellationToken)
        {
            var p = new UserTranslateExchangeidsParameter();
            return await this.SendAsync<UserTranslateExchangeidsParameter, UserTranslateExchangeidsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-translateexchangeids?view=graph-rest-1.0
        /// </summary>
        public async Task<UserTranslateExchangeidsResponse> UserTranslateExchangeidsAsync(UserTranslateExchangeidsParameter parameter)
        {
            return await this.SendAsync<UserTranslateExchangeidsParameter, UserTranslateExchangeidsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-translateexchangeids?view=graph-rest-1.0
        /// </summary>
        public async Task<UserTranslateExchangeidsResponse> UserTranslateExchangeidsAsync(UserTranslateExchangeidsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserTranslateExchangeidsParameter, UserTranslateExchangeidsResponse>(parameter, cancellationToken);
        }
    }
}
