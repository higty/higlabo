using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Creates an edited or extended image given an original image and a prompt.
    /// <seealso href="https://api.openai.com/v1/images/edits">https://api.openai.com/v1/images/edits</seealso>
    /// </summary>
    public partial class ImagesEditsParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The image to edit. Must be a valid PNG file, less than 4MB, and square. If mask is not provided, image must have transparency, which will be used as the mask.
        /// </summary>
        public string Image { get; set; } = "";
        /// <summary>
        /// A text description of the desired image(s). The maximum length is 1000 characters.
        /// </summary>
        public string Prompt { get; set; } = "";
        /// <summary>
        /// An additional image whose fully transparent areas (e.g. where alpha is zero) indicate where image should be edited. Must be a valid PNG file, less than 4MB, and have the same dimensions as image.
        /// </summary>
        public string? Mask { get; set; }
        /// <summary>
        /// The model to use for image generation. Only dall-e-2 is supported at this time.
        /// </summary>
        public string? Model { get; set; }
        /// <summary>
        /// The number of images to generate. Must be between 1 and 10.
        /// </summary>
        public int? N { get; set; }
        /// <summary>
        /// The size of the generated images. Must be one of 256x256, 512x512, or 1024x1024.
        /// </summary>
        public string? Size { get; set; }
        /// <summary>
        /// The format in which the generated images are returned. Must be one of url or b64_json.
        /// </summary>
        public string? Response_Format { get; set; }
        /// <summary>
        /// A unique identifier representing your end-user, which can help OpenAI to monitor and detect abuse. Learn more.
        /// </summary>
        public string? User { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/images/edits";
        }
        public override object GetRequestBody()
        {
            return new {
            	image = this.Image,
            	prompt = this.Prompt,
            	mask = this.Mask,
            	model = this.Model,
            	n = this.N,
            	size = this.Size,
            	response_format = this.Response_Format,
            	user = this.User,
            };
        }
    }
    public partial class ImagesEditsResponse : RestApiDataResponse<List<ImageObject>>
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ImagesEditsResponse> ImagesEditsAsync(string image, string prompt)
        {
            var p = new ImagesEditsParameter();
            p.Image = image;
            p.Prompt = prompt;
            return await this.SendJsonAsync<ImagesEditsParameter, ImagesEditsResponse>(p, CancellationToken.None);
        }
        public async ValueTask<ImagesEditsResponse> ImagesEditsAsync(string image, string prompt, CancellationToken cancellationToken)
        {
            var p = new ImagesEditsParameter();
            p.Image = image;
            p.Prompt = prompt;
            return await this.SendJsonAsync<ImagesEditsParameter, ImagesEditsResponse>(p, cancellationToken);
        }
        public async ValueTask<ImagesEditsResponse> ImagesEditsAsync(ImagesEditsParameter parameter)
        {
            return await this.SendJsonAsync<ImagesEditsParameter, ImagesEditsResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<ImagesEditsResponse> ImagesEditsAsync(ImagesEditsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ImagesEditsParameter, ImagesEditsResponse>(parameter, cancellationToken);
        }
    }
}
