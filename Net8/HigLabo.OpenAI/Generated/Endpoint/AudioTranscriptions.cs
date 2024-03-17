using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Transcribes audio into the input language.
    /// <seealso href="https://api.openai.com/v1/audio/transcriptions">https://api.openai.com/v1/audio/transcriptions</seealso>
    /// </summary>
    public partial class AudioTranscriptionsParameter : RestApiParameter, IRestApiParameter, IFileParameter, IFormDataParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The audio file object (not file name) to transcribe, in one of these formats: flac, mp3, mp4, mpeg, mpga, m4a, ogg, wav, or webm.
        /// </summary>
        public FileParameter File { get; private set; } = new FileParameter("file");
        /// <summary>
        /// ID of the model to use. Only whisper-1 (which is powered by our open source Whisper V2 model) is currently available.
        /// </summary>
        public string Model { get; set; } = "";
        /// <summary>
        /// The language of the input audio. Supplying the input language in ISO-639-1 format will improve accuracy and latency.
        /// </summary>
        public string? Language { get; set; }
        /// <summary>
        /// An optional text to guide the model's style or continue a previous audio segment. The prompt should match the audio language.
        /// </summary>
        public string? Prompt { get; set; }
        /// <summary>
        /// The format of the transcript output, in one of these options: json, text, srt, verbose_json, or vtt.
        /// </summary>
        public string? Response_Format { get; set; }
        /// <summary>
        /// The sampling temperature, between 0 and 1. Higher values like 0.8 will make the output more random, while lower values like 0.2 will make it more focused and deterministic. If set to 0, the model will use log probability to automatically increase the temperature until certain thresholds are hit.
        /// </summary>
        public double? Temperature { get; set; }
        /// <summary>
        /// The timestamp granularities to populate for this transcription. response_format must be set verbose_json to use timestamp granularities. Either or both of these options are supported: word, or segment. Note: There is no additional latency for segment timestamps, but generating word timestamps incurs additional latency.
        /// </summary>
        public double[]? Timestamp_Granularities { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/audio/transcriptions";
        }
        public override object GetRequestBody()
        {
            return new {
            	file = this.File,
            	model = this.Model,
            	language = this.Language,
            	prompt = this.Prompt,
            	response_format = this.Response_Format,
            	temperature = this.Temperature,
            	timestamp_granularities = this.Timestamp_Granularities,
            };
        }
        IEnumerable<FileParameter> IFileParameter.GetFileParameters()
        {
            yield return this.File;
        }
        Dictionary<string, string> IFormDataParameter.CreateFormDataParameter()
        {
            var d = new Dictionary<string, string>();
            d["model"] = this.Model;
            if (this.Language != null) d["language"] = this.Language;
            if (this.Prompt != null) d["prompt"] = this.Prompt;
            if (this.Response_Format != null) d["response_format"] = this.Response_Format;
            if (this.Temperature != null) d["temperature"] = this.Temperature.Value.ToString();
            if (this.Timestamp_Granularities != null) d["timestamp_granularities"] = $"[{string.Format(",", this.Timestamp_Granularities)}]";
            return d;
        }
    }
    public partial class AudioTranscriptionsResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<AudioTranscriptionsResponse> AudioTranscriptionsAsync(string fileFileName, Stream fileStream, string model)
        {
            var p = new AudioTranscriptionsParameter();
            p.File.SetFile(fileFileName, fileStream);
            p.Model = model;
            return await this.SendFormDataAsync<AudioTranscriptionsParameter, AudioTranscriptionsResponse>(p, CancellationToken.None);
        }
        public async ValueTask<AudioTranscriptionsResponse> AudioTranscriptionsAsync(string fileFileName, Stream fileStream, string model, CancellationToken cancellationToken)
        {
            var p = new AudioTranscriptionsParameter();
            p.File.SetFile(fileFileName, fileStream);
            p.Model = model;
            return await this.SendFormDataAsync<AudioTranscriptionsParameter, AudioTranscriptionsResponse>(p, cancellationToken);
        }
        public async ValueTask<AudioTranscriptionsResponse> AudioTranscriptionsAsync(AudioTranscriptionsParameter parameter)
        {
            return await this.SendFormDataAsync<AudioTranscriptionsParameter, AudioTranscriptionsResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<AudioTranscriptionsResponse> AudioTranscriptionsAsync(AudioTranscriptionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendFormDataAsync<AudioTranscriptionsParameter, AudioTranscriptionsResponse>(parameter, cancellationToken);
        }
    }
}
