using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/signin-list?view=graph-rest-1.0
    /// </summary>
    public partial class SigninListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.UditLogs_SignIns: return $"/uditLogs/signIns";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AppDisplayName,
            AppId,
            AppliedConditionalAccessPolicies,
            ClientAppUsed,
            ConditionalAccessStatus,
            CorrelationId,
            CreatedDateTime,
            DeviceDetail,
            Id,
            IpAddress,
            IsInteractive,
            Location,
            ResourceDisplayName,
            ResourceId,
            RiskDetail,
            RiskEventTypes,
            RiskEventTypes_v2,
            RiskLevelAggregated,
            RiskLevelDuringSignIn,
            RiskState,
            Status,
            UserDisplayName,
            UserId,
            UserPrincipalName,
        }
        public enum ApiPath
        {
            UditLogs_SignIns,
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
    public partial class SigninListResponse : RestApiResponse
    {
        public SignIn[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/signin-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/signin-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SigninListResponse> SigninListAsync()
        {
            var p = new SigninListParameter();
            return await this.SendAsync<SigninListParameter, SigninListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/signin-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SigninListResponse> SigninListAsync(CancellationToken cancellationToken)
        {
            var p = new SigninListParameter();
            return await this.SendAsync<SigninListParameter, SigninListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/signin-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SigninListResponse> SigninListAsync(SigninListParameter parameter)
        {
            return await this.SendAsync<SigninListParameter, SigninListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/signin-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SigninListResponse> SigninListAsync(SigninListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SigninListParameter, SigninListResponse>(parameter, cancellationToken);
        }
    }
}
