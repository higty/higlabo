using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core;

public class DateTimeInputValidator : InputValidator
{
    public DateTime? MinValue { get; set; }
    public DateTime? MaxValue { get; set; }

    public DateTimeInputValidator(string message)
    {
        this.Message = message;
    }
    public DateTimeInputValidator(string message, DateTime? minValue, DateTime? maxValue)
    {
        this.Message = message;
        this.MinValue = minValue;
        this.MaxValue = maxValue;
    }
    public override InputValidateResult Validate(string? value)
    {
        if (value == null) { return new InputValidateResult(false, this.Message); }
        var v = value.ToDateTime();
        if (v == null) { return new InputValidateResult(false, this.Message); }
        if (v < MinValue) { return new InputValidateResult(false, this.Message); }
        if (v > MaxValue) { return new InputValidateResult(false, this.Message); }
        return new InputValidateResult(true, this.Message);
    }
}
