using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termsofusecontainer-list-agreements?view=graph-rest-1.0
    /// </summary>
    public partial class TermsofusecontainerListAgreementsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_TermsOfUse_Agreements: return $"/identityGovernance/termsOfUse/agreements";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            DisplayName,
            Id,
            IsPerDeviceAcceptanceRequired,
            IsViewingBeforeAcceptanceRequired,
            TermsExpiration,
            UserReacceptRequiredFrequency,
            Acceptances,
            File,
            Files,
        }
        public enum ApiPath
        {
            IdentityGovernance_TermsOfUse_Agreements,
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
    public partial class TermsofusecontainerListAgreementsResponse : RestApiResponse
    {
        public Agreement[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termsofusecontainer-list-agreements?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termsofusecontainer-list-agreements?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TermsofusecontainerListAgreementsResponse> TermsofusecontainerListAgreementsAsync()
        {
            var p = new TermsofusecontainerListAgreementsParameter();
            return await this.SendAsync<TermsofusecontainerListAgreementsParameter, TermsofusecontainerListAgreementsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termsofusecontainer-list-agreements?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TermsofusecontainerListAgreementsResponse> TermsofusecontainerListAgreementsAsync(CancellationToken cancellationToken)
        {
            var p = new TermsofusecontainerListAgreementsParameter();
            return await this.SendAsync<TermsofusecontainerListAgreementsParameter, TermsofusecontainerListAgreementsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termsofusecontainer-list-agreements?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TermsofusecontainerListAgreementsResponse> TermsofusecontainerListAgreementsAsync(TermsofusecontainerListAgreementsParameter parameter)
        {
            return await this.SendAsync<TermsofusecontainerListAgreementsParameter, TermsofusecontainerListAgreementsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termsofusecontainer-list-agreements?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TermsofusecontainerListAgreementsResponse> TermsofusecontainerListAgreementsAsync(TermsofusecontainerListAgreementsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TermsofusecontainerListAgreementsParameter, TermsofusecontainerListAgreementsResponse>(parameter, cancellationToken);
        }
    }
}
