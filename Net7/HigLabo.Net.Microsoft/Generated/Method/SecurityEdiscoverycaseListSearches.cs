using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-searches?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverycaseListSearchesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/searches";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            ContentQuery,
            CreatedBy,
            CreatedDateTime,
            DataSourceScopes,
            Description,
            DisplayName,
            Id,
            LastModifiedBy,
            LastModifiedDateTime,
            AdditionalSources,
            AddToReviewSetOperation,
            CustodianSources,
            LastEstimateStatisticsOperation,
            NoncustodialSources,
        }
        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches,
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
    public partial class SecurityEdiscoverycaseListSearchesResponse : RestApiResponse
    {
        public EdiscoverySearch[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-searches?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-searches?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycaseListSearchesResponse> SecurityEdiscoverycaseListSearchesAsync()
        {
            var p = new SecurityEdiscoverycaseListSearchesParameter();
            return await this.SendAsync<SecurityEdiscoverycaseListSearchesParameter, SecurityEdiscoverycaseListSearchesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-searches?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycaseListSearchesResponse> SecurityEdiscoverycaseListSearchesAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverycaseListSearchesParameter();
            return await this.SendAsync<SecurityEdiscoverycaseListSearchesParameter, SecurityEdiscoverycaseListSearchesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-searches?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycaseListSearchesResponse> SecurityEdiscoverycaseListSearchesAsync(SecurityEdiscoverycaseListSearchesParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverycaseListSearchesParameter, SecurityEdiscoverycaseListSearchesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-searches?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycaseListSearchesResponse> SecurityEdiscoverycaseListSearchesAsync(SecurityEdiscoverycaseListSearchesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverycaseListSearchesParameter, SecurityEdiscoverycaseListSearchesResponse>(parameter, cancellationToken);
        }
    }
}
