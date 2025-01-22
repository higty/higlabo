using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/user-list-mailfolders?view=graph-rest-1.0
/// </summary>
public partial class UserListMailFoldersParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? IdOrUserPrincipalName { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_MailFolders: return $"/me/mailFolders";
                case ApiPath.Users_IdOrUserPrincipalName_MailFolders: return $"/users/{IdOrUserPrincipalName}/mailFolders";
                case ApiPath.Me_MailFolders_: return $"/me/mailFolders/";
                case ApiPath.Users_IdOrUserPrincipalName_MailFolders_: return $"/users/{IdOrUserPrincipalName}/mailFolders/";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Me_MailFolders,
        Users_IdOrUserPrincipalName_MailFolders,
        Me_MailFolders_,
        Users_IdOrUserPrincipalName_MailFolders_,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "GET";
    public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
    IQueryParameter IQueryParameterProperty.Query
    {
        get
        {
            return this.Query;
        }
    }
}
public partial class UserListMailFoldersResponse : RestApiResponse<MailFolder>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/user-list-mailfolders?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-mailfolders?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserListMailFoldersResponse> UserListMailFoldersAsync()
    {
        var p = new UserListMailFoldersParameter();
        return await this.SendAsync<UserListMailFoldersParameter, UserListMailFoldersResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-mailfolders?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserListMailFoldersResponse> UserListMailFoldersAsync(CancellationToken cancellationToken)
    {
        var p = new UserListMailFoldersParameter();
        return await this.SendAsync<UserListMailFoldersParameter, UserListMailFoldersResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-mailfolders?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserListMailFoldersResponse> UserListMailFoldersAsync(UserListMailFoldersParameter parameter)
    {
        return await this.SendAsync<UserListMailFoldersParameter, UserListMailFoldersResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-mailfolders?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserListMailFoldersResponse> UserListMailFoldersAsync(UserListMailFoldersParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<UserListMailFoldersParameter, UserListMailFoldersResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-mailfolders?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<MailFolder> UserListMailFoldersEnumerateAsync(UserListMailFoldersParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<UserListMailFoldersParameter, UserListMailFoldersResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<MailFolder>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
