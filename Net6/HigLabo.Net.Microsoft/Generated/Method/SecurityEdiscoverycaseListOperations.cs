using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-operations?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverycaseListOperationsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Operations: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/operations";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Action,
            CompletedDateTime,
            CreatedBy,
            CreatedDateTime,
            Id,
            PercentProgress,
            ResultInfo,
            Status,
        }
        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Operations,
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
    public partial class SecurityEdiscoverycaseListOperationsResponse : RestApiResponse
    {
        public CaseOperation[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-operations?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-operations?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycaseListOperationsResponse> SecurityEdiscoverycaseListOperationsAsync()
        {
            var p = new SecurityEdiscoverycaseListOperationsParameter();
            return await this.SendAsync<SecurityEdiscoverycaseListOperationsParameter, SecurityEdiscoverycaseListOperationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-operations?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycaseListOperationsResponse> SecurityEdiscoverycaseListOperationsAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverycaseListOperationsParameter();
            return await this.SendAsync<SecurityEdiscoverycaseListOperationsParameter, SecurityEdiscoverycaseListOperationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-operations?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycaseListOperationsResponse> SecurityEdiscoverycaseListOperationsAsync(SecurityEdiscoverycaseListOperationsParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverycaseListOperationsParameter, SecurityEdiscoverycaseListOperationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-operations?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycaseListOperationsResponse> SecurityEdiscoverycaseListOperationsAsync(SecurityEdiscoverycaseListOperationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverycaseListOperationsParameter, SecurityEdiscoverycaseListOperationsResponse>(parameter, cancellationToken);
        }
    }
}
