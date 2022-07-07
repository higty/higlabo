using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TermsofusecontainerListAgreementsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_TermsOfUse_Agreements,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_TermsOfUse_Agreements: return $"/identityGovernance/termsOfUse/agreements";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/agreement?view=graph-rest-1.0
        /// </summary>
        public partial class Agreement
        {
            public string? DisplayName { get; set; }
            public string? Id { get; set; }
            public bool? IsPerDeviceAcceptanceRequired { get; set; }
            public bool? IsViewingBeforeAcceptanceRequired { get; set; }
            public TermsExpiration? TermsExpiration { get; set; }
            public string? UserReacceptRequiredFrequency { get; set; }
        }

        public Agreement[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termsofusecontainer-list-agreements?view=graph-rest-1.0
        /// </summary>
        public async Task<TermsofusecontainerListAgreementsResponse> TermsofusecontainerListAgreementsAsync()
        {
            var p = new TermsofusecontainerListAgreementsParameter();
            return await this.SendAsync<TermsofusecontainerListAgreementsParameter, TermsofusecontainerListAgreementsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termsofusecontainer-list-agreements?view=graph-rest-1.0
        /// </summary>
        public async Task<TermsofusecontainerListAgreementsResponse> TermsofusecontainerListAgreementsAsync(CancellationToken cancellationToken)
        {
            var p = new TermsofusecontainerListAgreementsParameter();
            return await this.SendAsync<TermsofusecontainerListAgreementsParameter, TermsofusecontainerListAgreementsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termsofusecontainer-list-agreements?view=graph-rest-1.0
        /// </summary>
        public async Task<TermsofusecontainerListAgreementsResponse> TermsofusecontainerListAgreementsAsync(TermsofusecontainerListAgreementsParameter parameter)
        {
            return await this.SendAsync<TermsofusecontainerListAgreementsParameter, TermsofusecontainerListAgreementsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termsofusecontainer-list-agreements?view=graph-rest-1.0
        /// </summary>
        public async Task<TermsofusecontainerListAgreementsResponse> TermsofusecontainerListAgreementsAsync(TermsofusecontainerListAgreementsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TermsofusecontainerListAgreementsParameter, TermsofusecontainerListAgreementsResponse>(parameter, cancellationToken);
        }
    }
}
