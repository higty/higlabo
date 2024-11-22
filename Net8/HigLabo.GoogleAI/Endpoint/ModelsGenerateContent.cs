using HigLabo.Core;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;

namespace HigLabo.GoogleAI;

public partial class ModelsGenerateContentParameter : RestApiParameter, IRestApiParameter, IContentsProperty
{
    string IRestApiParameter.HttpMethod { get; } = "POST";

    public string Model { get; set; } = "";
    public List<Content> Contents { get; init; } = new();
    public List<Tool>? Tools { get; set; } 
    public List<SafetyCategory>? SafetySettings { get; set; }
    public Content? SystemInstruction { get; set; }
    public GenerationConfiguration? GenerationConfig { get; set; }

    public bool Stream { get; set; } = true;

    string IRestApiParameter.GetApiPath()
    {
        if (this.Stream)
        {
            return $"models/{this.Model}:streamGenerateContent";
        }
        return $"models/{this.Model}:generateContent";
    }
    public override object GetRequestBody()
    {
        return new
        {
            contents = this.Contents,
            tools = this.Tools,
            systemInstruction = this.SystemInstruction,
            safetySettings = this.SafetySettings,
            generationConfig = this.GenerationConfig,
        };
    }

}
public class ModelsGenerateContentObject
{
    public List<Candidate> Candidates { get; init; } = new();
}
public class ModelsGenerateContentResponse : RestApiResponse
{
    public List<Candidate> Candidates { get; init; } = new();
}

public partial class GoogleAIClient
{
    public async ValueTask<ModelsGenerateContentResponse> GenerateContentAsync(ModelsGenerateContentParameter parameter)
    {
        return await this.GenerateContentAsync(parameter, CancellationToken.None);
    }
    public async ValueTask<ModelsGenerateContentResponse> GenerateContentAsync(ModelsGenerateContentParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<ModelsGenerateContentParameter, ModelsGenerateContentResponse>(parameter, cancellationToken);
    }

    public async IAsyncEnumerable<string> GenerateContentStreamAsync(string message, string model)
    {
        var p = new ModelsGenerateContentParameter();
        p.AddUserMessage(message);
        p.Model = model;
        p.Stream = true;
        await foreach (var item in this.GetStreamAsync(p, null, CancellationToken.None))
        {
            yield return item;
        }
    }
    public async IAsyncEnumerable<string> GenerateContentStreamAsync(string message, string model, GenerateContentStreamResult result, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var p = new ModelsGenerateContentParameter();
        p.AddUserMessage(message);
        p.Model = model;
        p.Stream = true;
        await foreach (var item in this.GetStreamAsync(p, result, cancellationToken))
        {
            yield return item;
        }
    }
    public async IAsyncEnumerable<string> GenerateContentStreamAsync(string message, string model, int maxOutputTokens, GenerateContentStreamResult result, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var p = new ModelsGenerateContentParameter();
        p.AddUserMessage(message);
        p.Model = model;
        p.GenerationConfig = new();
        p.GenerationConfig.MaxOutputTokens = maxOutputTokens;
        p.Stream = true;
        await foreach (var item in this.GetStreamAsync(p, result, cancellationToken))
        {
            yield return item;
        }
    }
    public async IAsyncEnumerable<string> GenerateContentStreamAsync(ModelsGenerateContentParameter parameter)
    {
        parameter.Stream = true;
        await foreach (var item in this.GetStreamAsync(parameter, null, CancellationToken.None))
        {
            yield return item;
        }
    }
    public async IAsyncEnumerable<string> GenerateContentStreamAsync(ModelsGenerateContentParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        parameter.Stream = true;
        await foreach (var item in this.GetStreamAsync(parameter, null, cancellationToken))
        {
            yield return item;
        }
    }
    public async IAsyncEnumerable<string> GenerateContentStreamAsync(ModelsGenerateContentParameter parameter, GenerateContentStreamResult result, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        parameter.Stream = true;
        await foreach (var item in this.GetStreamAsync(parameter, result, cancellationToken))
        {
            yield return item;
        }
    }

    public async IAsyncEnumerable<ServerSentEventLine> GetStreamAsync<TParameter>(TParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        where TParameter : RestApiParameter, IRestApiParameter
    {
        var p = parameter as IRestApiParameter;
        var req = this.CreateRequestMessage(parameter);
        req.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/event-stream"));
        var requestBodyText = "";
        if (string.Equals(p.HttpMethod, "POST", StringComparison.OrdinalIgnoreCase))
        {
            requestBodyText = JsonConverter.SerializeObject(parameter.GetRequestBody());
        }
        req.Content = new StringContent(requestBodyText, Encoding.UTF8, new MediaTypeHeaderValue("application/json"));

        Debug.WriteLine(requestBodyText);
        var res = await this.SendRequestAsync(req, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

        if (res.IsSuccessStatusCode == false)
        {
            var responseBodyText = await res.Content.ReadAsStringAsync();
            var errorRes = this.JsonConverter.DeserializeObject<GoogleAIServerErrorResponse>(responseBodyText);
            throw new GoogleAIServerException(parameter, req, requestBodyText, res, responseBodyText, errorRes);
        }

        using (var stream = await res.Content.ReadAsStreamAsync())
        {
            try
            {
                var sseProcessor = new ServerSentEventProcessor(stream);
                await foreach (var line in sseProcessor.Process(cancellationToken))
                {
                    yield return line;
                }
            }
            finally
            {
                stream.Close();
            }
        }
    }
    public async IAsyncEnumerable<string> GetStreamAsync(ModelsGenerateContentParameter parameter, GenerateContentStreamResult? result, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var eventName = "";
        await foreach (var line in this.GetStreamAsync(parameter, cancellationToken))
        {
            if (line.IsEvent())
            {
                eventName = line.GetText();
            }
            if (line.IsData())
            {
                var text = line.GetText();
                if (string.Equals(text, "[DONE]", StringComparison.OrdinalIgnoreCase)) { continue; }

                var o = this.JsonConverter.DeserializeObject<ModelsGenerateContentObject>(text);
                if (o != null)
                {
                    foreach (var candidate in o.Candidates)
                    {
                        foreach (var part in candidate.Content.Parts)
                        {
                            yield return part.ToString();
                        }
                        if (result != null)
                        {
                            result.Process(candidate);
                        }
                    }
                }
            }
        }
    }

}
