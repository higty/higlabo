using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/provisioningobjectsummary-list?view=graph-rest-1.0
    /// </summary>
    public partial class ProvisioningObjectSummaryListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.AuditLogs_Provisioning: return $"/auditLogs/provisioning";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            AuditLogs_Provisioning,
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
    public partial class ProvisioningObjectSummaryListResponse : RestApiResponse<ProvisioningObjectSummary>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/provisioningobjectsummary-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/provisioningobjectsummary-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ProvisioningObjectSummaryListResponse> ProvisioningObjectSummaryListAsync()
        {
            var p = new ProvisioningObjectSummaryListParameter();
            return await this.SendAsync<ProvisioningObjectSummaryListParameter, ProvisioningObjectSummaryListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/provisioningobjectsummary-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ProvisioningObjectSummaryListResponse> ProvisioningObjectSummaryListAsync(CancellationToken cancellationToken)
        {
            var p = new ProvisioningObjectSummaryListParameter();
            return await this.SendAsync<ProvisioningObjectSummaryListParameter, ProvisioningObjectSummaryListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/provisioningobjectsummary-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ProvisioningObjectSummaryListResponse> ProvisioningObjectSummaryListAsync(ProvisioningObjectSummaryListParameter parameter)
        {
            return await this.SendAsync<ProvisioningObjectSummaryListParameter, ProvisioningObjectSummaryListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/provisioningobjectsummary-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ProvisioningObjectSummaryListResponse> ProvisioningObjectSummaryListAsync(ProvisioningObjectSummaryListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ProvisioningObjectSummaryListParameter, ProvisioningObjectSummaryListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/provisioningobjectsummary-list?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<ProvisioningObjectSummary> ProvisioningObjectSummaryListEnumerateAsync(ProvisioningObjectSummaryListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<ProvisioningObjectSummaryListParameter, ProvisioningObjectSummaryListResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<ProvisioningObjectSummary>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
