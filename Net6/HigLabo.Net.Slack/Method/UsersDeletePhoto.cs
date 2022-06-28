
namespace HigLabo.Net.Slack
{
    public class UsersDeletePhotoParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "users.deletePhoto";
        public string HttpMethod { get; private set; } = "GET";
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
