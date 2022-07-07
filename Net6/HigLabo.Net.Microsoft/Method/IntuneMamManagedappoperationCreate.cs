using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamManagedappoperationCreateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceAppManagement_ManagedAppRegistrations_ManagedAppRegistrationId_Operations,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_ManagedAppRegistrations_ManagedAppRegistrationId_Operations: return $"/deviceAppManagement/managedAppRegistrations/{ManagedAppRegistrationId}/operations";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? State { get; set; }
        public string? Id { get; set; }
        public string? Version { get; set; }
        public string ManagedAppRegistrationId { get; set; }
    }
    public partial class IntuneMamManagedappoperationCreateResponse : RestApiResponse
    {
        public string? DisplayName { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? State { get; set; }
        public string? Id { get; set; }
        public string? Version { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappoperation-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappoperationCreateResponse> IntuneMamManagedappoperationCreateAsync()
        {
            var p = new IntuneMamManagedappoperationCreateParameter();
            return await this.SendAsync<IntuneMamManagedappoperationCreateParameter, IntuneMamManagedappoperationCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappoperation-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappoperationCreateResponse> IntuneMamManagedappoperationCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamManagedappoperationCreateParameter();
            return await this.SendAsync<IntuneMamManagedappoperationCreateParameter, IntuneMamManagedappoperationCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappoperation-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappoperationCreateResponse> IntuneMamManagedappoperationCreateAsync(IntuneMamManagedappoperationCreateParameter parameter)
        {
            return await this.SendAsync<IntuneMamManagedappoperationCreateParameter, IntuneMamManagedappoperationCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappoperation-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappoperationCreateResponse> IntuneMamManagedappoperationCreateAsync(IntuneMamManagedappoperationCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamManagedappoperationCreateParameter, IntuneMamManagedappoperationCreateResponse>(parameter, cancellationToken);
        }
    }
}
