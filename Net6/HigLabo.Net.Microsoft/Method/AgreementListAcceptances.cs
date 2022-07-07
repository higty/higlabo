using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AgreementListAcceptancesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_TermsOfUse_Agreements_AgreementsId_Acceptances,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_TermsOfUse_Agreements_AgreementsId_Acceptances: return $"/identityGovernance/termsOfUse/agreements/{AgreementsId}/acceptances";
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
        public string AgreementsId { get; set; }
    }
    public partial class AgreementListAcceptancesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/agreementacceptance?view=graph-rest-1.0
        /// </summary>
        public partial class AgreementAcceptance
        {
            public enum AgreementAcceptancestring
            {
                Accepted,
                Declined,
            }

            public string? AgreementFileId { get; set; }
            public string? AgreementId { get; set; }
            public string? DeviceDisplayName { get; set; }
            public string? DeviceId { get; set; }
            public string? DeviceOSType { get; set; }
            public string? DeviceOSVersion { get; set; }
            public DateTimeOffset? ExpirationDateTime { get; set; }
            public string? Id { get; set; }
            public DateTimeOffset? RecordedDateTime { get; set; }
            public AgreementAcceptancestring State { get; set; }
            public string? UserDisplayName { get; set; }
            public string? UserEmail { get; set; }
            public string? UserId { get; set; }
            public string? UserPrincipalName { get; set; }
        }

        public AgreementAcceptance[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/agreement-list-acceptances?view=graph-rest-1.0
        /// </summary>
        public async Task<AgreementListAcceptancesResponse> AgreementListAcceptancesAsync()
        {
            var p = new AgreementListAcceptancesParameter();
            return await this.SendAsync<AgreementListAcceptancesParameter, AgreementListAcceptancesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/agreement-list-acceptances?view=graph-rest-1.0
        /// </summary>
        public async Task<AgreementListAcceptancesResponse> AgreementListAcceptancesAsync(CancellationToken cancellationToken)
        {
            var p = new AgreementListAcceptancesParameter();
            return await this.SendAsync<AgreementListAcceptancesParameter, AgreementListAcceptancesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/agreement-list-acceptances?view=graph-rest-1.0
        /// </summary>
        public async Task<AgreementListAcceptancesResponse> AgreementListAcceptancesAsync(AgreementListAcceptancesParameter parameter)
        {
            return await this.SendAsync<AgreementListAcceptancesParameter, AgreementListAcceptancesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/agreement-list-acceptances?view=graph-rest-1.0
        /// </summary>
        public async Task<AgreementListAcceptancesResponse> AgreementListAcceptancesAsync(AgreementListAcceptancesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AgreementListAcceptancesParameter, AgreementListAcceptancesResponse>(parameter, cancellationToken);
        }
    }
}
