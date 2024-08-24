using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printer-list-jobs?view=graph-rest-1.0
    /// </summary>
    public partial class PrinterListJobsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? PrinterId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Printers_PrinterId_Jobs: return $"/print/printers/{PrinterId}/jobs";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Print_Printers_PrinterId_Jobs,
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
    public partial class PrinterListJobsResponse : RestApiResponse<PrintJob>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printer-list-jobs?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printer-list-jobs?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinterListJobsResponse> PrinterListJobsAsync()
        {
            var p = new PrinterListJobsParameter();
            return await this.SendAsync<PrinterListJobsParameter, PrinterListJobsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printer-list-jobs?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinterListJobsResponse> PrinterListJobsAsync(CancellationToken cancellationToken)
        {
            var p = new PrinterListJobsParameter();
            return await this.SendAsync<PrinterListJobsParameter, PrinterListJobsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printer-list-jobs?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinterListJobsResponse> PrinterListJobsAsync(PrinterListJobsParameter parameter)
        {
            return await this.SendAsync<PrinterListJobsParameter, PrinterListJobsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printer-list-jobs?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinterListJobsResponse> PrinterListJobsAsync(PrinterListJobsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrinterListJobsParameter, PrinterListJobsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printer-list-jobs?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<PrintJob> PrinterListJobsEnumerateAsync(PrinterListJobsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<PrinterListJobsParameter, PrinterListJobsResponse>(parameter, cancellationToken);
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
