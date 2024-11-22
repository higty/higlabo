using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

/// <summary>
/// Returns a list of runs belonging to a thread.
/// <seealso href="https://api.openai.com/v1/threads/{thread_id}/runs">https://api.openai.com/v1/threads/{thread_id}/runs</seealso>
/// </summary>
public partial class RunsParameter : RestApiParameter, IRestApiParameter, IAssistantApiParameter, IQueryParameterProperty
{
    string IRestApiParameter.HttpMethod { get; } = "GET";
    /// <summary>
    /// The ID of the thread the run belongs to.
    /// </summary>
    public string Thread_Id { get; set; } = "";
    IQueryParameter IQueryParameterProperty.QueryParameter
    {
        get
        {
            return this.QueryParameter;
        }
    }
    public QueryParameter QueryParameter { get; set; } = new QueryParameter();

    string IRestApiParameter.GetApiPath()
    {
        return $"/threads/{Thread_Id}/runs";
    }
    public override object GetRequestBody()
    {
        return EmptyParameter;
    }
}
public partial class RunsResponse : RestApiDataResponse<List<RunObject>>
{
    public string First_Id { get; set; } = "";
    public string Last_Id { get; set; } = "";
    public bool Has_More { get; set; }
}
public partial class OpenAIClient
{
    public async ValueTask<RunsResponse> RunsAsync(string thread_Id)
    {
        var p = new RunsParameter();
        p.Thread_Id = thread_Id;
        return await this.SendJsonAsync<RunsParameter, RunsResponse>(p, CancellationToken.None);
    }
    public async ValueTask<RunsResponse> RunsAsync(string thread_Id, CancellationToken cancellationToken)
    {
        var p = new RunsParameter();
        p.Thread_Id = thread_Id;
        return await this.SendJsonAsync<RunsParameter, RunsResponse>(p, cancellationToken);
    }
    public async ValueTask<RunsResponse> RunsAsync(RunsParameter parameter)
    {
        return await this.SendJsonAsync<RunsParameter, RunsResponse>(parameter, CancellationToken.None);
    }
    public async ValueTask<RunsResponse> RunsAsync(RunsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<RunsParameter, RunsResponse>(parameter, cancellationToken);
    }
}
