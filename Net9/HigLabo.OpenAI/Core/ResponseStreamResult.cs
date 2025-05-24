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
    public ResponseStreamResponse? Response { get; set; }
    public string? Text { get; set; } 
    public List<ResponseStreamEvent> EventList { get; init; } = new();

    public List<IResponseStreamEvent> GetEventList()
    {
        var l = new List<IResponseStreamEvent>();
        foreach (var item in this.EventList)
        {
            var o = item.CreateTypedData();
            if (o == null) { continue; }
            if (o is ResponseStreamResponse)
            {
                this.Response = (ResponseStreamResponse)o;
            }
            l.Add(o);
        }
        return l;
    }
}
public class ResponseStreamEventName
{
    public const string Created = "response.created";
    public const string In_Progress = "response.in_progress";
    public const string Completed = "response.completed";
    public const string Failed = "response.failed";
    public const string Incomplete = "response.incomplete";
    public const string Queued = "response.queued";
    public const string Error = "response.error";

    public class Output_Item
    {
        public const string Added = "response.output_item.added";
        public const string Done = "response.output_item.done";
    }
    public class Content_Part
    {
        public const string Added = "response.content_part.added";
        public const string Done = "response.content_part.done";
    }
    public class Output_Text
    {
        public const string Delta = "response.output_text.delta";
        public class Annotation
        {
            public const string Added = "response.output_text.annotation.added";
        }
        public const string Done = "response.output_text.done";
    }
    public class Refusal
    {
        public const string Delta = "response.refusal.delta";
        public const string Done = "response.refusal.done";
    }
    public class Function_Call_Arguments
    {
        public const string Delta = "response.function_call_arguments.delta";
        public const string Done = "response.function_call_arguments.done";
    }
    public class File_Search_Call
    {
        public const string In_Progress = "response.file_search_call.in_progress";
        public const string Searching = "response.file_search_call.searching";
        public const string Completed = "response.file_search_call.completed";
    }
    public class Web_Search_Call
    {
        public const string In_Progress = "response.web_search_call.in_progress";
        public const string Searching = "response.web_search_call.searching";
        public const string Completed = "response.web_search_call.completed";
    }
    public class Reasoning_Summary_Part
    {
        public const string Added = "response.reasoning_summary_part.added";
        public const string Done = "response.reasoning_summary_part.done";
    }
    public class Reasoning_Summary_Text
    {
        public const string Delta = "response.reasoning_summary_text.delta";
        public const string Done = "response.reasoning_summary_text.done";
    }
    public class Image_Generation_Call
    {
        public const string Generating = "response.image_generation_call.generating";
        public const string In_Progress = "response.image_generation_call.in_progress";
        public const string Completed = "response.image_generation_call.completed";
        public const string Partial_Image = "response.image_generation_call.partial_image";
    }
    public class Mcp_Call
    {
        public class Arguments
        {
            public const string Delta = "response.mcp_call.arguments.delta";
            public const string Done = "response.mcp_call.arguments.done";
        }
        public const string In_Progress = "response.mcp_call.in_progress";
        public const string Completed = "response.mcp_call.completed";
        public const string Failed = "response.mcp_call.failed";
    }
    public class Mcp_List_Tools
    {
        public const string In_Progress = "response.mcp_list_tools.in_progress";
        public const string Completed = "response.mcp_list_tools.completed";
        public const string Failed = "response.mcp_list_tools.failed";
    }
    public class Output_Text_Annotation
    {
        public const string Added = "response.output_text_annotation.added";
    }
    public class Reasoning
    {
        public const string Delta = "response.reasoning.delta";
        public const string Done = "response.reasoning.done";
    }
    public class Reasoning_Summary
    {
        public const string Delta = "response.reasoning_summary.delta";
        public const string Done = "response.reasoning_summary.done";
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
            case ResponseStreamEventName.Created: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamResponse>(this.Data)!;
            case ResponseStreamEventName.In_Progress: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamResponse>(this.Data)!;
            case ResponseStreamEventName.Completed: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamResponse>(this.Data)!;
            case ResponseStreamEventName.Failed: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamResponse>(this.Data)!;
            case ResponseStreamEventName.Incomplete: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamResponse>(this.Data)!;
            case ResponseStreamEventName.Queued: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamQueued>(this.Data)!;
            case ResponseStreamEventName.Output_Item.Added: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamOutputItem>(this.Data)!;
            case ResponseStreamEventName.Output_Item.Done: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamOutputItem>(this.Data)!;
            case ResponseStreamEventName.Content_Part.Added: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamContentPart>(this.Data)!;
            case ResponseStreamEventName.Content_Part.Done: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamContentPart>(this.Data)!;
            case ResponseStreamEventName.Output_Text.Delta: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamOutputTextDelta>(this.Data)!;
            case ResponseStreamEventName.Output_Text.Annotation.Added: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamOutputTextAnnotationAdded>(this.Data)!;
            case ResponseStreamEventName.Output_Text.Done: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamOutputTextDone>(this.Data)!;
            case ResponseStreamEventName.Refusal.Delta: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamRefusal>(this.Data)!;
            case ResponseStreamEventName.Refusal.Done: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamRefusalDone>(this.Data)!;
            case ResponseStreamEventName.Function_Call_Arguments.Delta: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamFunctionCallArguments>(this.Data)!;
            case ResponseStreamEventName.Function_Call_Arguments.Done: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamFunctionCallArgumentsDone>(this.Data)!;
            case ResponseStreamEventName.File_Search_Call.In_Progress: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamFileSearchCall>(this.Data)!;
            case ResponseStreamEventName.File_Search_Call.Searching: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamFileSearchCall>(this.Data)!;
            case ResponseStreamEventName.File_Search_Call.Completed: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamFileSearchCall>(this.Data)!;
            case ResponseStreamEventName.Web_Search_Call.In_Progress: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamWebSearchCall>(this.Data)!;
            case ResponseStreamEventName.Web_Search_Call.Searching: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamWebSearchCall>(this.Data)!;
            case ResponseStreamEventName.Web_Search_Call.Completed: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamWebSearchCall>(this.Data)!;
            case ResponseStreamEventName.Reasoning_Summary_Part.Added: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamReasoningSummaryPart>(this.Data)!;
            case ResponseStreamEventName.Reasoning_Summary_Part.Done: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamReasoningSummaryPart>(this.Data)!;
            case ResponseStreamEventName.Reasoning_Summary_Text.Delta: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamReasoningSummaryTextDelta>(this.Data)!;
            case ResponseStreamEventName.Reasoning_Summary_Text.Done: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamReasoningSummaryTextDone>(this.Data)!;
            case ResponseStreamEventName.Image_Generation_Call.Generating: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamImageGenerationCall>(this.Data)!;
            case ResponseStreamEventName.Image_Generation_Call.In_Progress: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamImageGenerationCall>(this.Data)!;
            case ResponseStreamEventName.Image_Generation_Call.Completed: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamImageGenerationCall>(this.Data)!;
            case ResponseStreamEventName.Image_Generation_Call.Partial_Image: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamImageGenerationCallPartialImage>(this.Data)!;
            case ResponseStreamEventName.Mcp_Call.Arguments.Delta: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamMcpCallArgumentsDelta>(this.Data)!;
            case ResponseStreamEventName.Mcp_Call.Arguments.Done: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamMcpCallArgumentsDone>(this.Data)!;
            case ResponseStreamEventName.Mcp_Call.In_Progress: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamMcpCallArgumentsInProgress>(this.Data)!;
            case ResponseStreamEventName.Mcp_Call.Completed: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamMcpCallArguments>(this.Data)!;
            case ResponseStreamEventName.Mcp_Call.Failed: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamMcpCallArguments>(this.Data)!;
            case ResponseStreamEventName.Mcp_List_Tools.In_Progress: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamMcpListTools>(this.Data)!;
            case ResponseStreamEventName.Mcp_List_Tools.Completed: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamMcpListTools>(this.Data)!;
            case ResponseStreamEventName.Mcp_List_Tools.Failed: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamMcpListTools>(this.Data)!;
            case ResponseStreamEventName.Output_Text_Annotation.Added: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamOutputTextAnnotationAdded>(this.Data)!;
            case ResponseStreamEventName.Reasoning.Delta: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamReasoningDelta>(this.Data)!;
            case ResponseStreamEventName.Reasoning.Done: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamReasoningDone>(this.Data)!;
            case ResponseStreamEventName.Reasoning_Summary.Delta: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamReasoningSummaryDelta>(this.Data)!;
            case ResponseStreamEventName.Reasoning_Summary.Done: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamReasoningSummaryDone>(this.Data)!;
            case ResponseStreamEventName.Error: return OpenAIClient.JsonConverter.DeserializeObject<ResponseStreamError>(this.Data)!;
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
public interface IResponseStreamEventDelta
{
    string Delta { get; }
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
public class ResponseStreamOutputTextDelta : IResponseStreamEvent, IResponseStreamEventDelta
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
public class ResponseStreamRefusal : IResponseStreamEvent, IResponseStreamEventDelta
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

public class ResponseStreamFunctionCallArguments : IResponseStreamEvent, IResponseStreamEventDelta
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
public class ResponseStreamReasoningSummaryTextDelta : IResponseStreamEvent, IResponseStreamEventDelta
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
public class ResponseStreamReasoningDelta : IResponseStreamEvent, IResponseStreamEventDelta
{
    public string Type { get; set; } = "";
    public string Item_Id { get; set; } = "";
    public int Output_Index { get; set; }
    public int Content_Index { get; set; }
    public ReasoningDelta Delta { get; set; } = new();
    string IResponseStreamEventDelta.Delta
    {
        get { return this.Delta.Text; }
    }
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
public class ResponseStreamReasoningSummaryDelta : IResponseStreamEvent, IResponseStreamEventDelta
{
    public string Type { get; set; } = "";
    public string Item_Id { get; set; } = "";
    public int Output_Index { get; set; }
    public int Summary_Index { get; set; }
    public ReasoningDelta Delta { get; set; } = new();
    string IResponseStreamEventDelta.Delta
    {
        get { return this.Delta.Text; }
    }
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