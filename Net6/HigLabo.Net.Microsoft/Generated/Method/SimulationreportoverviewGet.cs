using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/simulationreportoverview-get?view=graph-rest-1.0
    /// </summary>
    public partial class SimulationreportoverviewGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SimulationId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_AttackSimulation_Simulations_SimulationId_Report_Overview: return $"/security/attackSimulation/simulations/{SimulationId}/report/overview";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Security_AttackSimulation_Simulations_SimulationId_Report_Overview,
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
    public partial class SimulationreportoverviewGetResponse : RestApiResponse
    {
        public RecommendedAction[]? RecommendedActions { get; set; }
        public Int32? ResolvedTargetsCount { get; set; }
        public SimulationEventsContent? SimulationEventsContent { get; set; }
        public TrainingEventsContent? TrainingEventsContent { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/simulationreportoverview-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/simulationreportoverview-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SimulationreportoverviewGetResponse> SimulationreportoverviewGetAsync()
        {
            var p = new SimulationreportoverviewGetParameter();
            return await this.SendAsync<SimulationreportoverviewGetParameter, SimulationreportoverviewGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/simulationreportoverview-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SimulationreportoverviewGetResponse> SimulationreportoverviewGetAsync(CancellationToken cancellationToken)
        {
            var p = new SimulationreportoverviewGetParameter();
            return await this.SendAsync<SimulationreportoverviewGetParameter, SimulationreportoverviewGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/simulationreportoverview-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SimulationreportoverviewGetResponse> SimulationreportoverviewGetAsync(SimulationreportoverviewGetParameter parameter)
        {
            return await this.SendAsync<SimulationreportoverviewGetParameter, SimulationreportoverviewGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/simulationreportoverview-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SimulationreportoverviewGetResponse> SimulationreportoverviewGetAsync(SimulationreportoverviewGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SimulationreportoverviewGetParameter, SimulationreportoverviewGetResponse>(parameter, cancellationToken);
        }
    }
}
