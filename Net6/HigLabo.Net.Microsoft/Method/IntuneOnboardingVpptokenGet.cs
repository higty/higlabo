using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingVpptokenGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement_VppTokens_VppTokenId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_VppTokens_VppTokenId: return $"/deviceAppManagement/vppTokens/{VppTokenId}";
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
        public string VppTokenId { get; set; }
    }
    public partial class IntuneOnboardingVpptokenGetResponse : RestApiResponse
    {
        public enum VppTokenVppTokenAccountType
        {
            Business,
            Education,
        }
        public enum VppTokenVppTokenState
        {
            Unknown,
            Valid,
            Expired,
            Invalid,
            AssignedToExternalMDM,
        }
        public enum VppTokenVppTokenSyncStatus
        {
            None,
            InProgress,
            Completed,
            Failed,
        }

        public string? Id { get; set; }
        public string? OrganizationName { get; set; }
        public VppTokenAccountType? VppTokenAccountType { get; set; }
        public string? AppleId { get; set; }
        public DateTimeOffset? ExpirationDateTime { get; set; }
        public DateTimeOffset? LastSyncDateTime { get; set; }
        public string? Token { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public VppTokenState? State { get; set; }
        public VppTokenSyncStatus? LastSyncStatus { get; set; }
        public bool? AutomaticallyUpdateApps { get; set; }
        public string? CountryOrRegion { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-vpptoken-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingVpptokenGetResponse> IntuneOnboardingVpptokenGetAsync()
        {
            var p = new IntuneOnboardingVpptokenGetParameter();
            return await this.SendAsync<IntuneOnboardingVpptokenGetParameter, IntuneOnboardingVpptokenGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-vpptoken-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingVpptokenGetResponse> IntuneOnboardingVpptokenGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingVpptokenGetParameter();
            return await this.SendAsync<IntuneOnboardingVpptokenGetParameter, IntuneOnboardingVpptokenGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-vpptoken-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingVpptokenGetResponse> IntuneOnboardingVpptokenGetAsync(IntuneOnboardingVpptokenGetParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingVpptokenGetParameter, IntuneOnboardingVpptokenGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-vpptoken-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingVpptokenGetResponse> IntuneOnboardingVpptokenGetAsync(IntuneOnboardingVpptokenGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingVpptokenGetParameter, IntuneOnboardingVpptokenGetResponse>(parameter, cancellationToken);
        }
    }
}
