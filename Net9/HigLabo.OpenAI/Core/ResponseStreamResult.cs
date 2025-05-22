using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public class ResponseStreamResult
{
    public string? Text { get; set; } 
    public List<ResponseStreamEvent> EventList { get; init; } = new();

    public List<IResponseStreamEvent> GetEventList()
    {
        var l = new List<IResponseStreamEvent>();
        foreach (var item in this.EventList)
        {
            var o = item.CreateTypedData();
            if (o == null) { continue; }
            l.Add(o);
        }
        return l;
    }
}

public class ResponseStreamEvent
{
    public string EventName { get; set; } = "";
    public string Data { get; set; } = "";

    public ResponseStreamEvent(string eventName, string data)
    {
        this.EventName = eventName;
        this.Data = data;
    }
    public IResponseStreamEvent? CreateTypedData()
    {
        switch (this.EventName)
        {
            case "response.created": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamResponse>(this.Data)!;
            case "response.in_progress": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamResponse>(this.Data)!;
            case "response.completed": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamResponse>(this.Data)!;
            case "response.failed": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamResponse>(this.Data)!;
            case "response.incomplete": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamResponse>(this.Data)!;
            case "response.output_item.added": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamOutputItem>(this.Data)!;
            case "response.output_item.done": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamOutputItem>(this.Data)!;
            case "response.content_part.added": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamContentPart>(this.Data)!;
            case "response.content_part.done": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamContentPart>(this.Data)!;
            case "response.output_text.delta": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamOutputTextDelta>(this.Data)!;
            case "response.output_text.annotation.added": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamOutputTextAnnotationAdded>(this.Data)!;
            case "response.output_text.done": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamOutputTextDone>(this.Data)!;
            case "response.refusal.delta": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamRefusal>(this.Data)!;
            case "response.refusal.done": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamRefusalDone>(this.Data)!;
            case "response.function_call_arguments.delta": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamFunctionCallArguments>(this.Data)!;
            case "response.function_call_arguments.done": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamFunctionCallArgumentsDone>(this.Data)!;
            case "response.file_search_call.in_progress": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamFileSearchCall>(this.Data)!;
            case "response.file_search_call.searching": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamFileSearchCall>(this.Data)!;
            case "response.file_search_call.completed": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamFileSearchCall>(this.Data)!;
            case "response.web_search_call.in_progress": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamWebSearchCall>(this.Data)!;
            case "response.web_search_call.searching": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamWebSearchCall>(this.Data)!;
            case "response.web_search_call.completed": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamWebSearchCall>(this.Data)!;
            case "response.reasoning_summary_part.added": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamReasoningSummaryPart>(this.Data)!;
            case "response.reasoning_summary_part.done": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamReasoningSummaryPart>(this.Data)!;
            case "response.reasoning_summary_text.delta": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamReasoningSummaryTextDelta>(this.Data)!;
            case "response.reasoning_summary_text.done": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamReasoningSummaryTextDone>(this.Data)!;
            case "response.image_generation_call.generating": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamImageGenerationCall>(this.Data)!;
            case "response.image_generation_call.in_progress": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamImageGenerationCall>(this.Data)!;
            case "response.image_generation_call.completed": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamImageGenerationCall>(this.Data)!;
            case "response.image_generation_call.partial_image": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamImageGenerationCallPartialImage>(this.Data)!;
            case "response.mcp_call.arguments.delta": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamMcpCallArgumentsDelta>(this.Data)!;
            case "response.mcp_call.arguments.done": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamMcpCallArgumentsDone>(this.Data)!;
            case "response.mcp_call.in_progress": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamMcpCallArgumentsInProgress>(this.Data)!;
            case "response.mcp_call.completed": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamMcpCallArguments>(this.Data)!;
            case "response.mcp_call.failed": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamMcpCallArguments>(this.Data)!;
            case "response.mcp_list_tools.in_progress": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamMcpListTools>(this.Data)!;
            case "response.mcp_list_tools.completed": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamMcpListTools>(this.Data)!;
            case "response.mcp_list_tools.failed": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamMcpListTools>(this.Data)!;
            case "response.output_text_annotation.added": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamOutputTextAnnotationAdded>(this.Data)!;
            case "response.queued": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamQueued>(this.Data)!;
            case "response.reasoning.delta": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamReasoningDelta>(this.Data)!;
            case "response.reasoning.done": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamReasoningDone>(this.Data)!;
            case "response.reasoning_summary.delta": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamReasoningSummaryDelta>(this.Data)!;
            case "response.reasoning_summary.done": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamReasoningSummaryDone>(this.Data)!;
            case "error": return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamError>(this.Data)!;
            default: return null;
        }
    }
    public override string ToString()
    {
        return this.EventName;
    }
}

