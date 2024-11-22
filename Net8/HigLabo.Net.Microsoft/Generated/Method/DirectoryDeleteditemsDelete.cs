using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-delete?view=graph-rest-1.0
/// </summary>
public partial class DirectoryDeletedItemsDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Directory_DeletedItems_Id: return $"/directory/deletedItems/{Id}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Directory_DeletedItems_Id,
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
public partial class DirectoryDeletedItemsDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryDeletedItemsDeleteResponse> DirectoryDeletedItemsDeleteAsync()
    {
        var p = new DirectoryDeletedItemsDeleteParameter();
        return await this.SendAsync<DirectoryDeletedItemsDeleteParameter, DirectoryDeletedItemsDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryDeletedItemsDeleteResponse> DirectoryDeletedItemsDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new DirectoryDeletedItemsDeleteParameter();
        return await this.SendAsync<DirectoryDeletedItemsDeleteParameter, DirectoryDeletedItemsDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryDeletedItemsDeleteResponse> DirectoryDeletedItemsDeleteAsync(DirectoryDeletedItemsDeleteParameter parameter)
    {
        return await this.SendAsync<DirectoryDeletedItemsDeleteParameter, DirectoryDeletedItemsDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryDeletedItemsDeleteResponse> DirectoryDeletedItemsDeleteAsync(DirectoryDeletedItemsDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<DirectoryDeletedItemsDeleteParameter, DirectoryDeletedItemsDeleteResponse>(parameter, cancellationToken);
    }
}
