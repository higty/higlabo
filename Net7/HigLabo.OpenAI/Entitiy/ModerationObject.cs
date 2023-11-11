using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    public class ModerationObject
    {
        public string Id { get; set; } = "";
        public string Model { get; set; } = "";
        public List<ModerationResultObject> Results { get; set; } = new();
    }
    public class ModerationObjectResponse: RestApiResponse
    {
        public string Id { get; set; } = "";
        public string Model { get; set; } = "";
        public List<ModerationResultObject> Results { get; set; } = new();
    }
    public class ModerationResultObject
    {
        public bool Flagged { get; set; }
        public ModerationCategoryObject Categories { get; set; } = new();
        public ModerationCategoryScoreObject Category_Scores { get; set; } = new();
    }
    public class ModerationCategoryObject
    {
        public bool Sexual { get; set; }
        public bool Hate { get; set; }
        public bool Harassment { get; set; }
        [JsonProperty("self-harm")]
        [JsonPropertyName("self-harm")]
        public bool SelfHarm { get; set; }
        [JsonProperty("sexual/minors")]
        [JsonPropertyName("sexual/minors")]
        public bool Sexual_Minors { get; set; }
        [JsonProperty("hate/threatening")]
        [JsonPropertyName("hate/threatening")]
        public bool Hate_Threatening { get; set; }
        [JsonProperty("violence/graphic")]
        [JsonPropertyName("violence/graphic")]
        public bool Violence_Graphic { get; set; }
        [JsonProperty("self-harm/intent")]
        [JsonPropertyName("self-harm/intent")]
        public bool SelfHarm_Intent { get; set; }
        [JsonProperty("self-harm/instructions")]
        [JsonPropertyName("self-harm/instructions")]
        public bool SelfHarm_Instructions { get; set; }
        [JsonProperty("harassment/threatening")]
        [JsonPropertyName("harassment/threatening")]
        public bool Harassment_Threatening { get; set; }
        public bool Violence { get; set; }
    }
    public class ModerationCategoryScoreObject
    {
        public double Sexual { get; set; }
        public double Hate { get; set; }
        public double Harassment { get; set; }
        [JsonProperty("self-harm")]
        [JsonPropertyName("self-harm")]
        public double SelfHarm { get; set; }
        [JsonProperty("sexual/minors")]
        [JsonPropertyName("sexual/minors")]
        public double Sexual_Minors { get; set; }
        [JsonProperty("hate/threatening")]
        [JsonPropertyName("hate/threatening")]
        public double Hate_Threatening { get; set; }
        [JsonProperty("violence/graphic")]
        [JsonPropertyName("violence/graphic")]
        public double Violence_Graphic { get; set; }
        [JsonProperty("self-harm/intent")]
        [JsonPropertyName("self-harm/intent")]
        public double SelfHarm_Intent { get; set; }
        [JsonProperty("self-harm/instructions")]
        [JsonPropertyName("self-harm/instructions")]
        public double SelfHarm_Instructions { get; set; }
        [JsonProperty("harassment/threatening")]
        [JsonPropertyName("harassment/threatening")]
        public double Harassment_Threatening { get; set; }
        public double Violence { get; set; }
    }
}
