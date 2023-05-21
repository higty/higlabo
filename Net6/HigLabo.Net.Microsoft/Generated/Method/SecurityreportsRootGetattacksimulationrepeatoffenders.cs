using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationrepeatoffenders?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityreportsRootGetattacksimulationrepeatoffendersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_Security_GetAttackSimulationRepeatOffenders: return $"/reports/security/getAttackSimulationRepeatOffenders";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AttackSimulationUser,
            RepeatOffenceCount,
        }
        public enum ApiPath
        {
            Reports_Security_GetAttackSimulationRepeatOffenders,
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
    public partial class SecurityreportsRootGetattacksimulationrepeatoffendersResponse : RestApiResponse
    {
        public AttackSimulationRepeatOffender[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationrepeatoffenders?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationrepeatoffenders?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityreportsRootGetattacksimulationrepeatoffendersResponse> SecurityreportsRootGetattacksimulationrepeatoffendersAsync()
        {
            var p = new SecurityreportsRootGetattacksimulationrepeatoffendersParameter();
            return await this.SendAsync<SecurityreportsRootGetattacksimulationrepeatoffendersParameter, SecurityreportsRootGetattacksimulationrepeatoffendersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationrepeatoffenders?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityreportsRootGetattacksimulationrepeatoffendersResponse> SecurityreportsRootGetattacksimulationrepeatoffendersAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityreportsRootGetattacksimulationrepeatoffendersParameter();
            return await this.SendAsync<SecurityreportsRootGetattacksimulationrepeatoffendersParameter, SecurityreportsRootGetattacksimulationrepeatoffendersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationrepeatoffenders?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityreportsRootGetattacksimulationrepeatoffendersResponse> SecurityreportsRootGetattacksimulationrepeatoffendersAsync(SecurityreportsRootGetattacksimulationrepeatoffendersParameter parameter)
        {
            return await this.SendAsync<SecurityreportsRootGetattacksimulationrepeatoffendersParameter, SecurityreportsRootGetattacksimulationrepeatoffendersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationrepeatoffenders?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityreportsRootGetattacksimulationrepeatoffendersResponse> SecurityreportsRootGetattacksimulationrepeatoffendersAsync(SecurityreportsRootGetattacksimulationrepeatoffendersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityreportsRootGetattacksimulationrepeatoffendersParameter, SecurityreportsRootGetattacksimulationrepeatoffendersResponse>(parameter, cancellationToken);
        }
    }
}
