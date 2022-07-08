using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class WorksheetRangeParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }
            public string IdOrName { get; set; }
            public string ItemPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Range: return $"/me/drive/items/{Id}/workbook/worksheets/{IdOrName}/range";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Range: return $"/me/drive/root:/{ItemPath}:/workbook/worksheets/{IdOrName}/range";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Range,
            Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Range,
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
    public partial class WorksheetRangeResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/worksheet-range?view=graph-rest-1.0
        /// </summary>
        public async Task<WorksheetRangeResponse> WorksheetRangeAsync()
        {
            var p = new WorksheetRangeParameter();
            return await this.SendAsync<WorksheetRangeParameter, WorksheetRangeResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/worksheet-range?view=graph-rest-1.0
        /// </summary>
        public async Task<WorksheetRangeResponse> WorksheetRangeAsync(CancellationToken cancellationToken)
        {
            var p = new WorksheetRangeParameter();
            return await this.SendAsync<WorksheetRangeParameter, WorksheetRangeResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/worksheet-range?view=graph-rest-1.0
        /// </summary>
        public async Task<WorksheetRangeResponse> WorksheetRangeAsync(WorksheetRangeParameter parameter)
        {
            return await this.SendAsync<WorksheetRangeParameter, WorksheetRangeResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/worksheet-range?view=graph-rest-1.0
        /// </summary>
        public async Task<WorksheetRangeResponse> WorksheetRangeAsync(WorksheetRangeParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorksheetRangeParameter, WorksheetRangeResponse>(parameter, cancellationToken);
        }
    }
}
