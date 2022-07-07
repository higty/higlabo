using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class WorkbookListWorksheetsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Worksheets,
            Me_Drive_Root_ItemPath_Workbook_Worksheets,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets: return $"/me/drive/items/{Id}/workbook/worksheets";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets: return $"/me/drive/root:/{ItemPath}:/workbook/worksheets";
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
        public string ItemPath { get; set; }
    }
    public partial class WorkbookListWorksheetsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/worksheet?view=graph-rest-1.0
        /// </summary>
        public partial class Worksheet
        {
            public enum Worksheetstring
            {
                Visible,
                Hidden,
                VeryHidden,
            }

            public string? Id { get; set; }
            public string? Name { get; set; }
            public int? Position { get; set; }
            public Worksheetstring Visibility { get; set; }
        }

        public Worksheet[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbook-list-worksheets?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookListWorksheetsResponse> WorkbookListWorksheetsAsync()
        {
            var p = new WorkbookListWorksheetsParameter();
            return await this.SendAsync<WorkbookListWorksheetsParameter, WorkbookListWorksheetsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbook-list-worksheets?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookListWorksheetsResponse> WorkbookListWorksheetsAsync(CancellationToken cancellationToken)
        {
            var p = new WorkbookListWorksheetsParameter();
            return await this.SendAsync<WorkbookListWorksheetsParameter, WorkbookListWorksheetsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbook-list-worksheets?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookListWorksheetsResponse> WorkbookListWorksheetsAsync(WorkbookListWorksheetsParameter parameter)
        {
            return await this.SendAsync<WorkbookListWorksheetsParameter, WorkbookListWorksheetsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbook-list-worksheets?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookListWorksheetsResponse> WorkbookListWorksheetsAsync(WorkbookListWorksheetsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorkbookListWorksheetsParameter, WorkbookListWorksheetsResponse>(parameter, cancellationToken);
        }
    }
}
