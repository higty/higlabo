using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class WorkbookListNamesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Names,
            Me_Drive_Root_ItemPath_Workbook_Names,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Names: return $"/me/drive/items/{Id}/workbook/names";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Names: return $"/me/drive/root:/{ItemPath}:/workbook/names";
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
    public partial class WorkbookListNamesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/nameditem?view=graph-rest-1.0
        /// </summary>
        public partial class NamedItem
        {
            public enum NamedItemstring
            {
                String,
                Integer,
                Double,
                Boolean,
                Range,
            }

            public string? Name { get; set; }
            public string? Comment { get; set; }
            public string? Scope { get; set; }
            public NamedItemstring Type { get; set; }
            public Json? Value { get; set; }
            public bool? Visible { get; set; }
        }

        public NamedItem[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbook-list-names?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookListNamesResponse> WorkbookListNamesAsync()
        {
            var p = new WorkbookListNamesParameter();
            return await this.SendAsync<WorkbookListNamesParameter, WorkbookListNamesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbook-list-names?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookListNamesResponse> WorkbookListNamesAsync(CancellationToken cancellationToken)
        {
            var p = new WorkbookListNamesParameter();
            return await this.SendAsync<WorkbookListNamesParameter, WorkbookListNamesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbook-list-names?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookListNamesResponse> WorkbookListNamesAsync(WorkbookListNamesParameter parameter)
        {
            return await this.SendAsync<WorkbookListNamesParameter, WorkbookListNamesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbook-list-names?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookListNamesResponse> WorkbookListNamesAsync(WorkbookListNamesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorkbookListNamesParameter, WorkbookListNamesResponse>(parameter, cancellationToken);
        }
    }
}
