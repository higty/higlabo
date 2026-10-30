How to use?
Download via Nuget search by HigLabo.Anthropic

All source code is 
https://github.com/higty/higlabo/tree/master/Net9

HigLabo.Anthropic is that.

You can see sample code at
https://github.com/higty/higlabo/blob/master/Net9/HigLabo.Anthropic.SampleConsoleApp/AnthropicClientPlayground.cs

Nuget: HigLabo.Anthropic

## API version 2026-10-21

Version 10.2.0.0 targets API version `2026-10-21` by default and supports .NET 8, 9, and 10.

```csharp
var client = new AnthropicClient(apiKey);
var parameter = new MessagesParameter { Model = ModelNames.ClaudeSonnet4_6, Max_Tokens = 1024 };
parameter.AddUserMessage("Hello, Claude");
var response = await client.MessagesAsync(parameter);
```

Migration from earlier HigLabo.Anthropic versions:

- Remove assignments to `MessagesParameter.Temperature`, `Top_P`, and `Top_K`. These properties and JSON fields are removed; the API rejects even their former defaults.
- For custom `IChatMessage` blocks, put documents in user messages. Direct assistant documents return HTTP 400; nested tool-result documents remain accepted.
- Remove non-empty text `citations` arrays from user messages, including search results. Assistant citations and document/search-result `citations: { enabled: true }` remain accepted. The server validates these restrictions.
- `AnthropicSettings.BetaVersion` now defaults to empty. Stable tools need no beta header. Set it explicitly for beta features.

`AnthropicSettings.Version` still accepts an explicit version. For non-default sampling, keep the previous library and API `2023-06-01`.

Authentication retains the accepted `x-api-key` header. Official SDK, Admin API, and Enterprise Analytics changes do not affect this library.

See the [official migration guide](https://platform.claude.com/docs/en/api/migration-2026-10-21).

Run the HTTP contract tests (no API key or network requests required):

```powershell
dotnet test Net9/HigLabo.Anthropic.Test/HigLabo.Anthropic.Test.csproj
```
