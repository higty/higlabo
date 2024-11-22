using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/longrunningoperation-get?view=graph-rest-1.0
/// </summary>
public partial class LongrunningOperationGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? IdOrUserPrincipalName { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Users_IdOrUserPrincipalName_Authentication_Operations_Id: return $"/users/{IdOrUserPrincipalName}/authentication/operations/{Id}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Users_IdOrUserPrincipalName_Authentication_Operations_Id,
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
public partial class LongrunningOperationGetResponse : RestApiResponse
{
    public enum LongRunningOperationLongRunningOperationStatus
    {
        NotStarted,
        Running,
        Succeeded,
        Failed,
        UnknownFutureValue,
    }

    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? LastActionDateTime { get; set; }
    public string? ResourceLocation { get; set; }
    public LongRunningOperationLongRunningOperationStatus Status { get; set; }
    public string? StatusDetail { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/longrunningoperation-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/longrunningoperation-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<LongrunningOperationGetResponse> LongrunningOperationGetAsync()
    {
        var p = new LongrunningOperationGetParameter();
        return await this.SendAsync<LongrunningOperationGetParameter, LongrunningOperationGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/longrunningoperation-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<LongrunningOperationGetResponse> LongrunningOperationGetAsync(CancellationToken cancellationToken)
    {
        var p = new LongrunningOperationGetParameter();
        return await this.SendAsync<LongrunningOperationGetParameter, LongrunningOperationGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/longrunningoperation-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<LongrunningOperationGetResponse> LongrunningOperationGetAsync(LongrunningOperationGetParameter parameter)
    {
        return await this.SendAsync<LongrunningOperationGetParameter, LongrunningOperationGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/longrunningoperation-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<LongrunningOperationGetResponse> LongrunningOperationGetAsync(LongrunningOperationGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<LongrunningOperationGetParameter, LongrunningOperationGetResponse>(parameter, cancellationToken);
    }
}
