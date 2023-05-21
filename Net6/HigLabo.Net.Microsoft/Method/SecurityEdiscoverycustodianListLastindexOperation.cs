using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-lastindexoperation?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverycustodianListLastindexOperationParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }
            public string? EdiscoverycustodianId { get; set; }
            public string? EdiscoveryNoncustodialDataSourceId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians_EdiscoverycustodianId_LastIndexOperation: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/custodians/{EdiscoverycustodianId}/lastIndexOperation";
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_NoncustodialSources_EdiscoveryNoncustodialDataSourceId_LastIndexOperation: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/noncustodialSources/{EdiscoveryNoncustodialDataSourceId}/lastIndexOperation";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Custodians_EdiscoverycustodianId_LastIndexOperation,
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_NoncustodialSources_EdiscoveryNoncustodialDataSourceId_LastIndexOperation,
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
    public partial class SecurityEdiscoverycustodianListLastindexOperationResponse : RestApiResponse
    {
        public EdiscoveryIndexOperation[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-lastindexoperation?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-lastindexoperation?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycustodianListLastindexOperationResponse> SecurityEdiscoverycustodianListLastindexOperationAsync()
        {
            var p = new SecurityEdiscoverycustodianListLastindexOperationParameter();
            return await this.SendAsync<SecurityEdiscoverycustodianListLastindexOperationParameter, SecurityEdiscoverycustodianListLastindexOperationResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-lastindexoperation?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycustodianListLastindexOperationResponse> SecurityEdiscoverycustodianListLastindexOperationAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverycustodianListLastindexOperationParameter();
            return await this.SendAsync<SecurityEdiscoverycustodianListLastindexOperationParameter, SecurityEdiscoverycustodianListLastindexOperationResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-lastindexoperation?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycustodianListLastindexOperationResponse> SecurityEdiscoverycustodianListLastindexOperationAsync(SecurityEdiscoverycustodianListLastindexOperationParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverycustodianListLastindexOperationParameter, SecurityEdiscoverycustodianListLastindexOperationResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycustodian-list-lastindexoperation?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycustodianListLastindexOperationResponse> SecurityEdiscoverycustodianListLastindexOperationAsync(SecurityEdiscoverycustodianListLastindexOperationParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverycustodianListLastindexOperationParameter, SecurityEdiscoverycustodianListLastindexOperationResponse>(parameter, cancellationToken);
        }
    }
}
