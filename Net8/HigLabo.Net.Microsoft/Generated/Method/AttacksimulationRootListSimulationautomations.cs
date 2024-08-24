using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/attacksimulationroot-list-simulationautomations?view=graph-rest-1.0
    /// </summary>
    public partial class AttackSimulationRootListSimulationautomationsParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class AttackSimulationRootListSimulationautomationsResponse : RestApiResponse<SimulationAutomation>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/attacksimulationroot-list-simulationautomations?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/attacksimulationroot-list-simulationautomations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AttackSimulationRootListSimulationautomationsResponse> AttackSimulationRootListSimulationautomationsAsync()
        {
            var p = new AttackSimulationRootListSimulationautomationsParameter();
            return await this.SendAsync<AttackSimulationRootListSimulationautomationsParameter, AttackSimulationRootListSimulationautomationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/attacksimulationroot-list-simulationautomations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AttackSimulationRootListSimulationautomationsResponse> AttackSimulationRootListSimulationautomationsAsync(CancellationToken cancellationToken)
        {
            var p = new AttackSimulationRootListSimulationautomationsParameter();
            return await this.SendAsync<AttackSimulationRootListSimulationautomationsParameter, AttackSimulationRootListSimulationautomationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/attacksimulationroot-list-simulationautomations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AttackSimulationRootListSimulationautomationsResponse> AttackSimulationRootListSimulationautomationsAsync(AttackSimulationRootListSimulationautomationsParameter parameter)
        {
            return await this.SendAsync<AttackSimulationRootListSimulationautomationsParameter, AttackSimulationRootListSimulationautomationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/attacksimulationroot-list-simulationautomations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AttackSimulationRootListSimulationautomationsResponse> AttackSimulationRootListSimulationautomationsAsync(AttackSimulationRootListSimulationautomationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AttackSimulationRootListSimulationautomationsParameter, AttackSimulationRootListSimulationautomationsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/attacksimulationroot-list-simulationautomations?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<SimulationAutomation> AttackSimulationRootListSimulationautomationsEnumerateAsync(AttackSimulationRootListSimulationautomationsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<AttackSimulationRootListSimulationautomationsParameter, AttackSimulationRootListSimulationautomationsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<SimulationAutomation>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
