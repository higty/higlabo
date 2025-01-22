using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/plannerbucket-delete?view=graph-rest-1.0
/// </summary>
public partial class PlannerbucketDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Planner_Buckets_Id: return $"/planner/buckets/{Id}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Planner_Buckets_Id,
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
public partial class PlannerbucketDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/plannerbucket-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerbucket-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlannerbucketDeleteResponse> PlannerbucketDeleteAsync()
    {
        var p = new PlannerbucketDeleteParameter();
        return await this.SendAsync<PlannerbucketDeleteParameter, PlannerbucketDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerbucket-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlannerbucketDeleteResponse> PlannerbucketDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new PlannerbucketDeleteParameter();
        return await this.SendAsync<PlannerbucketDeleteParameter, PlannerbucketDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerbucket-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlannerbucketDeleteResponse> PlannerbucketDeleteAsync(PlannerbucketDeleteParameter parameter)
    {
        return await this.SendAsync<PlannerbucketDeleteParameter, PlannerbucketDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/plannerbucket-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlannerbucketDeleteResponse> PlannerbucketDeleteAsync(PlannerbucketDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<PlannerbucketDeleteParameter, PlannerbucketDeleteResponse>(parameter, cancellationToken);
    }
}
