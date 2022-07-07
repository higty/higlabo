using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TableRangeParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Tables_IdOrname_Range,
            Me_Drive_Root_ItemPath_Workbook_Tables_IdOrname_Range,
            Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Tables_IdOrname_Range,
            Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Tables_IdOrname_Range,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Tables_IdOrname_Range: return $"/me/drive/items/{Id}/workbook/tables/{IdOrName}/range";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Tables_IdOrname_Range: return $"/me/drive/root:/{ItemPath}:/workbook/tables/{IdOrName}/range";
                    case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Tables_IdOrname_Range: return $"/me/drive/items/{ItemsId}/workbook/worksheets/{WorksheetsIdOrName}/tables/{TablesIdOrName}/range";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Tables_IdOrname_Range: return $"/me/drive/root:/{RootItemPath}/workbook/worksheets/{WorksheetsIdOrName}/tables/{TablesIdOrName}/range";
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
        public string ItemsId { get; set; }
        public string WorksheetsIdOrName { get; set; }
        public string TablesIdOrName { get; set; }
        public string RootItemPath { get; set; }
    }
    public partial class TableRangeResponse : RestApiResponse
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
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/table-range?view=graph-rest-1.0
        /// </summary>
        public async Task<TableRangeResponse> TableRangeAsync()
        {
            var p = new TableRangeParameter();
            return await this.SendAsync<TableRangeParameter, TableRangeResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/table-range?view=graph-rest-1.0
        /// </summary>
        public async Task<TableRangeResponse> TableRangeAsync(CancellationToken cancellationToken)
        {
            var p = new TableRangeParameter();
            return await this.SendAsync<TableRangeParameter, TableRangeResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/table-range?view=graph-rest-1.0
        /// </summary>
        public async Task<TableRangeResponse> TableRangeAsync(TableRangeParameter parameter)
        {
            return await this.SendAsync<TableRangeParameter, TableRangeResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/table-range?view=graph-rest-1.0
        /// </summary>
        public async Task<TableRangeResponse> TableRangeAsync(TableRangeParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TableRangeParameter, TableRangeResponse>(parameter, cancellationToken);
        }
    }
}
