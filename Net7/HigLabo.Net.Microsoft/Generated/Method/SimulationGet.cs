using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/simulation-get?view=graph-rest-1.0
    /// </summary>
    public partial class SimulationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SimulationId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_AttackSimulation_Simulations_SimulationId: return $"/security/attackSimulation/simulations/{SimulationId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AttackTechnique,
            AttackType,
            AutomationId,
            CompletionDateTime,
            CreatedBy,
            CreatedDateTime,
            Description,
            DisplayName,
            Id,
            IsAutomated,
            LastModifiedBy,
            LastModifiedDateTime,
            LaunchDateTime,
            PayloadDeliveryPlatform,
            Report,
            Status,
        }
        public enum ApiPath
        {
            Security_AttackSimulation_Simulations_SimulationId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    public partial class SimulationGetResponse : RestApiResponse
    {
        public enum SimulationSimulationAttackTechnique
        {
            Unknown,
            CredentialHarvesting,
            AttachmentMalware,
            DriveByUrl,
            LinkInAttachment,
            LinkToMalwareFile,
            UnknownFutureValue,
        }
        public enum SimulationSimulationAttackType
        {
            Unknown,
            Social,
            Cloud,
            Endpoint,
            UnknownFutureValue,
        }
        public enum SimulationPayloadDeliveryPlatform
        {
            Unknown,
            Sms,
            Email,
            Teams,
            UnknownFutureValue,
        }
        public enum SimulationSimulationStatus
        {
            Unknown,
            Draft,
            Running,
            Scheduled,
            Succeeded,
            Failed,
            Cancelled,
            Excluded,
            UnknownFutureValue,
        }

        public SimulationSimulationAttackTechnique AttackTechnique { get; set; }
        public SimulationSimulationAttackType AttackType { get; set; }
        public string? AutomationId { get; set; }
        public DateTimeOffset? CompletionDateTime { get; set; }
        public EmailIdentity? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsAutomated { get; set; }
        public EmailIdentity? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? LaunchDateTime { get; set; }
        public SimulationPayloadDeliveryPlatform PayloadDeliveryPlatform { get; set; }
        public SimulationReport? Report { get; set; }
        public SimulationSimulationStatus Status { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/simulation-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/simulation-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SimulationGetResponse> SimulationGetAsync()
        {
            var p = new SimulationGetParameter();
            return await this.SendAsync<SimulationGetParameter, SimulationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/simulation-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SimulationGetResponse> SimulationGetAsync(CancellationToken cancellationToken)
        {
            var p = new SimulationGetParameter();
            return await this.SendAsync<SimulationGetParameter, SimulationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/simulation-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SimulationGetResponse> SimulationGetAsync(SimulationGetParameter parameter)
        {
            return await this.SendAsync<SimulationGetParameter, SimulationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/simulation-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SimulationGetResponse> SimulationGetAsync(SimulationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SimulationGetParameter, SimulationGetResponse>(parameter, cancellationToken);
        }
    }
}
