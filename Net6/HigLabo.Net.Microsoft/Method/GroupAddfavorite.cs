using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupAddfavoriteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_Id_AddFavorite: return $"/groups/{Id}/addFavorite";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Groups_Id_AddFavorite,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class GroupAddfavoriteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-addfavorite?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupAddfavoriteResponse> GroupAddfavoriteAsync()
        {
            var p = new GroupAddfavoriteParameter();
            return await this.SendAsync<GroupAddfavoriteParameter, GroupAddfavoriteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-addfavorite?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupAddfavoriteResponse> GroupAddfavoriteAsync(CancellationToken cancellationToken)
        {
            var p = new GroupAddfavoriteParameter();
            return await this.SendAsync<GroupAddfavoriteParameter, GroupAddfavoriteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-addfavorite?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupAddfavoriteResponse> GroupAddfavoriteAsync(GroupAddfavoriteParameter parameter)
        {
            return await this.SendAsync<GroupAddfavoriteParameter, GroupAddfavoriteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-addfavorite?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupAddfavoriteResponse> GroupAddfavoriteAsync(GroupAddfavoriteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupAddfavoriteParameter, GroupAddfavoriteResponse>(parameter, cancellationToken);
        }
    }
}
