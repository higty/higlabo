using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-custodians?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverycaseListCustodiansParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/custodians";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AcknowledgedDateTime,
            CreatedDateTime,
            DisplayName,
            Email,
            HoldStatus,
            Id,
            LastModifiedDateTime,
            ReleasedDateTime,
            Status,
            LastIndexOperation,
            SiteSources,
            UnifiedGroupSources,
            UserSources,
        }
        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians,
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
    public partial class SecurityEdiscoverycaseListCustodiansResponse : RestApiResponse
    {
        public EdiscoveryCustodian[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-custodians?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-custodians?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycaseListCustodiansResponse> SecurityEdiscoverycaseListCustodiansAsync()
        {
            var p = new SecurityEdiscoverycaseListCustodiansParameter();
            return await this.SendAsync<SecurityEdiscoverycaseListCustodiansParameter, SecurityEdiscoverycaseListCustodiansResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-custodians?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycaseListCustodiansResponse> SecurityEdiscoverycaseListCustodiansAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverycaseListCustodiansParameter();
            return await this.SendAsync<SecurityEdiscoverycaseListCustodiansParameter, SecurityEdiscoverycaseListCustodiansResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-custodians?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycaseListCustodiansResponse> SecurityEdiscoverycaseListCustodiansAsync(SecurityEdiscoverycaseListCustodiansParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverycaseListCustodiansParameter, SecurityEdiscoverycaseListCustodiansResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-custodians?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycaseListCustodiansResponse> SecurityEdiscoverycaseListCustodiansAsync(SecurityEdiscoverycaseListCustodiansParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverycaseListCustodiansParameter, SecurityEdiscoverycaseListCustodiansResponse>(parameter, cancellationToken);
        }
    }
}
