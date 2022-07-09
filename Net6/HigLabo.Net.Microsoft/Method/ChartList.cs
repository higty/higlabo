using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
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
    public partial class ChartListResponse : RestApiResponse
    {
        public Chart[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chart-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ChartListResponse> ChartListAsync()
        {
            var p = new ChartListParameter();
            return await this.SendAsync<ChartListParameter, ChartListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chart-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ChartListResponse> ChartListAsync(CancellationToken cancellationToken)
        {
            var p = new ChartListParameter();
            return await this.SendAsync<ChartListParameter, ChartListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chart-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ChartListResponse> ChartListAsync(ChartListParameter parameter)
        {
            return await this.SendAsync<ChartListParameter, ChartListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chart-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ChartListResponse> ChartListAsync(ChartListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChartListParameter, ChartListResponse>(parameter, cancellationToken);
        }
    }
}
