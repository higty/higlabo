using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/range-update?view=graph-rest-1.0
    /// </summary>
    public partial class RangeUpdateParameter : IRestApiParameter
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
                    case ApiPath.Me_Drive_Items_Id_Workbook_Names_Name_Range: return $"/me/drive/items/{Id}/workbook/names/{Name}/range";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Names_Name_Range: return $"/me/drive/root:/{ItemPath}:/workbook/names/{Name}/range";
                    case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Range: return $"/me/drive/items/{Id}/workbook/worksheets/{IdOrName}/range";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Range: return $"/me/drive/root:/{ItemPath}:/workbook/worksheets/{IdOrName}/range";
                    case ApiPath.Me_Drive_Items_Id_Workbook_Tables_IdOrname_Columns_IdOrname_Range: return $"/me/drive/items/{ItemsId}/workbook/tables/{TablesIdOrName}/columns/{ColumnsIdOrName}/range";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Tables_IdOrname_Columns_IdOrname_Range: return $"/me/drive/root:/{RootItemPath}/workbook/tables/{TablesIdOrName}/columns/{ColumnsIdOrName}/range";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Names_Name_Range,
            Me_Drive_Root_ItemPath_Workbook_Names_Name_Range,
            Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Range,
            Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Range,
            Me_Drive_Items_Id_Workbook_Tables_IdOrname_Columns_IdOrname_Range,
            Me_Drive_Root_ItemPath_Workbook_Tables_IdOrname_Columns_IdOrname_Range,
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
        public bool? ColumnHidden { get; set; }
        public Json? Formulas { get; set; }
        public Json? FormulasLocal { get; set; }
        public Json? FormulasR1C1 { get; set; }
        public Json? NumberFormat { get; set; }
        public bool? RowHidden { get; set; }
        public Json? Values { get; set; }
    }
    public partial class RangeUpdateResponse : RestApiResponse
    {
        public enum RangeJson
        {
            Unknown,
            Empty,
            String,
            Integer,
            Double,
            Boolean,
            Error,
        }

        public string? Address { get; set; }
        public string? AddressLocal { get; set; }
        public int? CellCount { get; set; }
        public int? ColumnCount { get; set; }
        public bool? ColumnHidden { get; set; }
        public int? ColumnIndex { get; set; }
        public Json? Formulas { get; set; }
        public Json? FormulasLocal { get; set; }
        public Json? FormulasR1C1 { get; set; }
        public bool? Hidden { get; set; }
        public Json? NumberFormat { get; set; }
        public int? RowCount { get; set; }
        public bool? RowHidden { get; set; }
        public int? RowIndex { get; set; }
        public Json? Text { get; set; }
        public RangeJson ValueTypes { get; set; }
        public Json? Values { get; set; }
        public RangeFormat? Format { get; set; }
        public RangeSort? Sort { get; set; }
        public Worksheet? Worksheet { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/range-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/range-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RangeUpdateResponse> RangeUpdateAsync()
        {
            var p = new RangeUpdateParameter();
            return await this.SendAsync<RangeUpdateParameter, RangeUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/range-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RangeUpdateResponse> RangeUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new RangeUpdateParameter();
            return await this.SendAsync<RangeUpdateParameter, RangeUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/range-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RangeUpdateResponse> RangeUpdateAsync(RangeUpdateParameter parameter)
        {
            return await this.SendAsync<RangeUpdateParameter, RangeUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/range-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RangeUpdateResponse> RangeUpdateAsync(RangeUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RangeUpdateParameter, RangeUpdateResponse>(parameter, cancellationToken);
        }
    }
}
