using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class Int32InputValidator : InputValidator
    {
        public int? MinValue { get; set; }
        public int? MaxValue { get; set; }

        public Int32InputValidator(string message)
        {
            this.Message = message;
        }
        public Int32InputValidator(string message, int? minValue, int? maxValue)
        {
            this.Message = message;
            this.MinValue = minValue;
            this.MaxValue = maxValue;
        }
        public override InputValidateResult Validate(string? value)
        {
            if (value == null) { return new InputValidateResult(false, this.Message); }
            var v = value.ToInt32();
            if (v == null) { return new InputValidateResult(false, this.Message); }
            if (v < MinValue) { return new InputValidateResult(false, this.Message); }
            if (v > MaxValue) { return new InputValidateResult(false, this.Message); }
            return new InputValidateResult(true, this.Message);
        }
    }
}
