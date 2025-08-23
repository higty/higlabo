using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// List evaluations for a project.
    /// <seealso href="https://api.openai.com/v1/evals">https://api.openai.com/v1/evals</seealso>
    /// </summary>
    public partial class EvalsParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        internal static readonly EvalsParameter Empty = new EvalsParameter();

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
            return $"/evals";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class EvalsResponse : RestApiDataResponse<List<EvalObject>>
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<EvalsResponse> EvalsAsync()
        {
            return await this.SendJsonAsync<EvalsParameter, EvalsResponse>(EvalsParameter.Empty, System.Threading.CancellationToken.None);
        }
        public async ValueTask<EvalsResponse> EvalsAsync(CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<EvalsParameter, EvalsResponse>(EvalsParameter.Empty, cancellationToken);
        }
        public async ValueTask<EvalsResponse> EvalsAsync(EvalsParameter parameter)
        {
            return await this.SendJsonAsync<EvalsParameter, EvalsResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<EvalsResponse> EvalsAsync(EvalsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<EvalsParameter, EvalsResponse>(parameter, cancellationToken);
        }
    }
}
