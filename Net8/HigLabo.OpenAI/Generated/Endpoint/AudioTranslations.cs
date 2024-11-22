using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

/// <summary>
/// Translates audio into English.
/// <seealso href="https://api.openai.com/v1/audio/translations">https://api.openai.com/v1/audio/translations</seealso>
/// </summary>
public partial class AudioTranslationsParameter : RestApiParameter, IRestApiParameter, IFileParameter, IFormDataParameter
{
    string IRestApiParameter.HttpMethod { get; } = "POST";
    /// <summary>
    /// The audio file object (not file name) translate, in one of these formats: flac, mp3, mp4, mpeg, mpga, m4a, ogg, wav, or webm.
    /// </summary>
    public FileParameter File { get; private set; } = new FileParameter("file");
    /// <summary>
    /// ID of the model to use. Only whisper-1 (which is powered by our open source Whisper V2 model) is currently available.
    /// </summary>
    public string Model { get; set; } = "";
    /// <summary>
    /// An optional text to guide the model's style or continue a previous audio segment. The prompt should be in English.
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

    string IRestApiParameter.GetApiPath()
    {
        return $"/audio/translations";
    }
    public override object GetRequestBody()
    {
        return new {
        	file = this.File,
        	model = this.Model,
        	prompt = this.Prompt,
        	response_format = this.Response_Format,
        	temperature = this.Temperature,
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
        if (this.Prompt != null) d["prompt"] = this.Prompt;
        if (this.Response_Format != null) d["response_format"] = this.Response_Format;
        if (this.Temperature != null) d["temperature"] = this.Temperature.Value.ToString();
        return d;
    }
}
public partial class AudioTranslationsResponse : RestApiResponse
{
}
public partial class OpenAIClient
{
    public async ValueTask<AudioTranslationsResponse> AudioTranslationsAsync(string fileFileName, Stream fileStream, string model)
    {
        var p = new AudioTranslationsParameter();
        p.File.SetFile(fileFileName, fileStream);
        p.Model = model;
        return await this.SendFormDataAsync<AudioTranslationsParameter, AudioTranslationsResponse>(p, CancellationToken.None);
    }
    public async ValueTask<AudioTranslationsResponse> AudioTranslationsAsync(string fileFileName, Stream fileStream, string model, CancellationToken cancellationToken)
    {
        var p = new AudioTranslationsParameter();
        p.File.SetFile(fileFileName, fileStream);
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
