using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneCompanytermsTermsandconditionsassignmentDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_TermsAndConditions_TermsAndConditionsId_Assignments_TermsAndConditionsAssignmentId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_TermsAndConditions_TermsAndConditionsId_Assignments_TermsAndConditionsAssignmentId: return $"/deviceManagement/termsAndConditions/{TermsAndConditionsId}/assignments/{TermsAndConditionsAssignmentId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string TermsAndConditionsId { get; set; }
        public string TermsAndConditionsAssignmentId { get; set; }
    }
    public partial class IntuneCompanytermsTermsandconditionsassignmentDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditionsassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsassignmentDeleteResponse> IntuneCompanytermsTermsandconditionsassignmentDeleteAsync()
        {
            var p = new IntuneCompanytermsTermsandconditionsassignmentDeleteParameter();
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsassignmentDeleteParameter, IntuneCompanytermsTermsandconditionsassignmentDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditionsassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsassignmentDeleteResponse> IntuneCompanytermsTermsandconditionsassignmentDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneCompanytermsTermsandconditionsassignmentDeleteParameter();
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsassignmentDeleteParameter, IntuneCompanytermsTermsandconditionsassignmentDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditionsassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsassignmentDeleteResponse> IntuneCompanytermsTermsandconditionsassignmentDeleteAsync(IntuneCompanytermsTermsandconditionsassignmentDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsassignmentDeleteParameter, IntuneCompanytermsTermsandconditionsassignmentDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditionsassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsassignmentDeleteResponse> IntuneCompanytermsTermsandconditionsassignmentDeleteAsync(IntuneCompanytermsTermsandconditionsassignmentDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsassignmentDeleteParameter, IntuneCompanytermsTermsandconditionsassignmentDeleteResponse>(parameter, cancellationToken);
        }
    }
}
