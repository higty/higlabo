using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Delete a fine-tuned model. You must have the Owner role in your organization to delete a model.
    /// <seealso href="https://api.openai.com/v1/models/{model}">https://api.openai.com/v1/models/{model}</seealso>
    /// </summary>
    public partial class ModelDeleteParameter : IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        /// <summary>
        /// The model to delete
        /// </summary>
        public string Model { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/models/{Model}";
        }
    }
    public partial class ModelDeleteResponse : DeleteObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ModelDeleteResponse> ModelDeleteAsync(string model)
        {
            var p = new ModelDeleteParameter();
            p.Model = model;
            return await this.SendJsonAsync<ModelDeleteParameter, ModelDeleteResponse>(p, CancellationToken.None);
        }
        public async ValueTask<ModelDeleteResponse> ModelDeleteAsync(string model, CancellationToken cancellationToken)
        {
            var p = new ModelDeleteParameter();
            p.Model = model;
            return await this.SendJsonAsync<ModelDeleteParameter, ModelDeleteResponse>(p, cancellationToken);
        }
        public async ValueTask<ModelDeleteResponse> ModelDeleteAsync(ModelDeleteParameter parameter)
        {
            return await this.SendJsonAsync<ModelDeleteParameter, ModelDeleteResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<ModelDeleteResponse> ModelDeleteAsync(ModelDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ModelDeleteParameter, ModelDeleteResponse>(parameter, cancellationToken);
        }
    }
}
