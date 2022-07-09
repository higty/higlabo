using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChartImageParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Charts_Name_Image: return $"/me/drive/items/{Id}/workbook/worksheets/{IdOrName}/charts/{Name}/image";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Charts_Name_Image: return $"/me/drive/root:/{ItemPath}:/workbook/worksheets/{IdOrName}/charts/{Name}/image";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Charts_Name_Image,
            Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Charts_Name_Image,
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
    public partial class ChartImageResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chart-image?view=graph-rest-1.0
        /// </summary>
        public async Task<ChartImageResponse> ChartImageAsync()
        {
            var p = new ChartImageParameter();
            return await this.SendAsync<ChartImageParameter, ChartImageResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chart-image?view=graph-rest-1.0
        /// </summary>
        public async Task<ChartImageResponse> ChartImageAsync(CancellationToken cancellationToken)
        {
            var p = new ChartImageParameter();
            return await this.SendAsync<ChartImageParameter, ChartImageResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chart-image?view=graph-rest-1.0
        /// </summary>
        public async Task<ChartImageResponse> ChartImageAsync(ChartImageParameter parameter)
        {
            return await this.SendAsync<ChartImageParameter, ChartImageResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/chart-image?view=graph-rest-1.0
        /// </summary>
        public async Task<ChartImageResponse> ChartImageAsync(ChartImageParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChartImageParameter, ChartImageResponse>(parameter, cancellationToken);
        }
    }
}
