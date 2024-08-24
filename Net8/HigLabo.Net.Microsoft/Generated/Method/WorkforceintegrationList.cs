using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

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
    public partial class WorkforceintegrationListResponse : RestApiResponse<WorkforceIntegration>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/workforceintegration-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/workforceintegration-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WorkforceintegrationListResponse> WorkforceintegrationListAsync()
        {
            var p = new WorkforceintegrationListParameter();
            return await this.SendAsync<WorkforceintegrationListParameter, WorkforceintegrationListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/workforceintegration-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WorkforceintegrationListResponse> WorkforceintegrationListAsync(CancellationToken cancellationToken)
        {
            var p = new WorkforceintegrationListParameter();
            return await this.SendAsync<WorkforceintegrationListParameter, WorkforceintegrationListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/workforceintegration-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WorkforceintegrationListResponse> WorkforceintegrationListAsync(WorkforceintegrationListParameter parameter)
        {
            return await this.SendAsync<WorkforceintegrationListParameter, WorkforceintegrationListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/workforceintegration-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WorkforceintegrationListResponse> WorkforceintegrationListAsync(WorkforceintegrationListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorkforceintegrationListParameter, WorkforceintegrationListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/workforceintegration-list?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<WorkforceIntegration> WorkforceintegrationListEnumerateAsync(WorkforceintegrationListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<WorkforceintegrationListParameter, WorkforceintegrationListResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<WorkforceIntegration>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
