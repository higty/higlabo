using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneCompanytermsTermsandconditionsDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_TermsAndConditions_TermsAndConditionsId,
            DeviceManagement_TermsAndConditions_TermsAndConditionsId_AcceptanceStatuses_TermsAndConditionsAcceptanceStatusId_TermsAndConditions,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_TermsAndConditions_TermsAndConditionsId: return $"/deviceManagement/termsAndConditions/{TermsAndConditionsId}";
                    case ApiPath.DeviceManagement_TermsAndConditions_TermsAndConditionsId_AcceptanceStatuses_TermsAndConditionsAcceptanceStatusId_TermsAndConditions: return $"/deviceManagement/termsAndConditions/{TermsAndConditionsId}/acceptanceStatuses/{TermsAndConditionsAcceptanceStatusId}/termsAndConditions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string TermsAndConditionsId { get; set; }
        public string TermsAndConditionsAcceptanceStatusId { get; set; }
    }
    public partial class IntuneCompanytermsTermsandconditionsDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditions-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsDeleteResponse> IntuneCompanytermsTermsandconditionsDeleteAsync()
        {
            var p = new IntuneCompanytermsTermsandconditionsDeleteParameter();
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsDeleteParameter, IntuneCompanytermsTermsandconditionsDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditions-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsDeleteResponse> IntuneCompanytermsTermsandconditionsDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneCompanytermsTermsandconditionsDeleteParameter();
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsDeleteParameter, IntuneCompanytermsTermsandconditionsDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditions-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsDeleteResponse> IntuneCompanytermsTermsandconditionsDeleteAsync(IntuneCompanytermsTermsandconditionsDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsDeleteParameter, IntuneCompanytermsTermsandconditionsDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditions-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsDeleteResponse> IntuneCompanytermsTermsandconditionsDeleteAsync(IntuneCompanytermsTermsandconditionsDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsDeleteParameter, IntuneCompanytermsTermsandconditionsDeleteResponse>(parameter, cancellationToken);
        }
    }
}
