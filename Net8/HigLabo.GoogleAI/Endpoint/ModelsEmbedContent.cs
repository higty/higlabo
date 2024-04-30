using HigLabo.Core;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;

namespace HigLabo.GoogleAI
{
    public partial class ModelsEmbedContentParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";

        public string Model { get; set; } = "";
        public Content Content { get; init; } = new();
        public TaskType? TaskType { get; set; }
        public string? Title { get; set; }
        public int? OutputDimensionality { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"models/{this.Model}:embedContent";
        }
        public override object GetRequestBody()
        {
            return new
            {
                content = this.Content,
                taskType = this.TaskType,
                title = this.Title,
                outputDimensionality = this.OutputDimensionality,
            };
        }

        public void SetText(string text)
        {
            this.Content.Parts.Clear();
            this.Content.Parts.Add(new ContentPart(text));
        }
    }
    public class ModelsEmbedContentObject
    {
        public ContentEmbedding Embedding { get; set; } = new();
    }
    public class ModelsEmbedContentResponse : RestApiResponse
    {
        public ContentEmbedding Embedding { get; set; } = new();
    }

    public partial class GoogleAIClient
    {
        public async ValueTask<ModelsEmbedContentResponse> EmbedContentAsync(ModelsEmbedContentParameter parameter)
        {
            return await this.EmbedContentAsync(parameter, CancellationToken.None);
        }
        public async ValueTask<ModelsEmbedContentResponse> EmbedContentAsync(ModelsEmbedContentParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ModelsEmbedContentParameter, ModelsEmbedContentResponse>(parameter, cancellationToken);
        }
    }
}
