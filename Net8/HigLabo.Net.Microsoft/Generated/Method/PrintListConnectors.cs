using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-list-connectors?view=graph-rest-1.0
    /// </summary>
    public partial class PrintListConnectorsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Connectors: return $"/print/connectors";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Print_Connectors,
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
    public partial class PrintListConnectorsResponse : RestApiResponse<PrintConnector>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-list-connectors?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-list-connectors?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintListConnectorsResponse> PrintListConnectorsAsync()
        {
            var p = new PrintListConnectorsParameter();
            return await this.SendAsync<PrintListConnectorsParameter, PrintListConnectorsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-list-connectors?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintListConnectorsResponse> PrintListConnectorsAsync(CancellationToken cancellationToken)
        {
            var p = new PrintListConnectorsParameter();
            return await this.SendAsync<PrintListConnectorsParameter, PrintListConnectorsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-list-connectors?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintListConnectorsResponse> PrintListConnectorsAsync(PrintListConnectorsParameter parameter)
        {
            return await this.SendAsync<PrintListConnectorsParameter, PrintListConnectorsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-list-connectors?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintListConnectorsResponse> PrintListConnectorsAsync(PrintListConnectorsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintListConnectorsParameter, PrintListConnectorsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-list-connectors?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<PrintConnector> PrintListConnectorsEnumerateAsync(PrintListConnectorsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<PrintListConnectorsParameter, PrintListConnectorsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<PrintConnector>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
