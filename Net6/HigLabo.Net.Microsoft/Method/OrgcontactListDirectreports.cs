using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OrgcontactListDirectreportsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Contacts_Id_DirectReports,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Contacts_Id_DirectReports: return $"/contacts/{Id}/directReports";
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
    public partial class OrgcontactListDirectreportsResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/orgcontact-list-directreports?view=graph-rest-1.0
        /// </summary>
        public async Task<OrgcontactListDirectreportsResponse> OrgcontactListDirectreportsAsync()
        {
            var p = new OrgcontactListDirectreportsParameter();
            return await this.SendAsync<OrgcontactListDirectreportsParameter, OrgcontactListDirectreportsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/orgcontact-list-directreports?view=graph-rest-1.0
        /// </summary>
        public async Task<OrgcontactListDirectreportsResponse> OrgcontactListDirectreportsAsync(CancellationToken cancellationToken)
        {
            var p = new OrgcontactListDirectreportsParameter();
            return await this.SendAsync<OrgcontactListDirectreportsParameter, OrgcontactListDirectreportsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/orgcontact-list-directreports?view=graph-rest-1.0
        /// </summary>
        public async Task<OrgcontactListDirectreportsResponse> OrgcontactListDirectreportsAsync(OrgcontactListDirectreportsParameter parameter)
        {
            return await this.SendAsync<OrgcontactListDirectreportsParameter, OrgcontactListDirectreportsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/orgcontact-list-directreports?view=graph-rest-1.0
        /// </summary>
        public async Task<OrgcontactListDirectreportsResponse> OrgcontactListDirectreportsAsync(OrgcontactListDirectreportsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OrgcontactListDirectreportsParameter, OrgcontactListDirectreportsResponse>(parameter, cancellationToken);
        }
    }
}
