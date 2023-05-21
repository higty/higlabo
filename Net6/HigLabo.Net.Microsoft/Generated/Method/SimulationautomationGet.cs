using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/simulationautomation-get?view=graph-rest-1.0
    /// </summary>
    public partial class SimulationautomationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SimulationAutomationId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_AttackSimulation_SimulationAutomations_SimulationAutomationId: return $"/security/attackSimulation/simulationAutomations/{SimulationAutomationId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Security_AttackSimulation_SimulationAutomations_SimulationAutomationId,
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
    public partial class SimulationautomationGetResponse : RestApiResponse
    {
        public enum SimulationAutomationSimulationAutomationStatus
        {
            Unknown,
            Draft,
            NotRunning,
            Running,
            Completed,
            UnknownFutureValue,
        }

        public EmailIdentity? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public EmailIdentity? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? LastRunDateTime { get; set; }
        public DateTimeOffset? NextRunDateTime { get; set; }
        public SimulationAutomationSimulationAutomationStatus Status { get; set; }
        public SimulationAutomationRun[]? Runs { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/simulationautomation-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/simulationautomation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SimulationautomationGetResponse> SimulationautomationGetAsync()
        {
            var p = new SimulationautomationGetParameter();
            return await this.SendAsync<SimulationautomationGetParameter, SimulationautomationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/simulationautomation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SimulationautomationGetResponse> SimulationautomationGetAsync(CancellationToken cancellationToken)
        {
            var p = new SimulationautomationGetParameter();
            return await this.SendAsync<SimulationautomationGetParameter, SimulationautomationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/simulationautomation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SimulationautomationGetResponse> SimulationautomationGetAsync(SimulationautomationGetParameter parameter)
        {
            return await this.SendAsync<SimulationautomationGetParameter, SimulationautomationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/simulationautomation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SimulationautomationGetResponse> SimulationautomationGetAsync(SimulationautomationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SimulationautomationGetParameter, SimulationautomationGetResponse>(parameter, cancellationToken);
        }
    }
}
