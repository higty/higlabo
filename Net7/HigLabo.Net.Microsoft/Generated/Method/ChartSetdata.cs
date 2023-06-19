using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chart-setdata?view=graph-rest-1.0
    /// </summary>
    public partial class ChartSetdataParameter : IRestApiParameter
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
                    case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Charts_Name_SetData: return $"/me/drive/items/{Id}/workbook/worksheets/{IdOrName}/charts/{Name}/setData";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Charts_Name_SetData: return $"/me/drive/root:/{ItemPath}:/workbook/worksheets/{IdOrName}/charts/{Name}/setData";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ChartSetdataParameterstring
        {
            Auto,
            Columns,
            Rows,
        }
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Charts_Name_SetData,
            Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Charts_Name_SetData,
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
        public Json? SourceData { get; set; }
        public ChartSetdataParameterstring SeriesBy { get; set; }
    }
    public partial class ChartSetdataResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/chart-setdata?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chart-setdata?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChartSetdataResponse> ChartSetdataAsync()
        {
            var p = new ChartSetdataParameter();
            return await this.SendAsync<ChartSetdataParameter, ChartSetdataResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chart-setdata?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChartSetdataResponse> ChartSetdataAsync(CancellationToken cancellationToken)
        {
            var p = new ChartSetdataParameter();
            return await this.SendAsync<ChartSetdataParameter, ChartSetdataResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chart-setdata?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChartSetdataResponse> ChartSetdataAsync(ChartSetdataParameter parameter)
        {
            return await this.SendAsync<ChartSetdataParameter, ChartSetdataResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/chart-setdata?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChartSetdataResponse> ChartSetdataAsync(ChartSetdataParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChartSetdataParameter, ChartSetdataResponse>(parameter, cancellationToken);
        }
    }
}
