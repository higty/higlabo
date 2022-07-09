using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChartGetParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
            Height,
            Id,
            Left,
            Name,
            Top,
            Width,
            Axes,
            DataLabels,
            Format,
            Legend,
            Series,
            Title,
            Worksheet,
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
    public partial class ChartGetResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chart-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ChartGetResponse> ChartGetAsync()
        {
            var p = new ChartGetParameter();
            return await this.SendAsync<ChartGetParameter, ChartGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chart-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ChartGetResponse> ChartGetAsync(CancellationToken cancellationToken)
        {
            var p = new ChartGetParameter();
            return await this.SendAsync<ChartGetParameter, ChartGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chart-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ChartGetResponse> ChartGetAsync(ChartGetParameter parameter)
        {
            return await this.SendAsync<ChartGetParameter, ChartGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chart-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ChartGetResponse> ChartGetAsync(ChartGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChartGetParameter, ChartGetResponse>(parameter, cancellationToken);
        }
    }
}
