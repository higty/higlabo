using System.Net;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace HigLabo.OpenAI.Test;

[TestClass]
public class ResponsesTests
{
    [TestMethod]
    public async Task SendsCurrentOptionsAndReadsUsageThroughHttpClient()
    {
        using var handler = new ResponseHandler();
        using var httpClient = new HttpClient(handler);
        var client = new OpenAIClient("test-key", httpClient);
        var parameter = new ResponseCreateParameter
        {
            Model = ModelNames.Gpt_6_1_Sol,
            Reasoning = new() { Effort = "high", Mode = "pro", Context = "all_turns" },
            Prompt_Cache_Options = new() { Mode = "explicit", Ttl = "30m", Prewarm = false },
            Service_Tier = "default",
        };
        parameter.AddMessage(ResponseInputRole.Developer, "Shared reference material");
        parameter.Input![0].Content[0].Prompt_Cache_Breakpoint = new();
        parameter.AddUserMessage("Review the plan");

        var response = await client.ResponseCreateAsync(parameter);
        var sent = handler.Body!;
        Assert.AreEqual("https://api.openai.com/v1/responses", handler.Url);
        Assert.AreEqual("gpt-6.1-sol", (string?)sent["model"]);
        Assert.AreEqual("pro", (string?)sent["reasoning"]?["mode"]);
        Assert.AreEqual("all_turns", (string?)sent["reasoning"]?["context"]);
        Assert.AreEqual("30m", (string?)sent["prompt_cache_options"]?["ttl"]);
        Assert.AreEqual(false, (bool?)sent["prompt_cache_options"]?["prewarm"]);
        Assert.AreEqual("explicit", (string?)sent["input"]?[0]?["content"]?[0]?["prompt_cache_breakpoint"]?["mode"]);
        Assert.IsNull(sent["prompt_cache_retention"]);
        Assert.IsNull(sent["temperature"]);
        Assert.AreEqual(3000, response.Usage.Input_Tokens_Details.Cache_Write_Tokens);
        Assert.AreEqual("all_turns", response.Reasoning?.Context);
        Assert.AreEqual("default", response.Service_Tier);
        Assert.AreEqual("Reviewed", response.GetOutputText());
    }

    [TestMethod]
    public void ConfigurationUpdateHasNoMessageFieldsAndPreservesRequestEffort()
    {
        var parameter = new ResponseCreateParameter { Reasoning = new() { Effort = "low" } };
        parameter.AddConfigurationUpdate("high");
        parameter.AddUserMessage("Check the failure modes");
        var json = JObject.Parse(new OpenAIJsonConverter().SerializeObject(parameter.GetRequestBody()));
        Assert.IsTrue(JToken.DeepEquals(JObject.Parse("""{"type":"configuration_update","reasoning":{"effort":"high"}}"""), json["input"]?[0]));
        Assert.AreEqual("user", (string?)json["input"]?[1]?["role"]);
        Assert.AreEqual("low", (string?)json["reasoning"]?["effort"]);
    }

    [TestMethod]
    public void LegacyRequestOmitsNewOptions()
    {
        var parameter = new ResponseCreateParameter { Reasoning = new() { Effort = "medium" }, Prompt_Cache_Retention = "24h" };
        parameter.AddUserMessage("Hello");
        var json = JObject.Parse(new OpenAIJsonConverter().SerializeObject(parameter.GetRequestBody()));
        Assert.IsNull(json["prompt_cache_options"]);
        Assert.IsNull(json["reasoning"]?["mode"]);
        Assert.IsNull(json["reasoning"]?["context"]);
        Assert.AreEqual("24h", (string?)json["prompt_cache_retention"]);
    }

    private sealed class ResponseHandler : HttpMessageHandler
    {
        public JObject? Body { get; private set; }
        public string? Url { get; private set; }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Url = request.RequestUri!.ToString();
            Body = JObject.Parse(await request.Content!.ReadAsStringAsync(cancellationToken));
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("""
                    {"id":"resp_test","status":"completed","service_tier":"default",
                     "reasoning":{"effort":"high","mode":"pro","context":"all_turns"},
                     "output":[{"type":"message","content":[{"type":"output_text","text":"Reviewed"}]}],
                     "usage":{"input_tokens":15000,"input_tokens_details":{"cached_tokens":12000,"cache_write_tokens":3000},"output_tokens":100,"total_tokens":15100}}
                    """, Encoding.UTF8, "application/json"),
            };
        }
    }
}
