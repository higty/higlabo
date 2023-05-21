using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceannouncement-list-healthoverviews?view=graph-rest-1.0
    /// </summary>
    public partial class ServiceannouncementListHealthoverviewsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Admin_ServiceAnnouncement_HealthOverviews: return $"/admin/serviceAnnouncement/healthOverviews";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Id,
            Service,
            Status,
            Issues,
        }
        public enum ApiPath
        {
            Admin_ServiceAnnouncement_HealthOverviews,
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
    public partial class ServiceannouncementListHealthoverviewsResponse : RestApiResponse
    {
        public ServiceHealth[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceannouncement-list-healthoverviews?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceannouncement-list-healthoverviews?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceannouncementListHealthoverviewsResponse> ServiceannouncementListHealthoverviewsAsync()
        {
            var p = new ServiceannouncementListHealthoverviewsParameter();
            return await this.SendAsync<ServiceannouncementListHealthoverviewsParameter, ServiceannouncementListHealthoverviewsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceannouncement-list-healthoverviews?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceannouncementListHealthoverviewsResponse> ServiceannouncementListHealthoverviewsAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceannouncementListHealthoverviewsParameter();
            return await this.SendAsync<ServiceannouncementListHealthoverviewsParameter, ServiceannouncementListHealthoverviewsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceannouncement-list-healthoverviews?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceannouncementListHealthoverviewsResponse> ServiceannouncementListHealthoverviewsAsync(ServiceannouncementListHealthoverviewsParameter parameter)
        {
            return await this.SendAsync<ServiceannouncementListHealthoverviewsParameter, ServiceannouncementListHealthoverviewsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceannouncement-list-healthoverviews?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceannouncementListHealthoverviewsResponse> ServiceannouncementListHealthoverviewsAsync(ServiceannouncementListHealthoverviewsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceannouncementListHealthoverviewsParameter, ServiceannouncementListHealthoverviewsResponse>(parameter, cancellationToken);
        }
    }
}
