using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Create an ephemeral API token for use in client-side applications with the Realtime API specifically for realtime transcriptions. Can be configured with the same session parameters as the transcription_session.update client event.
    /// It responds with a session object, plus a client_secret key which contains a usable ephemeral API token that can be used to authenticate browser clients for the Realtime API.
    /// <seealso href="https://api.openai.com/v1/realtime/transcription_sessions">https://api.openai.com/v1/realtime/transcription_sessions</seealso>
    /// </summary>
    public partial class RealtimeTranscriptionSessionCreateParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The set of items to include in the transcription. Current available items are: item.input_audio_transcription.logprobs
        /// </summary>
        public List<string>? Include { get; set; }
        /// <summary>
        /// The format of input audio. Options are pcm16, g711_ulaw, or g711_alaw. For pcm16, input audio must be 16-bit PCM at a 24kHz sample rate, single channel (mono), and little-endian byte order.
        /// </summary>
        public string? Input_Audio_Format { get; set; }
        /// <summary>
        /// Configuration for input audio noise reduction. This can be set to null to turn off. Noise reduction filters audio added to the input audio buffer before it is sent to VAD and the model. Filtering the audio can improve VAD and turn detection accuracy (reducing false positives) and model performance by improving perception of the input audio.
        /// </summary>
        public object? Input_Audio_Noise_Reduction { get; set; }
        /// <summary>
        /// Configuration for input audio transcription. The client can optionally set the language and prompt for transcription, these offer additional guidance to the transcription service.
        /// </summary>
        public object? Input_Audio_Transcription { get; set; }
        /// <summary>
        /// Configuration for turn detection. Can be set to null to turn off. Server VAD means that the model will detect the start and end of speech based on audio volume and respond at the end of user speech.
        /// </summary>
        public object? Turn_Detection { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/realtime/transcription_sessions";
        }
        public override object GetRequestBody()
        {
            return new {
            	include = this.Include,
            	input_audio_format = this.Input_Audio_Format,
            	input_audio_noise_reduction = this.Input_Audio_Noise_Reduction,
            	input_audio_transcription = this.Input_Audio_Transcription,
            	turn_detection = this.Turn_Detection,
            };
        }
    }
    public partial class RealtimeTranscriptionSessionCreateResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<RealtimeTranscriptionSessionCreateResponse> RealtimeTranscriptionSessionCreateAsync()
        {
            var p = new RealtimeTranscriptionSessionCreateParameter();
            return await this.SendJsonAsync<RealtimeTranscriptionSessionCreateParameter, RealtimeTranscriptionSessionCreateResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<RealtimeTranscriptionSessionCreateResponse> RealtimeTranscriptionSessionCreateAsync(CancellationToken cancellationToken)
        {
            var p = new RealtimeTranscriptionSessionCreateParameter();
            return await this.SendJsonAsync<RealtimeTranscriptionSessionCreateParameter, RealtimeTranscriptionSessionCreateResponse>(p, cancellationToken);
        }
        public async ValueTask<RealtimeTranscriptionSessionCreateResponse> RealtimeTranscriptionSessionCreateAsync(RealtimeTranscriptionSessionCreateParameter parameter)
        {
            return await this.SendJsonAsync<RealtimeTranscriptionSessionCreateParameter, RealtimeTranscriptionSessionCreateResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<RealtimeTranscriptionSessionCreateResponse> RealtimeTranscriptionSessionCreateAsync(RealtimeTranscriptionSessionCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<RealtimeTranscriptionSessionCreateParameter, RealtimeTranscriptionSessionCreateResponse>(parameter, cancellationToken);
        }
    }
}
