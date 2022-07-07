using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamManagedappoperationListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
    }
    public partial class IntuneMamManagedappoperationListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-mam-managedappoperation?view=graph-rest-1.0
        /// </summary>
        public partial class ManagedAppOperation
        {
            public string? DisplayName { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public string? State { get; set; }
            public string? Id { get; set; }
            public string? Version { get; set; }
        }

        public ManagedAppOperation[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappoperation-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappoperationListResponse> IntuneMamManagedappoperationListAsync()
        {
            var p = new IntuneMamManagedappoperationListParameter();
            return await this.SendAsync<IntuneMamManagedappoperationListParameter, IntuneMamManagedappoperationListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappoperation-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappoperationListResponse> IntuneMamManagedappoperationListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamManagedappoperationListParameter();
            return await this.SendAsync<IntuneMamManagedappoperationListParameter, IntuneMamManagedappoperationListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappoperation-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappoperationListResponse> IntuneMamManagedappoperationListAsync(IntuneMamManagedappoperationListParameter parameter)
        {
            return await this.SendAsync<IntuneMamManagedappoperationListParameter, IntuneMamManagedappoperationListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappoperation-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappoperationListResponse> IntuneMamManagedappoperationListAsync(IntuneMamManagedappoperationListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamManagedappoperationListParameter, IntuneMamManagedappoperationListResponse>(parameter, cancellationToken);
        }
    }
}
