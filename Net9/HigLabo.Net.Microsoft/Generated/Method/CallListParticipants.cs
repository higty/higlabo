using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/call-list-participants?view=graph-rest-1.0
/// </summary>
public partial class CallListParticipantsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Communications_Calls_Id_Participants: return $"/communications/calls/{Id}/participants";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Communications_Calls_Id_Participants,
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
public partial class CallListParticipantsResponse : RestApiResponse<Participant>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/call-list-participants?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-list-participants?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CallListParticipantsResponse> CallListParticipantsAsync()
    {
        var p = new CallListParticipantsParameter();
        return await this.SendAsync<CallListParticipantsParameter, CallListParticipantsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-list-participants?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CallListParticipantsResponse> CallListParticipantsAsync(CancellationToken cancellationToken)
    {
        var p = new CallListParticipantsParameter();
        return await this.SendAsync<CallListParticipantsParameter, CallListParticipantsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-list-participants?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CallListParticipantsResponse> CallListParticipantsAsync(CallListParticipantsParameter parameter)
    {
        return await this.SendAsync<CallListParticipantsParameter, CallListParticipantsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-list-participants?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CallListParticipantsResponse> CallListParticipantsAsync(CallListParticipantsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<CallListParticipantsParameter, CallListParticipantsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-list-participants?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<Participant> CallListParticipantsEnumerateAsync(CallListParticipantsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<CallListParticipantsParameter, CallListParticipantsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<Participant>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
