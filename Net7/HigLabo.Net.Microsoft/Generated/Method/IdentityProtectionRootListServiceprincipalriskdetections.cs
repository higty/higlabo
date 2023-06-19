using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityprotectionroot-list-serviceprincipalriskdetections?view=graph-rest-1.0
    /// </summary>
    public partial class IdentityProtectionRootListServiceprincipalriskdetectionsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityProtection_ServicePrincipalRiskDetections: return $"/identityProtection/servicePrincipalRiskDetections";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Activity,
            ActivityDateTime,
            AdditionalInfo,
            AppId,
            CorrelationId,
            DetectedDateTime,
            DetectionTimingType,
            Id,
            IpAddress,
            KeyIds,
            LastUpdatedDateTime,
            Location,
            RequestId,
            RiskDetail,
            RiskEventType,
            RiskLevel,
            RiskState,
            ServicePrincipalDisplayName,
            ServicePrincipalId,
            Source,
            TokenIssuerType,
        }
        public enum ApiPath
        {
            IdentityProtection_ServicePrincipalRiskDetections,
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
    public partial class IdentityProtectionRootListServiceprincipalriskdetectionsResponse : RestApiResponse
    {
        public ServicePrincipalRiskDetection[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityprotectionroot-list-serviceprincipalriskdetections?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityprotectionroot-list-serviceprincipalriskdetections?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentityProtectionRootListServiceprincipalriskdetectionsResponse> IdentityProtectionRootListServiceprincipalriskdetectionsAsync()
        {
            var p = new IdentityProtectionRootListServiceprincipalriskdetectionsParameter();
            return await this.SendAsync<IdentityProtectionRootListServiceprincipalriskdetectionsParameter, IdentityProtectionRootListServiceprincipalriskdetectionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityprotectionroot-list-serviceprincipalriskdetections?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentityProtectionRootListServiceprincipalriskdetectionsResponse> IdentityProtectionRootListServiceprincipalriskdetectionsAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityProtectionRootListServiceprincipalriskdetectionsParameter();
            return await this.SendAsync<IdentityProtectionRootListServiceprincipalriskdetectionsParameter, IdentityProtectionRootListServiceprincipalriskdetectionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityprotectionroot-list-serviceprincipalriskdetections?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentityProtectionRootListServiceprincipalriskdetectionsResponse> IdentityProtectionRootListServiceprincipalriskdetectionsAsync(IdentityProtectionRootListServiceprincipalriskdetectionsParameter parameter)
        {
            return await this.SendAsync<IdentityProtectionRootListServiceprincipalriskdetectionsParameter, IdentityProtectionRootListServiceprincipalriskdetectionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityprotectionroot-list-serviceprincipalriskdetections?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentityProtectionRootListServiceprincipalriskdetectionsResponse> IdentityProtectionRootListServiceprincipalriskdetectionsAsync(IdentityProtectionRootListServiceprincipalriskdetectionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityProtectionRootListServiceprincipalriskdetectionsParameter, IdentityProtectionRootListServiceprincipalriskdetectionsResponse>(parameter, cancellationToken);
        }
    }
}
