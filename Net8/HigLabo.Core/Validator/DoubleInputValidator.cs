using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class DoubleInputValidator : InputValidator
    {
        public double? MinValue { get; set; }
        public double? MaxValue { get; set; }

        public DoubleInputValidator(string message)
        {
            this.Message = message;
        }
        public DoubleInputValidator(string message, double? minValue, double? maxValue)
        {
            this.Message = message;
            this.MinValue = minValue;
            this.MaxValue = maxValue;
        }
        public override InputValidateResult Validate(string? value)
        {
            if (value == null) { return new InputValidateResult(false, this.Message); }
            var v = value.ToDouble();
            if (v == null) { return new InputValidateResult(false, this.Message); }
            if (v < MinValue) { return new InputValidateResult(false, this.Message); }
            if (v > MaxValue) { return new InputValidateResult(false, this.Message); }
            return new InputValidateResult(true, this.Message);
        }
    }
}
