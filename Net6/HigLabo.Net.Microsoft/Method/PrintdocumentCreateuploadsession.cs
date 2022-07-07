using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrintdocumentCreateuploadsessionParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Print_Printers_Id_Jobs_Id_Documents_Id_CreateUploadSession,
            Print_Shares_Id_Jobs_Id_Documents_Id_CreateUploadSession,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Print_Printers_Id_Jobs_Id_Documents_Id_CreateUploadSession: return $"/print/printers/{PrintersId}/jobs/{JobsId}/documents/{DocumentsId}/createUploadSession";
                    case ApiPath.Print_Shares_Id_Jobs_Id_Documents_Id_CreateUploadSession: return $"/print/shares/{SharesId}/jobs/{JobsId}/documents/{DocumentsId}/createUploadSession";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public PrintDocumentUploadProperties? Properties { get; set; }
        public string PrintersId { get; set; }
        public string JobsId { get; set; }
        public string DocumentsId { get; set; }
        public string SharesId { get; set; }
    }
    public partial class PrintdocumentCreateuploadsessionResponse : RestApiResponse
    {
        public DateTimeOffset? ExpirationDateTime { get; set; }
        public String[]? NextExpectedRanges { get; set; }
        public string? UploadUrl { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printdocument-createuploadsession?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintdocumentCreateuploadsessionResponse> PrintdocumentCreateuploadsessionAsync()
        {
            var p = new PrintdocumentCreateuploadsessionParameter();
            return await this.SendAsync<PrintdocumentCreateuploadsessionParameter, PrintdocumentCreateuploadsessionResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printdocument-createuploadsession?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintdocumentCreateuploadsessionResponse> PrintdocumentCreateuploadsessionAsync(CancellationToken cancellationToken)
        {
            var p = new PrintdocumentCreateuploadsessionParameter();
            return await this.SendAsync<PrintdocumentCreateuploadsessionParameter, PrintdocumentCreateuploadsessionResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printdocument-createuploadsession?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintdocumentCreateuploadsessionResponse> PrintdocumentCreateuploadsessionAsync(PrintdocumentCreateuploadsessionParameter parameter)
        {
            return await this.SendAsync<PrintdocumentCreateuploadsessionParameter, PrintdocumentCreateuploadsessionResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printdocument-createuploadsession?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintdocumentCreateuploadsessionResponse> PrintdocumentCreateuploadsessionAsync(PrintdocumentCreateuploadsessionParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintdocumentCreateuploadsessionParameter, PrintdocumentCreateuploadsessionResponse>(parameter, cancellationToken);
        }
    }
}
