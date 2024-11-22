using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/worksheet-delete?view=graph-rest-1.0
/// </summary>
public partial class WorksheetDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }
        public string? IdOrName { get; set; }
        public string? ItemPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets_IdOrname: return $"/me/drive/items/{Id}/workbook/worksheets/{IdOrName}";
                case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname: return $"/me/drive/root:/{ItemPath}:/workbook/worksheets/{IdOrName}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Me_Drive_Items_Id_Workbook_Worksheets_IdOrname,
        Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "DELETE";
}
public partial class WorksheetDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/worksheet-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/worksheet-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<WorksheetDeleteResponse> WorksheetDeleteAsync()
    {
        var p = new WorksheetDeleteParameter();
        return await this.SendAsync<WorksheetDeleteParameter, WorksheetDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/worksheet-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<WorksheetDeleteResponse> WorksheetDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new WorksheetDeleteParameter();
        return await this.SendAsync<WorksheetDeleteParameter, WorksheetDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/worksheet-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<WorksheetDeleteResponse> WorksheetDeleteAsync(WorksheetDeleteParameter parameter)
    {
        return await this.SendAsync<WorksheetDeleteParameter, WorksheetDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/worksheet-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<WorksheetDeleteResponse> WorksheetDeleteAsync(WorksheetDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<WorksheetDeleteParameter, WorksheetDeleteResponse>(parameter, cancellationToken);
    }
}
