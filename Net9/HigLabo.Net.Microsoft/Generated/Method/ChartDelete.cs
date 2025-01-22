using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/chart-delete?view=graph-rest-1.0
/// </summary>
public partial class ChartDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }
        public string? IdOrName { get; set; }
        public string? Name { get; set; }
        public string? ItemPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Charts_Name: return $"/me/drive/items/{Id}/workbook/worksheets/{IdOrName}/charts/{Name}";
                case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Charts_Name: return $"/me/drive/root:/{ItemPath}:/workbook/worksheets/{IdOrName}/charts/{Name}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Charts_Name,
        Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Charts_Name,
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
public partial class ChartDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/chart-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chart-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChartDeleteResponse> ChartDeleteAsync()
    {
        var p = new ChartDeleteParameter();
        return await this.SendAsync<ChartDeleteParameter, ChartDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chart-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChartDeleteResponse> ChartDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new ChartDeleteParameter();
        return await this.SendAsync<ChartDeleteParameter, ChartDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chart-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChartDeleteResponse> ChartDeleteAsync(ChartDeleteParameter parameter)
    {
        return await this.SendAsync<ChartDeleteParameter, ChartDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chart-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChartDeleteResponse> ChartDeleteAsync(ChartDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ChartDeleteParameter, ChartDeleteResponse>(parameter, cancellationToken);
    }
}
