﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public class AdminApiKeyObject
{
    public string Id { get; set; } = "";
    public string Object { get; set; } = "";
    public string Name { get; set; } = "";
    public string Redacted_Value { get; set; } = "";
    public Int64 Created_At { get; set; }
    public DateTimeOffset CreateTime
    {
        get
        {
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created_At), TimeSpan.Zero);
        }
    }
    public AdminApiKeyOwner? Owner { get; set; }
}
public class AdminApiKeyObjectResponse : RestApiResponse
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string Redacted_Value { get; set; } = "";
    public Int64 Created_At { get; set; }
    public DateTimeOffset CreateTime
    {
        get
        {
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created_At), TimeSpan.Zero);
        }
    }
    public AdminApiKeyOwner? Owner { get; set; }
}