public interface IResponseStreamEvent
{
    string Type { get; }
}
public class ResponseStreamResponse : IResponseStreamEvent
{
    public string Type { get; set; } = "";
    public ResponseObject Response { get; set; } = new();
}
public class ResponseStreamOutputItem : ResponseStreamOutputItem<object>
{

}
public class ResponseStreamOutputItem<T> : IResponseStreamEvent
    where T: new()
{
    public string Type { get; set; } = "";
    public int Output_Index { get; set; }
    public T Item { get; set; } = new T();
    public int Sequence_Number { get; set; }
}
public class ResponseStreamContentPart : IResponseStreamEvent
{
    public class ContentPart
    {
        public string Type { get; set; } = "";
        public string Text { get; set; } = "";
        public string Refusal { get; set; } = "";
        public List<Annotation> Annotations { get; init; } = new();
    }
    public class Annotation
    {
        public string Type { get; set; } = "";
        public string Text { get; set; } = "";
        public int Index { get; set; }
        public string File_Id { get; set; } = "";
        public int Start_Index { get; set; }
        public int End_Index { get; set; }
        public string Title { get; set; } = "";
        public string Url { get; set; } = "";

        public override string ToString()
        {
            if (this.Text.HasValue()) { return this.Text; }
            if (this.Url.HasValue())
            {
                if (this.Title.HasValue()) { return $"{this.Url} {this.Title}"; }
                return this.Url;
            }
            if (this.File_Id.HasValue()) { return this.File_Id; }
            return this.Type;
        }
    }
    public string Type { get; set; } = "";
    public string Item_Id { get; set; } = "";
    public int Output_Index { get; set; }
    public int Content_Index { get; set; }
    public ContentPart Part { get; set; } = new();
    public int Sequence_Number { get; set; }
}
public class ResponseStreamOutputTextDelta : IResponseStreamEvent
{
    public string Type { get; set; } = "";
    public string Item_Id { get; set; } = "";
    public int Output_Index { get; set; }
    public int Content_Index { get; set; }
    public string Delta { get; set; } = "";
    public int Sequence_Number { get; set; }
}
public class ResponseStreamOutputTextAnnotation : IResponseStreamEvent
{
    public string Type { get; set; } = "";
    public string Item_Id { get; set; } = "";
    public int Output_Index { get; set; }
    public int Content_Index { get; set; }
    public int Annotation_Index { get; set; }
    public ResponseStreamAnnotation Annotation { get; set; } = new();
    public int Sequence_Number { get; set; }
}
public class ResponseStreamAnnotation : IResponseStreamEvent
{
    public string Type { get; set; } = "";
    public int? Index { get; set; }
    public string? File_Id { get; set; } = "";
    public string? Title { get; set; } = "";
    public string? Url { get; set; } = "";
    public int? Start_Index { get; set; }
    public int? End_Index { get; set; }
}
public class ResponseStreamOutputTextDone : IResponseStreamEvent
{
    public string Type { get; set; } = "";
    public string Item_Id { get; set; } = "";
    public int Output_Index { get; set; }
    public int Content_Index { get; set; }
    public string Text { get; set; } = "";
    public int Sequence_Number { get; set; }
}
public class ResponseStreamRefusal : IResponseStreamEvent
{
    public string Type { get; set; } = "";
    public string Item_Id { get; set; } = "";
    public int Output_Index { get; set; }
    public int Content_Index { get; set; }
    public string Delta { get; set; } = "";
    public int Sequence_Number { get; set; }
}
public class ResponseStreamRefusalDone : IResponseStreamEvent
{
    public string Type { get; set; } = "";
    public string Item_Id { get; set; } = "";
    public int Output_Index { get; set; }
    public int Content_Index { get; set; }
    public string Refusal { get; set; } = "";
    public int Sequence_Number { get; set; }
}

