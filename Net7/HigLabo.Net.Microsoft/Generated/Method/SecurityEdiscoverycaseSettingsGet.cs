using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycasesettings-get?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverycaseSettingsGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Settings: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/settings";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Settings,
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
    public partial class SecurityEdiscoverycaseSettingsGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public OcrSettings? Ocr { get; set; }
        public RedundancyDetectionSettings? RedundancyDetection { get; set; }
        public TopicModelingSettings? TopicModeling { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycasesettings-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycasesettings-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycaseSettingsGetResponse> SecurityEdiscoverycaseSettingsGetAsync()
        {
            var p = new SecurityEdiscoverycaseSettingsGetParameter();
            return await this.SendAsync<SecurityEdiscoverycaseSettingsGetParameter, SecurityEdiscoverycaseSettingsGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycasesettings-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycaseSettingsGetResponse> SecurityEdiscoverycaseSettingsGetAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverycaseSettingsGetParameter();
            return await this.SendAsync<SecurityEdiscoverycaseSettingsGetParameter, SecurityEdiscoverycaseSettingsGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycasesettings-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycaseSettingsGetResponse> SecurityEdiscoverycaseSettingsGetAsync(SecurityEdiscoverycaseSettingsGetParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverycaseSettingsGetParameter, SecurityEdiscoverycaseSettingsGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycasesettings-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycaseSettingsGetResponse> SecurityEdiscoverycaseSettingsGetAsync(SecurityEdiscoverycaseSettingsGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverycaseSettingsGetParameter, SecurityEdiscoverycaseSettingsGetResponse>(parameter, cancellationToken);
        }
    }
}
