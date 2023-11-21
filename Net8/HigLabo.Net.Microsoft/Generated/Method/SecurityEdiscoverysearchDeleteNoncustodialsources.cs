using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-delete-noncustodialsources?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverysearchDeleteNoncustodialsourcesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }
            public string? EdiscoverySearchId { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches_EdiscoverySearchId_NoncustodialSources_Id_ref: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/searches/{EdiscoverySearchId}/noncustodialSources/{Id}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches_EdiscoverySearchId_NoncustodialSources_Id_ref,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class SecurityEdiscoverysearchDeleteNoncustodialsourcesResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-delete-noncustodialsources?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-delete-noncustodialsources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverysearchDeleteNoncustodialsourcesResponse> SecurityEdiscoverysearchDeleteNoncustodialsourcesAsync()
        {
            var p = new SecurityEdiscoverysearchDeleteNoncustodialsourcesParameter();
            return await this.SendAsync<SecurityEdiscoverysearchDeleteNoncustodialsourcesParameter, SecurityEdiscoverysearchDeleteNoncustodialsourcesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-delete-noncustodialsources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverysearchDeleteNoncustodialsourcesResponse> SecurityEdiscoverysearchDeleteNoncustodialsourcesAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverysearchDeleteNoncustodialsourcesParameter();
            return await this.SendAsync<SecurityEdiscoverysearchDeleteNoncustodialsourcesParameter, SecurityEdiscoverysearchDeleteNoncustodialsourcesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-delete-noncustodialsources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverysearchDeleteNoncustodialsourcesResponse> SecurityEdiscoverysearchDeleteNoncustodialsourcesAsync(SecurityEdiscoverysearchDeleteNoncustodialsourcesParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverysearchDeleteNoncustodialsourcesParameter, SecurityEdiscoverysearchDeleteNoncustodialsourcesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverysearch-delete-noncustodialsources?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverysearchDeleteNoncustodialsourcesResponse> SecurityEdiscoverysearchDeleteNoncustodialsourcesAsync(SecurityEdiscoverysearchDeleteNoncustodialsourcesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverysearchDeleteNoncustodialsourcesParameter, SecurityEdiscoverysearchDeleteNoncustodialsourcesResponse>(parameter, cancellationToken);
        }
    }
}
