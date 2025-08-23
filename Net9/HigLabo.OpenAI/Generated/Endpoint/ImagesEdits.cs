using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Creates an edited or extended image given one or more source images and a prompt. This endpoint only supports gpt-image-1 and dall-e-2.
    /// <seealso href="https://api.openai.com/v1/images/edits">https://api.openai.com/v1/images/edits</seealso>
    /// </summary>
    public partial class ImagesEditsParameter : RestApiParameter, IRestApiParameter, IFileParameter, IFormDataParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The image(s) to edit. Must be a supported image file or an array of images.
        /// For gpt-image-1, each image should be a png, webp, or jpg file less than 50MB. You can provide up to 16 images.
        /// For dall-e-2, you can only provide one image, and it should be a square png file less than 4MB.
        /// </summary>
        public string Image { get; set; } = "";
        /// <summary>
        /// A text description of the desired image(s). The maximum length is 1000 characters for dall-e-2, and 32000 characters for gpt-image-1.
        /// </summary>
        public string Prompt { get; set; } = "";
        /// <summary>
        /// Allows to set transparency for the background of the generated image(s). This parameter is only supported for gpt-image-1. Must be one of transparent, opaque or auto (default value). When auto is used, the model will automatically determine the best background for the image.
        /// If transparent, the output format needs to support transparency, so it should be set to either png (default value) or webp.
        /// </summary>
        public string? Background { get; set; }
        /// <summary>
        /// Control how much effort the model will exert to match the style and features, especially facial features, of input images. This parameter is only supported for gpt-image-1. Supports high and low. Defaults to low.
        /// </summary>
        public string? Input_Fidelity { get; set; }
        /// <summary>
        /// An additional image whose fully transparent areas (e.g. where alpha is zero) indicate where image should be edited. If there are multiple images provided, the mask will be applied on the first image. Must be a valid PNG file, less than 4MB, and have the same dimensions as image.
        /// </summary>
        public FileParameter Mask { get; private set; } = new FileParameter("mask");
        /// <summary>
        /// The model to use for image generation. Only dall-e-2 and gpt-image-1 are supported. Defaults to dall-e-2 unless a parameter specific to gpt-image-1 is used.
        /// </summary>
        public string? Model { get; set; }
        /// <summary>
        /// The number of images to generate. Must be between 1 and 10.
        /// </summary>
        public int? N { get; set; }
        /// <summary>
        /// The compression level (0-100%) for the generated images. This parameter is only supported for gpt-image-1 with the webp or jpeg output formats, and defaults to 100.
        /// </summary>
        public int? Output_Compression { get; set; }
        /// <summary>
        /// The format in which the generated images are returned. This parameter is only supported for gpt-image-1. Must be one of png, jpeg, or webp. The default value is png.
        /// </summary>
        public string? Output_Format { get; set; }
        /// <summary>
        /// The number of partial images to generate. This parameter is used for streaming responses that return partial images. Value must be between 0 and 3. When set to 0, the response will be a single image sent in one streaming event.
        /// Note that the final image may be sent before the full number of partial images are generated if the full image is generated more quickly.
        /// </summary>
        public int? Partial_Images { get; set; }
        /// <summary>
        /// The quality of the image that will be generated. high, medium and low are only supported for gpt-image-1. dall-e-2 only supports standard quality. Defaults to auto.
        /// </summary>
        public string? Quality { get; set; }
        /// <summary>
        /// The format in which the generated images are returned. Must be one of url or b64_json. URLs are only valid for 60 minutes after the image has been generated. This parameter is only supported for dall-e-2, as gpt-image-1 will always return base64-encoded images.
        /// </summary>
        public string? Response_Format { get; set; }
        /// <summary>
        /// The size of the generated images. Must be one of 1024x1024, 1536x1024 (landscape), 1024x1536 (portrait), or auto (default value) for gpt-image-1, and one of 256x256, 512x512, or 1024x1024 for dall-e-2.
        /// </summary>
        public string? Size { get; set; }
        /// <summary>
        /// Edit the image in streaming mode. Defaults to false. See the Image generation guide for more information.
        /// </summary>
        public bool? Stream { get; set; }
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
            	background = this.Background,
            	input_fidelity = this.Input_Fidelity,
            	mask = this.Mask,
            	model = this.Model,
            	n = this.N,
            	output_compression = this.Output_Compression,
            	output_format = this.Output_Format,
            	partial_images = this.Partial_Images,
            	quality = this.Quality,
            	response_format = this.Response_Format,
            	size = this.Size,
            	stream = this.Stream,
            	user = this.User,
            };
        }
        IEnumerable<FileParameter> IFileParameter.GetFileParameters()
        {
            yield return this.Mask;
        }
        Dictionary<string, string> IFormDataParameter.CreateFormDataParameter()
        {
            var d = new Dictionary<string, string>();
            d["image"] = this.Image;
            d["prompt"] = this.Prompt;
            if (this.Background != null) d["background"] = this.Background;
            if (this.Input_Fidelity != null) d["input_fidelity"] = this.Input_Fidelity;
            if (this.Model != null) d["model"] = this.Model;
            if (this.N != null) d["n"] = this.N.Value.ToString();
            if (this.Output_Compression != null) d["output_compression"] = this.Output_Compression.Value.ToString();
            if (this.Output_Format != null) d["output_format"] = this.Output_Format;
            if (this.Partial_Images != null) d["partial_images"] = this.Partial_Images.Value.ToString();
            if (this.Quality != null) d["quality"] = this.Quality;
            if (this.Response_Format != null) d["response_format"] = this.Response_Format;
            if (this.Size != null) d["size"] = this.Size;
            if (this.Stream != null) d["stream"] = this.Stream.Value.ToString();
            if (this.User != null) d["user"] = this.User;
            return d;
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
            return await this.SendFormDataAsync<ImagesEditsParameter, ImagesEditsResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ImagesEditsResponse> ImagesEditsAsync(string image, string prompt, CancellationToken cancellationToken)
        {
            var p = new ImagesEditsParameter();
            p.Image = image;
            p.Prompt = prompt;
            return await this.SendFormDataAsync<ImagesEditsParameter, ImagesEditsResponse>(p, cancellationToken);
        }
        public async ValueTask<ImagesEditsResponse> ImagesEditsAsync(ImagesEditsParameter parameter)
        {
            return await this.SendFormDataAsync<ImagesEditsParameter, ImagesEditsResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ImagesEditsResponse> ImagesEditsAsync(ImagesEditsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendFormDataAsync<ImagesEditsParameter, ImagesEditsResponse>(parameter, cancellationToken);
        }
    }
}
