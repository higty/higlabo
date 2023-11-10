using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Lists the currently available models, and provides basic information about each one such as the owner and availability.
    /// <seealso href="https://api.openai.com/v1/models">https://api.openai.com/v1/models</seealso>
    /// </summary>
    public partial class ModelsParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";

        string IRestApiParameter.GetApiPath()
        {
            return $"/models";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class ModelsResponse : RestApiDataResponse<List<ModelObject>>
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ModelsResponse> ModelsAsync()
        {
            var p = new ModelsParameter();
            return await this.SendJsonAsync<ModelsParameter, ModelsResponse>(p, CancellationToken.None);
        }
        public async ValueTask<ModelsResponse> ModelsAsync(CancellationToken cancellationToken)
        {
            var p = new ModelsParameter();
            return await this.SendJsonAsync<ModelsParameter, ModelsResponse>(p, cancellationToken);
        }
        public async ValueTask<ModelsResponse> ModelsAsync(ModelsParameter parameter)
        {
            return await this.SendJsonAsync<ModelsParameter, ModelsResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<ModelsResponse> ModelsAsync(ModelsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ModelsParameter, ModelsResponse>(parameter, cancellationToken);
        }
    }
}
