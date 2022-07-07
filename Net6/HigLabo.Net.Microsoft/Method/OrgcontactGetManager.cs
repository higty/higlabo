using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OrgcontactGetManagerParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Contacts_Id_Manager,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Contacts_Id_Manager: return $"/contacts/{Id}/manager";
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
    }
    public partial class OrgcontactGetManagerResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/directoryobject?view=graph-rest-1.0
        /// </summary>
        public partial class DirectoryObject
        {
            public DateTimeOffset? DeletedDateTime { get; set; }
            public string? Id { get; set; }
        }

        public DirectoryObject[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/orgcontact-get-manager?view=graph-rest-1.0
        /// </summary>
        public async Task<OrgcontactGetManagerResponse> OrgcontactGetManagerAsync()
        {
            var p = new OrgcontactGetManagerParameter();
            return await this.SendAsync<OrgcontactGetManagerParameter, OrgcontactGetManagerResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/orgcontact-get-manager?view=graph-rest-1.0
        /// </summary>
        public async Task<OrgcontactGetManagerResponse> OrgcontactGetManagerAsync(CancellationToken cancellationToken)
        {
            var p = new OrgcontactGetManagerParameter();
            return await this.SendAsync<OrgcontactGetManagerParameter, OrgcontactGetManagerResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/orgcontact-get-manager?view=graph-rest-1.0
        /// </summary>
        public async Task<OrgcontactGetManagerResponse> OrgcontactGetManagerAsync(OrgcontactGetManagerParameter parameter)
        {
            return await this.SendAsync<OrgcontactGetManagerParameter, OrgcontactGetManagerResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/orgcontact-get-manager?view=graph-rest-1.0
        /// </summary>
        public async Task<OrgcontactGetManagerResponse> OrgcontactGetManagerAsync(OrgcontactGetManagerParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OrgcontactGetManagerParameter, OrgcontactGetManagerResponse>(parameter, cancellationToken);
        }
    }
}
