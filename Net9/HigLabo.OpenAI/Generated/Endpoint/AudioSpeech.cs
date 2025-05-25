using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

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
        /// The text to generate audio for. The maximum length is 4096 characters.
        /// </summary>
        public string Input { get; set; } = "";
        /// <summary>
        /// One of the available TTS models: tts-1, tts-1-hd or gpt-4o-mini-tts.
        /// </summary>
        public string Model { get; set; } = "";
        /// <summary>
        /// The voice to use when generating the audio. Supported voices are alloy, ash, ballad, coral, echo, fable, onyx, nova, sage, shimmer, and verse. Previews of the voices are available in the Text to speech guide.
        /// </summary>
        public string Voice { get; set; } = "";
        /// <summary>
        /// Control the voice of your generated audio with additional instructions. Does not work with tts-1 or tts-1-hd.
        /// </summary>
        public string? Instructions { get; set; }
        /// <summary>
        /// The format to audio in. Supported formats are mp3, opus, aac, flac, wav, and pcm.
        /// </summary>
        public string? Response_Format { get; set; }
        /// <summary>
        /// The speed of the generated audio. Select a value from 0.25 to 4.0. 1.0 is the default. Does not work with gpt-4o-mini-tts.
        /// </summary>
        public double? Speed { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/audio/speech";
        }
        public override object GetRequestBody()
        {
            return new {
            	input = this.Input,
            	model = this.Model,
            	voice = this.Voice,
            	instructions = this.Instructions,
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
        public async ValueTask<AudioSpeechResponse> AudioSpeechAsync(string input, string model, string voice)
        {
            var p = new AudioSpeechParameter();
            p.Input = input;
            p.Model = model;
            p.Voice = voice;
            return await this.SendJsonAsync<AudioSpeechParameter, AudioSpeechResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<AudioSpeechResponse> AudioSpeechAsync(string input, string model, string voice, CancellationToken cancellationToken)
        {
            var p = new AudioSpeechParameter();
            p.Input = input;
            p.Model = model;
            p.Voice = voice;
            return await this.SendJsonAsync<AudioSpeechParameter, AudioSpeechResponse>(p, cancellationToken);
        }
        public async ValueTask<AudioSpeechResponse> AudioSpeechAsync(AudioSpeechParameter parameter)
        {
            return await this.SendJsonAsync<AudioSpeechParameter, AudioSpeechResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<AudioSpeechResponse> AudioSpeechAsync(AudioSpeechParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<AudioSpeechParameter, AudioSpeechResponse>(parameter, cancellationToken);
        }
    }
}
