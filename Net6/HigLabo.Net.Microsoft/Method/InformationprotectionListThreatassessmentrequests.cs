using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/informationprotection-list-threatassessmentrequests?view=graph-rest-1.0
    /// </summary>
    public partial class InformationProtectionListThreatassessmentrequestsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.InformationProtection_ThreatAssessmentRequests: return $"/informationProtection/threatAssessmentRequests";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Category,
            ContentType,
            CreatedBy,
            CreatedDateTime,
            ExpectedAssessment,
            Id,
            RequestSource,
            Status,
            Results,
        }
        public enum ApiPath
        {
            InformationProtection_ThreatAssessmentRequests,
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
    public partial class InformationProtectionListThreatassessmentrequestsResponse : RestApiResponse
    {
        public ThreatAssessmentRequest[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/informationprotection-list-threatassessmentrequests?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/informationprotection-list-threatassessmentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<InformationProtectionListThreatassessmentrequestsResponse> InformationProtectionListThreatassessmentrequestsAsync()
        {
            var p = new InformationProtectionListThreatassessmentrequestsParameter();
            return await this.SendAsync<InformationProtectionListThreatassessmentrequestsParameter, InformationProtectionListThreatassessmentrequestsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/informationprotection-list-threatassessmentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<InformationProtectionListThreatassessmentrequestsResponse> InformationProtectionListThreatassessmentrequestsAsync(CancellationToken cancellationToken)
        {
            var p = new InformationProtectionListThreatassessmentrequestsParameter();
            return await this.SendAsync<InformationProtectionListThreatassessmentrequestsParameter, InformationProtectionListThreatassessmentrequestsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/informationprotection-list-threatassessmentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<InformationProtectionListThreatassessmentrequestsResponse> InformationProtectionListThreatassessmentrequestsAsync(InformationProtectionListThreatassessmentrequestsParameter parameter)
        {
            return await this.SendAsync<InformationProtectionListThreatassessmentrequestsParameter, InformationProtectionListThreatassessmentrequestsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/informationprotection-list-threatassessmentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<InformationProtectionListThreatassessmentrequestsResponse> InformationProtectionListThreatassessmentrequestsAsync(InformationProtectionListThreatassessmentrequestsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<InformationProtectionListThreatassessmentrequestsParameter, InformationProtectionListThreatassessmentrequestsResponse>(parameter, cancellationToken);
        }
    }
}
