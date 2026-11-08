namespace HigLabo.OpenAI;

public class ImageReference
{
    public string? File_Id { get; set; }
    public string? Image_Url { get; set; }
}

public class ImageSvgOptions
{
    public string Model { get; set; } = "";
    public ImageSvgReasoning? Reasoning { get; set; }
}

public class ImageSvgReasoning
{
    public string? Effort { get; set; }
}

/// <summary>Edits images referenced by URL, data URL or uploaded file ID using the JSON transport.</summary>
public class ImagesEditsJsonParameter : RestApiParameter, IRestApiParameter, IImageGenerateParameter
{
    string IRestApiParameter.HttpMethod => "POST";
    string IRestApiParameter.GetApiPath() => "/images/edits";
    public List<ImageReference> Images { get; set; } = new();
    public string Prompt { get; set; } = "";
    public string? Model { get; set; }
    public string? Background { get; set; }
    public string? Complexity { get; set; }
    public int? Frame_Count { get; set; }
    public int? Frame_Duration_Ms { get; set; }
    public string? Input_Fidelity { get; set; }
    public ImageReference? Markup { get; set; }
    public ImageReference? Mask { get; set; }
    public string? Moderation { get; set; }
    public int? N { get; set; }
    public int? Output_Compression { get; set; }
    public string? Output_Format { get; set; }
    public int? Partial_Images { get; set; }
    public string? Quality { get; set; }
    public string? Safety_Identifier { get; set; }
    public string? Size { get; set; }
    public bool? Stream { get; set; }
    public ImageSvgOptions? Svg { get; set; }
    public string? User { get; set; }

    public override object GetRequestBody() => new
    {
        images = Images, prompt = Prompt, model = Model, background = Background,
        complexity = Complexity, frame_count = Frame_Count, frame_duration_ms = Frame_Duration_Ms,
        input_fidelity = Input_Fidelity, markup = Markup, mask = Mask, moderation = Moderation,
        n = N, output_compression = Output_Compression, output_format = Output_Format,
        partial_images = Partial_Images, quality = Quality, safety_identifier = Safety_Identifier,
        size = Size, stream = Stream, svg = Svg, user = User,
    };
}

public partial class OpenAIClient
{
    public async IAsyncEnumerable<ImageGenerationStreamEvent> ImagesEditsStreamAsync(ImagesEditsJsonParameter parameter,
        [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        parameter.Stream = true;
        await foreach (var item in GetImageGenerateStreamEventAsync(parameter, null, cancellationToken))
            yield return item;
    }

    public ValueTask<ImagesEditsResponse> ImagesEditsAsync(ImagesEditsJsonParameter parameter)
        => ImagesEditsAsync(parameter, CancellationToken.None);

    public ValueTask<ImagesEditsResponse> ImagesEditsAsync(ImagesEditsJsonParameter parameter, CancellationToken cancellationToken)
    {
        parameter.Stream = null;
        return SendJsonAsync<ImagesEditsJsonParameter, ImagesEditsResponse>(parameter, cancellationToken);
    }
}
