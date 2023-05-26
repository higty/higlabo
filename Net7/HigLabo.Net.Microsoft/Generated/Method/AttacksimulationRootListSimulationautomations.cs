using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/attacksimulationroot-list-simulationautomations?view=graph-rest-1.0
    /// </summary>
    public partial class AttacksimulationRootListSimulationautomationsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_AttackSimulation_SimulationAutomations: return $"/security/attackSimulation/simulationAutomations";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            CreatedBy,
            CreatedDateTime,
            Description,
            DisplayName,
            Id,
            LastModifiedBy,
            LastModifiedDateTime,
            LastRunDateTime,
            NextRunDateTime,
            Status,
            Runs,
        }
        public enum ApiPath
        {
            Security_AttackSimulation_SimulationAutomations,
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
    public partial class AttacksimulationRootListSimulationautomationsResponse : RestApiResponse
    {
        public SimulationAutomation[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/attacksimulationroot-list-simulationautomations?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/attacksimulationroot-list-simulationautomations?view=graph-rest-1.0
        /// </summary>
        public async Task<AttacksimulationRootListSimulationautomationsResponse> AttacksimulationRootListSimulationautomationsAsync()
        {
            var p = new AttacksimulationRootListSimulationautomationsParameter();
            return await this.SendAsync<AttacksimulationRootListSimulationautomationsParameter, AttacksimulationRootListSimulationautomationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/attacksimulationroot-list-simulationautomations?view=graph-rest-1.0
        /// </summary>
        public async Task<AttacksimulationRootListSimulationautomationsResponse> AttacksimulationRootListSimulationautomationsAsync(CancellationToken cancellationToken)
        {
            var p = new AttacksimulationRootListSimulationautomationsParameter();
            return await this.SendAsync<AttacksimulationRootListSimulationautomationsParameter, AttacksimulationRootListSimulationautomationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/attacksimulationroot-list-simulationautomations?view=graph-rest-1.0
        /// </summary>
        public async Task<AttacksimulationRootListSimulationautomationsResponse> AttacksimulationRootListSimulationautomationsAsync(AttacksimulationRootListSimulationautomationsParameter parameter)
        {
            return await this.SendAsync<AttacksimulationRootListSimulationautomationsParameter, AttacksimulationRootListSimulationautomationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/attacksimulationroot-list-simulationautomations?view=graph-rest-1.0
        /// </summary>
        public async Task<AttacksimulationRootListSimulationautomationsResponse> AttacksimulationRootListSimulationautomationsAsync(AttacksimulationRootListSimulationautomationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AttacksimulationRootListSimulationautomationsParameter, AttacksimulationRootListSimulationautomationsResponse>(parameter, cancellationToken);
        }
    }
}
