using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    public class AzureSettings
    {
        public string ApiKey { get; set; } = "";
        /// <summary>
        /// https://your-endpoint.openai.azure.com/
        /// </summary>
        public string EndpointUrl { get; set; } = "";
        public string DeploymentId { get; set; } = "";
        public string ApiVersion { get; set; } = "2023-09-01-preview";

        public AzureSettings()
        {
        }
        public AzureSettings(string apiKey, string endpointUri, string deploymentId)
        {
            this.ApiKey = apiKey;
            this.EndpointUrl = endpointUri;
            this.DeploymentId = deploymentId;
        }
    }
}
