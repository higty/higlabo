using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneCompanytermsTermsandconditionsassignmentListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
    }
    public partial class IntuneCompanytermsTermsandconditionsassignmentListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-companyterms-termsandconditionsassignment?view=graph-rest-1.0
        /// </summary>
        public partial class TermsAndConditionsAssignment
        {
            public string? Id { get; set; }
            public DeviceAndAppManagementAssignmentTarget? Target { get; set; }
        }

        public TermsAndConditionsAssignment[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditionsassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsassignmentListResponse> IntuneCompanytermsTermsandconditionsassignmentListAsync()
        {
            var p = new IntuneCompanytermsTermsandconditionsassignmentListParameter();
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsassignmentListParameter, IntuneCompanytermsTermsandconditionsassignmentListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditionsassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsassignmentListResponse> IntuneCompanytermsTermsandconditionsassignmentListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneCompanytermsTermsandconditionsassignmentListParameter();
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsassignmentListParameter, IntuneCompanytermsTermsandconditionsassignmentListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditionsassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsassignmentListResponse> IntuneCompanytermsTermsandconditionsassignmentListAsync(IntuneCompanytermsTermsandconditionsassignmentListParameter parameter)
        {
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsassignmentListParameter, IntuneCompanytermsTermsandconditionsassignmentListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditionsassignment-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsassignmentListResponse> IntuneCompanytermsTermsandconditionsassignmentListAsync(IntuneCompanytermsTermsandconditionsassignmentListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsassignmentListParameter, IntuneCompanytermsTermsandconditionsassignmentListResponse>(parameter, cancellationToken);
        }
    }
}
