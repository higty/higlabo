using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationtrainingusercoverage?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityreportsRootGetattacksimulationtrainingUsercoverageParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_Security_GetAttackSimulationTrainingUserCoverage: return $"/reports/security/getAttackSimulationTrainingUserCoverage";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AttackSimulationUser,
            UserTrainings,
        }
        public enum ApiPath
        {
            Reports_Security_GetAttackSimulationTrainingUserCoverage,
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
    public partial class SecurityreportsRootGetattacksimulationtrainingUsercoverageResponse : RestApiResponse
    {
        public AttackSimulationTrainingUserCoverage[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationtrainingusercoverage?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationtrainingusercoverage?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityreportsRootGetattacksimulationtrainingUsercoverageResponse> SecurityreportsRootGetattacksimulationtrainingUsercoverageAsync()
        {
            var p = new SecurityreportsRootGetattacksimulationtrainingUsercoverageParameter();
            return await this.SendAsync<SecurityreportsRootGetattacksimulationtrainingUsercoverageParameter, SecurityreportsRootGetattacksimulationtrainingUsercoverageResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationtrainingusercoverage?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityreportsRootGetattacksimulationtrainingUsercoverageResponse> SecurityreportsRootGetattacksimulationtrainingUsercoverageAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityreportsRootGetattacksimulationtrainingUsercoverageParameter();
            return await this.SendAsync<SecurityreportsRootGetattacksimulationtrainingUsercoverageParameter, SecurityreportsRootGetattacksimulationtrainingUsercoverageResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationtrainingusercoverage?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityreportsRootGetattacksimulationtrainingUsercoverageResponse> SecurityreportsRootGetattacksimulationtrainingUsercoverageAsync(SecurityreportsRootGetattacksimulationtrainingUsercoverageParameter parameter)
        {
            return await this.SendAsync<SecurityreportsRootGetattacksimulationtrainingUsercoverageParameter, SecurityreportsRootGetattacksimulationtrainingUsercoverageResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationtrainingusercoverage?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityreportsRootGetattacksimulationtrainingUsercoverageResponse> SecurityreportsRootGetattacksimulationtrainingUsercoverageAsync(SecurityreportsRootGetattacksimulationtrainingUsercoverageParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityreportsRootGetattacksimulationtrainingUsercoverageParameter, SecurityreportsRootGetattacksimulationtrainingUsercoverageResponse>(parameter, cancellationToken);
        }
    }
}
