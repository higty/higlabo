using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Creates a variation of a given image.
    /// <seealso href="https://api.openai.com/v1/images/variations">https://api.openai.com/v1/images/variations</seealso>
    /// </summary>
    public partial class ImagesVariationsParameter : RestApiParameter, IRestApiParameter, IFileParameter, IFormDataParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The image to use as the basis for the variation(s). Must be a valid PNG file, less than 4MB, and square.
        /// </summary>
        public FileParameter Image { get; private set; } = new FileParameter("image");
        /// <summary>
        /// The model to use for image generation. Only dall-e-2 is supported at this time.
        /// </summary>
        public string? Model { get; set; }
        /// <summary>
        /// The number of images to generate. Must be between 1 and 10. For dall-e-3, only n=1 is supported.
        /// </summary>
        public int? N { get; set; }
        /// <summary>
        /// The format in which the generated images are returned. Must be one of url or b64_json. URLs are only valid for 60 minutes after the image has been generated.
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
        public override object GetRequestBody()
        {
            return new {
            	image = this.Image,
            	model = this.Model,
            	n = this.N,
            	response_format = this.Response_Format,
            	size = this.Size,
            	user = this.User,
            };
        }
        IEnumerable<FileParameter> IFileParameter.GetFileParameters()
        {
            yield return this.Image;
        }
        Dictionary<string, string> IFormDataParameter.CreateFormDataParameter()
        {
            var d = new Dictionary<string, string>();
            if (this.Model != null) d["model"] = this.Model;
            if (this.N != null) d["n"] = this.N.Value.ToString();
            if (this.Response_Format != null) d["response_format"] = this.Response_Format;
            if (this.Size != null) d["size"] = this.Size;
            if (this.User != null) d["user"] = this.User;
            return d;
        }
    }
    public partial class ImagesVariationsResponse : RestApiDataResponse<List<ImageObject>>
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ImagesVariationsResponse> ImagesVariationsAsync(string imageFileName, Stream imageStream)
        {
            var p = new ImagesVariationsParameter();
            p.Image.SetFile(imageFileName, imageStream);
            return await this.SendFormDataAsync<ImagesVariationsParameter, ImagesVariationsResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ImagesVariationsResponse> ImagesVariationsAsync(string imageFileName, Stream imageStream, CancellationToken cancellationToken)
        {
            var p = new ImagesVariationsParameter();
            p.Image.SetFile(imageFileName, imageStream);
            return await this.SendFormDataAsync<ImagesVariationsParameter, ImagesVariationsResponse>(p, cancellationToken);
        }
        public async ValueTask<ImagesVariationsResponse> ImagesVariationsAsync(ImagesVariationsParameter parameter)
        {
            return await this.SendFormDataAsync<ImagesVariationsParameter, ImagesVariationsResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ImagesVariationsResponse> ImagesVariationsAsync(ImagesVariationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendFormDataAsync<ImagesVariationsParameter, ImagesVariationsResponse>(parameter, cancellationToken);
        }
    }
}
