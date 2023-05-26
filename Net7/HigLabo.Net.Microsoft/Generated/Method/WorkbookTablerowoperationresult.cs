using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/workbook-tablerowoperationresult?view=graph-rest-1.0
    /// </summary>
    public partial class WorkbookTablerowOperationResultParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? ItemPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_TableRowOperationResult: return $"/me/drive/items/{Id}/workbook/tableRowOperationResult";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_TableRowOperationResult: return $"/me/drive/root:/{ItemPath}:/workbook/tableRowOperationResult";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_TableRowOperationResult,
            Me_Drive_Root_ItemPath_Workbook_TableRowOperationResult,
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
    public partial class WorkbookTablerowOperationResultResponse : RestApiResponse
    {
        public Int32? Index { get; set; }
        public Json? Values { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/workbook-tablerowoperationresult?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/workbook-tablerowoperationresult?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookTablerowOperationResultResponse> WorkbookTablerowOperationResultAsync()
        {
            var p = new WorkbookTablerowOperationResultParameter();
            return await this.SendAsync<WorkbookTablerowOperationResultParameter, WorkbookTablerowOperationResultResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/workbook-tablerowoperationresult?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookTablerowOperationResultResponse> WorkbookTablerowOperationResultAsync(CancellationToken cancellationToken)
        {
            var p = new WorkbookTablerowOperationResultParameter();
            return await this.SendAsync<WorkbookTablerowOperationResultParameter, WorkbookTablerowOperationResultResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/workbook-tablerowoperationresult?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookTablerowOperationResultResponse> WorkbookTablerowOperationResultAsync(WorkbookTablerowOperationResultParameter parameter)
        {
            return await this.SendAsync<WorkbookTablerowOperationResultParameter, WorkbookTablerowOperationResultResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/workbook-tablerowoperationresult?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookTablerowOperationResultResponse> WorkbookTablerowOperationResultAsync(WorkbookTablerowOperationResultParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorkbookTablerowOperationResultParameter, WorkbookTablerowOperationResultResponse>(parameter, cancellationToken);
        }
    }
}
