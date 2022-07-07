using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneCompanytermsTermsandconditionsacceptancestatusGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_TermsAndConditions_TermsAndConditionsId_AcceptanceStatuses_TermsAndConditionsAcceptanceStatusId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_TermsAndConditions_TermsAndConditionsId_AcceptanceStatuses_TermsAndConditionsAcceptanceStatusId: return $"/deviceManagement/termsAndConditions/{TermsAndConditionsId}/acceptanceStatuses/{TermsAndConditionsAcceptanceStatusId}";
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
        public string TermsAndConditionsId { get; set; }
        public string TermsAndConditionsAcceptanceStatusId { get; set; }
    }
    public partial class IntuneCompanytermsTermsandconditionsacceptancestatusGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? UserDisplayName { get; set; }
        public Int32? AcceptedVersion { get; set; }
        public DateTimeOffset? AcceptedDateTime { get; set; }
        public string? UserPrincipalName { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditionsacceptancestatus-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsacceptancestatusGetResponse> IntuneCompanytermsTermsandconditionsacceptancestatusGetAsync()
        {
            var p = new IntuneCompanytermsTermsandconditionsacceptancestatusGetParameter();
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsacceptancestatusGetParameter, IntuneCompanytermsTermsandconditionsacceptancestatusGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditionsacceptancestatus-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsacceptancestatusGetResponse> IntuneCompanytermsTermsandconditionsacceptancestatusGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneCompanytermsTermsandconditionsacceptancestatusGetParameter();
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsacceptancestatusGetParameter, IntuneCompanytermsTermsandconditionsacceptancestatusGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditionsacceptancestatus-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsacceptancestatusGetResponse> IntuneCompanytermsTermsandconditionsacceptancestatusGetAsync(IntuneCompanytermsTermsandconditionsacceptancestatusGetParameter parameter)
        {
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsacceptancestatusGetParameter, IntuneCompanytermsTermsandconditionsacceptancestatusGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditionsacceptancestatus-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsacceptancestatusGetResponse> IntuneCompanytermsTermsandconditionsacceptancestatusGetAsync(IntuneCompanytermsTermsandconditionsacceptancestatusGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsacceptancestatusGetParameter, IntuneCompanytermsTermsandconditionsacceptancestatusGetResponse>(parameter, cancellationToken);
        }
    }
}
