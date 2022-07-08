using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class RangeformatGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }
            public string Name { get; set; }
            public string ItemPath { get; set; }
            public string IdOrName { get; set; }
            public string ItemsId { get; set; }
            public string TablesIdOrName { get; set; }
            public string ColumnsIdOrName { get; set; }
            public string RootItemPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Names_Name_Range_Format: return $"/me/drive/items/{Id}/workbook/names/{Name}/range/format";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Names_Name_Range_Format: return $"/me/drive/root:/{ItemPath}:/workbook/names/{Name}/range/format";
                    case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Range: return $"/me/drive/items/{Id}/workbook/worksheets/{IdOrName}/range";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Range: return $"/me/drive/root:/{ItemPath}:/workbook/worksheets/{IdOrName}/range";
                    case ApiPath.Me_Drive_Items_Id_Workbook_Tables_IdOrname_Columns_IdOrname_Range_Format: return $"/me/drive/items/{ItemsId}/workbook/tables/{TablesIdOrName}/columns/{ColumnsIdOrName}/range/format";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Tables_IdOrname_Columns_IdOrname_Range_Format: return $"/me/drive/root:/{RootItemPath}/workbook/tables/{TablesIdOrName}/columns/{ColumnsIdOrName}/range/format";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Names_Name_Range_Format,
            Me_Drive_Root_ItemPath_Workbook_Names_Name_Range_Format,
            Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Range,
            Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Range,
            Me_Drive_Items_Id_Workbook_Tables_IdOrname_Columns_IdOrname_Range_Format,
            Me_Drive_Root_ItemPath_Workbook_Tables_IdOrname_Columns_IdOrname_Range_Format,
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
    public partial class RangeformatGetResponse : RestApiResponse
    {
        public enum RangeFormatstring
        {
            General,
            Left,
            Center,
            Right,
            Fill,
            Justify,
            CenterAcrossSelection,
            Distributed,
        }

        public Double? ColumnWidth { get; set; }
        public RangeFormatstring HorizontalAlignment { get; set; }
        public Double? RowHeight { get; set; }
        public RangeFormatstring VerticalAlignment { get; set; }
        public bool? WrapText { get; set; }
        public RangeBorder[]? Borders { get; set; }
        public RangeFill? Fill { get; set; }
        public RangeFont? Font { get; set; }
        public FormatProtection? Protection { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rangeformat-get?view=graph-rest-1.0
        /// </summary>
        public async Task<RangeformatGetResponse> RangeformatGetAsync()
        {
            var p = new RangeformatGetParameter();
            return await this.SendAsync<RangeformatGetParameter, RangeformatGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rangeformat-get?view=graph-rest-1.0
        /// </summary>
        public async Task<RangeformatGetResponse> RangeformatGetAsync(CancellationToken cancellationToken)
        {
            var p = new RangeformatGetParameter();
            return await this.SendAsync<RangeformatGetParameter, RangeformatGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rangeformat-get?view=graph-rest-1.0
        /// </summary>
        public async Task<RangeformatGetResponse> RangeformatGetAsync(RangeformatGetParameter parameter)
        {
            return await this.SendAsync<RangeformatGetParameter, RangeformatGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/rangeformat-get?view=graph-rest-1.0
        /// </summary>
        public async Task<RangeformatGetResponse> RangeformatGetAsync(RangeformatGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RangeformatGetParameter, RangeformatGetResponse>(parameter, cancellationToken);
        }
    }
}
