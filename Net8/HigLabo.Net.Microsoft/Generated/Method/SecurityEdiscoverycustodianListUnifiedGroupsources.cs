using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-unifiedgroupsources?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverycustodianListUnifiedGroupsourcesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }
            public string? CustodianId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians_CustodianId_UnifiedGroupSources: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/custodians/{CustodianId}/unifiedGroupSources";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians_CustodianId_UnifiedGroupSources,
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
    public partial class SecurityEdiscoverycustodianListUnifiedGroupsourcesResponse : RestApiResponse
    {
        public UnifiedGroupSource[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-unifiedgroupsources?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-unifiedgroupsources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycustodianListUnifiedGroupsourcesResponse> SecurityEdiscoverycustodianListUnifiedGroupsourcesAsync()
        {
            var p = new SecurityEdiscoverycustodianListUnifiedGroupsourcesParameter();
            return await this.SendAsync<SecurityEdiscoverycustodianListUnifiedGroupsourcesParameter, SecurityEdiscoverycustodianListUnifiedGroupsourcesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-unifiedgroupsources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycustodianListUnifiedGroupsourcesResponse> SecurityEdiscoverycustodianListUnifiedGroupsourcesAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverycustodianListUnifiedGroupsourcesParameter();
            return await this.SendAsync<SecurityEdiscoverycustodianListUnifiedGroupsourcesParameter, SecurityEdiscoverycustodianListUnifiedGroupsourcesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-unifiedgroupsources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycustodianListUnifiedGroupsourcesResponse> SecurityEdiscoverycustodianListUnifiedGroupsourcesAsync(SecurityEdiscoverycustodianListUnifiedGroupsourcesParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverycustodianListUnifiedGroupsourcesParameter, SecurityEdiscoverycustodianListUnifiedGroupsourcesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-unifiedgroupsources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycustodianListUnifiedGroupsourcesResponse> SecurityEdiscoverycustodianListUnifiedGroupsourcesAsync(SecurityEdiscoverycustodianListUnifiedGroupsourcesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverycustodianListUnifiedGroupsourcesParameter, SecurityEdiscoverycustodianListUnifiedGroupsourcesResponse>(parameter, cancellationToken);
        }
    }
}
