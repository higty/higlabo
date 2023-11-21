using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/worksheetcollection-add?view=graph-rest-1.0
    /// </summary>
    public partial class WorksheetCollectionAddParameter : IRestApiParameter
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
                    case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets: return $"/me/drive/items/{Id}/workbook/worksheets";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets: return $"/me/drive/root:/{ItemPath}:/workbook/worksheets";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Worksheetstring
        {
            Visible,
            Hidden,
            VeryHidden,
        }
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Worksheets,
            Me_Drive_Root_ItemPath_Workbook_Worksheets,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Name { get; set; }
        public string? Id { get; set; }
        public int? Position { get; set; }
        public Worksheetstring Visibility { get; set; }
        public Chart[]? Charts { get; set; }
        public NamedItem[]? Names { get; set; }
        public PivotTable[]? PivotTables { get; set; }
        public WorksheetProtection? Protection { get; set; }
        public Table[]? Tables { get; set; }
    }
    public partial class WorksheetCollectionAddResponse : RestApiResponse
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
        public Chart[]? Charts { get; set; }
        public NamedItem[]? Names { get; set; }
        public PivotTable[]? PivotTables { get; set; }
        public WorksheetProtection? Protection { get; set; }
        public Table[]? Tables { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/worksheetcollection-add?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/worksheetcollection-add?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WorksheetCollectionAddResponse> WorksheetCollectionAddAsync()
        {
            var p = new WorksheetCollectionAddParameter();
            return await this.SendAsync<WorksheetCollectionAddParameter, WorksheetCollectionAddResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/worksheetcollection-add?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WorksheetCollectionAddResponse> WorksheetCollectionAddAsync(CancellationToken cancellationToken)
        {
            var p = new WorksheetCollectionAddParameter();
            return await this.SendAsync<WorksheetCollectionAddParameter, WorksheetCollectionAddResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/worksheetcollection-add?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WorksheetCollectionAddResponse> WorksheetCollectionAddAsync(WorksheetCollectionAddParameter parameter)
        {
            return await this.SendAsync<WorksheetCollectionAddParameter, WorksheetCollectionAddResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/worksheetcollection-add?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<WorksheetCollectionAddResponse> WorksheetCollectionAddAsync(WorksheetCollectionAddParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorksheetCollectionAddParameter, WorksheetCollectionAddResponse>(parameter, cancellationToken);
        }
    }
}
