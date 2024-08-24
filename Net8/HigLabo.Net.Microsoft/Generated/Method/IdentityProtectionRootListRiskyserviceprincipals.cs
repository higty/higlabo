using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityprotectionroot-list-riskyserviceprincipals?view=graph-rest-1.0
    /// </summary>
    public partial class IdentityProtectionRootListRiskyServicePrincipalsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityProtection_RiskyServicePrincipals: return $"/identityProtection/riskyServicePrincipals";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityProtection_RiskyServicePrincipals,
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
    public partial class IdentityProtectionRootListRiskyServicePrincipalsResponse : RestApiResponse<RiskyServicePrincipal>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityprotectionroot-list-riskyserviceprincipals?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityprotectionroot-list-riskyserviceprincipals?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentityProtectionRootListRiskyServicePrincipalsResponse> IdentityProtectionRootListRiskyServicePrincipalsAsync()
        {
            var p = new IdentityProtectionRootListRiskyServicePrincipalsParameter();
            return await this.SendAsync<IdentityProtectionRootListRiskyServicePrincipalsParameter, IdentityProtectionRootListRiskyServicePrincipalsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityprotectionroot-list-riskyserviceprincipals?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentityProtectionRootListRiskyServicePrincipalsResponse> IdentityProtectionRootListRiskyServicePrincipalsAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityProtectionRootListRiskyServicePrincipalsParameter();
            return await this.SendAsync<IdentityProtectionRootListRiskyServicePrincipalsParameter, IdentityProtectionRootListRiskyServicePrincipalsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityprotectionroot-list-riskyserviceprincipals?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentityProtectionRootListRiskyServicePrincipalsResponse> IdentityProtectionRootListRiskyServicePrincipalsAsync(IdentityProtectionRootListRiskyServicePrincipalsParameter parameter)
        {
            return await this.SendAsync<IdentityProtectionRootListRiskyServicePrincipalsParameter, IdentityProtectionRootListRiskyServicePrincipalsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityprotectionroot-list-riskyserviceprincipals?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentityProtectionRootListRiskyServicePrincipalsResponse> IdentityProtectionRootListRiskyServicePrincipalsAsync(IdentityProtectionRootListRiskyServicePrincipalsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityProtectionRootListRiskyServicePrincipalsParameter, IdentityProtectionRootListRiskyServicePrincipalsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityprotectionroot-list-riskyserviceprincipals?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<RiskyServicePrincipal> IdentityProtectionRootListRiskyServicePrincipalsEnumerateAsync(IdentityProtectionRootListRiskyServicePrincipalsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<IdentityProtectionRootListRiskyServicePrincipalsParameter, IdentityProtectionRootListRiskyServicePrincipalsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<RiskyServicePrincipal>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
