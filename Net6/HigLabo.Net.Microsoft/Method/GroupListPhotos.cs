using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupListPhotosParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Groups_Id_Photos,
            Users_IdOrUserPrincipalName_JoinedGroups_Id_Photos,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Groups_Id_Photos: return $"/groups/{Id}/photos";
                    case ApiPath.Users_IdOrUserPrincipalName_JoinedGroups_Id_Photos: return $"/users/{IdOrUserPrincipalName}/joinedGroups/{Id}/photos";
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
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class GroupListPhotosResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/profilephoto?view=graph-rest-1.0
        /// </summary>
        public partial class ProfilePhoto
        {
            public string? Id { get; set; }
            public Int32? Height { get; set; }
            public Int32? Width { get; set; }
        }

        public ProfilePhoto[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-photos?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListPhotosResponse> GroupListPhotosAsync()
        {
            var p = new GroupListPhotosParameter();
            return await this.SendAsync<GroupListPhotosParameter, GroupListPhotosResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-photos?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListPhotosResponse> GroupListPhotosAsync(CancellationToken cancellationToken)
        {
            var p = new GroupListPhotosParameter();
            return await this.SendAsync<GroupListPhotosParameter, GroupListPhotosResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-photos?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListPhotosResponse> GroupListPhotosAsync(GroupListPhotosParameter parameter)
        {
            return await this.SendAsync<GroupListPhotosParameter, GroupListPhotosResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-photos?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListPhotosResponse> GroupListPhotosAsync(GroupListPhotosParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupListPhotosParameter, GroupListPhotosResponse>(parameter, cancellationToken);
        }
    }
}
