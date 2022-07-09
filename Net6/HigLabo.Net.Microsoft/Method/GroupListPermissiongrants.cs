using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupListPermissiongrantsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? GroupId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_GroupId_PermissionGrants: return $"/groups/{GroupId}/permissionGrants";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Groups_GroupId_PermissionGrants,
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
    public partial class GroupListPermissiongrantsResponse : RestApiResponse
    {
        public enum ResourceSpecificPermissionGrantstring
        {
            Application,
            Delegated,
        }

        public string? Id { get; set; }
        public DateTimeOffset? DeletedDateTime { get; set; }
        public string? ClientId { get; set; }
        public string? ClientAppId { get; set; }
        public string? ResourceAppId { get; set; }
        public ResourceSpecificPermissionGrantstring PermissionType { get; set; }
        public string? Permission { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-permissiongrants?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListPermissiongrantsResponse> GroupListPermissiongrantsAsync()
        {
            var p = new GroupListPermissiongrantsParameter();
            return await this.SendAsync<GroupListPermissiongrantsParameter, GroupListPermissiongrantsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-permissiongrants?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListPermissiongrantsResponse> GroupListPermissiongrantsAsync(CancellationToken cancellationToken)
        {
            var p = new GroupListPermissiongrantsParameter();
            return await this.SendAsync<GroupListPermissiongrantsParameter, GroupListPermissiongrantsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-permissiongrants?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListPermissiongrantsResponse> GroupListPermissiongrantsAsync(GroupListPermissiongrantsParameter parameter)
        {
            return await this.SendAsync<GroupListPermissiongrantsParameter, GroupListPermissiongrantsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-permissiongrants?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListPermissiongrantsResponse> GroupListPermissiongrantsAsync(GroupListPermissiongrantsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupListPermissiongrantsParameter, GroupListPermissiongrantsResponse>(parameter, cancellationToken);
        }
    }
}
