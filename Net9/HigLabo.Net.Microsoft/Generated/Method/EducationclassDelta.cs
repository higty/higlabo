using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationclass-delta?view=graph-rest-1.0
/// </summary>
public partial class EducationClassDeltaParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Education_Classes_Delta: return $"/education/classes/delta";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Education_Classes_Delta,
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
public partial class EducationClassDeltaResponse : RestApiResponse<EducationClass>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationclass-delta?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationclass-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationClassDeltaResponse> EducationClassDeltaAsync()
    {
        var p = new EducationClassDeltaParameter();
        return await this.SendAsync<EducationClassDeltaParameter, EducationClassDeltaResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationclass-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationClassDeltaResponse> EducationClassDeltaAsync(CancellationToken cancellationToken)
    {
        var p = new EducationClassDeltaParameter();
        return await this.SendAsync<EducationClassDeltaParameter, EducationClassDeltaResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationclass-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationClassDeltaResponse> EducationClassDeltaAsync(EducationClassDeltaParameter parameter)
    {
        return await this.SendAsync<EducationClassDeltaParameter, EducationClassDeltaResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationclass-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationClassDeltaResponse> EducationClassDeltaAsync(EducationClassDeltaParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<EducationClassDeltaParameter, EducationClassDeltaResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationclass-delta?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<EducationClass> EducationClassDeltaEnumerateAsync(EducationClassDeltaParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<EducationClassDeltaParameter, EducationClassDeltaResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<EducationClass>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
