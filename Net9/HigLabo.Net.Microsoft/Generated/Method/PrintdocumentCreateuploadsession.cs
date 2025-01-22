using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/printdocument-createuploadsession?view=graph-rest-1.0
/// </summary>
public partial class PrintdocumentCreateuploadsessionParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? PrintersId { get; set; }
        public string? JobsId { get; set; }
        public string? DocumentsId { get; set; }
        public string? SharesId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Print_Printers_Id_Jobs_Id_Documents_Id_CreateUploadSession: return $"/print/printers/{PrintersId}/jobs/{JobsId}/documents/{DocumentsId}/createUploadSession";
                case ApiPath.Print_Shares_Id_Jobs_Id_Documents_Id_CreateUploadSession: return $"/print/shares/{SharesId}/jobs/{JobsId}/documents/{DocumentsId}/createUploadSession";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Print_Printers_Id_Jobs_Id_Documents_Id_CreateUploadSession,
        Print_Shares_Id_Jobs_Id_Documents_Id_CreateUploadSession,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "POST";
    public PrintDocumentUploadProperties? Properties { get; set; }
    public DateTimeOffset? ExpirationDateTime { get; set; }
    public String[]? NextExpectedRanges { get; set; }
    public string? UploadUrl { get; set; }
}
public partial class PrintdocumentCreateuploadsessionResponse : RestApiResponse
{
    public DateTimeOffset? ExpirationDateTime { get; set; }
    public String[]? NextExpectedRanges { get; set; }
    public string? UploadUrl { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/printdocument-createuploadsession?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printdocument-createuploadsession?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrintdocumentCreateuploadsessionResponse> PrintdocumentCreateuploadsessionAsync()
    {
        var p = new PrintdocumentCreateuploadsessionParameter();
        return await this.SendAsync<PrintdocumentCreateuploadsessionParameter, PrintdocumentCreateuploadsessionResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printdocument-createuploadsession?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrintdocumentCreateuploadsessionResponse> PrintdocumentCreateuploadsessionAsync(CancellationToken cancellationToken)
    {
        var p = new PrintdocumentCreateuploadsessionParameter();
        return await this.SendAsync<PrintdocumentCreateuploadsessionParameter, PrintdocumentCreateuploadsessionResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printdocument-createuploadsession?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrintdocumentCreateuploadsessionResponse> PrintdocumentCreateuploadsessionAsync(PrintdocumentCreateuploadsessionParameter parameter)
    {
        return await this.SendAsync<PrintdocumentCreateuploadsessionParameter, PrintdocumentCreateuploadsessionResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printdocument-createuploadsession?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrintdocumentCreateuploadsessionResponse> PrintdocumentCreateuploadsessionAsync(PrintdocumentCreateuploadsessionParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<PrintdocumentCreateuploadsessionParameter, PrintdocumentCreateuploadsessionResponse>(parameter, cancellationToken);
    }
}
