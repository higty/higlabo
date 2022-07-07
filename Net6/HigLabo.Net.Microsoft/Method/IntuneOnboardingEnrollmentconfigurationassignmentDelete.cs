using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingEnrollmentconfigurationassignmentDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_DeviceEnrollmentConfigurations_DeviceEnrollmentConfigurationId_Assignments_EnrollmentConfigurationAssignmentId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceEnrollmentConfigurations_DeviceEnrollmentConfigurationId_Assignments_EnrollmentConfigurationAssignmentId: return $"/deviceManagement/deviceEnrollmentConfigurations/{DeviceEnrollmentConfigurationId}/assignments/{EnrollmentConfigurationAssignmentId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string DeviceEnrollmentConfigurationId { get; set; }
        public string EnrollmentConfigurationAssignmentId { get; set; }
    }
    public partial class IntuneOnboardingEnrollmentconfigurationassignmentDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-enrollmentconfigurationassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingEnrollmentconfigurationassignmentDeleteResponse> IntuneOnboardingEnrollmentconfigurationassignmentDeleteAsync()
        {
            var p = new IntuneOnboardingEnrollmentconfigurationassignmentDeleteParameter();
            return await this.SendAsync<IntuneOnboardingEnrollmentconfigurationassignmentDeleteParameter, IntuneOnboardingEnrollmentconfigurationassignmentDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-enrollmentconfigurationassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingEnrollmentconfigurationassignmentDeleteResponse> IntuneOnboardingEnrollmentconfigurationassignmentDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingEnrollmentconfigurationassignmentDeleteParameter();
            return await this.SendAsync<IntuneOnboardingEnrollmentconfigurationassignmentDeleteParameter, IntuneOnboardingEnrollmentconfigurationassignmentDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-enrollmentconfigurationassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingEnrollmentconfigurationassignmentDeleteResponse> IntuneOnboardingEnrollmentconfigurationassignmentDeleteAsync(IntuneOnboardingEnrollmentconfigurationassignmentDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingEnrollmentconfigurationassignmentDeleteParameter, IntuneOnboardingEnrollmentconfigurationassignmentDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-enrollmentconfigurationassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingEnrollmentconfigurationassignmentDeleteResponse> IntuneOnboardingEnrollmentconfigurationassignmentDeleteAsync(IntuneOnboardingEnrollmentconfigurationassignmentDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingEnrollmentconfigurationassignmentDeleteParameter, IntuneOnboardingEnrollmentconfigurationassignmentDeleteResponse>(parameter, cancellationToken);
        }
    }
}
