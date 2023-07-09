using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/orgcontact-list-memberof?view=graph-rest-1.0
    /// </summary>
    public partial class OrgcontactListMemberofParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Contacts_Id_MemberOf: return $"/contacts/{Id}/memberOf";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            DeletedDateTime,
            Id,
        }
        public enum ApiPath
        {
            Contacts_Id_MemberOf,
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
    public partial class OrgcontactListMemberofResponse : RestApiResponse
    {
        public DirectoryObject[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/orgcontact-list-memberof?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/orgcontact-list-memberof?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OrgcontactListMemberofResponse> OrgcontactListMemberofAsync()
        {
            var p = new OrgcontactListMemberofParameter();
            return await this.SendAsync<OrgcontactListMemberofParameter, OrgcontactListMemberofResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/orgcontact-list-memberof?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OrgcontactListMemberofResponse> OrgcontactListMemberofAsync(CancellationToken cancellationToken)
        {
            var p = new OrgcontactListMemberofParameter();
            return await this.SendAsync<OrgcontactListMemberofParameter, OrgcontactListMemberofResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/orgcontact-list-memberof?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OrgcontactListMemberofResponse> OrgcontactListMemberofAsync(OrgcontactListMemberofParameter parameter)
        {
            return await this.SendAsync<OrgcontactListMemberofParameter, OrgcontactListMemberofResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/orgcontact-list-memberof?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OrgcontactListMemberofResponse> OrgcontactListMemberofAsync(OrgcontactListMemberofParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OrgcontactListMemberofParameter, OrgcontactListMemberofResponse>(parameter, cancellationToken);
        }
    }
}
