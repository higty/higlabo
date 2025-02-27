﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core;

public interface IInputValidator
{
    string Message { get; }
    InputValidateResult Validate(string? value);
}
