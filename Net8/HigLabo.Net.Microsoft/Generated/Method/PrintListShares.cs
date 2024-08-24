using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-list-shares?view=graph-rest-1.0
    /// </summary>
    public partial class PrintListSharesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Shares: return $"/print/shares";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Print_Shares,
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
    public partial class PrintListSharesResponse : RestApiResponse<PrinterShare>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-list-shares?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-list-shares?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintListSharesResponse> PrintListSharesAsync()
        {
            var p = new PrintListSharesParameter();
            return await this.SendAsync<PrintListSharesParameter, PrintListSharesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-list-shares?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintListSharesResponse> PrintListSharesAsync(CancellationToken cancellationToken)
        {
            var p = new PrintListSharesParameter();
            return await this.SendAsync<PrintListSharesParameter, PrintListSharesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-list-shares?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintListSharesResponse> PrintListSharesAsync(PrintListSharesParameter parameter)
        {
            return await this.SendAsync<PrintListSharesParameter, PrintListSharesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-list-shares?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintListSharesResponse> PrintListSharesAsync(PrintListSharesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintListSharesParameter, PrintListSharesResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-list-shares?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<PrinterShare> PrintListSharesEnumerateAsync(PrintListSharesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<PrintListSharesParameter, PrintListSharesResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<PrinterShare>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
