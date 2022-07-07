using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class WorkbookTablerowoperationresultParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_TableRowOperationResult,
            Me_Drive_Root_ItemPath_Workbook_TableRowOperationResult,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_TableRowOperationResult: return $"/me/drive/items/{Id}/workbook/tableRowOperationResult";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_TableRowOperationResult: return $"/me/drive/root:/{ItemPath}:/workbook/tableRowOperationResult";
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
    public partial class WorkbookTablerowoperationresultResponse : RestApiResponse
    {
        public Int32? Index { get; set; }
        public Json? Values { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbook-tablerowoperationresult?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookTablerowoperationresultResponse> WorkbookTablerowoperationresultAsync()
        {
            var p = new WorkbookTablerowoperationresultParameter();
            return await this.SendAsync<WorkbookTablerowoperationresultParameter, WorkbookTablerowoperationresultResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbook-tablerowoperationresult?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookTablerowoperationresultResponse> WorkbookTablerowoperationresultAsync(CancellationToken cancellationToken)
        {
            var p = new WorkbookTablerowoperationresultParameter();
            return await this.SendAsync<WorkbookTablerowoperationresultParameter, WorkbookTablerowoperationresultResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbook-tablerowoperationresult?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookTablerowoperationresultResponse> WorkbookTablerowoperationresultAsync(WorkbookTablerowoperationresultParameter parameter)
        {
            return await this.SendAsync<WorkbookTablerowoperationresultParameter, WorkbookTablerowoperationresultResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbook-tablerowoperationresult?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookTablerowoperationresultResponse> WorkbookTablerowoperationresultAsync(WorkbookTablerowoperationresultParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorkbookTablerowoperationresultParameter, WorkbookTablerowoperationresultResponse>(parameter, cancellationToken);
        }
    }
}
