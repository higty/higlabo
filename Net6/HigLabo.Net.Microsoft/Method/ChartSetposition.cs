using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChartSetpositionParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }
            public string IdOrName { get; set; }
            public string Name { get; set; }
            public string ItemPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Charts_Name_SetPosition: return $"/me/drive/items/{Id}/workbook/worksheets/{IdOrName}/charts/{Name}/setPosition";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Charts_Name_SetPosition: return $"/me/drive/root:/{ItemPath}:/workbook/worksheets/{IdOrName}/charts/{Name}/setPosition";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Charts_Name_SetPosition,
            Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Charts_Name_SetPosition,
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
        public Json? StartCell { get; set; }
        public Json? EndCell { get; set; }
    }
    public partial class ChartSetpositionResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chart-setposition?view=graph-rest-1.0
        /// </summary>
        public async Task<ChartSetpositionResponse> ChartSetpositionAsync()
        {
            var p = new ChartSetpositionParameter();
            return await this.SendAsync<ChartSetpositionParameter, ChartSetpositionResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chart-setposition?view=graph-rest-1.0
        /// </summary>
        public async Task<ChartSetpositionResponse> ChartSetpositionAsync(CancellationToken cancellationToken)
        {
            var p = new ChartSetpositionParameter();
            return await this.SendAsync<ChartSetpositionParameter, ChartSetpositionResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chart-setposition?view=graph-rest-1.0
        /// </summary>
        public async Task<ChartSetpositionResponse> ChartSetpositionAsync(ChartSetpositionParameter parameter)
        {
            return await this.SendAsync<ChartSetpositionParameter, ChartSetpositionResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chart-setposition?view=graph-rest-1.0
        /// </summary>
        public async Task<ChartSetpositionResponse> ChartSetpositionAsync(ChartSetpositionParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChartSetpositionParameter, ChartSetpositionResponse>(parameter, cancellationToken);
        }
    }
}
