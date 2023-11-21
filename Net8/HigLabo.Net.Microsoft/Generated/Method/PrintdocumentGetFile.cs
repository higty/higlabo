using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printdocument-get-file?view=graph-rest-1.0
    /// </summary>
    public partial class PrintdocumentGetFileParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? PrinterId { get; set; }
            public string? PrintJobId { get; set; }
            public string? PrintDocumentId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Printers_PrinterId_Jobs_PrintJobId_Documents_PrintDocumentId_value: return $"/print/printers/{PrinterId}/jobs/{PrintJobId}/documents/{PrintDocumentId}/$value";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Print_Printers_PrinterId_Jobs_PrintJobId_Documents_PrintDocumentId_value,
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
    public partial class PrintdocumentGetFileResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printdocument-get-file?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printdocument-get-file?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintdocumentGetFileResponse> PrintdocumentGetFileAsync()
        {
            var p = new PrintdocumentGetFileParameter();
            return await this.SendAsync<PrintdocumentGetFileParameter, PrintdocumentGetFileResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printdocument-get-file?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintdocumentGetFileResponse> PrintdocumentGetFileAsync(CancellationToken cancellationToken)
        {
            var p = new PrintdocumentGetFileParameter();
            return await this.SendAsync<PrintdocumentGetFileParameter, PrintdocumentGetFileResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printdocument-get-file?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintdocumentGetFileResponse> PrintdocumentGetFileAsync(PrintdocumentGetFileParameter parameter)
        {
            return await this.SendAsync<PrintdocumentGetFileParameter, PrintdocumentGetFileResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printdocument-get-file?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintdocumentGetFileResponse> PrintdocumentGetFileAsync(PrintdocumentGetFileParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintdocumentGetFileParameter, PrintdocumentGetFileResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printdocument-get-file?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<Stream> PrintdocumentGetFileStreamAsync(PrintdocumentGetFileParameter parameter, CancellationToken cancellationToken)
        {
            return await this.DownloadStreamAsync(parameter, cancellationToken);
        }
    }
}
