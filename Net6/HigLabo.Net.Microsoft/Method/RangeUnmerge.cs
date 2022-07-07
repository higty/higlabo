using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class RangeUnmergeParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Names_Name_Range_Unmerge,
            Me_Drive_Root_ItemPath_Workbook_Names_Name_Range_Unmerge,
            Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Range,
            Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Range,
            Me_Drive_Items_Id_Workbook_Tables_IdOrname_Columns_IdOrname_Range_Unmerge,
            Me_Drive_Root_ItemPath_Workbook_Tables_IdOrname_Columns_IdOrname_Range_Unmerge,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Names_Name_Range_Unmerge: return $"/me/drive/items/{Id}/workbook/names/{Name}/range/unmerge";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Names_Name_Range_Unmerge: return $"/me/drive/root:/{ItemPath}:/workbook/names/{Name}/range/unmerge";
                    case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Range: return $"/me/drive/items/{Id}/workbook/worksheets/{IdOrName}/range";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Range: return $"/me/drive/root:/{ItemPath}:/workbook/worksheets/{IdOrName}/range";
                    case ApiPath.Me_Drive_Items_Id_Workbook_Tables_IdOrname_Columns_IdOrname_Range_Unmerge: return $"/me/drive/items/{ItemsId}/workbook/tables/{TablesIdOrName}/columns/{ColumnsIdOrName}/range/unmerge";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Tables_IdOrname_Columns_IdOrname_Range_Unmerge: return $"/me/drive/root:/{RootItemPath}/workbook/tables/{TablesIdOrName}/columns/{ColumnsIdOrName}/range/unmerge";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
        public string Name { get; set; }
        public string ItemPath { get; set; }
        public string IdOrName { get; set; }
        public string ItemsId { get; set; }
        public string TablesIdOrName { get; set; }
        public string ColumnsIdOrName { get; set; }
        public string RootItemPath { get; set; }
    }
    public partial class RangeUnmergeResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/range-unmerge?view=graph-rest-1.0
        /// </summary>
        public async Task<RangeUnmergeResponse> RangeUnmergeAsync()
        {
            var p = new RangeUnmergeParameter();
            return await this.SendAsync<RangeUnmergeParameter, RangeUnmergeResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/range-unmerge?view=graph-rest-1.0
        /// </summary>
        public async Task<RangeUnmergeResponse> RangeUnmergeAsync(CancellationToken cancellationToken)
        {
            var p = new RangeUnmergeParameter();
            return await this.SendAsync<RangeUnmergeParameter, RangeUnmergeResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/range-unmerge?view=graph-rest-1.0
        /// </summary>
        public async Task<RangeUnmergeResponse> RangeUnmergeAsync(RangeUnmergeParameter parameter)
        {
            return await this.SendAsync<RangeUnmergeParameter, RangeUnmergeResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/range-unmerge?view=graph-rest-1.0
        /// </summary>
        public async Task<RangeUnmergeResponse> RangeUnmergeAsync(RangeUnmergeParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RangeUnmergeParameter, RangeUnmergeResponse>(parameter, cancellationToken);
        }
    }
}
