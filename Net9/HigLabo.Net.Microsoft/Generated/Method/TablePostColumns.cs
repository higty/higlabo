using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/table-post-columns?view=graph-rest-1.0
/// </summary>
public partial class TablePostColumnsParameter : IRestApiParameter
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
                case ApiPath.Me_Drive_Items_Id_Workbook_Tables_IdOrname_Columns: return $"/me/drive/items/{Id}/workbook/tables/{IdOrName}/columns";
                case ApiPath.Me_Drive_Root_ItemPath_Workbook_Tables_IdOrname_Columns: return $"/me/drive/root:/{ItemPath}:/workbook/tables/{IdOrName}/columns";
                case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Tables_IdOrname_Columns: return $"/me/drive/items/{ItemsId}/workbook/worksheets/{WorksheetsIdOrName}/tables/{TablesIdOrName}/columns";
                case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Tables_IdOrname_Columns: return $"/me/drive/root:/{RootItemPath}/workbook/worksheets/{WorksheetsIdOrName}/tables/{TablesIdOrName}/columns";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Me_Drive_Items_Id_Workbook_Tables_IdOrname_Columns,
        Me_Drive_Root_ItemPath_Workbook_Tables_IdOrname_Columns,
        Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Tables_IdOrname_Columns,
        Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Tables_IdOrname_Columns,
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
    public string? Id { get; set; }
    public int? Index { get; set; }
    public string? Name { get; set; }
    public Json? Values { get; set; }
    public Filter? Filter { get; set; }
}
public partial class TablePostColumnsResponse : RestApiResponse
{
    public string? Id { get; set; }
    public int? Index { get; set; }
    public string? Name { get; set; }
    public Json? Values { get; set; }
    public Filter? Filter { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/table-post-columns?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/table-post-columns?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TablePostColumnsResponse> TablePostColumnsAsync()
    {
        var p = new TablePostColumnsParameter();
        return await this.SendAsync<TablePostColumnsParameter, TablePostColumnsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/table-post-columns?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TablePostColumnsResponse> TablePostColumnsAsync(CancellationToken cancellationToken)
    {
        var p = new TablePostColumnsParameter();
        return await this.SendAsync<TablePostColumnsParameter, TablePostColumnsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/table-post-columns?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TablePostColumnsResponse> TablePostColumnsAsync(TablePostColumnsParameter parameter)
    {
        return await this.SendAsync<TablePostColumnsParameter, TablePostColumnsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/table-post-columns?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TablePostColumnsResponse> TablePostColumnsAsync(TablePostColumnsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<TablePostColumnsParameter, TablePostColumnsResponse>(parameter, cancellationToken);
    }
}
