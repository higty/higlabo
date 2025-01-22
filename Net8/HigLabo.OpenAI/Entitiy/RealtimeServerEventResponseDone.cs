using System;
using System.Collections.Generic;

namespace HigLabo.OpenAI;
public class RealtimeServerEventResponseDone
{
    public string? Event_Id { get; set; } = null;
    public string? Type { get; set; } = null;
    public ResponseData? Response { get; set; } = null;

    public class ResponseData
    {
        public string? Id { get; set; } = null;
        public string? Object { get; set; } = null;
        public string? Status { get; set; } = null;
        public StatusDetails? Status_Details { get; set; } = null;
        public List<OutputItem>? Output { get; set; } = null;
        public UsageData? Usage { get; set; } = null;
    }

    public class StatusDetails
    {
        public string? Type { get; set; } = null;
        public string? Reason { get; set; } = null;
        public ErrorDetails? Error { get; set; } = null;
    }

    public class ErrorDetails
    {
        public string? Message { get; set; } = null;
        public string? Code { get; set; } = null;
    }

    public class OutputItem
    {
        public string? Id { get; set; } = null;
        public string? Object { get; set; } = null;
        public string? Type { get; set; } = null;
        public string? Status { get; set; } = null;
        public string? Role { get; set; } = null;
        public List<ContentItem>? Content { get; set; } = null;
        public string? Call_Id { get; set; } = null;
        public string? Name { get; set; } = null;
        public string? Arguments { get; set; } = null;
        public string? Output { get; set; } = null;
        public Dictionary<string, string>? Metadata { get; set; } = null;
    }

    public class ContentItem
    {
        public string? Type { get; set; } = null;
        public string? Text { get; set; } = null;
    }

    public class UsageData
    {
        public int? Total_Tokens { get; set; } = null;
        public int? Input_Tokens { get; set; } = null;
        public int? Output_Tokens { get; set; } = null;
        public TokenDetails? Input_Token_Details { get; set; } = null;
        public TokenDetails? Output_Token_Details { get; set; } = null;
    }

    public class TokenDetails
    {
        public int? Cached_Tokens { get; set; } = null;
        public int? Text_Tokens { get; set; } = null;
        public int? Audio_Tokens { get; set; } = null;
        public CachedTokensDetails? Cached_Tokens_Details { get; set; } = null;
    }

    public class CachedTokensDetails
    {
        public int? Text_Tokens { get; set; } = null;
        public int? Audio_Tokens { get; set; } = null;
    }
}