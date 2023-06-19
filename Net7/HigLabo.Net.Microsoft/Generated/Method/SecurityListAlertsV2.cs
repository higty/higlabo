using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-list-alerts_v2?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityListAlertsV2Parameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Alerts_v2: return $"/security/alerts_v2";
                    case ApiPath.Security_Alerts_V2: return $"/security/alerts_V2";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            ActorDisplayName,
            AlertWebUrl,
            AssignedTo,
            Category,
            Classification,
            Comments,
            CreatedDateTime,
            Description,
            DetectionSource,
            DetectorId,
            Determination,
            Evidence,
            FirstActivityDateTime,
            Id,
            IncidentId,
            IncidentWebUrl,
            LastActivityDateTime,
            LastUpdateDateTime,
            MitreTechniques,
            ProviderAlertId,
            RecommendedActions,
            ResolvedDateTime,
            ServiceSource,
            Severity,
            Status,
            TenantId,
            ThreatDisplayName,
            ThreatFamilyName,
            Title,
        }
        public enum ApiPath
        {
            Security_Alerts_v2,
            Security_Alerts_V2,
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
    public partial class SecurityListAlertsV2Response : RestApiResponse
    {
        public SecurityAlert[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-list-alerts_v2?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-list-alerts_v2?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityListAlertsV2Response> SecurityListAlertsV2Async()
        {
            var p = new SecurityListAlertsV2Parameter();
            return await this.SendAsync<SecurityListAlertsV2Parameter, SecurityListAlertsV2Response>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-list-alerts_v2?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityListAlertsV2Response> SecurityListAlertsV2Async(CancellationToken cancellationToken)
        {
            var p = new SecurityListAlertsV2Parameter();
            return await this.SendAsync<SecurityListAlertsV2Parameter, SecurityListAlertsV2Response>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-list-alerts_v2?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityListAlertsV2Response> SecurityListAlertsV2Async(SecurityListAlertsV2Parameter parameter)
        {
            return await this.SendAsync<SecurityListAlertsV2Parameter, SecurityListAlertsV2Response>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-list-alerts_v2?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityListAlertsV2Response> SecurityListAlertsV2Async(SecurityListAlertsV2Parameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityListAlertsV2Parameter, SecurityListAlertsV2Response>(parameter, cancellationToken);
        }
    }
}
