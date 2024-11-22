using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/workbook-list-worksheets?view=graph-rest-1.0
/// </summary>
public partial class WorkbookListWorksheetsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }
        public string? ItemPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets: return $"/me/drive/items/{Id}/workbook/worksheets";
                case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets: return $"/me/drive/root:/{ItemPath}:/workbook/worksheets";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
        Id,
        Name,
        Position,
        Visibility,
        Charts,
        Names,
        PivotTables,
        Protection,
        Tables,
    }
    public enum ApiPath
    {
        Me_Drive_Items_Id_Workbook_Worksheets,
        Me_Drive_Root_ItemPath_Workbook_Worksheets,
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
public partial class WorkbookListWorksheetsResponse : RestApiResponse
{
    public Worksheet[]? Value { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/workbook-list-worksheets?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/workbook-list-worksheets?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<WorkbookListWorksheetsResponse> WorkbookListWorksheetsAsync()
    {
        var p = new WorkbookListWorksheetsParameter();
        return await this.SendAsync<WorkbookListWorksheetsParameter, WorkbookListWorksheetsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/workbook-list-worksheets?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<WorkbookListWorksheetsResponse> WorkbookListWorksheetsAsync(CancellationToken cancellationToken)
    {
        var p = new WorkbookListWorksheetsParameter();
        return await this.SendAsync<WorkbookListWorksheetsParameter, WorkbookListWorksheetsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/workbook-list-worksheets?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<WorkbookListWorksheetsResponse> WorkbookListWorksheetsAsync(WorkbookListWorksheetsParameter parameter)
    {
        return await this.SendAsync<WorkbookListWorksheetsParameter, WorkbookListWorksheetsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/workbook-list-worksheets?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<WorkbookListWorksheetsResponse> WorkbookListWorksheetsAsync(WorkbookListWorksheetsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<WorkbookListWorksheetsParameter, WorkbookListWorksheetsResponse>(parameter, cancellationToken);
    }
}
