﻿using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/chart-update?view=graph-rest-1.0
/// </summary>
public partial class ChartUpdateParameter : IRestApiParameter
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
    string IRestApiParameter.HttpMethod { get; } = "PATCH";
    public Double? Height { get; set; }
    public Double? Left { get; set; }
    public string? Name { get; set; }
    public Double? Top { get; set; }
    public Double? Width { get; set; }
}
public partial class ChartUpdateResponse : RestApiResponse
{
    public Double? Height { get; set; }
    public string? Id { get; set; }
    public Double? Left { get; set; }
    public string? Name { get; set; }
    public Double? Top { get; set; }
    public Double? Width { get; set; }
    public ChartAxes? Axes { get; set; }
    public ChartDataLabels? DataLabels { get; set; }
    public ChartAreaFormat? Format { get; set; }
    public ChartLegend? Legend { get; set; }
    public ChartSeries[]? Series { get; set; }
    public ChartTitle? Title { get; set; }
    public Worksheet? Worksheet { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/chart-update?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chart-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChartUpdateResponse> ChartUpdateAsync()
    {
        var p = new ChartUpdateParameter();
        return await this.SendAsync<ChartUpdateParameter, ChartUpdateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chart-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChartUpdateResponse> ChartUpdateAsync(CancellationToken cancellationToken)
    {
        var p = new ChartUpdateParameter();
        return await this.SendAsync<ChartUpdateParameter, ChartUpdateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chart-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChartUpdateResponse> ChartUpdateAsync(ChartUpdateParameter parameter)
    {
        return await this.SendAsync<ChartUpdateParameter, ChartUpdateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chart-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChartUpdateResponse> ChartUpdateAsync(ChartUpdateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ChartUpdateParameter, ChartUpdateResponse>(parameter, cancellationToken);
    }
}
