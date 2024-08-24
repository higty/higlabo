using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/worksheet-list-tables?view=graph-rest-1.0
    /// </summary>
    public partial class WorksheetListTablesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? IdOrName { get; set; }
            public string? ItemPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Tables: return $"/me/drive/items/{Id}/workbook/worksheets/{IdOrName}/tables";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Tables: return $"/me/drive/root:/{ItemPath}:/workbook/worksheets/{IdOrName}/tables";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Tables,
            Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Tables,
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
    public partial class WorksheetListTablesResponse : RestApiResponse<Table>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/worksheet-list-tables?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/worksheet-list-tables?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WorksheetListTablesResponse> WorksheetListTablesAsync()
        {
            var p = new WorksheetListTablesParameter();
            return await this.SendAsync<WorksheetListTablesParameter, WorksheetListTablesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/worksheet-list-tables?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WorksheetListTablesResponse> WorksheetListTablesAsync(CancellationToken cancellationToken)
        {
            var p = new WorksheetListTablesParameter();
            return await this.SendAsync<WorksheetListTablesParameter, WorksheetListTablesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/worksheet-list-tables?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WorksheetListTablesResponse> WorksheetListTablesAsync(WorksheetListTablesParameter parameter)
        {
            return await this.SendAsync<WorksheetListTablesParameter, WorksheetListTablesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/worksheet-list-tables?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WorksheetListTablesResponse> WorksheetListTablesAsync(WorksheetListTablesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorksheetListTablesParameter, WorksheetListTablesResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/worksheet-list-tables?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<Table> WorksheetListTablesEnumerateAsync(WorksheetListTablesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<WorksheetListTablesParameter, WorksheetListTablesResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<Table>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
