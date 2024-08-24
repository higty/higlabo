using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-list?view=graph-rest-1.0
    /// </summary>
    public partial class ExternalConnectorsExternalconnectionListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.External_Connections: return $"/external/connections";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            External_Connections,
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
    public partial class ExternalConnectorsExternalconnectionListResponse : RestApiResponse<ExternalConnectorsExternalconnection>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalconnectionListResponse> ExternalConnectorsExternalconnectionListAsync()
        {
            var p = new ExternalConnectorsExternalconnectionListParameter();
            return await this.SendAsync<ExternalConnectorsExternalconnectionListParameter, ExternalConnectorsExternalconnectionListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalconnectionListResponse> ExternalConnectorsExternalconnectionListAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalConnectorsExternalconnectionListParameter();
            return await this.SendAsync<ExternalConnectorsExternalconnectionListParameter, ExternalConnectorsExternalconnectionListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalconnectionListResponse> ExternalConnectorsExternalconnectionListAsync(ExternalConnectorsExternalconnectionListParameter parameter)
        {
            return await this.SendAsync<ExternalConnectorsExternalconnectionListParameter, ExternalConnectorsExternalconnectionListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ExternalConnectorsExternalconnectionListResponse> ExternalConnectorsExternalconnectionListAsync(ExternalConnectorsExternalconnectionListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalConnectorsExternalconnectionListParameter, ExternalConnectorsExternalconnectionListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalconnection-list?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<ExternalConnectorsExternalconnection> ExternalConnectorsExternalconnectionListEnumerateAsync(ExternalConnectorsExternalconnectionListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<ExternalConnectorsExternalconnectionListParameter, ExternalConnectorsExternalconnectionListResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<ExternalConnectorsExternalconnection>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
