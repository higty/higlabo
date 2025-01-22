using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/directoryobject-delete?view=graph-rest-1.0
/// </summary>
public partial class DirectoryObjectDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.DirectoryObjects_Id: return $"/directoryObjects/{Id}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        DirectoryObjects_Id,
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
public partial class DirectoryObjectDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/directoryobject-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryobject-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryObjectDeleteResponse> DirectoryObjectDeleteAsync()
    {
        var p = new DirectoryObjectDeleteParameter();
        return await this.SendAsync<DirectoryObjectDeleteParameter, DirectoryObjectDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryobject-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryObjectDeleteResponse> DirectoryObjectDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new DirectoryObjectDeleteParameter();
        return await this.SendAsync<DirectoryObjectDeleteParameter, DirectoryObjectDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryobject-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryObjectDeleteResponse> DirectoryObjectDeleteAsync(DirectoryObjectDeleteParameter parameter)
    {
        return await this.SendAsync<DirectoryObjectDeleteParameter, DirectoryObjectDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryobject-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryObjectDeleteResponse> DirectoryObjectDeleteAsync(DirectoryObjectDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<DirectoryObjectDeleteParameter, DirectoryObjectDeleteResponse>(parameter, cancellationToken);
    }
}
