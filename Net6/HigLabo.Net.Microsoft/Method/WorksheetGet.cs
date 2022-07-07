using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class WorksheetGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
            Id,
            Name,
            Position,
            Visibility,
        }
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Worksheets_IdOrname,
            Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets_IdOrname: return $"/me/drive/items/{Id}/workbook/worksheets/{IdOrName}";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname: return $"/me/drive/root:/{ItemPath}:/workbook/worksheets/{IdOrName}";
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
    }
    public partial class WorksheetGetResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/worksheet-get?view=graph-rest-1.0
        /// </summary>
        public async Task<WorksheetGetResponse> WorksheetGetAsync()
        {
            var p = new WorksheetGetParameter();
            return await this.SendAsync<WorksheetGetParameter, WorksheetGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/worksheet-get?view=graph-rest-1.0
        /// </summary>
        public async Task<WorksheetGetResponse> WorksheetGetAsync(CancellationToken cancellationToken)
        {
            var p = new WorksheetGetParameter();
            return await this.SendAsync<WorksheetGetParameter, WorksheetGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/worksheet-get?view=graph-rest-1.0
        /// </summary>
        public async Task<WorksheetGetResponse> WorksheetGetAsync(WorksheetGetParameter parameter)
        {
            return await this.SendAsync<WorksheetGetParameter, WorksheetGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/worksheet-get?view=graph-rest-1.0
        /// </summary>
        public async Task<WorksheetGetResponse> WorksheetGetAsync(WorksheetGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorksheetGetParameter, WorksheetGetResponse>(parameter, cancellationToken);
        }
    }
}
