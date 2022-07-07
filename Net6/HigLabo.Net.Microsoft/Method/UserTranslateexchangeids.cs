using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserTranslateexchangeidsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_TranslateExchangeIds,
            Users_IdOruserPrincipalName_TranslateExchangeIds,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_TranslateExchangeIds: return $"/me/translateExchangeIds";
                    case ApiPath.Users_IdOruserPrincipalName_TranslateExchangeIds: return $"/users/{IdOrUserPrincipalName}/translateExchangeIds";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public String[]? InputIds { get; set; }
        public string? SourceIdType { get; set; }
        public string? TargetIdType { get; set; }
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class UserTranslateexchangeidsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/convertidresult?view=graph-rest-1.0
        /// </summary>
        public partial class ConvertIdResult
        {
            public string? SourceId { get; set; }
            public string? TargetId { get; set; }
            public GenericError? ErrorDetails { get; set; }
        }

        public ConvertIdResult[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-translateexchangeids?view=graph-rest-1.0
        /// </summary>
        public async Task<UserTranslateexchangeidsResponse> UserTranslateexchangeidsAsync()
        {
            var p = new UserTranslateexchangeidsParameter();
            return await this.SendAsync<UserTranslateexchangeidsParameter, UserTranslateexchangeidsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-translateexchangeids?view=graph-rest-1.0
        /// </summary>
        public async Task<UserTranslateexchangeidsResponse> UserTranslateexchangeidsAsync(CancellationToken cancellationToken)
        {
            var p = new UserTranslateexchangeidsParameter();
            return await this.SendAsync<UserTranslateexchangeidsParameter, UserTranslateexchangeidsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-translateexchangeids?view=graph-rest-1.0
        /// </summary>
        public async Task<UserTranslateexchangeidsResponse> UserTranslateexchangeidsAsync(UserTranslateexchangeidsParameter parameter)
        {
            return await this.SendAsync<UserTranslateexchangeidsParameter, UserTranslateexchangeidsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-translateexchangeids?view=graph-rest-1.0
        /// </summary>
        public async Task<UserTranslateexchangeidsResponse> UserTranslateexchangeidsAsync(UserTranslateexchangeidsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserTranslateexchangeidsParameter, UserTranslateexchangeidsResponse>(parameter, cancellationToken);
        }
    }
}
