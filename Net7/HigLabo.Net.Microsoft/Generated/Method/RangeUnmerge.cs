using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/range-unmerge?view=graph-rest-1.0
    /// </summary>
    public partial class RangeUnmergeParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? Name { get; set; }
            public string? ItemPath { get; set; }
            public string? IdOrName { get; set; }
            public string? ItemsId { get; set; }
            public string? TablesIdOrName { get; set; }
            public string? ColumnsIdOrName { get; set; }
            public string? RootItemPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Names_Name_Range_Unmerge: return $"/me/drive/items/{Id}/workbook/names/{Name}/range/unmerge";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Names_Name_Range_Unmerge: return $"/me/drive/root:/{ItemPath}:/workbook/names/{Name}/range/unmerge";
                    case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Range: return $"/me/drive/items/{Id}/workbook/worksheets/{IdOrName}/range";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Range: return $"/me/drive/root:/{ItemPath}:/workbook/worksheets/{IdOrName}/range";
                    case ApiPath.Me_Drive_Items_Id_Workbook_Tables_IdOrname_Columns_IdOrname_Range_Unmerge: return $"/me/drive/items/{ItemsId}/workbook/tables/{TablesIdOrName}/columns/{ColumnsIdOrName}/range/unmerge";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Tables_IdOrname_Columns_IdOrname_Range_Unmerge: return $"/me/drive/root:/{RootItemPath}/workbook/tables/{TablesIdOrName}/columns/{ColumnsIdOrName}/range/unmerge";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Names_Name_Range_Unmerge,
            Me_Drive_Root_ItemPath_Workbook_Names_Name_Range_Unmerge,
            Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Range,
            Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Range,
            Me_Drive_Items_Id_Workbook_Tables_IdOrname_Columns_IdOrname_Range_Unmerge,
            Me_Drive_Root_ItemPath_Workbook_Tables_IdOrname_Columns_IdOrname_Range_Unmerge,
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
    }
    public partial class RangeUnmergeResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/range-unmerge?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/range-unmerge?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RangeUnmergeResponse> RangeUnmergeAsync()
        {
            var p = new RangeUnmergeParameter();
            return await this.SendAsync<RangeUnmergeParameter, RangeUnmergeResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/range-unmerge?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RangeUnmergeResponse> RangeUnmergeAsync(CancellationToken cancellationToken)
        {
            var p = new RangeUnmergeParameter();
            return await this.SendAsync<RangeUnmergeParameter, RangeUnmergeResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/range-unmerge?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RangeUnmergeResponse> RangeUnmergeAsync(RangeUnmergeParameter parameter)
        {
            return await this.SendAsync<RangeUnmergeParameter, RangeUnmergeResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/range-unmerge?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RangeUnmergeResponse> RangeUnmergeAsync(RangeUnmergeParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RangeUnmergeParameter, RangeUnmergeResponse>(parameter, cancellationToken);
        }
    }
}
