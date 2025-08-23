using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Create the structure of an evaluation that can be used to test a model's performance. An evaluation is a set of testing criteria and the config for a data source, which dictates the schema of the data used in the evaluation. After creating an evaluation, you can run it on different models and model parameters. We support several types of graders and datasources. For more information, see the Evals guide.
    /// <seealso href="https://api.openai.com/v1/evals">https://api.openai.com/v1/evals</seealso>
    /// </summary>
    public partial class EvalCreateParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The configuration for the data source used for the evaluation runs. Dictates the schema of the data used in the evaluation.
        /// </summary>
        public DataSourceConfig Data_Source_Config { get; set; } = new();
        /// <summary>
        /// A list of graders for all eval runs in this group. Graders can reference variables in the data source using double curly braces notation, like {{item.variable_name}}. To reference the model's output, use the sample namespace (ie, {{sample.output_text}}).
        /// </summary>
        public List<string>? Testing_Criteria { get; set; }
        /// <summary>
        /// Set of 16 key-value pairs that can be attached to an object. This can be useful for storing additional information about the object in a structured format, and querying for objects via API or the dashboard.
        /// Keys are strings with a maximum length of 64 characters. Values are strings with a maximum length of 512 characters.
        /// </summary>
        public object? Metadata { get; set; }
        /// <summary>
        /// The name of the evaluation.
        /// </summary>
        public string? Name { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/evals";
        }
        public override object GetRequestBody()
        {
            return new {
            	data_source_config = this.Data_Source_Config,
            	testing_criteria = this.Testing_Criteria,
            	metadata = this.Metadata,
            	name = this.Name,
            };
        }
    }
    public partial class EvalCreateResponse : EvalObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<EvalCreateResponse> EvalCreateAsync(DataSourceConfig data_Source_Config, List<string>? testing_Criteria)
        {
            var p = new EvalCreateParameter();
            p.Data_Source_Config = data_Source_Config;
            p.Testing_Criteria = testing_Criteria;
            return await this.SendJsonAsync<EvalCreateParameter, EvalCreateResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<EvalCreateResponse> EvalCreateAsync(DataSourceConfig data_Source_Config, List<string>? testing_Criteria, CancellationToken cancellationToken)
        {
            var p = new EvalCreateParameter();
            p.Data_Source_Config = data_Source_Config;
            p.Testing_Criteria = testing_Criteria;
            return await this.SendJsonAsync<EvalCreateParameter, EvalCreateResponse>(p, cancellationToken);
        }
        public async ValueTask<EvalCreateResponse> EvalCreateAsync(EvalCreateParameter parameter)
        {
            return await this.SendJsonAsync<EvalCreateParameter, EvalCreateResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<EvalCreateResponse> EvalCreateAsync(EvalCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<EvalCreateParameter, EvalCreateResponse>(parameter, cancellationToken);
        }
    }
}
