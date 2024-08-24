using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationrepeatoffenders?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityreportsRootGetattackSimulationrepeatoffendersParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class SecurityreportsRootGetattackSimulationrepeatoffendersResponse : RestApiResponse<AttackSimulationRepeatOffender>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationrepeatoffenders?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationrepeatoffenders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityreportsRootGetattackSimulationrepeatoffendersResponse> SecurityreportsRootGetattackSimulationrepeatoffendersAsync()
        {
            var p = new SecurityreportsRootGetattackSimulationrepeatoffendersParameter();
            return await this.SendAsync<SecurityreportsRootGetattackSimulationrepeatoffendersParameter, SecurityreportsRootGetattackSimulationrepeatoffendersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationrepeatoffenders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityreportsRootGetattackSimulationrepeatoffendersResponse> SecurityreportsRootGetattackSimulationrepeatoffendersAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityreportsRootGetattackSimulationrepeatoffendersParameter();
            return await this.SendAsync<SecurityreportsRootGetattackSimulationrepeatoffendersParameter, SecurityreportsRootGetattackSimulationrepeatoffendersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationrepeatoffenders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityreportsRootGetattackSimulationrepeatoffendersResponse> SecurityreportsRootGetattackSimulationrepeatoffendersAsync(SecurityreportsRootGetattackSimulationrepeatoffendersParameter parameter)
        {
            return await this.SendAsync<SecurityreportsRootGetattackSimulationrepeatoffendersParameter, SecurityreportsRootGetattackSimulationrepeatoffendersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationrepeatoffenders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityreportsRootGetattackSimulationrepeatoffendersResponse> SecurityreportsRootGetattackSimulationrepeatoffendersAsync(SecurityreportsRootGetattackSimulationrepeatoffendersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityreportsRootGetattackSimulationrepeatoffendersParameter, SecurityreportsRootGetattackSimulationrepeatoffendersResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/securityreportsroot-getattacksimulationrepeatoffenders?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<AttackSimulationRepeatOffender> SecurityreportsRootGetattackSimulationrepeatoffendersEnumerateAsync(SecurityreportsRootGetattackSimulationrepeatoffendersParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<SecurityreportsRootGetattackSimulationrepeatoffendersParameter, SecurityreportsRootGetattackSimulationrepeatoffendersResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<AttackSimulationRepeatOffender>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
