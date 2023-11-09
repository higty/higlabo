using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Retrieves a model instance, providing basic information about the model such as the owner and permissioning.
    /// <seealso href="https://api.openai.com/v1/models/{model}">https://api.openai.com/v1/models/{model}</seealso>
    /// </summary>
    public partial class ModelRetrieveParameter : IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the model to use for this request
        /// </summary>
        public string Model { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/models/{Model}";
        }
    }
    public partial class ModelRetrieveResponse : ModelObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ModelRetrieveResponse> ModelRetrieveAsync(string model)
        {
            var p = new ModelRetrieveParameter();
            p.Model = model;
            return await this.SendJsonAsync<ModelRetrieveParameter, ModelRetrieveResponse>(p, CancellationToken.None);
        }
        public async ValueTask<ModelRetrieveResponse> ModelRetrieveAsync(string model, CancellationToken cancellationToken)
        {
            var p = new ModelRetrieveParameter();
            p.Model = model;
            return await this.SendJsonAsync<ModelRetrieveParameter, ModelRetrieveResponse>(p, cancellationToken);
        }
        public async ValueTask<ModelRetrieveResponse> ModelRetrieveAsync(ModelRetrieveParameter parameter)
        {
            return await this.SendJsonAsync<ModelRetrieveParameter, ModelRetrieveResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<ModelRetrieveResponse> ModelRetrieveAsync(ModelRetrieveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ModelRetrieveParameter, ModelRetrieveResponse>(parameter, cancellationToken);
        }
    }
}
