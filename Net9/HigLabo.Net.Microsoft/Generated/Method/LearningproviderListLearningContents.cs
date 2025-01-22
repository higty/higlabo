using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/learningprovider-list-learningcontents?view=graph-rest-1.0
/// </summary>
public partial class LearningProviderListLearningContentsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? LearningProviderId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.EmployeeExperience_LearningProviders_LearningProviderId_LearningContents: return $"/employeeExperience/learningProviders/{LearningProviderId}/learningContents";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        EmployeeExperience_LearningProviders_LearningProviderId_LearningContents,
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
public partial class LearningProviderListLearningContentsResponse : RestApiResponse<LearningContent>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/learningprovider-list-learningcontents?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/learningprovider-list-learningcontents?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<LearningProviderListLearningContentsResponse> LearningProviderListLearningContentsAsync()
    {
        var p = new LearningProviderListLearningContentsParameter();
        return await this.SendAsync<LearningProviderListLearningContentsParameter, LearningProviderListLearningContentsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/learningprovider-list-learningcontents?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<LearningProviderListLearningContentsResponse> LearningProviderListLearningContentsAsync(CancellationToken cancellationToken)
    {
        var p = new LearningProviderListLearningContentsParameter();
        return await this.SendAsync<LearningProviderListLearningContentsParameter, LearningProviderListLearningContentsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/learningprovider-list-learningcontents?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<LearningProviderListLearningContentsResponse> LearningProviderListLearningContentsAsync(LearningProviderListLearningContentsParameter parameter)
    {
        return await this.SendAsync<LearningProviderListLearningContentsParameter, LearningProviderListLearningContentsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/learningprovider-list-learningcontents?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<LearningProviderListLearningContentsResponse> LearningProviderListLearningContentsAsync(LearningProviderListLearningContentsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<LearningProviderListLearningContentsParameter, LearningProviderListLearningContentsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/learningprovider-list-learningcontents?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<LearningContent> LearningProviderListLearningContentsEnumerateAsync(LearningProviderListLearningContentsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<LearningProviderListLearningContentsParameter, LearningProviderListLearningContentsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<LearningContent>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
