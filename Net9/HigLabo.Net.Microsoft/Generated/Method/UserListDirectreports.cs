using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/user-list-directreports?view=graph-rest-1.0
/// </summary>
public partial class UserListDirectreportsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? IdOrUserPrincipalName { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_DirectReports: return $"/me/directReports";
                case ApiPath.Users_IdOrUserPrincipalName_DirectReports: return $"/users/{IdOrUserPrincipalName}/directReports";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Me_DirectReports,
        Users_IdOrUserPrincipalName_DirectReports,
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
public partial class UserListDirectreportsResponse : RestApiResponse<DirectoryObject>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/user-list-directreports?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-directreports?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserListDirectreportsResponse> UserListDirectreportsAsync()
    {
        var p = new UserListDirectreportsParameter();
        return await this.SendAsync<UserListDirectreportsParameter, UserListDirectreportsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-directreports?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserListDirectreportsResponse> UserListDirectreportsAsync(CancellationToken cancellationToken)
    {
        var p = new UserListDirectreportsParameter();
        return await this.SendAsync<UserListDirectreportsParameter, UserListDirectreportsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-directreports?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserListDirectreportsResponse> UserListDirectreportsAsync(UserListDirectreportsParameter parameter)
    {
        return await this.SendAsync<UserListDirectreportsParameter, UserListDirectreportsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-directreports?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserListDirectreportsResponse> UserListDirectreportsAsync(UserListDirectreportsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<UserListDirectreportsParameter, UserListDirectreportsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-directreports?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<DirectoryObject> UserListDirectreportsEnumerateAsync(UserListDirectreportsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<UserListDirectreportsParameter, UserListDirectreportsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<DirectoryObject>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
