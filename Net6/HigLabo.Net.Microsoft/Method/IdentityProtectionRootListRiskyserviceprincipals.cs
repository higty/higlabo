using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityprotectionroot-list-riskyserviceprincipals?view=graph-rest-1.0
    /// </summary>
    public partial class IdentityProtectionRootListRiskyserviceprincipalsParameter : IRestApiParameter, IQueryParameterProperty
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
            AppId,
            DisplayName,
            Id,
            IsEnabled,
            IsProcessing,
            RiskDetail,
            RiskLastUpdatedDateTime,
            RiskLevel,
            RiskState,
            ServicePrincipalType,
            History,
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
    public partial class IdentityProtectionRootListRiskyserviceprincipalsResponse : RestApiResponse
    {
        public RiskyServicePrincipal[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityprotectionroot-list-riskyserviceprincipals?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityprotectionroot-list-riskyserviceprincipals?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityProtectionRootListRiskyserviceprincipalsResponse> IdentityProtectionRootListRiskyserviceprincipalsAsync()
        {
            var p = new IdentityProtectionRootListRiskyserviceprincipalsParameter();
            return await this.SendAsync<IdentityProtectionRootListRiskyserviceprincipalsParameter, IdentityProtectionRootListRiskyserviceprincipalsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityprotectionroot-list-riskyserviceprincipals?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityProtectionRootListRiskyserviceprincipalsResponse> IdentityProtectionRootListRiskyserviceprincipalsAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityProtectionRootListRiskyserviceprincipalsParameter();
            return await this.SendAsync<IdentityProtectionRootListRiskyserviceprincipalsParameter, IdentityProtectionRootListRiskyserviceprincipalsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityprotectionroot-list-riskyserviceprincipals?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityProtectionRootListRiskyserviceprincipalsResponse> IdentityProtectionRootListRiskyserviceprincipalsAsync(IdentityProtectionRootListRiskyserviceprincipalsParameter parameter)
        {
            return await this.SendAsync<IdentityProtectionRootListRiskyserviceprincipalsParameter, IdentityProtectionRootListRiskyserviceprincipalsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityprotectionroot-list-riskyserviceprincipals?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityProtectionRootListRiskyserviceprincipalsResponse> IdentityProtectionRootListRiskyserviceprincipalsAsync(IdentityProtectionRootListRiskyserviceprincipalsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityProtectionRootListRiskyserviceprincipalsParameter, IdentityProtectionRootListRiskyserviceprincipalsResponse>(parameter, cancellationToken);
        }
    }
}
