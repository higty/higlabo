using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingOrganizationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Organization_OrganizationId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Organization_OrganizationId: return $"/organization/{OrganizationId}";
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
        public string OrganizationId { get; set; }
    }
    public partial class IntuneOnboardingOrganizationGetResponse : RestApiResponse
    {
        public enum OrganizationMdmAuthority
        {
            Unknown,
            Intune,
            Sccm,
            Office365,
        }

        public string? Id { get; set; }
        public MdmAuthority? MobileDeviceManagementAuthority { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-organization-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingOrganizationGetResponse> IntuneOnboardingOrganizationGetAsync()
        {
            var p = new IntuneOnboardingOrganizationGetParameter();
            return await this.SendAsync<IntuneOnboardingOrganizationGetParameter, IntuneOnboardingOrganizationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-organization-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingOrganizationGetResponse> IntuneOnboardingOrganizationGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingOrganizationGetParameter();
            return await this.SendAsync<IntuneOnboardingOrganizationGetParameter, IntuneOnboardingOrganizationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-organization-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingOrganizationGetResponse> IntuneOnboardingOrganizationGetAsync(IntuneOnboardingOrganizationGetParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingOrganizationGetParameter, IntuneOnboardingOrganizationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-organization-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingOrganizationGetResponse> IntuneOnboardingOrganizationGetAsync(IntuneOnboardingOrganizationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingOrganizationGetParameter, IntuneOnboardingOrganizationGetResponse>(parameter, cancellationToken);
        }
    }
}
