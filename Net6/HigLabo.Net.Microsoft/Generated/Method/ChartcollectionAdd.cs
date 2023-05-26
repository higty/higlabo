using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chartcollection-add?view=graph-rest-1.0
    /// </summary>
    public partial class ChartCollectionAddParameter : IRestApiParameter
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
                    case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Charts_Add: return $"/me/drive/items/{Id}/workbook/worksheets/{IdOrName}/charts/add";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Charts_Add: return $"/me/drive/root:/{ItemPath}:/workbook/worksheets/{IdOrName}/charts/add";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ChartCollectionAddParameterstring
        {
            ColumnClustered,
            ColumnStacked,
            ColumnStacked100,
            BarClustered,
            BarStacked,
            BarStacked100,
            LineStacked,
            LineStacked100,
            LineMarkers,
            LineMarkersStacked,
            LineMarkersStacked100,
            PieOfPie,
            Etc,
        }
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Charts_Add,
            Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Charts_Add,
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
        public ChartCollectionAddParameterstring Type { get; set; }
        public Json? SourceData { get; set; }
        public ChartCollectionAddParameterstring SeriesBy { get; set; }
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
    public partial class ChartCollectionAddResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/chartcollection-add?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chartcollection-add?view=graph-rest-1.0
        /// </summary>
        public async Task<ChartCollectionAddResponse> ChartCollectionAddAsync()
        {
            var p = new ChartCollectionAddParameter();
            return await this.SendAsync<ChartCollectionAddParameter, ChartCollectionAddResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chartcollection-add?view=graph-rest-1.0
        /// </summary>
        public async Task<ChartCollectionAddResponse> ChartCollectionAddAsync(CancellationToken cancellationToken)
        {
            var p = new ChartCollectionAddParameter();
            return await this.SendAsync<ChartCollectionAddParameter, ChartCollectionAddResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chartcollection-add?view=graph-rest-1.0
        /// </summary>
        public async Task<ChartCollectionAddResponse> ChartCollectionAddAsync(ChartCollectionAddParameter parameter)
        {
            return await this.SendAsync<ChartCollectionAddParameter, ChartCollectionAddResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chartcollection-add?view=graph-rest-1.0
        /// </summary>
        public async Task<ChartCollectionAddResponse> ChartCollectionAddAsync(ChartCollectionAddParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChartCollectionAddParameter, ChartCollectionAddResponse>(parameter, cancellationToken);
        }
    }
}
