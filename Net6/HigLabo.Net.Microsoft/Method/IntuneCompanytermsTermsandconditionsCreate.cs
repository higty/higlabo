using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneCompanytermsTermsandconditionsCreateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_TermsAndConditions,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_TermsAndConditions: return $"/deviceManagement/termsAndConditions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        public string? BodyText { get; set; }
        public string? AcceptanceStatement { get; set; }
        public Int32? Version { get; set; }
    }
    public partial class IntuneCompanytermsTermsandconditionsCreateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        public string? BodyText { get; set; }
        public string? AcceptanceStatement { get; set; }
        public Int32? Version { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditions-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsCreateResponse> IntuneCompanytermsTermsandconditionsCreateAsync()
        {
            var p = new IntuneCompanytermsTermsandconditionsCreateParameter();
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsCreateParameter, IntuneCompanytermsTermsandconditionsCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditions-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsCreateResponse> IntuneCompanytermsTermsandconditionsCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneCompanytermsTermsandconditionsCreateParameter();
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsCreateParameter, IntuneCompanytermsTermsandconditionsCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditions-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsCreateResponse> IntuneCompanytermsTermsandconditionsCreateAsync(IntuneCompanytermsTermsandconditionsCreateParameter parameter)
        {
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsCreateParameter, IntuneCompanytermsTermsandconditionsCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-termsandconditions-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsTermsandconditionsCreateResponse> IntuneCompanytermsTermsandconditionsCreateAsync(IntuneCompanytermsTermsandconditionsCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneCompanytermsTermsandconditionsCreateParameter, IntuneCompanytermsTermsandconditionsCreateResponse>(parameter, cancellationToken);
        }
    }
}
