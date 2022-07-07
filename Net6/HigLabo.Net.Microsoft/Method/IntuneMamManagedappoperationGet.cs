using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamManagedappoperationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string ManagedAppRegistrationId { get; set; }
        public string ManagedAppOperationId { get; set; }
    }
    public partial class IntuneMamManagedappoperationGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappoperation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappoperationGetResponse> IntuneMamManagedappoperationGetAsync()
        {
            var p = new IntuneMamManagedappoperationGetParameter();
            return await this.SendAsync<IntuneMamManagedappoperationGetParameter, IntuneMamManagedappoperationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappoperation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappoperationGetResponse> IntuneMamManagedappoperationGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamManagedappoperationGetParameter();
            return await this.SendAsync<IntuneMamManagedappoperationGetParameter, IntuneMamManagedappoperationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappoperation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappoperationGetResponse> IntuneMamManagedappoperationGetAsync(IntuneMamManagedappoperationGetParameter parameter)
        {
            return await this.SendAsync<IntuneMamManagedappoperationGetParameter, IntuneMamManagedappoperationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappoperation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappoperationGetResponse> IntuneMamManagedappoperationGetAsync(IntuneMamManagedappoperationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamManagedappoperationGetParameter, IntuneMamManagedappoperationGetResponse>(parameter, cancellationToken);
        }
    }
}
