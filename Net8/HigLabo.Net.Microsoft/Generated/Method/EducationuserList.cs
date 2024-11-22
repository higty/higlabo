using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationuser-list?view=graph-rest-1.0
/// </summary>
public partial class EducationUserListParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Education_Users: return $"/education/users";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Education_Users,
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
public partial class EducationUserListResponse : RestApiResponse<EducationUser>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationuser-list?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationuser-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationUserListResponse> EducationUserListAsync()
    {
        var p = new EducationUserListParameter();
        return await this.SendAsync<EducationUserListParameter, EducationUserListResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationuser-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationUserListResponse> EducationUserListAsync(CancellationToken cancellationToken)
    {
        var p = new EducationUserListParameter();
        return await this.SendAsync<EducationUserListParameter, EducationUserListResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationuser-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationUserListResponse> EducationUserListAsync(EducationUserListParameter parameter)
    {
        return await this.SendAsync<EducationUserListParameter, EducationUserListResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationuser-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationUserListResponse> EducationUserListAsync(EducationUserListParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<EducationUserListParameter, EducationUserListResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationuser-list?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<EducationUser> EducationUserListEnumerateAsync(EducationUserListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<EducationUserListParameter, EducationUserListResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<EducationUser>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
