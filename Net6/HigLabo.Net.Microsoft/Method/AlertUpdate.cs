using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AlertUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Alert_id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Alerts_Alert_id: return $"/security/alerts/{Alert_id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum AlertUpdateParameterAlertFeedback
        {
            Unknown,
            TruePositive,
            FalsePositive,
            BenignPositive,
        }
        public enum AlertUpdateParameterAlertStatus
        {
            Unknown,
            NewAlert,
            InProgress,
            Resolved,
        }
        public enum ApiPath
        {
            Security_Alerts_Alert_id,
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
        public string? AssignedTo { get; set; }
        public DateTimeOffset? ClosedDateTime { get; set; }
        public String[]? Comments { get; set; }
        public AlertUpdateParameterAlertFeedback Feedback { get; set; }
        public AlertUpdateParameterAlertStatus Status { get; set; }
        public String[]? Tags { get; set; }
        public SecurityVendorInformation? VendorInformation { get; set; }
    }
    public partial class AlertUpdateResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/alert-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AlertUpdateResponse> AlertUpdateAsync()
        {
            var p = new AlertUpdateParameter();
            return await this.SendAsync<AlertUpdateParameter, AlertUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/alert-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AlertUpdateResponse> AlertUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new AlertUpdateParameter();
            return await this.SendAsync<AlertUpdateParameter, AlertUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/alert-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AlertUpdateResponse> AlertUpdateAsync(AlertUpdateParameter parameter)
        {
            return await this.SendAsync<AlertUpdateParameter, AlertUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/alert-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AlertUpdateResponse> AlertUpdateAsync(AlertUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AlertUpdateParameter, AlertUpdateResponse>(parameter, cancellationToken);
        }
    }
}
