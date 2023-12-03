using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Generates audio from the input text.
    /// <seealso href="https://api.openai.com/v1/audio/speech">https://api.openai.com/v1/audio/speech</seealso>
    /// </summary>
    public partial class AudioSpeechParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// One of the available TTS models: tts-1 or tts-1-hd
        /// </summary>
        public string Model { get; set; } = "";
        /// <summary>
        /// The text to generate audio for. The maximum length is 4096 characters.
        /// </summary>
        public string Input { get; set; } = "";
        /// <summary>
        /// The voice to use when generating the audio. Supported voices are alloy, echo, fable, onyx, nova, and shimmer.
        /// </summary>
        public string Voice { get; set; } = "";
        /// <summary>
        /// The format to audio in. Supported formats are mp3, opus, aac, and flac.
        /// </summary>
        public string? Response_Format { get; set; }
        /// <summary>
        /// The speed of the generated audio. Select a value from 0.25 to 4.0. 1.0 is the default.
        /// </summary>
        public double? Speed { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/audio/speech";
        }
        public override object GetRequestBody()
        {
            return new {
            	model = this.Model,
            	input = this.Input,
            	voice = this.Voice,
            	response_format = this.Response_Format,
            	speed = this.Speed,
            };
        }
    }
    public partial class AudioSpeechResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<AudioSpeechResponse> AudioSpeechAsync(string model, string input, string voice)
        {
            var p = new AudioSpeechParameter();
            p.Model = model;
            p.Input = input;
            p.Voice = voice;
            return await this.SendJsonAsync<AudioSpeechParameter, AudioSpeechResponse>(p, CancellationToken.None);
        }
        public async ValueTask<AudioSpeechResponse> AudioSpeechAsync(string model, string input, string voice, CancellationToken cancellationToken)
        {
            var p = new AudioSpeechParameter();
            p.Model = model;
            p.Input = input;
            p.Voice = voice;
            return await this.SendJsonAsync<AudioSpeechParameter, AudioSpeechResponse>(p, cancellationToken);
        }
        public async ValueTask<AudioSpeechResponse> AudioSpeechAsync(AudioSpeechParameter parameter)
        {
            return await this.SendJsonAsync<AudioSpeechParameter, AudioSpeechResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<AudioSpeechResponse> AudioSpeechAsync(AudioSpeechParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<AudioSpeechParameter, AudioSpeechResponse>(parameter, cancellationToken);
        }
    }
}
