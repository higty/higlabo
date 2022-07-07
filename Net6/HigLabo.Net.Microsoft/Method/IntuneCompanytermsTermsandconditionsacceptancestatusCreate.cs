using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneCompanytermsTermsandconditionsacceptancestatusCreateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_TermsAndConditions_TermsAndConditionsId_AcceptanceStatuses,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_TermsAndConditions_TermsAndConditionsId_AcceptanceStatuses: return $"/deviceManagement/termsAndConditions/{TermsAndConditionsId}/acceptanceStatuses";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? UserDisplayName { get; set; }
        public Int32? AcceptedVersion { get; set; }
        public DateTimeOffset? AcceptedDateTime { get; set; }
        public string? UserPrincipalName { get; set; }
        public string TermsAndConditionsId { get; set; }
    }
    public partial class IntuneCompanytermsTermsandconditionsacceptancestatusCreateResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditionsacceptancestatus-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsacceptancestatusCreateResponse> IntuneCompanytermsTermsandconditionsacceptancestatusCreateAsync()
        {
            var p = new IntuneCompanytermsTermsandconditionsacceptancestatusCreateParameter();
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsacceptancestatusCreateParameter, IntuneCompanytermsTermsandconditionsacceptancestatusCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditionsacceptancestatus-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsacceptancestatusCreateResponse> IntuneCompanytermsTermsandconditionsacceptancestatusCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneCompanytermsTermsandconditionsacceptancestatusCreateParameter();
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsacceptancestatusCreateParameter, IntuneCompanytermsTermsandconditionsacceptancestatusCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditionsacceptancestatus-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsacceptancestatusCreateResponse> IntuneCompanytermsTermsandconditionsacceptancestatusCreateAsync(IntuneCompanytermsTermsandconditionsacceptancestatusCreateParameter parameter)
        {
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsacceptancestatusCreateParameter, IntuneCompanytermsTermsandconditionsacceptancestatusCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditionsacceptancestatus-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsacceptancestatusCreateResponse> IntuneCompanytermsTermsandconditionsacceptancestatusCreateAsync(IntuneCompanytermsTermsandconditionsacceptancestatusCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsacceptancestatusCreateParameter, IntuneCompanytermsTermsandconditionsacceptancestatusCreateResponse>(parameter, cancellationToken);
        }
    }
}
