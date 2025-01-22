using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class FilesRemoteInfoParameter : IRestApiParameter
{
    string IRestApiParameter.ApiPath { get; } = "files.remote.info";
    string IRestApiParameter.HttpMethod { get; } = "GET";
    public string? External_Id { get; set; }
    public string? File { get; set; }
}
public partial class FilesRemoteInfoResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/files.remote.info
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/files.remote.info
    /// </summary>
    public async ValueTask<FilesRemoteInfoResponse> FilesRemoteInfoAsync()
    {
        var p = new FilesRemoteInfoParameter();
        return await this.SendAsync<FilesRemoteInfoParameter, FilesRemoteInfoResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/files.remote.info
    /// </summary>
    public async ValueTask<FilesRemoteInfoResponse> FilesRemoteInfoAsync(CancellationToken cancellationToken)
    {
        var p = new FilesRemoteInfoParameter();
        return await this.SendAsync<FilesRemoteInfoParameter, FilesRemoteInfoResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/files.remote.info
    /// </summary>
    public async ValueTask<FilesRemoteInfoResponse> FilesRemoteInfoAsync(FilesRemoteInfoParameter parameter)
    {
        return await this.SendAsync<FilesRemoteInfoParameter, FilesRemoteInfoResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/files.remote.info
    /// </summary>
    public async ValueTask<FilesRemoteInfoResponse> FilesRemoteInfoAsync(FilesRemoteInfoParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<FilesRemoteInfoParameter, FilesRemoteInfoResponse>(parameter, cancellationToken);
    }
}
