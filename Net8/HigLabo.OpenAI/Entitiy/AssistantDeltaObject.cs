using System.Text;

namespace HigLabo.OpenAI
{
    public class AssistantDeltaObject
    {
        public string Id { get; set; } = "";
        public string Object { get; set; } = "";
        public AssistantDelta Delta { get; set; } = new();

        public class AssistantDelta
        {
            public string Role { get; set; } = "";
            public List<Message> Content { get; set; } = new();
            public List<string>? FileId { get; set; }
            public RunStep? Step_Details { get; set; } 
        }
        public class Message
        {
            public int Index { get; set; }
            public string Type { get; set; } = "";
            public MessageText Text { get; set; } = new();
        }
        public class MessageText
        {
            public string Value { get; set; } = "";
            public Annotation[]? Annotations { get; set; }

            public override string ToString()
            {
                return this.Value;
            }
        }
		public class Annotation
		{
			public int Index { get; set; }
			public string Type { get; set; } = "";
			public string Text { get; set; } = "";
			public string Start_Index { get; set; } = "";
			public string End_Index { get; set; } = "";
			public FileCitation File_Citation { get; set; } = new();
		}
		public class FileCitation
		{
			public string File_Id { get; set; } = "";
			public string Quote { get; set; } = "";
		}

		public class RunStep
        {
            public string Type { get; set; } = "";
            public MessageCreation? Message_Creation { get; set; }
            public List<ToolCall>? Tool_Calls { get; set; }
        }
        public class MessageCreation
        {
            public string Message_Id { get; set; } = "";

        }
        public class ToolCall
        {
            public int Index { get; set; }
            public string Id { get; set; } = "";
            public string Type { get; set; } = "";
            public CodeInterpreter? Code_Interpreter { get; set; } 
        }
        public class CodeInterpreter
        {
            public string Input { get; set; } = "";
            public List<string>? Outputs { get; set; }
        }

        public override string ToString()
        {
            return this.Delta?.Content.FirstOrDefault()?.Text.Value ?? this.Id;
        }
    }
}
