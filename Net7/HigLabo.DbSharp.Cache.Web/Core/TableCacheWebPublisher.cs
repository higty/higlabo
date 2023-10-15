using Azure.Core;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
    public class TableCacheWebPublisher
    {
        public HttpClient HttpClient { get; init; }
        public List<string> UrlList { get; private set; } = new();

        public TableCacheWebPublisher(HttpClient httpClient)
        {
            this.HttpClient = httpClient;
        }

        public async ValueTask Publish(String tableName)
        {
            foreach (var url in this.UrlList)
            {
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                var json = JsonSerializer.Serialize(new { TableName = tableName });
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await this.HttpClient.SendAsync(request);
            }
        }
        public async ValueTask Publish(String[] tableNameList)
        {
            foreach (var url in this.UrlList)
            {
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                var json = JsonSerializer.Serialize(new { TableNameList = tableNameList });
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await this.HttpClient.SendAsync(request);
            }
        }
    }
}
