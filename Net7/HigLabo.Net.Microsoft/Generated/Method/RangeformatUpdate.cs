using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rangeformat-update?view=graph-rest-1.0
    /// </summary>
    public partial class RangeformatUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? Name { get; set; }
            public string? ItemPath { get; set; }
            public string? IdOrName { get; set; }
            public string? ItemsId { get; set; }
            public string? TablesIdOrName { get; set; }
            public string? ColumnsIdOrName { get; set; }
            public string? RootItemPath { get; set; }

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

        public enum RangeformatUpdateParameterstring
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public Double? ColumnWidth { get; set; }
        public RangeformatUpdateParameterstring HorizontalAlignment { get; set; }
        public Double? RowHeight { get; set; }
        public RangeformatUpdateParameterstring VerticalAlignment { get; set; }
        public bool? WrapText { get; set; }
    }
    public partial class RangeformatUpdateResponse : RestApiResponse
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
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rangeformat-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rangeformat-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RangeformatUpdateResponse> RangeformatUpdateAsync()
        {
            var p = new RangeformatUpdateParameter();
            return await this.SendAsync<RangeformatUpdateParameter, RangeformatUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rangeformat-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RangeformatUpdateResponse> RangeformatUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new RangeformatUpdateParameter();
            return await this.SendAsync<RangeformatUpdateParameter, RangeformatUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rangeformat-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RangeformatUpdateResponse> RangeformatUpdateAsync(RangeformatUpdateParameter parameter)
        {
            return await this.SendAsync<RangeformatUpdateParameter, RangeformatUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rangeformat-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RangeformatUpdateResponse> RangeformatUpdateAsync(RangeformatUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RangeformatUpdateParameter, RangeformatUpdateResponse>(parameter, cancellationToken);
        }
    }
}
