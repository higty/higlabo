using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Kicks off a new run for a given evaluation, specifying the data source, and what model configuration to use to test. The datasource will be validated against the schema specified in the config of the evaluation.
    /// <seealso href="https://api.openai.com/v1/evals/{eval_id}/runs">https://api.openai.com/v1/evals/{eval_id}/runs</seealso>
    /// </summary>
    public partial class EvalRunCreateParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the evaluation to create a run for.
        /// </summary>
        public string Eval_Id { get; set; } = "";
        /// <summary>
        /// Details about the run's data source.
        /// </summary>
        public object? Data_Source { get; set; }
        /// <summary>
        /// Set of 16 key-value pairs that can be attached to an object. This can be useful for storing additional information about the object in a structured format, and querying for objects via API or the dashboard.
        /// Keys are strings with a maximum length of 64 characters. Values are strings with a maximum length of 512 characters.
        /// </summary>
        public object? Metadata { get; set; }
        /// <summary>
        /// The name of the run.
        /// </summary>
        public string? Name { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/evals/{Eval_Id}/runs";
        }
        public override object GetRequestBody()
        {
            return new {
            	data_source = this.Data_Source,
            	metadata = this.Metadata,
            	name = this.Name,
            };
        }
    }
    public partial class EvalRunCreateResponse : EvalRunObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<EvalRunCreateResponse> EvalRunCreateAsync(string eval_Id, object data_Source)
        {
            var p = new EvalRunCreateParameter();
            p.Eval_Id = eval_Id;
            p.Data_Source = data_Source;
            return await this.SendJsonAsync<EvalRunCreateParameter, EvalRunCreateResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<EvalRunCreateResponse> EvalRunCreateAsync(string eval_Id, object data_Source, CancellationToken cancellationToken)
        {
            var p = new EvalRunCreateParameter();
            p.Eval_Id = eval_Id;
            p.Data_Source = data_Source;
            return await this.SendJsonAsync<EvalRunCreateParameter, EvalRunCreateResponse>(p, cancellationToken);
        }
        public async ValueTask<EvalRunCreateResponse> EvalRunCreateAsync(EvalRunCreateParameter parameter)
        {
            return await this.SendJsonAsync<EvalRunCreateParameter, EvalRunCreateResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<EvalRunCreateResponse> EvalRunCreateAsync(EvalRunCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<EvalRunCreateParameter, EvalRunCreateResponse>(parameter, cancellationToken);
        }
    }
}