public class ResponseStreamFunctionCallArguments : IResponseStreamEvent
{
    public string Type { get; set; } = "";
    public string Item_Id { get; set; } = "";
    public int Output_Index { get; set; }
    public string Delta { get; set; } = "";
    public int Sequence_Number { get; set; }
}
public class ResponseStreamFunctionCallArgumentsDone : IResponseStreamEvent
{
    public string Type { get; set; } = "";
    public string Item_Id { get; set; } = "";
    public int Output_Index { get; set; }
    public string Arguments { get; set; } = "";
    public int Sequence_Number { get; set; }
}

public class ResponseStreamFileSearchCall : IResponseStreamEvent
{
    public string Type { get; set; } = "";
    public int Output_Index { get; set; }
    public string Item_Id { get; set; } = "";
    public int Sequence_Number { get; set; }
}
public class ResponseStreamWebSearchCall : IResponseStreamEvent
{
    public string Type { get; set; } = "";
    public int Output_Index { get; set; }
    public string Item_Id { get; set; } = "";
}
public class ResponseStreamReasoningSummaryPartText : IResponseStreamEvent
{
    public string Type { get; set; } = "";
    public string Text { get; set; } = "";
}
public class ResponseStreamReasoningSummaryPart : IResponseStreamEvent
{
    public string Type { get; set; } = "";
    public string Item_Id { get; set; } = "";
    public int Output_Index { get; set; }
    public int Summary_Index { get; set; }
    public ResponseStreamReasoningSummaryPartText Part { get; set; } = new();
    public int Sequence_Number { get; set; }
}
public class ResponseStreamReasoningSummaryTextDelta : IResponseStreamEvent
{
    public string Type { get; set; } = "";
    public string Item_Id { get; set; } = "";
    public int Output_Index { get; set; }
    public int Summary_Index { get; set; }
    public string Delta { get; set; } = "";
    public int Sequence_Number { get; set; }
}
public class ResponseStreamReasoningSummaryTextDone : IResponseStreamEvent
{
    public string Type { get; set; } = "";
    public string Item_Id { get; set; } = "";
    public int Output_Index { get; set; }
    public int Summary_Index { get; set; }
    public string Text { get; set; } = "";
    public int Sequence_Number { get; set; }
}

public class ResponseStreamImageGenerationCall : IResponseStreamEvent
{
    public string Type { get; set; } = "";
    public int Output_Index { get; set; }
    public string Item_Id { get; set; } = "";
    public int Sequence_Number { get; set; }
}
public class ResponseStreamImageGenerationCallPartialImage : IResponseStreamEvent
{
    public string Type { get; set; } = "";
    public int Output_Index { get; set; }
    public string Item_Id { get; set; } = "";
    public int Sequence_Number { get; set; }
    public int Partial_Image_Index { get; set; }
    public string Partial_Image_b64 { get; set; } = "";

    public Byte[] GetBytes()
    {
        return Convert.FromBase64String(this.Partial_Image_b64);
    }
    public Stream GetStream()
    {
        return new MemoryStream(Convert.FromBase64String(this.Partial_Image_b64));
    }
}

