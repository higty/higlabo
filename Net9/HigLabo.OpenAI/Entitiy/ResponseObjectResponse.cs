using System.Globalization;

namespace HigLabo.OpenAI;

public class ResponseObject
{
    public Int64 Created_At { get; set; }
    public DateTimeOffset CreateTime
    {
        get
        {
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created_At), TimeSpan.Zero);
        }
    }
    public OpenAIServerError? Error { get; set; }
    public string Id { get; set; } = "";
    public IncompleteDetails? Incomplete_Details { get; set; }
    public string? Instructions { get; set; }
    public int? Max_Output_Tokens { get; set; }
    public object? MetaData { get; set; }
    public string Model { get; set; } = "";
    public List<ResponseOutput> Output { get; set; } = new();
    public string? Output_Text { get; set; }
    public bool Parallel_Tool_Calls { get; set; }
    public string? Previous_Response_Id { get; set; }
    public Reasoning? Reasoning { get; set; }
    public string Status { get; set; } = "";
    public float? Temperature { get; set; }
    public object? Text { get; set; }
    public object? ToolChoice { get; set; }
    public List<ToolCall>? Tools { get; set; }
    public float? Top_P { get; set; }
    public string? Truncation { get; set; }
    public ResponseUsageResult Usage { get; set; } = new();
    public string User { get; set; } = "";
}
public class ResponseObjectResponse : RestApiResponse
{
    public Int64 Created_At { get; set; }
    public DateTimeOffset CreateTime
    {
        get
        {
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created_At), TimeSpan.Zero);
        }
    }
    public OpenAIServerError? Error { get; set; }
    public string Id { get; set; } = "";
    public IncompleteDetails? Incomplete_Details { get; set; }
    public string? Instructions { get; set; }
    public int? Max_Output_Tokens { get; set; }
    public object? MetaData { get; set; }
    public string Model { get; set; } = "";
    public List<ResponseOutput> Output { get; set; } = new();
    public string? Output_Text { get; set; }
    public bool Parallel_Tool_Calls { get; set; }
    public string? Previous_Response_Id { get; set; }
    public Reasoning? Reasoning { get; set; }
    public string Status { get; set; } = "";
    public float? Temperature { get; set; }
    public object? Text { get; set; }
    public object? ToolChoice { get; set; }
    public List<ToolCall>? Tools { get; set; }
    public float? Top_P { get; set; }
    public string? Truncation { get; set; }
    public ResponseUsageResult Usage { get; set; } = new();
    public string User { get; set; } = "";
}
public class IncompleteDetails
{
    public string Reason { get; set; } = "";

    public override string ToString()
    {
        return this.Reason;
    }
}
public class ResponseOutput
{
    public string Type { get; set; } = "";
    public string Id { get; set; } = "";
    public string Status { get; set; } = "";
    public string Role { get; set; } = "";
    public List<string>? Queries { get; set; }
    public List<ResponseOutputContent> Content { get; set; } = new();
    //Image generation
    public string Background { get; set; } = "";
    public string Output_Format { get; set; } = "";
    public string Quality { get; set; } = "";
    public string Result { get; set; } = "";
    public string Revised_Prompt { get; set; } = "";
    public string Size { get; set; } = "";


    public override string ToString()
    {
        if (this.Type == "web_search_call") { return this.Type; }
        if (this.Type == "message") { return $"{this.Type} {this.Role}"; }
        return $"{this.Type} {this.Role}".Trim();
    }
}
public class ResponseOutputContent
{
    public class Annotation
    {
        public string Type { get; set; } = "";
        //FileCitation
        public string File_Id { get; set; } = "";
        public int Index { get; set; }
        //UrlCitation
        public int Start_Index { get; set; }
        public int End_Index { get; set; }
        public string Title { get; set; } = "";
        public string Url { get; set; } = "";
        //FilePath

        public override string ToString()
        {
            switch (this.Type)
            {
                case "url_citation": return $"{this.Title} {this.Url}";
                case "file_citation": return $"{this.File_Id}";
                case "file_path": return $"{this.File_Id}";
                default: return this.Type;
            }
        }
    }
    public class ComputerUseAction
    {
        public string Type { get; set; } = "";
        public string? Button { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public List<PathPosition>? Path { get; set; }
        public List<string>? Keys { get; set; }
        public int Scroll_X { get; set; }
        public int Scroll_Y { get; set; }
        public string? Text { get; set; }

        public override string ToString()
        {
            return this.Type;
        }
    }
    public class PathPosition
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return $"{this.X},{this.Y}";
        }
    }
    public class PendingSafetyCheck
    {
        public string Code { get; set; } = "";
        public string Id { get; set; } = "";
        public string Message { get; set; } = "";

        public override string ToString()
        {
            return this.Message;
        }
    }
    public class ReasoningSummary
    {
        public string Text { get; set; } = "";
        public string Type { get; set; } = "";

        public override string ToString()
        {
            return this.Text;
        }
    }

    public string Type { get; set; } = "";
    public string Text { get; set; } = "";
    public string Id { get; set; } = "";
    public string Status { get; set; } = "";

    public string Call_Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string Arguments { get; set; } = "";

    public List<Annotation>? Annotations { get; set; }
    public List<string>? Queries { get; set; }
    public ComputerUseAction? Action { get; set; }
    public List<PendingSafetyCheck>? Pending_Safety_Checks { get; set; }
    public List<ReasoningSummary>? Summary { get; set; }

    public override string ToString()
    {
        return $"{this.Type} {this.Text}";
    }
}
