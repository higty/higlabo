using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class WorksheetcollectionAddParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Worksheets_,
            Me_Drive_Root_ItemPath_Workbook_Worksheets_,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets_: return $"/me/drive/items/{Id}/workbook/worksheets/";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets_: return $"/me/drive/root:/{ItemPath}:/workbook/worksheets/";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Name { get; set; }
        public string Id { get; set; }
        public string ItemPath { get; set; }
    }
    public partial class WorksheetcollectionAddResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/worksheetcollection-add?view=graph-rest-1.0
        /// </summary>
        public async Task<WorksheetcollectionAddResponse> WorksheetcollectionAddAsync()
        {
            var p = new WorksheetcollectionAddParameter();
            return await this.SendAsync<WorksheetcollectionAddParameter, WorksheetcollectionAddResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/worksheetcollection-add?view=graph-rest-1.0
        /// </summary>
        public async Task<WorksheetcollectionAddResponse> WorksheetcollectionAddAsync(CancellationToken cancellationToken)
        {
            var p = new WorksheetcollectionAddParameter();
            return await this.SendAsync<WorksheetcollectionAddParameter, WorksheetcollectionAddResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/worksheetcollection-add?view=graph-rest-1.0
        /// </summary>
        public async Task<WorksheetcollectionAddResponse> WorksheetcollectionAddAsync(WorksheetcollectionAddParameter parameter)
        {
            return await this.SendAsync<WorksheetcollectionAddParameter, WorksheetcollectionAddResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/worksheetcollection-add?view=graph-rest-1.0
        /// </summary>
        public async Task<WorksheetcollectionAddResponse> WorksheetcollectionAddAsync(WorksheetcollectionAddParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorksheetcollectionAddParameter, WorksheetcollectionAddResponse>(parameter, cancellationToken);
        }
    }
}
