using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationuser-delta?view=graph-rest-1.0
/// </summary>
public partial class EducationUserDeltaParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Education_Users_Delta: return $"/education/users/delta";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Education_Users_Delta,
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
public partial class EducationUserDeltaResponse : RestApiResponse<EducationUser>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationuser-delta?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationuser-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationUserDeltaResponse> EducationUserDeltaAsync()
    {
        var p = new EducationUserDeltaParameter();
        return await this.SendAsync<EducationUserDeltaParameter, EducationUserDeltaResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationuser-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationUserDeltaResponse> EducationUserDeltaAsync(CancellationToken cancellationToken)
    {
        var p = new EducationUserDeltaParameter();
        return await this.SendAsync<EducationUserDeltaParameter, EducationUserDeltaResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationuser-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationUserDeltaResponse> EducationUserDeltaAsync(EducationUserDeltaParameter parameter)
    {
        return await this.SendAsync<EducationUserDeltaParameter, EducationUserDeltaResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationuser-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationUserDeltaResponse> EducationUserDeltaAsync(EducationUserDeltaParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<EducationUserDeltaParameter, EducationUserDeltaResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationuser-delta?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<EducationUser> EducationUserDeltaEnumerateAsync(EducationUserDeltaParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<EducationUserDeltaParameter, EducationUserDeltaResponse>(parameter, cancellationToken);
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
