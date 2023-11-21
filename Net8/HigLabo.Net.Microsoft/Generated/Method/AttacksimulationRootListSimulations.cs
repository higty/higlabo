using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/attacksimulationroot-list-simulations?view=graph-rest-1.0
    /// </summary>
    public partial class AttacksimulationRootListSimulationsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_AttackSimulation_Simulations: return $"/security/attackSimulation/simulations";
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
            Security_AttackSimulation_Simulations,
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
    public partial class AttacksimulationRootListSimulationsResponse : RestApiResponse
    {
        public Simulation[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/attacksimulationroot-list-simulations?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/attacksimulationroot-list-simulations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AttacksimulationRootListSimulationsResponse> AttacksimulationRootListSimulationsAsync()
        {
            var p = new AttacksimulationRootListSimulationsParameter();
            return await this.SendAsync<AttacksimulationRootListSimulationsParameter, AttacksimulationRootListSimulationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/attacksimulationroot-list-simulations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AttacksimulationRootListSimulationsResponse> AttacksimulationRootListSimulationsAsync(CancellationToken cancellationToken)
        {
            var p = new AttacksimulationRootListSimulationsParameter();
            return await this.SendAsync<AttacksimulationRootListSimulationsParameter, AttacksimulationRootListSimulationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/attacksimulationroot-list-simulations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AttacksimulationRootListSimulationsResponse> AttacksimulationRootListSimulationsAsync(AttacksimulationRootListSimulationsParameter parameter)
        {
            return await this.SendAsync<AttacksimulationRootListSimulationsParameter, AttacksimulationRootListSimulationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/attacksimulationroot-list-simulations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AttacksimulationRootListSimulationsResponse> AttacksimulationRootListSimulationsAsync(AttacksimulationRootListSimulationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AttacksimulationRootListSimulationsParameter, AttacksimulationRootListSimulationsResponse>(parameter, cancellationToken);
        }
    }
}
