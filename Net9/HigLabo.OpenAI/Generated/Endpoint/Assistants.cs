using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Returns a list of assistants.
    /// <seealso href="https://api.openai.com/v1/assistants">https://api.openai.com/v1/assistants</seealso>
    /// </summary>
    public partial class AssistantsParameter : RestApiParameter, IRestApiParameter, IAssistantApiParameter, IQueryParameterProperty
    {
        internal static readonly AssistantsParameter Empty = new AssistantsParameter();

        string IRestApiParameter.HttpMethod { get; } = "GET";
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
            return $"/assistants";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class AssistantsResponse : RestApiDataResponse<List<AssistantObject>>
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<AssistantsResponse> AssistantsAsync()
        {
            return await this.SendJsonAsync<AssistantsParameter, AssistantsResponse>(AssistantsParameter.Empty, CancellationToken.None);
        }
        public async ValueTask<AssistantsResponse> AssistantsAsync(CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<AssistantsParameter, AssistantsResponse>(AssistantsParameter.Empty, cancellationToken);
        }
        public async ValueTask<AssistantsResponse> AssistantsAsync(AssistantsParameter parameter)
        {
            return await this.SendJsonAsync<AssistantsParameter, AssistantsResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<AssistantsResponse> AssistantsAsync(AssistantsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<AssistantsParameter, AssistantsResponse>(parameter, cancellationToken);
        }
    }
}
