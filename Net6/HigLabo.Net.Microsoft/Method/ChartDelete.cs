using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChartDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Charts_Name,
            Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Charts_Name,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Charts_Name: return $"/me/drive/items/{Id}/workbook/worksheets/{IdOrName}/charts/{Name}";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Charts_Name: return $"/me/drive/root:/{ItemPath}:/workbook/worksheets/{IdOrName}/charts/{Name}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
        public string IdOrName { get; set; }
        public string Name { get; set; }
        public string ItemPath { get; set; }
    }
    public partial class ChartDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chart-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ChartDeleteResponse> ChartDeleteAsync()
        {
            var p = new ChartDeleteParameter();
            return await this.SendAsync<ChartDeleteParameter, ChartDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chart-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ChartDeleteResponse> ChartDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new ChartDeleteParameter();
            return await this.SendAsync<ChartDeleteParameter, ChartDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chart-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ChartDeleteResponse> ChartDeleteAsync(ChartDeleteParameter parameter)
        {
            return await this.SendAsync<ChartDeleteParameter, ChartDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chart-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ChartDeleteResponse> ChartDeleteAsync(ChartDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChartDeleteParameter, ChartDeleteResponse>(parameter, cancellationToken);
        }
    }
}
