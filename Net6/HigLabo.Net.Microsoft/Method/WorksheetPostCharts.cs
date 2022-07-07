using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class WorksheetPostChartsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Charts_,
            Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Charts_,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Charts_: return $"/me/drive/items/{Id}/workbook/worksheets/{IdOrName}/charts/";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Charts_: return $"/me/drive/root:/{ItemPath}:/workbook/worksheets/{IdOrName}/charts/";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
        public string IdOrName { get; set; }
        public string ItemPath { get; set; }
    }
    public partial class WorksheetPostChartsResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/worksheet-post-charts?view=graph-rest-1.0
        /// </summary>
        public async Task<WorksheetPostChartsResponse> WorksheetPostChartsAsync()
        {
            var p = new WorksheetPostChartsParameter();
            return await this.SendAsync<WorksheetPostChartsParameter, WorksheetPostChartsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/worksheet-post-charts?view=graph-rest-1.0
        /// </summary>
        public async Task<WorksheetPostChartsResponse> WorksheetPostChartsAsync(CancellationToken cancellationToken)
        {
            var p = new WorksheetPostChartsParameter();
            return await this.SendAsync<WorksheetPostChartsParameter, WorksheetPostChartsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/worksheet-post-charts?view=graph-rest-1.0
        /// </summary>
        public async Task<WorksheetPostChartsResponse> WorksheetPostChartsAsync(WorksheetPostChartsParameter parameter)
        {
            return await this.SendAsync<WorksheetPostChartsParameter, WorksheetPostChartsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/worksheet-post-charts?view=graph-rest-1.0
        /// </summary>
        public async Task<WorksheetPostChartsResponse> WorksheetPostChartsAsync(WorksheetPostChartsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorksheetPostChartsParameter, WorksheetPostChartsResponse>(parameter, cancellationToken);
        }
    }
}
