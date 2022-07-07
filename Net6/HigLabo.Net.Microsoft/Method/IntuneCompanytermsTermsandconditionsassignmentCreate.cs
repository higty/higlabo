using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneCompanytermsTermsandconditionsassignmentCreateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_TermsAndConditions_TermsAndConditionsId_Assignments,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_TermsAndConditions_TermsAndConditionsId_Assignments: return $"/deviceManagement/termsAndConditions/{TermsAndConditionsId}/assignments";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public DeviceAndAppManagementAssignmentTarget? Target { get; set; }
        public string TermsAndConditionsId { get; set; }
    }
    public partial class IntuneCompanytermsTermsandconditionsassignmentCreateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public DeviceAndAppManagementAssignmentTarget? Target { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditionsassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsassignmentCreateResponse> IntuneCompanytermsTermsandconditionsassignmentCreateAsync()
        {
            var p = new IntuneCompanytermsTermsandconditionsassignmentCreateParameter();
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsassignmentCreateParameter, IntuneCompanytermsTermsandconditionsassignmentCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditionsassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsassignmentCreateResponse> IntuneCompanytermsTermsandconditionsassignmentCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneCompanytermsTermsandconditionsassignmentCreateParameter();
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsassignmentCreateParameter, IntuneCompanytermsTermsandconditionsassignmentCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditionsassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsassignmentCreateResponse> IntuneCompanytermsTermsandconditionsassignmentCreateAsync(IntuneCompanytermsTermsandconditionsassignmentCreateParameter parameter)
        {
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsassignmentCreateParameter, IntuneCompanytermsTermsandconditionsassignmentCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditionsassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsassignmentCreateResponse> IntuneCompanytermsTermsandconditionsassignmentCreateAsync(IntuneCompanytermsTermsandconditionsassignmentCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsassignmentCreateParameter, IntuneCompanytermsTermsandconditionsassignmentCreateResponse>(parameter, cancellationToken);
        }
    }
}
