using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DriveitemUnfollowParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string ItemId { get; set; }
            public string UserId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Drive_Following_ItemId: return $"/me/drive/following/{ItemId}";
                    case ApiPath.Users_UserId_Drive_Following_ItemId: return $"/users/{UserId}/drive/following/{ItemId}";
                    case ApiPath.Me_Drive_Items_ItemId_Unfollow: return $"/me/drive/items/{ItemId}/unfollow";
                    case ApiPath.Users_UserId_Drive_Items_ItemId_Unfollow: return $"/users/{UserId}/drive/items/{ItemId}/unfollow";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Drive_Following_ItemId,
            Users_UserId_Drive_Following_ItemId,
            Me_Drive_Items_ItemId_Unfollow,
            Users_UserId_Drive_Items_ItemId_Unfollow,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class DriveitemUnfollowResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-unfollow?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemUnfollowResponse> DriveitemUnfollowAsync()
        {
            var p = new DriveitemUnfollowParameter();
            return await this.SendAsync<DriveitemUnfollowParameter, DriveitemUnfollowResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-unfollow?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemUnfollowResponse> DriveitemUnfollowAsync(CancellationToken cancellationToken)
        {
            var p = new DriveitemUnfollowParameter();
            return await this.SendAsync<DriveitemUnfollowParameter, DriveitemUnfollowResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-unfollow?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemUnfollowResponse> DriveitemUnfollowAsync(DriveitemUnfollowParameter parameter)
        {
            return await this.SendAsync<DriveitemUnfollowParameter, DriveitemUnfollowResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-unfollow?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemUnfollowResponse> DriveitemUnfollowAsync(DriveitemUnfollowParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DriveitemUnfollowParameter, DriveitemUnfollowResponse>(parameter, cancellationToken);
        }
    }
}
