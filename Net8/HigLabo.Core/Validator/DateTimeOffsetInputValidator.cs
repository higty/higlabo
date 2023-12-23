using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class DateTimeOffsetInputValidator : InputValidator
    {
        public DateTimeOffset? MinValue { get; set; }
        public DateTimeOffset? MaxValue { get; set; }

        public DateTimeOffsetInputValidator(string message)
        {
            this.Message = message;
        }
        public DateTimeOffsetInputValidator(string message, DateTimeOffset? minValue, DateTimeOffset? maxValue)
        {
            this.Message = message;
            this.MinValue = minValue;
            this.MaxValue = maxValue;
        }
        public override InputValidateResult Validate(string? value)
        {
            if (value == null) { return new InputValidateResult(false, this.Message); }
            var v = value.ToDateTimeOffset();
            if (v == null) { return new InputValidateResult(false, this.Message); }
            if (v < MinValue) { return new InputValidateResult(false, this.Message); }
            if (v > MaxValue) { return new InputValidateResult(false, this.Message); }
            return new InputValidateResult(true, this.Message);
        }
    }
}
