using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class RangeDeleteParameter : IRestApiParameter
    {
        public enum RangeDeleteParameterstring
        {
            Up,
            Left,
        }
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Names_Name_Range_Delete,
            Me_Drive_Root_ItemPath_Workbook_Names_Name_Range_Delete,
            Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Range,
            Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Range,
            Me_Drive_Items_Id_Workbook_Tables_IdOrname_Columns_IdOrname_Range_Delete,
            Me_Drive_Root_ItemPath_Workbook_Tables_IdOrname_Columns_IdOrname_Range_Delete,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Names_Name_Range_Delete: return $"/me/drive/items/{Id}/workbook/names/{Name}/range/delete";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Names_Name_Range_Delete: return $"/me/drive/root:/{ItemPath}:/workbook/names/{Name}/range/delete";
                    case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Range: return $"/me/drive/items/{Id}/workbook/worksheets/{IdOrName}/range";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Range: return $"/me/drive/root:/{ItemPath}:/workbook/worksheets/{IdOrName}/range";
                    case ApiPath.Me_Drive_Items_Id_Workbook_Tables_IdOrname_Columns_IdOrname_Range_Delete: return $"/me/drive/items/{ItemsId}/workbook/tables/{TablesIdOrName}/columns/{ColumnsIdOrName}/range/delete";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Tables_IdOrname_Columns_IdOrname_Range_Delete: return $"/me/drive/root:/{RootItemPath}/workbook/tables/{TablesIdOrName}/columns/{ColumnsIdOrName}/range/delete";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public RangeDeleteParameterstring Shift { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string ItemPath { get; set; }
        public string IdOrName { get; set; }
        public string ItemsId { get; set; }
        public string TablesIdOrName { get; set; }
        public string ColumnsIdOrName { get; set; }
        public string RootItemPath { get; set; }
    }
    public partial class RangeDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/range-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<RangeDeleteResponse> RangeDeleteAsync()
        {
            var p = new RangeDeleteParameter();
            return await this.SendAsync<RangeDeleteParameter, RangeDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/range-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<RangeDeleteResponse> RangeDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new RangeDeleteParameter();
            return await this.SendAsync<RangeDeleteParameter, RangeDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/range-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<RangeDeleteResponse> RangeDeleteAsync(RangeDeleteParameter parameter)
        {
            return await this.SendAsync<RangeDeleteParameter, RangeDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/range-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<RangeDeleteResponse> RangeDeleteAsync(RangeDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RangeDeleteParameter, RangeDeleteResponse>(parameter, cancellationToken);
        }
    }
}
