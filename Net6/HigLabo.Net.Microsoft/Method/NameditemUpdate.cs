using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class NameditemUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? Name { get; set; }
            public string? ItemPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Names_Name: return $"/me/drive/items/{Id}/workbook/names/{Name}";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Names_Name: return $"/me/drive/root:/{ItemPath}:/workbook/names/{Name}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Names_Name,
            Me_Drive_Root_ItemPath_Workbook_Names_Name,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public bool? Visible { get; set; }
        public string? Comment { get; set; }
    }
    public partial class NameditemUpdateResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/nameditem-update?view=graph-rest-1.0
        /// </summary>
        public async Task<NameditemUpdateResponse> NameditemUpdateAsync()
        {
            var p = new NameditemUpdateParameter();
            return await this.SendAsync<NameditemUpdateParameter, NameditemUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/nameditem-update?view=graph-rest-1.0
        /// </summary>
        public async Task<NameditemUpdateResponse> NameditemUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new NameditemUpdateParameter();
            return await this.SendAsync<NameditemUpdateParameter, NameditemUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/nameditem-update?view=graph-rest-1.0
        /// </summary>
        public async Task<NameditemUpdateResponse> NameditemUpdateAsync(NameditemUpdateParameter parameter)
        {
            return await this.SendAsync<NameditemUpdateParameter, NameditemUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/nameditem-update?view=graph-rest-1.0
        /// </summary>
        public async Task<NameditemUpdateResponse> NameditemUpdateAsync(NameditemUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<NameditemUpdateParameter, NameditemUpdateResponse>(parameter, cancellationToken);
        }
    }
}
