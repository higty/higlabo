using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Creates a variation of a given image.
    /// <seealso href="https://api.openai.com/v1/images/variations">https://api.openai.com/v1/images/variations</seealso>
    /// </summary>
    public partial class ImagesVariationsParameter : RestApiParameter, IRestApiParameter, IFileParameter, IFormDataParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        string IFileParameter.ParameterName
        {
            get
            {
                return "image";
            }
        }
        string IFileParameter.FileName { get; set; } = "";
        /// <summary>
        /// The image to use as the basis for the variation(s). Must be a valid PNG file, less than 4MB, and square.
        /// </summary>
        public Stream? Image { get; private set; }
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
        Stream IFileParameter.GetFileStream()
        {
            if (this.Image == null) throw new InvalidOperationException("Image property must be set.");
            return this.Image;
        }
        public void SetFile(string fileName, Stream stream)
        {
            ((IFileParameter)this).FileName = fileName;
            this.Image = stream;
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
        public async ValueTask<ImagesVariationsResponse> ImagesVariationsAsync(string fileName, Stream image)
        {
            var p = new ImagesVariationsParameter();
            p.SetFile(fileName, image);
            return await this.SendFormDataAsync<ImagesVariationsParameter, ImagesVariationsResponse>(p, CancellationToken.None);
        }
        public async ValueTask<ImagesVariationsResponse> ImagesVariationsAsync(string fileName, Stream image, CancellationToken cancellationToken)
        {
            var p = new ImagesVariationsParameter();
            p.SetFile(fileName, image);
            return await this.SendFormDataAsync<ImagesVariationsParameter, ImagesVariationsResponse>(p, cancellationToken);
        }
        public async ValueTask<ImagesVariationsResponse> ImagesVariationsAsync(ImagesVariationsParameter parameter)
        {
            return await this.SendFormDataAsync<ImagesVariationsParameter, ImagesVariationsResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<ImagesVariationsResponse> ImagesVariationsAsync(ImagesVariationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendFormDataAsync<ImagesVariationsParameter, ImagesVariationsResponse>(parameter, cancellationToken);
        }
    }
}
