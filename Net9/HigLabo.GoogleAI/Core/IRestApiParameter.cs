﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.GoogleAI;

public interface IRestApiParameter
{
    string GetApiPath();
    string HttpMethod { get; }
}
