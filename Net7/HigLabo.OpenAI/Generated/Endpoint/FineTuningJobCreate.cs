using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Creates a job that fine-tunes a specified model from a given dataset.Response includes details of the enqueued job including job status and the name of the fine-tuned models once complete.Learn more about fine-tuning
    /// <seealso href="https://api.openai.com/v1/fine_tuning/jobs">https://api.openai.com/v1/fine_tuning/jobs</seealso>
    /// </summary>
    public partial class FineTuningJobCreateParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The name of the model to fine-tune. You can select one of the
        /// supported models.
        /// </summary>
        public string Model { get; set; } = "";
        /// <summary>
        /// The ID of an uploaded file that contains training data.See upload file for how to upload a file.Your dataset must be formatted as a JSONL file. Additionally, you must upload your file with the purpose fine-tune.See the fine-tuning guide for more details.
        /// </summary>
        public string Training_File { get; set; } = "";
        /// <summary>
        /// The hyperparameters used for the fine-tuning job.
        /// </summary>
        public object? Hyperparameters { get; set; }
        /// <summary>
        /// A string of up to 18 characters that will be added to your fine-tuned model name.For example, a suffix of "custom-model-name" would produce a model name like ft:gpt-3.5-turbo:openai:custom-model-name:7p4lURel.
        /// </summary>
        public string? Suffix { get; set; }
        /// <summary>
        /// The ID of an uploaded file that contains validation data.If you provide this file, the data is used to generate validation
        /// metrics periodically during fine-tuning. These metrics can be viewed in
        /// the fine-tuning results file.
        /// The same data should not be present in both train and validation files.Your dataset must be formatted as a JSONL file. You must upload your file with the purpose fine-tune.See the fine-tuning guide for more details.
        /// </summary>
        public string? Validation_File { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/fine_tuning/jobs";
        }
        public override object GetRequestBody()
        {
            return new {
            	model = this.Model,
            	training_file = this.Training_File,
            	hyperparameters = this.Hyperparameters,
            	suffix = this.Suffix,
            	validation_file = this.Validation_File,
            };
        }
    }
    public partial class FineTuningJobCreateResponse : FineTuningJobResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<FineTuningJobCreateResponse> FineTuningJobCreateAsync(string model, string training_File)
        {
            var p = new FineTuningJobCreateParameter();
            p.Model = model;
            p.Training_File = training_File;
            return await this.SendJsonAsync<FineTuningJobCreateParameter, FineTuningJobCreateResponse>(p, CancellationToken.None);
        }
        public async ValueTask<FineTuningJobCreateResponse> FineTuningJobCreateAsync(string model, string training_File, CancellationToken cancellationToken)
        {
            var p = new FineTuningJobCreateParameter();
            p.Model = model;
            p.Training_File = training_File;
            return await this.SendJsonAsync<FineTuningJobCreateParameter, FineTuningJobCreateResponse>(p, cancellationToken);
        }
        public async ValueTask<FineTuningJobCreateResponse> FineTuningJobCreateAsync(FineTuningJobCreateParameter parameter)
        {
            return await this.SendJsonAsync<FineTuningJobCreateParameter, FineTuningJobCreateResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<FineTuningJobCreateResponse> FineTuningJobCreateAsync(FineTuningJobCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<FineTuningJobCreateParameter, FineTuningJobCreateResponse>(parameter, cancellationToken);
        }
    }
}
