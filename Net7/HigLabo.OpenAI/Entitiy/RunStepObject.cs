using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HigLabo.OpenAI.RunStepObject;

namespace HigLabo.OpenAI
{
    public class RunStepObject
    {
        public class StepDetail
        {
            public string Type { get; set; } = "";
            public MessageCreation? Message_Creation { get; set; }
        }
        public class MessageCreation
        {
            public string Message_Id { get; set; } = "";
        }
        public class ToolCal
        {
            public string Id { get; set; } = "";
            public string Type { get; set; } = "";
            public CodeInterpreter? Code_Interpreter { get; set; }
        }
        public class CodeInterpreter
        {
            public string Input { get; set; } = "";
        }
        public class CodeInterpreterOutput
        {
            public string Type { get; set; } = "";
            public string Logs { get; set; } = "";
            public CodeInterpreterImageOutput? Image { get; set; }
        }
        public class CodeInterpreterImageOutput
        {
            public string File_Id { get; set; } = "";
        }
        public class RunStepRetrievalToolCall
        {
            public string Id { get; set; } = "";
            public string Type { get; set; } = "";
            public Object? Retrieval { get; set; }
        }
        public class RunStepFunctionCall
        {
            public string Id { get; set; } = "";
            public string Type { get; set; } = "";
            public RunStepFunction? Function { get; set; }
        }
        public class RunStepFunction
        {
            public string Name { get; set; } = "";
            public string Arguments { get; set; } = "";
            public string? Output { get; set; }
        }
        public class RunStepError
        {
            public string Code { get; set; } = "";
            public string Message { get; set; } = "";
        }
        public string Id { get; set; } = "";
        public string Object { get; set; } = "";
        public Int64 Created_At { get; set; }
        public DateTimeOffset CreateTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created_At), TimeSpan.Zero);
            }
        }
        public string Assistant_Id { get; set; } = "";
        public string Thread_Id { get; set; } = "";
        public string Run_Id { get; set; } = "";
        public string Type { get; set; } = "";
        public string Status { get; set; } = "";
        public StepDetail? Step_details { get; set; }
        public RunStepError? Last_Error { get; set; }

        public Int64 Expires_At { get; set; }
        public DateTimeOffset ExpireTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Expires_At), TimeSpan.Zero);
            }
        }
        public Int64 Cancelled_At { get; set; }
        public DateTimeOffset CancelTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Cancelled_At), TimeSpan.Zero);
            }
        }
        public Int64 Failed_At { get; set; }
        public DateTimeOffset FailTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Failed_At), TimeSpan.Zero);
            }
        }
        public Int64 Completed_At { get; set; }
        public DateTimeOffset CompleteTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Completed_At), TimeSpan.Zero);
            }
        }
        public string? MetaData { get; set; }
    }
    public class RunStepObjectResponse: RestApiResponse
    {
        public string Id { get; set; } = "";
        public Int64 Created_At { get; set; }
        public DateTimeOffset CreateTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created_At), TimeSpan.Zero);
            }
        }
        public string Assistant_Id { get; set; } = "";
        public string Thread_Id { get; set; } = "";
        public string Run_Id { get; set; } = "";
        public string Type { get; set; } = "";
        public string Status { get; set; } = "";
        public StepDetail? Step_details { get; set; }
        public RunStepError? Last_Error { get; set; }

        public Int64 Expires_At { get; set; }
        public DateTimeOffset ExpireTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Expires_At), TimeSpan.Zero);
            }
        }
        public Int64 Cancelled_At { get; set; }
        public DateTimeOffset CancelTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Cancelled_At), TimeSpan.Zero);
            }
        }
        public Int64 Failed_At { get; set; }
        public DateTimeOffset FailTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Failed_At), TimeSpan.Zero);
            }
        }
        public Int64 Completed_At { get; set; }
        public DateTimeOffset CompleteTime
        {
            get
            {
                return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Completed_At), TimeSpan.Zero);
            }
        }
        public string? MetaData { get; set; }
    }
}
