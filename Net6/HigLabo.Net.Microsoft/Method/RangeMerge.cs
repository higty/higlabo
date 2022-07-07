using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class RangeMergeParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Names_Name_Range_Merge,
            Me_Drive_Root_ItemPath_Workbook_Names_Name_Range_Merge,
            Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Range,
            Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Range,
            Me_Drive_Items_Id_Workbook_Tables_IdOrname_Columns_IdOrname_Range_Merge,
            Me_Drive_Root_ItemPath_Workbook_Tables_IdOrname_Columns_IdOrname_Range_Merge,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Names_Name_Range_Merge: return $"/me/drive/items/{Id}/workbook/names/{Name}/range/merge";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Names_Name_Range_Merge: return $"/me/drive/root:/{ItemPath}:/workbook/names/{Name}/range/merge";
                    case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Range: return $"/me/drive/items/{Id}/workbook/worksheets/{IdOrName}/range";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Range: return $"/me/drive/root:/{ItemPath}:/workbook/worksheets/{IdOrName}/range";
                    case ApiPath.Me_Drive_Items_Id_Workbook_Tables_IdOrname_Columns_IdOrname_Range_Merge: return $"/me/drive/items/{ItemsId}/workbook/tables/{TablesIdOrName}/columns/{ColumnsIdOrName}/range/merge";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Tables_IdOrname_Columns_IdOrname_Range_Merge: return $"/me/drive/root:/{RootItemPath}/workbook/tables/{TablesIdOrName}/columns/{ColumnsIdOrName}/range/merge";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public bool? Across { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string ItemPath { get; set; }
        public string IdOrName { get; set; }
        public string ItemsId { get; set; }
        public string TablesIdOrName { get; set; }
        public string ColumnsIdOrName { get; set; }
        public string RootItemPath { get; set; }
    }
    public partial class RangeMergeResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/range-merge?view=graph-rest-1.0
        /// </summary>
        public async Task<RangeMergeResponse> RangeMergeAsync()
        {
            var p = new RangeMergeParameter();
            return await this.SendAsync<RangeMergeParameter, RangeMergeResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/range-merge?view=graph-rest-1.0
        /// </summary>
        public async Task<RangeMergeResponse> RangeMergeAsync(CancellationToken cancellationToken)
        {
            var p = new RangeMergeParameter();
            return await this.SendAsync<RangeMergeParameter, RangeMergeResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/range-merge?view=graph-rest-1.0
        /// </summary>
        public async Task<RangeMergeResponse> RangeMergeAsync(RangeMergeParameter parameter)
        {
            return await this.SendAsync<RangeMergeParameter, RangeMergeResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/range-merge?view=graph-rest-1.0
        /// </summary>
        public async Task<RangeMergeResponse> RangeMergeAsync(RangeMergeParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RangeMergeParameter, RangeMergeResponse>(parameter, cancellationToken);
        }
    }
}
