using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingEnrollmentconfigurationassignmentGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string DeviceEnrollmentConfigurationId { get; set; }
        public string EnrollmentConfigurationAssignmentId { get; set; }
    }
    public partial class IntuneOnboardingEnrollmentconfigurationassignmentGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public DeviceAndAppManagementAssignmentTarget? Target { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-enrollmentconfigurationassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingEnrollmentconfigurationassignmentGetResponse> IntuneOnboardingEnrollmentconfigurationassignmentGetAsync()
        {
            var p = new IntuneOnboardingEnrollmentconfigurationassignmentGetParameter();
            return await this.SendAsync<IntuneOnboardingEnrollmentconfigurationassignmentGetParameter, IntuneOnboardingEnrollmentconfigurationassignmentGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-enrollmentconfigurationassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingEnrollmentconfigurationassignmentGetResponse> IntuneOnboardingEnrollmentconfigurationassignmentGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingEnrollmentconfigurationassignmentGetParameter();
            return await this.SendAsync<IntuneOnboardingEnrollmentconfigurationassignmentGetParameter, IntuneOnboardingEnrollmentconfigurationassignmentGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-enrollmentconfigurationassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingEnrollmentconfigurationassignmentGetResponse> IntuneOnboardingEnrollmentconfigurationassignmentGetAsync(IntuneOnboardingEnrollmentconfigurationassignmentGetParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingEnrollmentconfigurationassignmentGetParameter, IntuneOnboardingEnrollmentconfigurationassignmentGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-enrollmentconfigurationassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingEnrollmentconfigurationassignmentGetResponse> IntuneOnboardingEnrollmentconfigurationassignmentGetAsync(IntuneOnboardingEnrollmentconfigurationassignmentGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingEnrollmentconfigurationassignmentGetParameter, IntuneOnboardingEnrollmentconfigurationassignmentGetResponse>(parameter, cancellationToken);
        }
    }
}
