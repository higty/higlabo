using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core;

public class StringLengthInputValidator : InputValidator
{
    public int? MinLength { get; set; }
    public int? MaxLength { get; set; }

    public StringLengthInputValidator(string message, int? minLength, int? maxLength)
    {
        this.Message = message;
        this.MinLength = minLength;
        this.MaxLength = maxLength;
    }

    public override InputValidateResult Validate(string? value)
    {
        if (value == null) { return new InputValidateResult(false, this.Message); }
        if (value.Length < this.MinLength) { return new InputValidateResult(false, this.Message); }
        if (value.Length > this.MaxLength) { return new InputValidateResult(false, this.Message); }
        return new InputValidateResult(true, this.Message);
    }
}
