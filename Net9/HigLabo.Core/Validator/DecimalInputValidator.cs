using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core;

public class DecimalInputValidator : InputValidator
{
    public decimal? MinValue { get; set; }
    public decimal? MaxValue { get; set; }

    public DecimalInputValidator(string message)
    {
        this.Message = message;
    }
    public DecimalInputValidator(string message, decimal? minValue, decimal? maxValue)
    {
        this.Message = message;
        this.MinValue = minValue;
        this.MaxValue = maxValue;
    }
    public override InputValidateResult Validate(string? value)
    {
        if (value == null) { return new InputValidateResult(false, this.Message); }
        var v = value.ToDecimal();
        if (v == null) { return new InputValidateResult(false, this.Message); }
        if (v < MinValue) { return new InputValidateResult(false, this.Message); }
        if (v > MaxValue) { return new InputValidateResult(false, this.Message); }
        return new InputValidateResult(true, this.Message);
    }
}
