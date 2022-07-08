using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServicehealthissueIncidentreportParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string ServiceHealthIssueId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Admin_ServiceAnnouncement_Issues_ServiceHealthIssueId_IncidentReport: return $"/admin/serviceAnnouncement/issues/{ServiceHealthIssueId}/incidentReport";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Admin_ServiceAnnouncement_Issues_ServiceHealthIssueId_IncidentReport,
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
    public partial class ServicehealthissueIncidentreportResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/servicehealthissue-incidentreport?view=graph-rest-1.0
        /// </summary>
        public async Task<ServicehealthissueIncidentreportResponse> ServicehealthissueIncidentreportAsync()
        {
            var p = new ServicehealthissueIncidentreportParameter();
            return await this.SendAsync<ServicehealthissueIncidentreportParameter, ServicehealthissueIncidentreportResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/servicehealthissue-incidentreport?view=graph-rest-1.0
        /// </summary>
        public async Task<ServicehealthissueIncidentreportResponse> ServicehealthissueIncidentreportAsync(CancellationToken cancellationToken)
        {
            var p = new ServicehealthissueIncidentreportParameter();
            return await this.SendAsync<ServicehealthissueIncidentreportParameter, ServicehealthissueIncidentreportResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/servicehealthissue-incidentreport?view=graph-rest-1.0
        /// </summary>
        public async Task<ServicehealthissueIncidentreportResponse> ServicehealthissueIncidentreportAsync(ServicehealthissueIncidentreportParameter parameter)
        {
            return await this.SendAsync<ServicehealthissueIncidentreportParameter, ServicehealthissueIncidentreportResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/servicehealthissue-incidentreport?view=graph-rest-1.0
        /// </summary>
        public async Task<ServicehealthissueIncidentreportResponse> ServicehealthissueIncidentreportAsync(ServicehealthissueIncidentreportParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServicehealthissueIncidentreportParameter, ServicehealthissueIncidentreportResponse>(parameter, cancellationToken);
        }
    }
}
