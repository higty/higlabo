using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationsimulationusercoverage?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityreportsRootGetattackSimulationSimulationUsercoverageParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_Security_GetAttackSimulationSimulationUserCoverage: return $"/reports/security/getAttackSimulationSimulationUserCoverage";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_Security_GetAttackSimulationSimulationUserCoverage,
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
    public partial class SecurityreportsRootGetattackSimulationSimulationUsercoverageResponse : RestApiResponse<AttackSimulationSimulationUserCoverage>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationsimulationusercoverage?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationsimulationusercoverage?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityreportsRootGetattackSimulationSimulationUsercoverageResponse> SecurityreportsRootGetattackSimulationSimulationUsercoverageAsync()
        {
            var p = new SecurityreportsRootGetattackSimulationSimulationUsercoverageParameter();
            return await this.SendAsync<SecurityreportsRootGetattackSimulationSimulationUsercoverageParameter, SecurityreportsRootGetattackSimulationSimulationUsercoverageResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationsimulationusercoverage?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityreportsRootGetattackSimulationSimulationUsercoverageResponse> SecurityreportsRootGetattackSimulationSimulationUsercoverageAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityreportsRootGetattackSimulationSimulationUsercoverageParameter();
            return await this.SendAsync<SecurityreportsRootGetattackSimulationSimulationUsercoverageParameter, SecurityreportsRootGetattackSimulationSimulationUsercoverageResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationsimulationusercoverage?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityreportsRootGetattackSimulationSimulationUsercoverageResponse> SecurityreportsRootGetattackSimulationSimulationUsercoverageAsync(SecurityreportsRootGetattackSimulationSimulationUsercoverageParameter parameter)
        {
            return await this.SendAsync<SecurityreportsRootGetattackSimulationSimulationUsercoverageParameter, SecurityreportsRootGetattackSimulationSimulationUsercoverageResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationsimulationusercoverage?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityreportsRootGetattackSimulationSimulationUsercoverageResponse> SecurityreportsRootGetattackSimulationSimulationUsercoverageAsync(SecurityreportsRootGetattackSimulationSimulationUsercoverageParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityreportsRootGetattackSimulationSimulationUsercoverageParameter, SecurityreportsRootGetattackSimulationSimulationUsercoverageResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationsimulationusercoverage?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<AttackSimulationSimulationUserCoverage> SecurityreportsRootGetattackSimulationSimulationUsercoverageEnumerateAsync(SecurityreportsRootGetattackSimulationSimulationUsercoverageParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<SecurityreportsRootGetattackSimulationSimulationUsercoverageParameter, SecurityreportsRootGetattackSimulationSimulationUsercoverageResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<AttackSimulationSimulationUserCoverage>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
