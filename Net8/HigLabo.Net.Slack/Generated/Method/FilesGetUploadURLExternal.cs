using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class FilesGetUploadURLExternalParameter : IRestApiParameter
{
    string IRestApiParameter.ApiPath { get; } = "files.getUploadURLExternal";
    string IRestApiParameter.HttpMethod { get; } = "GET";
    public string? Filename { get; set; }
    public int? Length { get; set; }
    public string? Alt_Txt { get; set; }
    public string? Snippet_Type { get; set; }
}
public partial class FilesGetUploadURLExternalResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/files.getUploadURLExternal
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/files.getUploadURLExternal
    /// </summary>
    public async ValueTask<FilesGetUploadURLExternalResponse> FilesGetUploadURLExternalAsync(string? filename, int? length)
    {
        var p = new FilesGetUploadURLExternalParameter();
        p.Filename = filename;
        p.Length = length;
        return await this.SendAsync<FilesGetUploadURLExternalParameter, FilesGetUploadURLExternalResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/files.getUploadURLExternal
    /// </summary>
    public async ValueTask<FilesGetUploadURLExternalResponse> FilesGetUploadURLExternalAsync(string? filename, int? length, CancellationToken cancellationToken)
    {
        var p = new FilesGetUploadURLExternalParameter();
        p.Filename = filename;
        p.Length = length;
        return await this.SendAsync<FilesGetUploadURLExternalParameter, FilesGetUploadURLExternalResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/files.getUploadURLExternal
    /// </summary>
    public async ValueTask<FilesGetUploadURLExternalResponse> FilesGetUploadURLExternalAsync(FilesGetUploadURLExternalParameter parameter)
    {
        return await this.SendAsync<FilesGetUploadURLExternalParameter, FilesGetUploadURLExternalResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/files.getUploadURLExternal
    /// </summary>
    public async ValueTask<FilesGetUploadURLExternalResponse> FilesGetUploadURLExternalAsync(FilesGetUploadURLExternalParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<FilesGetUploadURLExternalParameter, FilesGetUploadURLExternalResponse>(parameter, cancellationToken);
    }
}
