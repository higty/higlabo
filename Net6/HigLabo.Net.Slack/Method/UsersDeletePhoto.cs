
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
        public async Task<UsersDeletePhotoResponse> UsersDeletePhotoAsync()
        {
            var p = new UsersDeletePhotoParameter();
            return await this.SendAsync<UsersDeletePhotoParameter, UsersDeletePhotoResponse>(p, CancellationToken.None);
        }
        public async Task<UsersDeletePhotoResponse> UsersDeletePhotoAsync(CancellationToken cancellationToken)
        {
            var p = new UsersDeletePhotoParameter();
            return await this.SendAsync<UsersDeletePhotoParameter, UsersDeletePhotoResponse>(p, cancellationToken);
        }
        public async Task<UsersDeletePhotoResponse> UsersDeletePhotoAsync(UsersDeletePhotoParameter parameter)
        {
            return await this.SendAsync<UsersDeletePhotoParameter, UsersDeletePhotoResponse>(parameter, CancellationToken.None);
        }
        public async Task<UsersDeletePhotoResponse> UsersDeletePhotoAsync(UsersDeletePhotoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UsersDeletePhotoParameter, UsersDeletePhotoResponse>(parameter, cancellationToken);
        }
    }
}
