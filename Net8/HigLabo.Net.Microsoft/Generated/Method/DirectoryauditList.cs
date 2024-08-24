using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryaudit-list?view=graph-rest-1.0
    /// </summary>
    public partial class DirectoryAuditListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.AuditLogs_Directoryaudits: return $"/auditLogs/directoryaudits";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            AuditLogs_Directoryaudits,
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
    public partial class DirectoryAuditListResponse : RestApiResponse<DirectoryAudit>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryaudit-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryaudit-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryAuditListResponse> DirectoryAuditListAsync()
        {
            var p = new DirectoryAuditListParameter();
            return await this.SendAsync<DirectoryAuditListParameter, DirectoryAuditListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryaudit-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryAuditListResponse> DirectoryAuditListAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryAuditListParameter();
            return await this.SendAsync<DirectoryAuditListParameter, DirectoryAuditListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryaudit-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryAuditListResponse> DirectoryAuditListAsync(DirectoryAuditListParameter parameter)
        {
            return await this.SendAsync<DirectoryAuditListParameter, DirectoryAuditListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryaudit-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryAuditListResponse> DirectoryAuditListAsync(DirectoryAuditListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryAuditListParameter, DirectoryAuditListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryaudit-list?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<DirectoryAudit> DirectoryAuditListEnumerateAsync(DirectoryAuditListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<DirectoryAuditListParameter, DirectoryAuditListResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<DirectoryAudit>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
