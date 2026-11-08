Release note
2026-11-07 updated. Added GPT-6.1 Terra, GPT-6 Cyber/Rosalind and GPT Image 2.6 model constants; current Responses and image API options; compaction, token counting and response cancellation; JSON image editing; 12-hour cache pricing.
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

## API updates checked on 2026-11-07

The active implementation is under `Net9/HigLabo.OpenAI` and targets .NET 8, 9 and 10. Earlier framework copies are not updated by this change.

- `ResponseCompactAsync` calls `POST /responses/compact`. Preserve its entire output window with `ResponseInput.FromItems(compacted.Output)` before the next request. This retains encrypted compaction items, messages and unknown fields.
- `ResponseInputTokensAsync` calls `POST /responses/input_tokens` without generating a response.
- `ResponseCancelAsync` returns the cancelled response. The existing `ResponseCcancelAsync` spelling remains available and now also exposes the response body.
- `ResponseCreateParameter` supports `Context_Management`, image context compression, Cyber access programs and object-valued tool choices. Cache diagnostics, background/completion metadata, root-level function calls and encrypted reasoning/compaction items are available in response models.
- Tool models include namespaces, tool search, custom, computer, shell, apply-patch and image-generation tools. Function tools support deferred loading, asynchronous calls, allowed callers and output schemas.
- Chat Completions supports prompt-cache options/retention and object-valued tool choices. Service tiers remain strings, including `ultrafast` where the selected model supports it.

`Tool_Choice` is now `object?` in Responses and Chat Completions. Existing string assignments such as `"auto"` remain valid; code reading it into a string must cast or pattern-match. `ResponseStreamOutputItem.OutputItem.Pending_Safety_Checks` is now a list, matching the API's array. Recompile consumers against these updated public types.

```csharp
var compacted = await client.ResponseCompactAsync(new ResponseCompactParameter
{
    Model = ModelNames.Gpt_6_1_Terra,
    Input = previousInput,
});
var next = new ResponseCreateParameter
{
    Model = ModelNames.Gpt_6_1_Terra,
    Input = ResponseInput.FromItems(compacted.Output),
    Context_Management = new() { new() { Compact_Threshold = 200_000 } },
    Prompt_Cache_Options = new() { Ttl = "12h" },
};
next.AddUserMessage("Continue the task.");
var response = await client.ResponseCreateAsync(next);
```

GPT Image 2.6 requests support `Complexity`, `Frame_Count`, `Frame_Duration_Ms` and `Svg`. Use `Output_Format = "gif"` for animations or `"svg"` for SVG; model/project access and format-specific restrictions apply. Use `ImagesEditsJsonParameter` to edit image URLs, data URLs or uploaded file IDs, with optional `Markup` or `Mask`. Existing multipart editing supports uploaded `Markup` as well.

```csharp
var edited = await client.ImagesEditsAsync(new ImagesEditsJsonParameter
{
    Model = ModelNames.Gpt_Image_2_6_Sunburst,
    Prompt = "Follow the marked areas.",
    Images = new() { new() { File_Id = "file_uploaded_image" } },
    Markup = new() { Image_Url = "https://example.com/markup.png" },
    Complexity = "high",
});
```

`ModelNames.CalculateCost(model, usage, "12h")` uses 12-hour cache-write rates. The existing overload assumes `30m`. GPT-6.1 Terra and current GPT-5.6 Terra/Luna standard text rates are included, with long-context adjustments for the documented GPT-5.4/5.5/5.6/6 models. Service tiers, pro mode, regional surcharges, tools and non-text charges require separate accounting. Cyber/Rosalind and new image model constants do not imply account access or a text-price estimate.

This update covers the existing Responses, Chat Completions and image REST/SSE surfaces. Dedicated Agents, Live and Decisions clients and Responses WebSocket transport are not implemented.

Official references:

- [API changelog](https://developers.openai.com/api/docs/changelog)
- [Responses create](https://developers.openai.com/api/reference/resources/responses/methods/create)
- [Compaction](https://developers.openai.com/api/docs/guides/compaction)
- [Input token counts](https://developers.openai.com/api/reference/resources/responses/subresources/input_tokens/methods/count)
- [Image generation](https://developers.openai.com/api/reference/resources/images/methods/generate)
- [Image editing](https://developers.openai.com/api/reference/resources/images/methods/edit)
- [Pricing](https://developers.openai.com/api/docs/pricing)

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

`CalculateCost(model, usage)` estimates standard text-token costs in USD. Named GPT-6 models use long-context rates above 272,000 input tokens. Responses estimates include GPT-5.6/GPT-6 cache writes; Chat Completions estimates now discount cached input. GPT-5.6 Sol uses the current standard rate checked on 2026-11-07. Other existing model prices were not fully refreshed. Service tiers, regional surcharges, tools and audio/image/session charges need separate accounting. New image and Live constants return `null` from this text-token estimator. The explicit-price Responses overload accepts a fifth `cacheWritePrice` argument; the original overload retains its historical cache-write rate.

Official references checked 2026-09-30:

- [API changelog](https://developers.openai.com/api/docs/changelog)
- [Model guidance](https://developers.openai.com/api/docs/guides/latest-model)
- [Reasoning](https://developers.openai.com/api/docs/guides/reasoning)
- [Prompt caching](https://developers.openai.com/api/docs/guides/prompt-caching)
- [Pricing](https://developers.openai.com/api/docs/pricing)

Run regression tests from the repository root with `dotnet test Net9/HigLabo.OpenAI.Test/HigLabo.OpenAI.Test.csproj`. Tests use a local HTTP handler and do not call the paid API.


