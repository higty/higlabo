using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Creates an image given a prompt.
    /// <seealso href="https://api.openai.com/v1/images/generations">https://api.openai.com/v1/images/generations</seealso>
    /// </summary>
    public partial class ImagesGenerationsParameter : IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// A text description of the desired image(s). The maximum length is 1000 characters for dall-e-2 and 4000 characters for dall-e-3.
        /// </summary>
        public string Prompt { get; set; } = "";
        /// <summary>
        /// The model to use for image generation.
        /// </summary>
        public string? Model { get; set; }
        /// <summary>
        /// The number of images to generate. Must be between 1 and 10. For dall-e-3, only n=1 is supported.
        /// </summary>
        public int? N { get; set; }
        /// <summary>
        /// The quality of the image that will be generated. hd creates images with finer details and greater consistency across the image. This param is only supported for dall-e-3.
        /// </summary>
        public string? Quality { get; set; }
        /// <summary>
        /// The format in which the generated images are returned. Must be one of url or b64_json.
        /// </summary>
        public string? Response_Format { get; set; }
        /// <summary>
        /// The size of the generated images. Must be one of 256x256, 512x512, or 1024x1024 for dall-e-2. Must be one of 1024x1024, 1792x1024, or 1024x1792 for dall-e-3 models.
        /// </summary>
        public string? Size { get; set; }
        /// <summary>
        /// The style of the generated images. Must be one of vivid or natural. Vivid causes the model to lean towards generating hyper-real and dramatic images. Natural causes the model to produce more natural, less hyper-real looking images. This param is only supported for dall-e-3.
        /// </summary>
        public string? Style { get; set; }
        /// <summary>
        /// A unique identifier representing your end-user, which can help OpenAI to monitor and detect abuse. Learn more.
        /// </summary>
        public string? User { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/images/generations";
        }
    }
    public partial class ImagesGenerationsResponse : RestApiDataResponse<List<ImageObject>>
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ImagesGenerationsResponse> ImagesGenerationsAsync(string prompt, CancellationToken cancellationToken)
        {
            var p = new ImagesGenerationsParameter();
            p.Prompt = prompt;
            return await this.SendJsonAsync<ImagesGenerationsParameter, ImagesGenerationsResponse>(p, cancellationToken);
        }
        public async ValueTask<ImagesGenerationsResponse> ImagesGenerationsAsync(ImagesGenerationsParameter parameter)
        {
            return await this.SendJsonAsync<ImagesGenerationsParameter, ImagesGenerationsResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<ImagesGenerationsResponse> ImagesGenerationsAsync(ImagesGenerationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ImagesGenerationsParameter, ImagesGenerationsResponse>(parameter, cancellationToken);
        }
    }
}
