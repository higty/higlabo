using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrintdocumentGetFileParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Print_Printers_PrinterId_Jobs_PrintJobId_Documents_PrintDocumentId_value,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Print_Printers_PrinterId_Jobs_PrintJobId_Documents_PrintDocumentId_value: return $"/print/printers/{PrinterId}/jobs/{PrintJobId}/documents/{PrintDocumentId}/$value";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string PrinterId { get; set; }
        public string PrintJobId { get; set; }
        public string PrintDocumentId { get; set; }
    }
    public partial class PrintdocumentGetFileResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printdocument-get-file?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintdocumentGetFileResponse> PrintdocumentGetFileAsync()
        {
            var p = new PrintdocumentGetFileParameter();
            return await this.SendAsync<PrintdocumentGetFileParameter, PrintdocumentGetFileResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printdocument-get-file?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintdocumentGetFileResponse> PrintdocumentGetFileAsync(CancellationToken cancellationToken)
        {
            var p = new PrintdocumentGetFileParameter();
            return await this.SendAsync<PrintdocumentGetFileParameter, PrintdocumentGetFileResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printdocument-get-file?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintdocumentGetFileResponse> PrintdocumentGetFileAsync(PrintdocumentGetFileParameter parameter)
        {
            return await this.SendAsync<PrintdocumentGetFileParameter, PrintdocumentGetFileResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printdocument-get-file?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintdocumentGetFileResponse> PrintdocumentGetFileAsync(PrintdocumentGetFileParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintdocumentGetFileParameter, PrintdocumentGetFileResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printdocument-get-file?view=graph-rest-1.0
        /// </summary>
        public async Task<Stream> PrintdocumentGetFileStreamAsync(PrintdocumentGetFileParameter parameter, CancellationToken cancellationToken)
        {
            return await this.DownloadStreamAsync(parameter, cancellationToken);
        }
    }
}
