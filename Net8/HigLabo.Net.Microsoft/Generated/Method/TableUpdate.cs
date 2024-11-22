using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/table-update?view=graph-rest-1.0
/// </summary>
public partial class TableUpdateParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }
        public string? IdOrName { get; set; }
        public string? ItemPath { get; set; }
        public string? ItemsId { get; set; }
        public string? WorksheetsIdOrName { get; set; }
        public string? TablesIdOrName { get; set; }
        public string? RootItemPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_Drive_Items_Id_Workbook_Tables_IdOrname: return $"/me/drive/items/{Id}/workbook/tables/{IdOrName}";
                case ApiPath.Me_Drive_Root_ItemPath_Workbook_Tables_IdOrname: return $"/me/drive/root:/{ItemPath}:/workbook/tables/{IdOrName}";
                case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Tables_IdOrname: return $"/me/drive/items/{ItemsId}/workbook/worksheets/{WorksheetsIdOrName}/tables/{TablesIdOrName}";
                case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Tables_IdOrname: return $"/me/drive/root:/{RootItemPath}/workbook/worksheets/{WorksheetsIdOrName}/tables/{TablesIdOrName}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum TableUpdateParameterstring
    {
        TableStyleLight1,
        TableStyleLight21,
        TableStyleMedium1,
        TableStyleMedium28,
        TableStyleDark1,
        TableStyleDark11,
    }
    public enum ApiPath
    {
        Me_Drive_Items_Id_Workbook_Tables_IdOrname,
        Me_Drive_Root_ItemPath_Workbook_Tables_IdOrname,
        Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Tables_IdOrname,
        Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Tables_IdOrname,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "PATCH";
    public string? Name { get; set; }
    public bool? ShowHeaders { get; set; }
    public bool? ShowTotals { get; set; }
    public TableUpdateParameterstring Style { get; set; }
}
public partial class TableUpdateResponse : RestApiResponse
{
    public bool? HighlightFirstColumn { get; set; }
    public bool? HighlightLastColumn { get; set; }
    public string? Id { get; set; }
    public string? LegacyId { get; set; }
    public string? Name { get; set; }
    public bool? ShowBandedRows { get; set; }
    public bool? ShowBandedColumns { get; set; }
    public bool? ShowFilterButton { get; set; }
    public bool? ShowHeaders { get; set; }
    public bool? ShowTotals { get; set; }
    public string? Style { get; set; }
    public WorkbookTableColumn[]? Columns { get; set; }
    public WorkbookTableRow[]? Rows { get; set; }
    public TableSort? Sort { get; set; }
    public Worksheet? Worksheet { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/table-update?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/table-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TableUpdateResponse> TableUpdateAsync()
    {
        var p = new TableUpdateParameter();
        return await this.SendAsync<TableUpdateParameter, TableUpdateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/table-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TableUpdateResponse> TableUpdateAsync(CancellationToken cancellationToken)
    {
        var p = new TableUpdateParameter();
        return await this.SendAsync<TableUpdateParameter, TableUpdateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/table-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TableUpdateResponse> TableUpdateAsync(TableUpdateParameter parameter)
    {
        return await this.SendAsync<TableUpdateParameter, TableUpdateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/table-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TableUpdateResponse> TableUpdateAsync(TableUpdateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<TableUpdateParameter, TableUpdateResponse>(parameter, cancellationToken);
    }
}
