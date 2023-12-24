using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class InputValidateResult
    {
        public bool Valid { get; set; } = true;
        public string Message { get; set; } = "";

        public InputValidateResult(bool valid)
            : this(valid, "")
        {
        }
        public InputValidateResult(bool valid, string message)
        {
            Valid = valid;
            Message = message;
        }

        public static implicit operator bool(InputValidateResult inputValidateResult)
        {
            return inputValidateResult.Valid;
        }
    }
}
