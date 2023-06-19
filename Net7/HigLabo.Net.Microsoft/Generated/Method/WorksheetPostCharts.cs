using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/worksheet-post-charts?view=graph-rest-1.0
    /// </summary>
    public partial class WorksheetPostChartsParameter : IRestApiParameter
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
                    case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Charts_: return $"/me/drive/items/{Id}/workbook/worksheets/{IdOrName}/charts/";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Charts_: return $"/me/drive/root:/{ItemPath}:/workbook/worksheets/{IdOrName}/charts/";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Charts_,
            Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Charts_,
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
    public partial class WorksheetPostChartsResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/worksheet-post-charts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/worksheet-post-charts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WorksheetPostChartsResponse> WorksheetPostChartsAsync()
        {
            var p = new WorksheetPostChartsParameter();
            return await this.SendAsync<WorksheetPostChartsParameter, WorksheetPostChartsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/worksheet-post-charts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WorksheetPostChartsResponse> WorksheetPostChartsAsync(CancellationToken cancellationToken)
        {
            var p = new WorksheetPostChartsParameter();
            return await this.SendAsync<WorksheetPostChartsParameter, WorksheetPostChartsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/worksheet-post-charts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WorksheetPostChartsResponse> WorksheetPostChartsAsync(WorksheetPostChartsParameter parameter)
        {
            return await this.SendAsync<WorksheetPostChartsParameter, WorksheetPostChartsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/worksheet-post-charts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WorksheetPostChartsResponse> WorksheetPostChartsAsync(WorksheetPostChartsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorksheetPostChartsParameter, WorksheetPostChartsResponse>(parameter, cancellationToken);
        }
    }
}
