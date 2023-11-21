using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/riskyuser-confirmcompromised?view=graph-rest-1.0
    /// </summary>
    public partial class RiskyUserConfirmcompromisedParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityProtection_RiskyUsers_ConfirmCompromised: return $"/identityProtection/riskyUsers/confirmCompromised";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            IdentityProtection_RiskyUsers_ConfirmCompromised,
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
        public String[]? UserIds { get; set; }
    }
    public partial class RiskyUserConfirmcompromisedResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/riskyuser-confirmcompromised?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyuser-confirmcompromised?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RiskyUserConfirmcompromisedResponse> RiskyUserConfirmcompromisedAsync()
        {
            var p = new RiskyUserConfirmcompromisedParameter();
            return await this.SendAsync<RiskyUserConfirmcompromisedParameter, RiskyUserConfirmcompromisedResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyuser-confirmcompromised?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RiskyUserConfirmcompromisedResponse> RiskyUserConfirmcompromisedAsync(CancellationToken cancellationToken)
        {
            var p = new RiskyUserConfirmcompromisedParameter();
            return await this.SendAsync<RiskyUserConfirmcompromisedParameter, RiskyUserConfirmcompromisedResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyuser-confirmcompromised?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RiskyUserConfirmcompromisedResponse> RiskyUserConfirmcompromisedAsync(RiskyUserConfirmcompromisedParameter parameter)
        {
            return await this.SendAsync<RiskyUserConfirmcompromisedParameter, RiskyUserConfirmcompromisedResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/riskyuser-confirmcompromised?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RiskyUserConfirmcompromisedResponse> RiskyUserConfirmcompromisedAsync(RiskyUserConfirmcompromisedParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RiskyUserConfirmcompromisedParameter, RiskyUserConfirmcompromisedResponse>(parameter, cancellationToken);
        }
    }
}
