using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class ValidationResult
    {
        public const String SummaryMessage = "SummaryMessage";

        public String Name { get; set; }
        public String Message { get; set; }
        public Object Value { get; set; }

        public ValidationResult() { }
        public ValidationResult(String name, String message)
        {
            this.Name = name;
            this.Message = message;
        }
        public ValidationResult(String name, String message, Object value)
        {
            this.Name = name;
            this.Message = message;
            this.Value = value;
        }
        public override string ToString()
        {
            return this.Message;
        }
    }
}
