using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/simulationautomation-list-runs?view=graph-rest-1.0
    /// </summary>
    public partial class SimulationautomationListRunsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SimulationAutomationId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_AttackSimulation_SimulationAutomations_SimulationAutomationId_Runs: return $"/security/attackSimulation/simulationAutomations/{SimulationAutomationId}/runs";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            EndDateTime,
            Id,
            SimulationId,
            StartDateTime,
            Status,
        }
        public enum ApiPath
        {
            Security_AttackSimulation_SimulationAutomations_SimulationAutomationId_Runs,
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
    public partial class SimulationautomationListRunsResponse : RestApiResponse
    {
        public SimulationAutomationRun[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/simulationautomation-list-runs?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/simulationautomation-list-runs?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SimulationautomationListRunsResponse> SimulationautomationListRunsAsync()
        {
            var p = new SimulationautomationListRunsParameter();
            return await this.SendAsync<SimulationautomationListRunsParameter, SimulationautomationListRunsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/simulationautomation-list-runs?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SimulationautomationListRunsResponse> SimulationautomationListRunsAsync(CancellationToken cancellationToken)
        {
            var p = new SimulationautomationListRunsParameter();
            return await this.SendAsync<SimulationautomationListRunsParameter, SimulationautomationListRunsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/simulationautomation-list-runs?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SimulationautomationListRunsResponse> SimulationautomationListRunsAsync(SimulationautomationListRunsParameter parameter)
        {
            return await this.SendAsync<SimulationautomationListRunsParameter, SimulationautomationListRunsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/simulationautomation-list-runs?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SimulationautomationListRunsResponse> SimulationautomationListRunsAsync(SimulationautomationListRunsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SimulationautomationListRunsParameter, SimulationautomationListRunsResponse>(parameter, cancellationToken);
        }
    }
}
