using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Create an ephemeral API token for use in client-side applications with the Realtime API. Can be configured with the same session parameters as the session.update client event.
    /// It responds with a session object, plus a client_secret key which contains a usable ephemeral API token that can be used to authenticate browser clients for the Realtime API.
    /// <seealso href="https://api.openai.com/v1/realtime/sessions">https://api.openai.com/v1/realtime/sessions</seealso>
    /// </summary>
    public partial class RealtimeSessionCreateParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// Configuration options for the generated client secret.
        /// </summary>
        public object? Client_Secret { get; set; }
        /// <summary>
        /// The format of input audio. Options are pcm16, g711_ulaw, or g711_alaw. For pcm16, input audio must be 16-bit PCM at a 24kHz sample rate, single channel (mono), and little-endian byte order.
        /// </summary>
        public string? Input_Audio_Format { get; set; }
        /// <summary>
        /// Configuration for input audio noise reduction. This can be set to null to turn off. Noise reduction filters audio added to the input audio buffer before it is sent to VAD and the model. Filtering the audio can improve VAD and turn detection accuracy (reducing false positives) and model performance by improving perception of the input audio.
        /// </summary>
        public object? Input_Audio_Noise_Reduction { get; set; }
        /// <summary>
        /// Configuration for input audio transcription, defaults to off and can be set to null to turn off once on. Input audio transcription is not native to the model, since the model consumes audio directly. Transcription runs asynchronously through the /audio/transcriptions endpoint and should be treated as guidance of input audio content rather than precisely what the model heard. The client can optionally set the language and prompt for transcription, these offer additional guidance to the transcription service.
        /// </summary>
        public object? Input_Audio_Transcription { get; set; }
        /// <summary>
        /// The default system instructions (i.e. system message) prepended to model calls. This field allows the client to guide the model on desired responses. The model can be instructed on response content and format, (e.g. "be extremely succinct", "act friendly", "here are examples of good responses") and on audio behavior (e.g. "talk quickly", "inject emotion into your voice", "laugh frequently"). The instructions are not guaranteed to be followed by the model, but they provide guidance to the model on the desired behavior.
        /// Note that the server sets default instructions which will be used if this field is not set and are visible in the session.created event at the start of the session.
        /// </summary>
        public string? Instructions { get; set; }
        /// <summary>
        /// Maximum number of output tokens for a single assistant response, inclusive of tool calls. Provide an integer between 1 and 4096 to limit output tokens, or inf for the maximum available tokens for a given model. Defaults to inf.
        /// </summary>
        public object? Max_Response_Output_Tokens { get; set; }
        /// <summary>
        /// The set of modalities the model can respond with. To disable audio, set this to ["text"].
        /// </summary>
        public object? Modalities { get; set; }
        /// <summary>
        /// The Realtime model used for this session.
        /// </summary>
        public string? Model { get; set; }
        /// <summary>
        /// The format of output audio. Options are pcm16, g711_ulaw, or g711_alaw. For pcm16, output audio is sampled at a rate of 24kHz.
        /// </summary>
        public string? Output_Audio_Format { get; set; }
        /// <summary>
        /// The speed of the model's spoken response. 1.0 is the default speed. 0.25 is the minimum speed. 1.5 is the maximum speed. This value can only be changed in between model turns, not while a response is in progress.
        /// </summary>
        public double? Speed { get; set; }
        /// <summary>
        /// Sampling temperature for the model, limited to [0.6, 1.2]. For audio models a temperature of 0.8 is highly recommended for best performance.
        /// </summary>
        public double? Temperature { get; set; }
        /// <summary>
        /// How the model chooses tools. Options are auto, none, required, or specify a function.
        /// </summary>
        public string? Tool_Choice { get; set; }
        /// <summary>
        /// Tools (functions) available to the model.
        /// </summary>
        public List<Tool>? Tools { get; set; }
        /// <summary>
        /// Configuration options for tracing. Set to null to disable tracing. Once tracing is enabled for a session, the configuration cannot be modified.
        /// auto will create a trace for the session with default values for the workflow name, group id, and metadata.
        /// </summary>
        public object? Tracing { get; set; }
        /// <summary>
        /// Configuration for turn detection, ether Server VAD or Semantic VAD. This can be set to null to turn off, in which case the client must manually trigger model response. Server VAD means that the model will detect the start and end of speech based on audio volume and respond at the end of user speech. Semantic VAD is more advanced and uses a turn detection model (in conjunction with VAD) to semantically estimate whether the user has finished speaking, then dynamically sets a timeout based on this probability. For example, if user audio trails off with "uhhm", the model will score a low probability of turn end and wait longer for the user to continue speaking. This can be useful for more natural conversations, but may have a higher latency.
        /// </summary>
        public object? Turn_Detection { get; set; }
        /// <summary>
        /// The voice the model uses to respond. Voice cannot be changed during the session once the model has responded with audio at least once. Current voice options are alloy, ash, ballad, coral, echo, sage, shimmer, and verse.
        /// </summary>
        public string? Voice { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/realtime/sessions";
        }
        public override object GetRequestBody()
        {
            return new {
            	client_secret = this.Client_Secret,
            	input_audio_format = this.Input_Audio_Format,
            	input_audio_noise_reduction = this.Input_Audio_Noise_Reduction,
            	input_audio_transcription = this.Input_Audio_Transcription,
            	instructions = this.Instructions,
            	max_response_output_tokens = this.Max_Response_Output_Tokens,
            	modalities = this.Modalities,
            	model = this.Model,
            	output_audio_format = this.Output_Audio_Format,
            	speed = this.Speed,
            	temperature = this.Temperature,
            	tool_choice = this.Tool_Choice,
            	tools = this.Tools,
            	tracing = this.Tracing,
            	turn_detection = this.Turn_Detection,
            	voice = this.Voice,
            };
        }
    }
    public partial class RealtimeSessionCreateResponse : RealtimeSessionObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<RealtimeSessionCreateResponse> RealtimeSessionCreateAsync()
        {
            var p = new RealtimeSessionCreateParameter();
            return await this.SendJsonAsync<RealtimeSessionCreateParameter, RealtimeSessionCreateResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<RealtimeSessionCreateResponse> RealtimeSessionCreateAsync(CancellationToken cancellationToken)
        {
            var p = new RealtimeSessionCreateParameter();
            return await this.SendJsonAsync<RealtimeSessionCreateParameter, RealtimeSessionCreateResponse>(p, cancellationToken);
        }
        public async ValueTask<RealtimeSessionCreateResponse> RealtimeSessionCreateAsync(RealtimeSessionCreateParameter parameter)
        {
            return await this.SendJsonAsync<RealtimeSessionCreateParameter, RealtimeSessionCreateResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<RealtimeSessionCreateResponse> RealtimeSessionCreateAsync(RealtimeSessionCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<RealtimeSessionCreateParameter, RealtimeSessionCreateResponse>(parameter, cancellationToken);
        }
    }
}
