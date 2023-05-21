using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printershare-list-jobs?view=graph-rest-1.0
    /// </summary>
    public partial class PrintershareListJobsParameter : IRestApiParameter, IQueryParameterProperty
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
            Configuration,
            CreatedBy,
            CreatedDateTime,
            Id,
            IsFetchable,
            RedirectedFrom,
            RedirectedTo,
            Status,
            Documents,
            Tasks,
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
    public partial class PrintershareListJobsResponse : RestApiResponse
    {
        public PrintJob[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printershare-list-jobs?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printershare-list-jobs?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareListJobsResponse> PrintershareListJobsAsync()
        {
            var p = new PrintershareListJobsParameter();
            return await this.SendAsync<PrintershareListJobsParameter, PrintershareListJobsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printershare-list-jobs?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareListJobsResponse> PrintershareListJobsAsync(CancellationToken cancellationToken)
        {
            var p = new PrintershareListJobsParameter();
            return await this.SendAsync<PrintershareListJobsParameter, PrintershareListJobsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printershare-list-jobs?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareListJobsResponse> PrintershareListJobsAsync(PrintershareListJobsParameter parameter)
        {
            return await this.SendAsync<PrintershareListJobsParameter, PrintershareListJobsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printershare-list-jobs?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareListJobsResponse> PrintershareListJobsAsync(PrintershareListJobsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintershareListJobsParameter, PrintershareListJobsResponse>(parameter, cancellationToken);
        }
    }
}
