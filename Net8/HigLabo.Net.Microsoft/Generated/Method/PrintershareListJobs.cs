using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printershare-list-jobs?view=graph-rest-1.0
    /// </summary>
    public partial class PrinterShareListJobsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? PrinterShareId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Shares_PrinterShareId_Jobs: return $"/print/shares/{PrinterShareId}/jobs";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Print_Shares_PrinterShareId_Jobs,
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
    public partial class PrinterShareListJobsResponse : RestApiResponse<PrintJob>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printershare-list-jobs?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printershare-list-jobs?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinterShareListJobsResponse> PrinterShareListJobsAsync()
        {
            var p = new PrinterShareListJobsParameter();
            return await this.SendAsync<PrinterShareListJobsParameter, PrinterShareListJobsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printershare-list-jobs?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinterShareListJobsResponse> PrinterShareListJobsAsync(CancellationToken cancellationToken)
        {
            var p = new PrinterShareListJobsParameter();
            return await this.SendAsync<PrinterShareListJobsParameter, PrinterShareListJobsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printershare-list-jobs?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinterShareListJobsResponse> PrinterShareListJobsAsync(PrinterShareListJobsParameter parameter)
        {
            return await this.SendAsync<PrinterShareListJobsParameter, PrinterShareListJobsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printershare-list-jobs?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinterShareListJobsResponse> PrinterShareListJobsAsync(PrinterShareListJobsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrinterShareListJobsParameter, PrinterShareListJobsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printershare-list-jobs?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<PrintJob> PrinterShareListJobsEnumerateAsync(PrinterShareListJobsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<PrinterShareListJobsParameter, PrinterShareListJobsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<PrintJob>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
