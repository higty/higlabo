using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/workforceintegration-list?view=graph-rest-1.0
    /// </summary>
    public partial class WorkforceintegrationListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teamwork_WorkforceIntegrations: return $"/teamwork/workforceIntegrations";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            ApiVersion,
            DisplayName,
            Encryption,
            IsActive,
            SupportedEntities,
            Url,
        }
        public enum ApiPath
        {
            Teamwork_WorkforceIntegrations,
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
    public partial class WorkforceintegrationListResponse : RestApiResponse
    {
        public WorkforceIntegration[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/workforceintegration-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/workforceintegration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkforceintegrationListResponse> WorkforceintegrationListAsync()
        {
            var p = new WorkforceintegrationListParameter();
            return await this.SendAsync<WorkforceintegrationListParameter, WorkforceintegrationListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/workforceintegration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkforceintegrationListResponse> WorkforceintegrationListAsync(CancellationToken cancellationToken)
        {
            var p = new WorkforceintegrationListParameter();
            return await this.SendAsync<WorkforceintegrationListParameter, WorkforceintegrationListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/workforceintegration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkforceintegrationListResponse> WorkforceintegrationListAsync(WorkforceintegrationListParameter parameter)
        {
            return await this.SendAsync<WorkforceintegrationListParameter, WorkforceintegrationListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/workforceintegration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkforceintegrationListResponse> WorkforceintegrationListAsync(WorkforceintegrationListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorkforceintegrationListParameter, WorkforceintegrationListResponse>(parameter, cancellationToken);
        }
    }
}
