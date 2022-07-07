using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingOrganizationListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Organization,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Organization: return $"/organization";
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
    }
    public partial class IntuneOnboardingOrganizationListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-onboarding-organization?view=graph-rest-1.0
        /// </summary>
        public partial class Organization
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

        public Organization[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-organization-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingOrganizationListResponse> IntuneOnboardingOrganizationListAsync()
        {
            var p = new IntuneOnboardingOrganizationListParameter();
            return await this.SendAsync<IntuneOnboardingOrganizationListParameter, IntuneOnboardingOrganizationListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-organization-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingOrganizationListResponse> IntuneOnboardingOrganizationListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingOrganizationListParameter();
            return await this.SendAsync<IntuneOnboardingOrganizationListParameter, IntuneOnboardingOrganizationListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-organization-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingOrganizationListResponse> IntuneOnboardingOrganizationListAsync(IntuneOnboardingOrganizationListParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingOrganizationListParameter, IntuneOnboardingOrganizationListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-organization-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingOrganizationListResponse> IntuneOnboardingOrganizationListAsync(IntuneOnboardingOrganizationListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingOrganizationListParameter, IntuneOnboardingOrganizationListResponse>(parameter, cancellationToken);
        }
    }
}
