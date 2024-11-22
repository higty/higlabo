using Azure.Core;
using HigLabo.Core;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.DbSharp;

public class TableCacheWebPublisher
{
    public HttpClient HttpClient { get; init; }
    public List<string> UrlList { get; private set; } = new();

    public TableCacheWebPublisher(HttpClient httpClient)
    {
        this.HttpClient = httpClient;
        this.HttpClient.DefaultRequestHeaders.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue()
        {
            NoCache = true
        };
    }

    public async ValueTask Publish(String tableName)
    {
        foreach (var url in this.UrlList)
        {
            var response = await this.HttpClient.PostAsJsonAsync(url, new { TableName = tableName });
        }
    }
    public async ValueTask Publish(String[] tableNameList)
    {
        foreach (var url in this.UrlList)
        {
            var response = await this.HttpClient.PostAsJsonAsync(url, new { TableNameList = tableNameList });
        }
    }
}
