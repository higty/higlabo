using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class WorksheetListChartsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Charts,
            Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Charts,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Charts: return $"/me/drive/items/{Id}/workbook/worksheets/{IdOrName}/charts";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Charts: return $"/me/drive/root:/{ItemPath}:/workbook/worksheets/{IdOrName}/charts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string Id { get; set; }
        public string IdOrName { get; set; }
        public string ItemPath { get; set; }
    }
    public partial class WorksheetListChartsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/chart?view=graph-rest-1.0
        /// </summary>
        public partial class Chart
        {
            public Double? Height { get; set; }
            public string? Id { get; set; }
            public Double? Left { get; set; }
            public string? Name { get; set; }
            public Double? Top { get; set; }
            public Double? Width { get; set; }
        }

        public Chart[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/worksheet-list-charts?view=graph-rest-1.0
        /// </summary>
        public async Task<WorksheetListChartsResponse> WorksheetListChartsAsync()
        {
            var p = new WorksheetListChartsParameter();
            return await this.SendAsync<WorksheetListChartsParameter, WorksheetListChartsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/worksheet-list-charts?view=graph-rest-1.0
        /// </summary>
        public async Task<WorksheetListChartsResponse> WorksheetListChartsAsync(CancellationToken cancellationToken)
        {
            var p = new WorksheetListChartsParameter();
            return await this.SendAsync<WorksheetListChartsParameter, WorksheetListChartsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/worksheet-list-charts?view=graph-rest-1.0
        /// </summary>
        public async Task<WorksheetListChartsResponse> WorksheetListChartsAsync(WorksheetListChartsParameter parameter)
        {
            return await this.SendAsync<WorksheetListChartsParameter, WorksheetListChartsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/worksheet-list-charts?view=graph-rest-1.0
        /// </summary>
        public async Task<WorksheetListChartsResponse> WorksheetListChartsAsync(WorksheetListChartsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorksheetListChartsParameter, WorksheetListChartsResponse>(parameter, cancellationToken);
        }
    }
}
