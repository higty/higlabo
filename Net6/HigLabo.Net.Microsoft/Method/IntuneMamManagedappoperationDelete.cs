using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamManagedappoperationDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_ManagedAppRegistrations_ManagedAppRegistrationId_Operations_ManagedAppOperationId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_ManagedAppRegistrations_ManagedAppRegistrationId_Operations_ManagedAppOperationId: return $"/deviceAppManagement/managedAppRegistrations/{ManagedAppRegistrationId}/operations/{ManagedAppOperationId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string ManagedAppRegistrationId { get; set; }
        public string ManagedAppOperationId { get; set; }
    }
    public partial class IntuneMamManagedappoperationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappoperation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappoperationDeleteResponse> IntuneMamManagedappoperationDeleteAsync()
        {
            var p = new IntuneMamManagedappoperationDeleteParameter();
            return await this.SendAsync<IntuneMamManagedappoperationDeleteParameter, IntuneMamManagedappoperationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappoperation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappoperationDeleteResponse> IntuneMamManagedappoperationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamManagedappoperationDeleteParameter();
            return await this.SendAsync<IntuneMamManagedappoperationDeleteParameter, IntuneMamManagedappoperationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappoperation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappoperationDeleteResponse> IntuneMamManagedappoperationDeleteAsync(IntuneMamManagedappoperationDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneMamManagedappoperationDeleteParameter, IntuneMamManagedappoperationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappoperation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappoperationDeleteResponse> IntuneMamManagedappoperationDeleteAsync(IntuneMamManagedappoperationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamManagedappoperationDeleteParameter, IntuneMamManagedappoperationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
