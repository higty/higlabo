using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    public class OpenAIServerError
    {
        public string Code { get; set; } = "";
        public string Message { get; set; } = "";
        public string Param { get; set; } = "";
        public string Type { get; set; } = "";
    }
    public class OpenAIServerErrorResponse
    {
        public OpenAIServerError Error { get; set; } = new();
    }
    public class OpenAIServerException : Exception
    {
        public string RawJson { get; set; } = "";
        public OpenAIServerError Error { get; set; }

        public OpenAIServerException(string rawJson, OpenAIServerError error)
            : base(error.Message)
        {
            this.RawJson = rawJson;
            this.Error = error;
        }
    }
}
