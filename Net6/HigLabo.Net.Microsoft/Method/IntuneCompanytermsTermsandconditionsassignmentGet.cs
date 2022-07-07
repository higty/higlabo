using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneCompanytermsTermsandconditionsassignmentGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        public string TermsAndConditionsAssignmentId { get; set; }
    }
    public partial class IntuneCompanytermsTermsandconditionsassignmentGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public DeviceAndAppManagementAssignmentTarget? Target { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditionsassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsassignmentGetResponse> IntuneCompanytermsTermsandconditionsassignmentGetAsync()
        {
            var p = new IntuneCompanytermsTermsandconditionsassignmentGetParameter();
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsassignmentGetParameter, IntuneCompanytermsTermsandconditionsassignmentGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditionsassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsassignmentGetResponse> IntuneCompanytermsTermsandconditionsassignmentGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneCompanytermsTermsandconditionsassignmentGetParameter();
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsassignmentGetParameter, IntuneCompanytermsTermsandconditionsassignmentGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditionsassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsassignmentGetResponse> IntuneCompanytermsTermsandconditionsassignmentGetAsync(IntuneCompanytermsTermsandconditionsassignmentGetParameter parameter)
        {
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsassignmentGetParameter, IntuneCompanytermsTermsandconditionsassignmentGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditionsassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsassignmentGetResponse> IntuneCompanytermsTermsandconditionsassignmentGetAsync(IntuneCompanytermsTermsandconditionsassignmentGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsassignmentGetParameter, IntuneCompanytermsTermsandconditionsassignmentGetResponse>(parameter, cancellationToken);
        }
    }
}
