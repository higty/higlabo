using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-casesroot-list-ediscoverycases?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityCasesRootListEdiscoverycasesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases: return $"/security/cases/ediscoveryCases";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            ClosedBy,
            ClosedDateTime,
            CreatedBy,
            CreatedDateTime,
            Description,
            DisplayName,
            ExternalId,
            Id,
            LastModifiedBy,
            LastModifiedDateTime,
            Status,
            Custodians,
            NoncustodialDataSources,
            Operations,
            ReviewSets,
            Searches,
            Settings,
            Tags,
        }
        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases,
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
    public partial class SecurityCasesRootListEdiscoverycasesResponse : RestApiResponse
    {
        public EdiscoveryCase[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-casesroot-list-ediscoverycases?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-casesroot-list-ediscoverycases?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityCasesRootListEdiscoverycasesResponse> SecurityCasesRootListEdiscoverycasesAsync()
        {
            var p = new SecurityCasesRootListEdiscoverycasesParameter();
            return await this.SendAsync<SecurityCasesRootListEdiscoverycasesParameter, SecurityCasesRootListEdiscoverycasesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-casesroot-list-ediscoverycases?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityCasesRootListEdiscoverycasesResponse> SecurityCasesRootListEdiscoverycasesAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityCasesRootListEdiscoverycasesParameter();
            return await this.SendAsync<SecurityCasesRootListEdiscoverycasesParameter, SecurityCasesRootListEdiscoverycasesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-casesroot-list-ediscoverycases?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityCasesRootListEdiscoverycasesResponse> SecurityCasesRootListEdiscoverycasesAsync(SecurityCasesRootListEdiscoverycasesParameter parameter)
        {
            return await this.SendAsync<SecurityCasesRootListEdiscoverycasesParameter, SecurityCasesRootListEdiscoverycasesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-casesroot-list-ediscoverycases?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityCasesRootListEdiscoverycasesResponse> SecurityCasesRootListEdiscoverycasesAsync(SecurityCasesRootListEdiscoverycasesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityCasesRootListEdiscoverycasesParameter, SecurityCasesRootListEdiscoverycasesResponse>(parameter, cancellationToken);
        }
    }
}
