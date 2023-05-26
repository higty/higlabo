using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/orgcontact-list-directreports?view=graph-rest-1.0
    /// </summary>
    public partial class OrgcontactListDirectreportsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Contacts_Id_DirectReports: return $"/contacts/{Id}/directReports";
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
            Contacts_Id_DirectReports,
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
    public partial class OrgcontactListDirectreportsResponse : RestApiResponse
    {
        public DirectoryObject[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/orgcontact-list-directreports?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/orgcontact-list-directreports?view=graph-rest-1.0
        /// </summary>
        public async Task<OrgcontactListDirectreportsResponse> OrgcontactListDirectreportsAsync()
        {
            var p = new OrgcontactListDirectreportsParameter();
            return await this.SendAsync<OrgcontactListDirectreportsParameter, OrgcontactListDirectreportsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/orgcontact-list-directreports?view=graph-rest-1.0
        /// </summary>
        public async Task<OrgcontactListDirectreportsResponse> OrgcontactListDirectreportsAsync(CancellationToken cancellationToken)
        {
            var p = new OrgcontactListDirectreportsParameter();
            return await this.SendAsync<OrgcontactListDirectreportsParameter, OrgcontactListDirectreportsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/orgcontact-list-directreports?view=graph-rest-1.0
        /// </summary>
        public async Task<OrgcontactListDirectreportsResponse> OrgcontactListDirectreportsAsync(OrgcontactListDirectreportsParameter parameter)
        {
            return await this.SendAsync<OrgcontactListDirectreportsParameter, OrgcontactListDirectreportsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/orgcontact-list-directreports?view=graph-rest-1.0
        /// </summary>
        public async Task<OrgcontactListDirectreportsResponse> OrgcontactListDirectreportsAsync(OrgcontactListDirectreportsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OrgcontactListDirectreportsParameter, OrgcontactListDirectreportsResponse>(parameter, cancellationToken);
        }
    }
}
