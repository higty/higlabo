using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core;

public class DateOnlyInputValidator : InputValidator
{
    public DateOnly? MinValue { get; set; }
    public DateOnly? MaxValue { get; set; }

    public DateOnlyInputValidator(string message)
    {
        this.Message = message;
    }
    public DateOnlyInputValidator(string message, DateOnly? minValue, DateOnly? maxValue)
    {
        this.Message = message;
        this.MinValue = minValue;
        this.MaxValue = maxValue;
    }
    public override InputValidateResult Validate(string? value)
    {
        if (value == null) { return new InputValidateResult(false, this.Message); }
        var v = value.ToDateOnly();
        if (v == null) { return new InputValidateResult(false, this.Message); }
        if (v < MinValue) { return new InputValidateResult(false, this.Message); }
        if (v > MaxValue) { return new InputValidateResult(false, this.Message); }
        return new InputValidateResult(true, this.Message);
    }
}
