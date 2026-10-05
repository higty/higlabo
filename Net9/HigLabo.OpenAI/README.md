Release note
2026-09-30 updated. Added current model names, Responses reasoning/cache controls, configuration updates and cache-aware token cost estimates.
2025-03-14 Support Responses API endpoint, and web search, file search and more.
※Breaking change. The endpoint of ChatCompletions are all changed to ChatCompletionCreate. Please see latest sample code. https://github.com/higty/higlabo/blob/master/Net9/HigLabo.OpenAI.SampleConsoleApp/OpenAIPlayground.cs
2025-10-08 updated. Support video generation by Sora2.
2025-08-24 updated. Support conversation, eval, certificate endpoints.

You can see sample code with latest library at
https://github.com/higty/higlabo/blob/master/Net9/HigLabo.OpenAI.SampleConsoleApp/OpenAIPlayground.cs

How to use?
Download via Nuget. Please search by HigLabo.OpenAI

All source code is 
https://github.com/higty/higlabo
Search HigLabo.OpenAI in this repository.

## Current Responses API options

```csharp
var parameter = new ResponseCreateParameter
{
    Model = ModelNames.Gpt_6_1_Sol,
    Reasoning = new Reasoning { Effort = "medium", Context = "all_turns" },
    Prompt_Cache_Options = new PromptCacheOptions { Mode = "implicit", Ttl = "30m" },
};
parameter.AddUserMessage("Review this migration plan.");
var response = await client.ResponseCreateAsync(parameter);

var next = new ResponseCreateParameter
{
    Model = parameter.Model,
    Previous_Response_Id = response.Id,
    Reasoning = parameter.Reasoning,
};
next.AddConfigurationUpdate("high");
next.AddUserMessage("Analyze the failure modes.");
var followUp = await client.ResponseCreateAsync(next);
```

Set `Reasoning.Mode = "pro"` for supported models. Configuration updates apply only to standard, single-agent GPT-6 requests; do not combine them with pro mode, automatic compaction/truncation, or adjacent updates. Add the update before the next user message.

For explicit caching, use `Prompt_Cache_Options.Mode = "explicit"` and assign a `PromptCacheBreakpoint` to the last reusable content's `Prompt_Cache_Breakpoint`. `Prewarm = true` prepares the cache without output. Older models can use `Prompt_Cache_Retention` instead. Unset optional fields are omitted.

New constants include GPT-6.1 Sol, GPT-6 Sol/Luna, GPT Image 2.5 Sunburst/Flare, GPT-Realtime 2.1/Mini, GPT-Audio 1.5, and GPT-Live 1. Constants do not imply transport support: GPT-Live sessions and the Agents API are not implemented by this update. Image 2.5 works with the existing image endpoints; their `Quality` string accepts `xhigh` or `max`.

`CalculateCost(model, usage)` estimates standard text-token costs in USD. Named GPT-6 models use long-context rates above 272,000 input tokens. Responses estimates include GPT-5.6/GPT-6 cache writes; Chat Completions estimates now discount cached input. GPT-5.6 Sol uses the promotion documented on 2026-09-30. Other existing model prices were not fully refreshed. Service tiers, regional surcharges, tools and audio/image/session charges need separate accounting. New image and Live constants return `null` from this text-token estimator. The explicit-price Responses overload accepts a fifth `cacheWritePrice` argument; the original overload retains its historical cache-write rate.

Official references checked 2026-09-30:

- [API changelog](https://developers.openai.com/api/docs/changelog)
- [Model guidance](https://developers.openai.com/api/docs/guides/latest-model)
- [Reasoning](https://developers.openai.com/api/docs/guides/reasoning)
- [Prompt caching](https://developers.openai.com/api/docs/guides/prompt-caching)
- [Pricing](https://developers.openai.com/api/docs/pricing)

Run regression tests from the repository root with `dotnet test Net9/HigLabo.OpenAI.Test/HigLabo.OpenAI.Test.csproj`. Tests use a local HTTP handler and do not call the paid API.