public class ResponseStreamMcpCallArgumentsDelta : IResponseStreamEvent
{
    public string Type { get; set; } = "";
    public int Output_Index { get; set; }
    public string Item_Id { get; set; } = "";
    public object? Delta { get; set; }
    public int Sequence_Number { get; set; }
}
public class ResponseStreamMcpCallArgumentsDone : IResponseStreamEvent
{
    public string Type { get; set; } = "";
    public int Output_Index { get; set; }
    public string Item_Id { get; set; } = "";
    public object? Arguments { get; set; }
    public int Sequence_Number { get; set; }
}
public class ResponseStreamMcpCallArgumentsInProgress : IResponseStreamEvent
{
    public string Type { get; set; } = "";
    public int Output_Index { get; set; }
    public string Item_Id { get; set; } = "";
    public int Sequence_Number { get; set; }
}
public class ResponseStreamMcpCallArguments : IResponseStreamEvent
{
    public string Type { get; set; } = "";
    public int Sequence_Number { get; set; }
}
public class ResponseStreamMcpListTools : IResponseStreamEvent
{
    public string Type { get; set; } = "";
    public int Sequence_Number { get; set; }
}

public class ResponseStreamOutputTextAnnotationAdded : IResponseStreamEvent
{
    public class OutputTextAnnotation
    {
        public string Type { get; set; } = "";
        public string Text { get; set; } = "";
        public int Index { get; set; }
        public string File_Id { get; set; } = "";
        public int Start_Index { get; set; }
        public int End_Index { get; set; }
        public string Title { get; set; } = "";
        public string Url { get; set; } = "";
        public string FileName { get; set; } = "";
    }
    public string Type { get; set; } = "";
    public string Item_Id { get; set; } = "";
    public int Output_Index { get; set; }
    public int Content_Index { get; set; }
    public int Annotation_Index { get; set; }
    public OutputTextAnnotation Annotation { get; set; } = new();
    public int Sequence_Number { get; set; }
}

public class ResponseStreamQueued : IResponseStreamEvent
{
    public string Type { get; set; } = "";
    public ResponseObject Response { get; set; } = new();
    public int Sequence_Number { get; set; }
}
public class ReasoningDelta 
{
    public string Text { get; set; } = "";
}
public class ResponseStreamReasoningDelta : IResponseStreamEvent
{
    public string Type { get; set; } = "";
    public string Item_Id { get; set; } = "";
    public int Output_Index { get; set; }
    public int Content_Index { get; set; }
    public ReasoningDelta Delta { get; set; } = new();
    public int Sequence_Number { get; set; }
}
public class ResponseStreamReasoningDone : IResponseStreamEvent
{
    public string Type { get; set; } = "";
    public string Item_Id { get; set; } = "";
    public int Output_Index { get; set; }
    public int Content_Index { get; set; }
    public string Text { get; set; } = "";
    public int Sequence_Number { get; set; }
}
public class ResponseStreamReasoningSummaryDelta : IResponseStreamEvent
{
    public string Type { get; set; } = "";
    public string Item_Id { get; set; } = "";
    public int Output_Index { get; set; }
    public int Summary_Index { get; set; }
    public ReasoningDelta Delta { get; set; } = new();
    public int Sequence_Number { get; set; }
}
public class ResponseStreamReasoningSummaryDone : IResponseStreamEvent
{
    public string Type { get; set; } = "";
    public string Item_Id { get; set; } = "";
    public int Output_Index { get; set; }
    public int Summary_Index { get; set; }
    public string Text { get; set; } = "";
    public int Sequence_Number { get; set; }
}
public class ResponseStreamError : IResponseStreamEvent
{
    public string Type { get; set; } = "";
    public string Code { get; set; } = "";
    public string Message { get; set; } = "";
    public object? Params { get; set; }
    public int Sequence_Number { get; set; }
}