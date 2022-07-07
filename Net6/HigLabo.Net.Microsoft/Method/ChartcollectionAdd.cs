using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChartcollectionAddParameter : IRestApiParameter
    {
        public enum ChartcollectionAddParameterstring
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

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Charts_Add: return $"/me/drive/items/{Id}/workbook/worksheets/{IdOrName}/charts/add";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Charts_Add: return $"/me/drive/root:/{ItemPath}:/workbook/worksheets/{IdOrName}/charts/add";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public ChartcollectionAddParameterstring Type { get; set; }
        public Json? SourceData { get; set; }
        public ChartcollectionAddParameterstring SeriesBy { get; set; }
        public string Id { get; set; }
        public string IdOrName { get; set; }
        public string ItemPath { get; set; }
    }
    public partial class ChartcollectionAddResponse : RestApiResponse
    {
        public Double? Height { get; set; }
        public string? Id { get; set; }
        public Double? Left { get; set; }
        public string? Name { get; set; }
        public Double? Top { get; set; }
        public Double? Width { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chartcollection-add?view=graph-rest-1.0
        /// </summary>
        public async Task<ChartcollectionAddResponse> ChartcollectionAddAsync()
        {
            var p = new ChartcollectionAddParameter();
            return await this.SendAsync<ChartcollectionAddParameter, ChartcollectionAddResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chartcollection-add?view=graph-rest-1.0
        /// </summary>
        public async Task<ChartcollectionAddResponse> ChartcollectionAddAsync(CancellationToken cancellationToken)
        {
            var p = new ChartcollectionAddParameter();
            return await this.SendAsync<ChartcollectionAddParameter, ChartcollectionAddResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chartcollection-add?view=graph-rest-1.0
        /// </summary>
        public async Task<ChartcollectionAddResponse> ChartcollectionAddAsync(ChartcollectionAddParameter parameter)
        {
            return await this.SendAsync<ChartcollectionAddParameter, ChartcollectionAddResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chartcollection-add?view=graph-rest-1.0
        /// </summary>
        public async Task<ChartcollectionAddResponse> ChartcollectionAddAsync(ChartcollectionAddParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChartcollectionAddParameter, ChartcollectionAddResponse>(parameter, cancellationToken);
        }
    }
}
