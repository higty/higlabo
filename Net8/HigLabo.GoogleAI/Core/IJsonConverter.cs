﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.GoogleAI;

public interface IJsonConverter
{
    string SerializeObject(object obj);
    T DeserializeObject<T>(String json);
}
