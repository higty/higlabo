using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Creates a variation of a given image.
    /// <seealso href="https://api.openai.com/v1/images/variations">https://api.openai.com/v1/images/variations</seealso>
    /// </summary>
    public partial class ImagesVariationsParameter : IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The image to use as the basis for the variation(s). Must be a valid PNG file, less than 4MB, and square.
        /// </summary>
        public string Image { get; set; } = "";
        /// <summary>
        /// The model to use for image generation. Only dall-e-2 is supported at this time.
        /// </summary>
        public string? Model { get; set; }
        /// <summary>
        /// The number of images to generate. Must be between 1 and 10. For dall-e-3, only n=1 is supported.
        /// </summary>
        public int? N { get; set; }
        /// <summary>
        /// The format in which the generated images are returned. Must be one of url or b64_json.
        /// </summary>
        public string? Response_Format { get; set; }
        /// <summary>
        /// The size of the generated images. Must be one of 256x256, 512x512, or 1024x1024.
        /// </summary>
        public string? Size { get; set; }
        /// <summary>
        /// A unique identifier representing your end-user, which can help OpenAI to monitor and detect abuse. Learn more.
        /// </summary>
        public string? User { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/images/variations";
        }
    }
    public partial class ImagesVariationsResponse : RestApiDataResponse<List<ImageObject>>
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ImagesVariationsResponse> ImagesVariationsAsync(string image)
        {
            var p = new ImagesVariationsParameter();
            p.Image = image;
            return await this.SendJsonAsync<ImagesVariationsParameter, ImagesVariationsResponse>(p, CancellationToken.None);
        }
        public async ValueTask<ImagesVariationsResponse> ImagesVariationsAsync(string image, CancellationToken cancellationToken)
        {
            var p = new ImagesVariationsParameter();
            p.Image = image;
            return await this.SendJsonAsync<ImagesVariationsParameter, ImagesVariationsResponse>(p, cancellationToken);
        }
        public async ValueTask<ImagesVariationsResponse> ImagesVariationsAsync(ImagesVariationsParameter parameter)
        {
            return await this.SendJsonAsync<ImagesVariationsParameter, ImagesVariationsResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<ImagesVariationsResponse> ImagesVariationsAsync(ImagesVariationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ImagesVariationsParameter, ImagesVariationsResponse>(parameter, cancellationToken);
        }
    }
}
