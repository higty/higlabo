using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AlertGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
            ActivityGroupName,
            AssignedTo,
            AzureSubscriptionId,
            AzureTenantId,
            Category,
            ClosedDateTime,
            CloudAppStates,
            Comments,
            Confidence,
            CreatedDateTime,
            Description,
            DetectionIds,
            EventDateTime,
            Feedback,
            FileStates,
            HostStates,
            Id,
            IncidentIds,
            LastModifiedDateTime,
            MalwareStates,
            NetworkConnections,
            Processes,
            RecommendedActions,
            RegistryKeyStates,
            SecurityResources,
            Severity,
            SourceMaterials,
            Status,
            Tags,
            Title,
            Triggers,
            UserStates,
            VendorInformation,
            VulnerabilityStates,
        }
        public enum ApiPath
        {
            Security_Alerts_Alert_id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Security_Alerts_Alert_id: return $"/security/alerts/{Alert_id}";
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
        public string Alert_id { get; set; }
    }
    public partial class AlertGetResponse : RestApiResponse
    {
        public enum AlertAlertFeedback
        {
            Unknown,
            TruePositive,
            FalsePositive,
            BenignPositive,
        }
        public enum AlertAlertSeverity
        {
            Unknown,
            Informational,
            Low,
            Medium,
            High,
        }
        public enum AlertAlertStatus
        {
            Unknown,
            NewAlert,
            InProgress,
            Resolved,
        }

        public string? ActivityGroupName { get; set; }
        public string? AssignedTo { get; set; }
        public string? AzureSubscriptionId { get; set; }
        public string? AzureTenantId { get; set; }
        public string? Category { get; set; }
        public DateTimeOffset? ClosedDateTime { get; set; }
        public CloudAppSecurityState[]? CloudAppStates { get; set; }
        public String[]? Comments { get; set; }
        public Int32? Confidence { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public String[]? DetectionIds { get; set; }
        public DateTimeOffset? EventDateTime { get; set; }
        public AlertAlertFeedback Feedback { get; set; }
        public FileSecurityState[]? FileStates { get; set; }
        public HostSecurityState[]? HostStates { get; set; }
        public string? Id { get; set; }
        public String[]? IncidentIds { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public MalwareState[]? MalwareStates { get; set; }
        public NetworkConnection[]? NetworkConnections { get; set; }
        public Process[]? Processes { get; set; }
        public String[]? RecommendedActions { get; set; }
        public RegistryKeyState[]? RegistryKeyStates { get; set; }
        public SecurityResource[]? SecurityResources { get; set; }
        public AlertAlertSeverity Severity { get; set; }
        public String[]? SourceMaterials { get; set; }
        public AlertAlertStatus Status { get; set; }
        public String[]? Tags { get; set; }
        public string? Title { get; set; }
        public AlertTrigger[]? Triggers { get; set; }
        public UserSecurityState[]? UserStates { get; set; }
        public SecurityVendorInformation? VendorInformation { get; set; }
        public VulnerabilityState[]? VulnerabilityStates { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/alert-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AlertGetResponse> AlertGetAsync()
        {
            var p = new AlertGetParameter();
            return await this.SendAsync<AlertGetParameter, AlertGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/alert-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AlertGetResponse> AlertGetAsync(CancellationToken cancellationToken)
        {
            var p = new AlertGetParameter();
            return await this.SendAsync<AlertGetParameter, AlertGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/alert-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AlertGetResponse> AlertGetAsync(AlertGetParameter parameter)
        {
            return await this.SendAsync<AlertGetParameter, AlertGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/alert-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AlertGetResponse> AlertGetAsync(AlertGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AlertGetParameter, AlertGetResponse>(parameter, cancellationToken);
        }
    }
}
