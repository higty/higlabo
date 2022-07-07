using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneCompanytermsTermsandconditionsacceptancestatusDeleteParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string TermsAndConditionsId { get; set; }
        public string TermsAndConditionsAcceptanceStatusId { get; set; }
    }
    public partial class IntuneCompanytermsTermsandconditionsacceptancestatusDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditionsacceptancestatus-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsacceptancestatusDeleteResponse> IntuneCompanytermsTermsandconditionsacceptancestatusDeleteAsync()
        {
            var p = new IntuneCompanytermsTermsandconditionsacceptancestatusDeleteParameter();
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsacceptancestatusDeleteParameter, IntuneCompanytermsTermsandconditionsacceptancestatusDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditionsacceptancestatus-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsacceptancestatusDeleteResponse> IntuneCompanytermsTermsandconditionsacceptancestatusDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneCompanytermsTermsandconditionsacceptancestatusDeleteParameter();
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsacceptancestatusDeleteParameter, IntuneCompanytermsTermsandconditionsacceptancestatusDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditionsacceptancestatus-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsacceptancestatusDeleteResponse> IntuneCompanytermsTermsandconditionsacceptancestatusDeleteAsync(IntuneCompanytermsTermsandconditionsacceptancestatusDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsacceptancestatusDeleteParameter, IntuneCompanytermsTermsandconditionsacceptancestatusDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditionsacceptancestatus-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsacceptancestatusDeleteResponse> IntuneCompanytermsTermsandconditionsacceptancestatusDeleteAsync(IntuneCompanytermsTermsandconditionsacceptancestatusDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsacceptancestatusDeleteParameter, IntuneCompanytermsTermsandconditionsacceptancestatusDeleteResponse>(parameter, cancellationToken);
        }
    }
}
