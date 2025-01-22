using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core;

public class TimeOnlyInputValidator : InputValidator
{
    public TimeOnly? MinValue { get; set; }
    public TimeOnly? MaxValue { get; set; }

    public TimeOnlyInputValidator(string message)
    {
        this.Message = message;
    }
    public TimeOnlyInputValidator(string message, TimeOnly? minValue, TimeOnly? maxValue)
    {
        this.Message = message;
        this.MinValue = minValue;
        this.MaxValue = maxValue;
    }
    public override InputValidateResult Validate(string? value)
    {
        if (value == null) { return new InputValidateResult(false, this.Message); }
        var v = value.ToTimeOnly();
        if (v == null) { return new InputValidateResult(false, this.Message); }
        if (v < MinValue) { return new InputValidateResult(false, this.Message); }
        if (v > MaxValue) { return new InputValidateResult(false, this.Message); }
        return new InputValidateResult(true, this.Message);
    }
}
