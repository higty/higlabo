using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingVpptokenSynclicensesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_VppTokens_VppTokenId_SyncLicenses,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_VppTokens_VppTokenId_SyncLicenses: return $"/deviceAppManagement/vppTokens/{VppTokenId}/syncLicenses";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string VppTokenId { get; set; }
    }
    public partial class IntuneOnboardingVpptokenSynclicensesResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-vpptoken-synclicenses?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingVpptokenSynclicensesResponse> IntuneOnboardingVpptokenSynclicensesAsync()
        {
            var p = new IntuneOnboardingVpptokenSynclicensesParameter();
            return await this.SendAsync<IntuneOnboardingVpptokenSynclicensesParameter, IntuneOnboardingVpptokenSynclicensesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-vpptoken-synclicenses?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingVpptokenSynclicensesResponse> IntuneOnboardingVpptokenSynclicensesAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingVpptokenSynclicensesParameter();
            return await this.SendAsync<IntuneOnboardingVpptokenSynclicensesParameter, IntuneOnboardingVpptokenSynclicensesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-vpptoken-synclicenses?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingVpptokenSynclicensesResponse> IntuneOnboardingVpptokenSynclicensesAsync(IntuneOnboardingVpptokenSynclicensesParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingVpptokenSynclicensesParameter, IntuneOnboardingVpptokenSynclicensesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-vpptoken-synclicenses?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingVpptokenSynclicensesResponse> IntuneOnboardingVpptokenSynclicensesAsync(IntuneOnboardingVpptokenSynclicensesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingVpptokenSynclicensesParameter, IntuneOnboardingVpptokenSynclicensesResponse>(parameter, cancellationToken);
        }
    }
}
