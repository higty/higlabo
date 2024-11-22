using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class FilesRemoteUpdateParameter : IRestApiParameter
{
    string IRestApiParameter.ApiPath { get; } = "files.remote.update";
    string IRestApiParameter.HttpMethod { get; } = "GET";
    public string? External_Id { get; set; }
    public string? External_Url { get; set; }
    public string? File { get; set; }
    public string? Filetype { get; set; }
    public string? Indexable_File_Contents { get; set; }
    public string? Preview_Image { get; set; }
    public string? Title { get; set; }
}
public partial class FilesRemoteUpdateResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/files.remote.update
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/files.remote.update
    /// </summary>
    public async ValueTask<FilesRemoteUpdateResponse> FilesRemoteUpdateAsync()
    {
        var p = new FilesRemoteUpdateParameter();
        return await this.SendAsync<FilesRemoteUpdateParameter, FilesRemoteUpdateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/files.remote.update
    /// </summary>
    public async ValueTask<FilesRemoteUpdateResponse> FilesRemoteUpdateAsync(CancellationToken cancellationToken)
    {
        var p = new FilesRemoteUpdateParameter();
        return await this.SendAsync<FilesRemoteUpdateParameter, FilesRemoteUpdateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/files.remote.update
    /// </summary>
    public async ValueTask<FilesRemoteUpdateResponse> FilesRemoteUpdateAsync(FilesRemoteUpdateParameter parameter)
    {
        return await this.SendAsync<FilesRemoteUpdateParameter, FilesRemoteUpdateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/files.remote.update
    /// </summary>
    public async ValueTask<FilesRemoteUpdateResponse> FilesRemoteUpdateAsync(FilesRemoteUpdateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<FilesRemoteUpdateParameter, FilesRemoteUpdateResponse>(parameter, cancellationToken);
    }
}
