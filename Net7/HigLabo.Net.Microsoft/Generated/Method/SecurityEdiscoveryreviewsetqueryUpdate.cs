using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewsetquery-update?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoveryreviewsetqueryUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }
            public string? EdiscoveryReviewSetId { get; set; }
            public string? QueryId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_ReviewSets_EdiscoveryReviewSetId_Queries_QueryId: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/reviewSets/{EdiscoveryReviewSetId}/queries/{QueryId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_ReviewSets_EdiscoveryReviewSetId_Queries_QueryId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? DisplayName { get; set; }
        public string? ContentQuery { get; set; }
    }
    public partial class SecurityEdiscoveryreviewsetqueryUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewsetquery-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewsetquery-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoveryreviewsetqueryUpdateResponse> SecurityEdiscoveryreviewsetqueryUpdateAsync()
        {
            var p = new SecurityEdiscoveryreviewsetqueryUpdateParameter();
            return await this.SendAsync<SecurityEdiscoveryreviewsetqueryUpdateParameter, SecurityEdiscoveryreviewsetqueryUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewsetquery-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoveryreviewsetqueryUpdateResponse> SecurityEdiscoveryreviewsetqueryUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoveryreviewsetqueryUpdateParameter();
            return await this.SendAsync<SecurityEdiscoveryreviewsetqueryUpdateParameter, SecurityEdiscoveryreviewsetqueryUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewsetquery-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoveryreviewsetqueryUpdateResponse> SecurityEdiscoveryreviewsetqueryUpdateAsync(SecurityEdiscoveryreviewsetqueryUpdateParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoveryreviewsetqueryUpdateParameter, SecurityEdiscoveryreviewsetqueryUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewsetquery-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoveryreviewsetqueryUpdateResponse> SecurityEdiscoveryreviewsetqueryUpdateAsync(SecurityEdiscoveryreviewsetqueryUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoveryreviewsetqueryUpdateParameter, SecurityEdiscoveryreviewsetqueryUpdateResponse>(parameter, cancellationToken);
        }
    }
}
