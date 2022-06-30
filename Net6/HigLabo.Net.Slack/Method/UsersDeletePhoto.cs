
namespace HigLabo.Net.Slack
{
    public partial class UsersDeletePhotoParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "users.deletePhoto";
        string IRestApiParameter.HttpMethod { get; } = "GET";
    }
    public partial class UsersDeletePhotoResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/users.deletePhoto
        /// </summary>
        public async Task<UsersDeletePhotoResponse> UsersDeletePhotoAsync()
        {
            var p = new UsersDeletePhotoParameter();
            return await this.SendAsync<UsersDeletePhotoParameter, UsersDeletePhotoResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/users.deletePhoto
        /// </summary>
        public async Task<UsersDeletePhotoResponse> UsersDeletePhotoAsync(CancellationToken cancellationToken)
        {
            var p = new UsersDeletePhotoParameter();
            return await this.SendAsync<UsersDeletePhotoParameter, UsersDeletePhotoResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/users.deletePhoto
        /// </summary>
        public async Task<UsersDeletePhotoResponse> UsersDeletePhotoAsync(UsersDeletePhotoParameter parameter)
        {
            return await this.SendAsync<UsersDeletePhotoParameter, UsersDeletePhotoResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/users.deletePhoto
        /// </summary>
        public async Task<UsersDeletePhotoResponse> UsersDeletePhotoAsync(UsersDeletePhotoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UsersDeletePhotoParameter, UsersDeletePhotoResponse>(parameter, cancellationToken);
        }
    }
}
