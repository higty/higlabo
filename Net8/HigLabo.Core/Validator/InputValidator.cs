using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public abstract class InputValidator : IInputValidator
    {
        public string Message { get; set; } = "";
        public abstract InputValidateResult Validate(string? value);
    }
}
