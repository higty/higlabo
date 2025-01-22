using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/chart-list?view=graph-rest-1.0
/// </summary>
public partial class ChartListParameter : IRestApiParameter, IQueryParameterProperty
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
                case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Charts: return $"/me/drive/items/{Id}/workbook/worksheets/{IdOrName}/charts";
                case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Charts: return $"/me/drive/root:/{ItemPath}:/workbook/worksheets/{IdOrName}/charts";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Charts,
        Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Charts,
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
public partial class ChartListResponse : RestApiResponse<Chart>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/chart-list?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chart-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChartListResponse> ChartListAsync()
    {
        var p = new ChartListParameter();
        return await this.SendAsync<ChartListParameter, ChartListResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chart-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChartListResponse> ChartListAsync(CancellationToken cancellationToken)
    {
        var p = new ChartListParameter();
        return await this.SendAsync<ChartListParameter, ChartListResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chart-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChartListResponse> ChartListAsync(ChartListParameter parameter)
    {
        return await this.SendAsync<ChartListParameter, ChartListResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chart-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ChartListResponse> ChartListAsync(ChartListParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ChartListParameter, ChartListResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chart-list?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<Chart> ChartListEnumerateAsync(ChartListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<ChartListParameter, ChartListResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<Chart>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
