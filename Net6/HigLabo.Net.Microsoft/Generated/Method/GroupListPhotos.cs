using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-photos?view=graph-rest-1.0
    /// </summary>
    public partial class GroupListPhotosParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_Id_Photos: return $"/groups/{Id}/photos";
                    case ApiPath.Users_IdOrUserPrincipalName_JoinedGroups_Id_Photos: return $"/users/{IdOrUserPrincipalName}/joinedGroups/{Id}/photos";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Id,
            Height,
            Width,
        }
        public enum ApiPath
        {
            Groups_Id_Photos,
            Users_IdOrUserPrincipalName_JoinedGroups_Id_Photos,
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
    public partial class GroupListPhotosResponse : RestApiResponse
    {
        public ProfilePhoto[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-photos?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-photos?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListPhotosResponse> GroupListPhotosAsync()
        {
            var p = new GroupListPhotosParameter();
            return await this.SendAsync<GroupListPhotosParameter, GroupListPhotosResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-photos?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListPhotosResponse> GroupListPhotosAsync(CancellationToken cancellationToken)
        {
            var p = new GroupListPhotosParameter();
            return await this.SendAsync<GroupListPhotosParameter, GroupListPhotosResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-photos?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListPhotosResponse> GroupListPhotosAsync(GroupListPhotosParameter parameter)
        {
            return await this.SendAsync<GroupListPhotosParameter, GroupListPhotosResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-photos?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListPhotosResponse> GroupListPhotosAsync(GroupListPhotosParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupListPhotosParameter, GroupListPhotosResponse>(parameter, cancellationToken);
        }
    }
}
