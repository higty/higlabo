using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> PostJsonAsync(this HttpClient client, String url, String json)
        {
            return await client.PostAsync(url, new StreamContent(new MemoryStream(Encoding.UTF8.GetBytes(json))));
        }
        public static async Task<HttpResponseMessage> PostFormAsync(this HttpClient client, String url, Dictionary<String, String> data)
        {
            return await client.PostAsync(url, new FormUrlEncodedContent(data));
        }
    }
}
