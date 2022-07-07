using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class NameditemGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_Names_Name,
            Me_Drive_Root_ItemPath_Workbook_Names_Name,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_Names_Name: return $"/me/drive/items/{Id}/workbook/names/{Name}";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_Names_Name: return $"/me/drive/root:/{ItemPath}:/workbook/names/{Name}";
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
        public string Name { get; set; }
        public string ItemPath { get; set; }
    }
    public partial class NameditemGetResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/nameditem-get?view=graph-rest-1.0
        /// </summary>
        public async Task<NameditemGetResponse> NameditemGetAsync()
        {
            var p = new NameditemGetParameter();
            return await this.SendAsync<NameditemGetParameter, NameditemGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/nameditem-get?view=graph-rest-1.0
        /// </summary>
        public async Task<NameditemGetResponse> NameditemGetAsync(CancellationToken cancellationToken)
        {
            var p = new NameditemGetParameter();
            return await this.SendAsync<NameditemGetParameter, NameditemGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/nameditem-get?view=graph-rest-1.0
        /// </summary>
        public async Task<NameditemGetResponse> NameditemGetAsync(NameditemGetParameter parameter)
        {
            return await this.SendAsync<NameditemGetParameter, NameditemGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/nameditem-get?view=graph-rest-1.0
        /// </summary>
        public async Task<NameditemGetResponse> NameditemGetAsync(NameditemGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<NameditemGetParameter, NameditemGetResponse>(parameter, cancellationToken);
        }
    }
}
