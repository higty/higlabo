using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class NameditemAddParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }
            public string ItemPath { get; set; }
            public string IdOrName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Names_Add: return $"/me/drive/items/{Id}/workbook/names/add";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Names_Add: return $"/me/drive/root:/{ItemPath}:/workbook/names/add";
                    case ApiPath.Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Names_Add: return $"/me/drive/items/{Id}/workbook/worksheets/{IdOrName}/names/add";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Names_Add: return $"/me/drive/root:/{ItemPath}:/workbook/worksheets/{IdOrName}/names/add";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum NamedItemstring
        {
            String,
            Integer,
            Double,
            Boolean,
            Range,
        }
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Names_Add,
            Me_Drive_Root_ItemPath_Workbook_Names_Add,
            Me_Drive_Items_Id_Workbook_Worksheets_IdOrname_Names_Add,
            Me_Drive_Root_ItemPath_Workbook_Worksheets_IdOrname_Names_Add,
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
        public Json? Reference { get; set; }
        public string? Comment { get; set; }
        public string? Scope { get; set; }
        public NamedItemstring Type { get; set; }
        public Json? Value { get; set; }
        public bool? Visible { get; set; }
        public Worksheet? Worksheet { get; set; }
    }
    public partial class NameditemAddResponse : RestApiResponse
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
        public Worksheet? Worksheet { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/nameditem-add?view=graph-rest-1.0
        /// </summary>
        public async Task<NameditemAddResponse> NameditemAddAsync()
        {
            var p = new NameditemAddParameter();
            return await this.SendAsync<NameditemAddParameter, NameditemAddResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/nameditem-add?view=graph-rest-1.0
        /// </summary>
        public async Task<NameditemAddResponse> NameditemAddAsync(CancellationToken cancellationToken)
        {
            var p = new NameditemAddParameter();
            return await this.SendAsync<NameditemAddParameter, NameditemAddResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/nameditem-add?view=graph-rest-1.0
        /// </summary>
        public async Task<NameditemAddResponse> NameditemAddAsync(NameditemAddParameter parameter)
        {
            return await this.SendAsync<NameditemAddParameter, NameditemAddResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/nameditem-add?view=graph-rest-1.0
        /// </summary>
        public async Task<NameditemAddResponse> NameditemAddAsync(NameditemAddParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<NameditemAddParameter, NameditemAddResponse>(parameter, cancellationToken);
        }
    }
}
