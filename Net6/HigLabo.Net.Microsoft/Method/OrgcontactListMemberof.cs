using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OrgcontactListMemberofParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Contacts_Id_MemberOf,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Contacts_Id_MemberOf: return $"/contacts/{Id}/memberOf";
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
    public partial class OrgcontactListMemberofResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/orgcontact-list-memberof?view=graph-rest-1.0
        /// </summary>
        public async Task<OrgcontactListMemberofResponse> OrgcontactListMemberofAsync()
        {
            var p = new OrgcontactListMemberofParameter();
            return await this.SendAsync<OrgcontactListMemberofParameter, OrgcontactListMemberofResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/orgcontact-list-memberof?view=graph-rest-1.0
        /// </summary>
        public async Task<OrgcontactListMemberofResponse> OrgcontactListMemberofAsync(CancellationToken cancellationToken)
        {
            var p = new OrgcontactListMemberofParameter();
            return await this.SendAsync<OrgcontactListMemberofParameter, OrgcontactListMemberofResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/orgcontact-list-memberof?view=graph-rest-1.0
        /// </summary>
        public async Task<OrgcontactListMemberofResponse> OrgcontactListMemberofAsync(OrgcontactListMemberofParameter parameter)
        {
            return await this.SendAsync<OrgcontactListMemberofParameter, OrgcontactListMemberofResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/orgcontact-list-memberof?view=graph-rest-1.0
        /// </summary>
        public async Task<OrgcontactListMemberofResponse> OrgcontactListMemberofAsync(OrgcontactListMemberofParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OrgcontactListMemberofParameter, OrgcontactListMemberofResponse>(parameter, cancellationToken);
        }
    }
}
