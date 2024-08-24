using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/attacksimulationroot-list-simulations?view=graph-rest-1.0
    /// </summary>
    public partial class AttackSimulationRootListSimulationsParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class AttackSimulationRootListSimulationsResponse : RestApiResponse<Simulation>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/attacksimulationroot-list-simulations?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/attacksimulationroot-list-simulations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AttackSimulationRootListSimulationsResponse> AttackSimulationRootListSimulationsAsync()
        {
            var p = new AttackSimulationRootListSimulationsParameter();
            return await this.SendAsync<AttackSimulationRootListSimulationsParameter, AttackSimulationRootListSimulationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/attacksimulationroot-list-simulations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AttackSimulationRootListSimulationsResponse> AttackSimulationRootListSimulationsAsync(CancellationToken cancellationToken)
        {
            var p = new AttackSimulationRootListSimulationsParameter();
            return await this.SendAsync<AttackSimulationRootListSimulationsParameter, AttackSimulationRootListSimulationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/attacksimulationroot-list-simulations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AttackSimulationRootListSimulationsResponse> AttackSimulationRootListSimulationsAsync(AttackSimulationRootListSimulationsParameter parameter)
        {
            return await this.SendAsync<AttackSimulationRootListSimulationsParameter, AttackSimulationRootListSimulationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/attacksimulationroot-list-simulations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AttackSimulationRootListSimulationsResponse> AttackSimulationRootListSimulationsAsync(AttackSimulationRootListSimulationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AttackSimulationRootListSimulationsParameter, AttackSimulationRootListSimulationsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/attacksimulationroot-list-simulations?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<Simulation> AttackSimulationRootListSimulationsEnumerateAsync(AttackSimulationRootListSimulationsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<AttackSimulationRootListSimulationsParameter, AttackSimulationRootListSimulationsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<Simulation>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
