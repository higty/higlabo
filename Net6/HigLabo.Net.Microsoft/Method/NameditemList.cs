using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class NameditemListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }
            public string ItemPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Names: return $"/me/drive/items/{Id}/workbook/names";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Names: return $"/me/drive/root:/{ItemPath}:/workbook/names";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Name,
            Comment,
            Scope,
            Type,
            Value,
            Visible,
            Worksheet,
        }
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Names,
            Me_Drive_Root_ItemPath_Workbook_Names,
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
    public partial class NameditemListResponse : RestApiResponse
    {
        public NamedItem[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/nameditem-list?view=graph-rest-1.0
        /// </summary>
        public async Task<NameditemListResponse> NameditemListAsync()
        {
            var p = new NameditemListParameter();
            return await this.SendAsync<NameditemListParameter, NameditemListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/nameditem-list?view=graph-rest-1.0
        /// </summary>
        public async Task<NameditemListResponse> NameditemListAsync(CancellationToken cancellationToken)
        {
            var p = new NameditemListParameter();
            return await this.SendAsync<NameditemListParameter, NameditemListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/nameditem-list?view=graph-rest-1.0
        /// </summary>
        public async Task<NameditemListResponse> NameditemListAsync(NameditemListParameter parameter)
        {
            return await this.SendAsync<NameditemListParameter, NameditemListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/nameditem-list?view=graph-rest-1.0
        /// </summary>
        public async Task<NameditemListResponse> NameditemListAsync(NameditemListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<NameditemListParameter, NameditemListResponse>(parameter, cancellationToken);
        }
    }
}
