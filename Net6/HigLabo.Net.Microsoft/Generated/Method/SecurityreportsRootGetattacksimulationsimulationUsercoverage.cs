using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationsimulationusercoverage?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityreportsRootGetattacksimulationsimulationUsercoverageParameter : IRestApiParameter, IQueryParameterProperty
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
            AttackSimulationUser,
            ClickCount,
            CompromisedCount,
            LatestSimulationDateTime,
            SimulationCount,
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
    public partial class SecurityreportsRootGetattacksimulationsimulationUsercoverageResponse : RestApiResponse
    {
        public AttackSimulationSimulationUserCoverage[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationsimulationusercoverage?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationsimulationusercoverage?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityreportsRootGetattacksimulationsimulationUsercoverageResponse> SecurityreportsRootGetattacksimulationsimulationUsercoverageAsync()
        {
            var p = new SecurityreportsRootGetattacksimulationsimulationUsercoverageParameter();
            return await this.SendAsync<SecurityreportsRootGetattacksimulationsimulationUsercoverageParameter, SecurityreportsRootGetattacksimulationsimulationUsercoverageResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationsimulationusercoverage?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityreportsRootGetattacksimulationsimulationUsercoverageResponse> SecurityreportsRootGetattacksimulationsimulationUsercoverageAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityreportsRootGetattacksimulationsimulationUsercoverageParameter();
            return await this.SendAsync<SecurityreportsRootGetattacksimulationsimulationUsercoverageParameter, SecurityreportsRootGetattacksimulationsimulationUsercoverageResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationsimulationusercoverage?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityreportsRootGetattacksimulationsimulationUsercoverageResponse> SecurityreportsRootGetattacksimulationsimulationUsercoverageAsync(SecurityreportsRootGetattacksimulationsimulationUsercoverageParameter parameter)
        {
            return await this.SendAsync<SecurityreportsRootGetattacksimulationsimulationUsercoverageParameter, SecurityreportsRootGetattacksimulationsimulationUsercoverageResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationsimulationusercoverage?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityreportsRootGetattacksimulationsimulationUsercoverageResponse> SecurityreportsRootGetattacksimulationsimulationUsercoverageAsync(SecurityreportsRootGetattacksimulationsimulationUsercoverageParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityreportsRootGetattacksimulationsimulationUsercoverageParameter, SecurityreportsRootGetattacksimulationsimulationUsercoverageResponse>(parameter, cancellationToken);
        }
    }
}
