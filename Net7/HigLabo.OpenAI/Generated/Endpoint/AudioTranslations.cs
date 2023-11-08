
namespace HigLabo.OpenAI
{
    /// <summary>
    /// https://api.openai.com/v1/audio/translations
    /// Translates audio into English.
    /// </summary>
    public partial class AudioTranslationsParameter : IRestApiParameter, IFormDataParameter, IFileParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "post";
        string IRestApiParameter.ApiPath { get; } = "https://api.openai.com/v1/audio/translations";
        string IFileParameter.ParameterName
        {
            get
            {
                return "file";
            }
        }
        string IFileParameter.FileName { get; set; } = "";
        /// <summary>
        /// The audio file object (not file name) translate, in one of these formats: flac, mp3, mp4, mpeg, mpga, m4a, ogg, wav, or webm.
        /// </summary>
        public Stream? File { get; private set; }
        /// <summary>
        /// ID of the model to use. Only whisper-1 is currently available.
        /// </summary>
        public string Model { get; set; } = "";
        /// <summary>
        /// An optional text to guide the model's style or continue a previous audio segment. The prompt should be in English.
        /// </summary>
        public string Prompt { get; set; } = "";
        /// <summary>
        /// The format of the transcript output, in one of these options: json, text, srt, verbose_json, or vtt.
        /// </summary>
        public string Response_format { get; set; } = "";
        /// <summary>
        /// The sampling temperature, between 0 and 1. Higher values like 0.8 will make the output more random, while lower values like 0.2 will make it more focused and deterministic. If set to 0, the model will use log probability to automatically increase the temperature until certain thresholds are hit.
        /// </summary>
        public double Temperature { get; set; }

        Dictionary<string, string> IFormDataParameter.CreateFormDataParameter()
        {
            var d = new Dictionary<string, string>();
            d["model"] = this.Model;
            d["prompt"] = this.Prompt;
            d["response_format"] = this.Response_format;
            d["temperature"] = this.Temperature.ToString();
            return d;
        }
        Stream IFileParameter.GetFileStream()
        {
            if (this.File == null) throw new InvalidOperationException("File property must be set.");
            return this.File;
        }
        public void SetFile(string fileName, Stream stream)
        {
            ((IFileParameter)this).FileName = fileName;
            this.File = stream;
        }
    }
    public partial class AudioTranslationsResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<AudioTranslationsResponse> AudioTranslationsAsync(string fileName, Stream file, string model, CancellationToken cancellationToken)
        {
            var p = new AudioTranslationsParameter();
            p.SetFile(fileName, file);
            p.Model = model;
            return await this.SendFormDataAsync<AudioTranslationsParameter, AudioTranslationsResponse>(p, cancellationToken);
        }
        public async ValueTask<AudioTranslationsResponse> AudioTranslationsAsync(AudioTranslationsParameter parameter)
        {
            return await this.SendFormDataAsync<AudioTranslationsParameter, AudioTranslationsResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<AudioTranslationsResponse> AudioTranslationsAsync(AudioTranslationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendFormDataAsync<AudioTranslationsParameter, AudioTranslationsResponse>(parameter, cancellationToken);
        }
    }
}
