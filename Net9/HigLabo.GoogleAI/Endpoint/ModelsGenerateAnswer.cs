using HigLabo.Core;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;

namespace HigLabo.GoogleAI;

public class ModelsGenerateAnswerParameter : RestApiParameter, IRestApiParameter, IContentsProperty
{
    string IRestApiParameter.HttpMethod { get; } = "POST";

    public string Model { get; set; } = "";
    public List<Content> Contents { get; init; } = new();
    public AnswerStyle AnswerStyle { get; set; } = AnswerStyle.Answer_Style_Unspecified; 
    public List<SafetySetting>? SafetySettings { get; set; }
    public GroundingPassages? InlinePassages { get; set; }
    public SemanticRetrieverConfig? SemanticRetriever { get; set; }
    public double? Temperature { get; set; }
    public bool Stream { get; set; } = false;

    string IRestApiParameter.GetApiPath()
    {
        if (this.Stream)
        {
            return $"models/{this.Model}:streamGenerateAnswer";
        }
        return $"models/{this.Model}:generateAnswer";
    }
    public override object GetRequestBody()
    {
        return new
        {
            contents = this.Contents,
            answerStyle = this.AnswerStyle,
            safetySettings = this.SafetySettings,
            inlinePassages = this.InlinePassages,
            semanticRetriever = this.SemanticRetriever,
            temperature = this.Temperature,
        };
    }
}
public class ModelsGenerateAnswerObject
{
    public Candidate Answer { get; init; } = new();
    public double AnswerableProbability { get; set; }
    public InputFeedback InputFeedback { get; set; } = new();
}
public class ModelsGenerateAnswerResponse : RestApiResponse
{
    public Candidate Answer { get; init; } = new();
    public double AnswerableProbability { get; set; }
    public InputFeedback InputFeedback { get; set; } = new();
}

public partial class GoogleAIClient
{
    public async ValueTask<ModelsGenerateAnswerResponse> GenerateAnswerAsync(ModelsGenerateAnswerParameter parameter)
    {
        return await this.GenerateAnswerAsync(parameter, CancellationToken.None);
    }
    public async ValueTask<ModelsGenerateAnswerResponse> GenerateAnswerAsync(ModelsGenerateAnswerParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendJsonAsync<ModelsGenerateAnswerParameter, ModelsGenerateAnswerResponse>(parameter, cancellationToken);
    }

}
