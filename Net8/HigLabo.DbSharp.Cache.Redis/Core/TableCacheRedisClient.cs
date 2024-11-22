using Azure;
using Azure.Core;
using StackExchange.Redis;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HigLabo.DbSharp;

public class TableCacheRedisClient
{
    public event EventHandler<TableCacheUpdatedEventArgs>? CacheUpdated;

    private ConnectionMultiplexer _Connection;
    private ISubscriber _Subscriber;
    public String AccessToken { get; private set; }
    public string ChannelName { get; init; }

    public TableCacheRedisClient(string accessKey, string channelName)
    {
        this.AccessToken = accessKey;
        this.ChannelName = channelName;
        _Connection = ConnectionMultiplexer.Connect(accessKey);
        _Subscriber = _Connection.GetSubscriber();
    }
    public void Subscribe(RedisChannel.PatternMode patternMode)
    {
        _Subscriber.Subscribe(new RedisChannel(this.ChannelName, patternMode), this.OnUpdate);
    }
    public async ValueTask SubscribeAsync(RedisChannel.PatternMode patternMode)
    {
        await _Subscriber.SubscribeAsync(new RedisChannel(this.ChannelName, patternMode), this.OnUpdate);
    }

    public async ValueTask PublishAsync(String tableName)
    {
        await this.PublishAsync(new String[] { tableName });
    }
    public async ValueTask PublishAsync(IEnumerable<String> tableNameList)
    {
        await this.PublishAsync(tableNameList, RedisChannel.PatternMode.Auto);
    }
    public async ValueTask PublishAsync(IEnumerable<String> tableNameList, RedisChannel.PatternMode patternMode)
    {
        var e = new TableCacheUpdatedEventArgs(DateTimeOffset.Now);
        e.TableNameList.AddRange(tableNameList);
        RedisValue value = JsonSerializer.Serialize(e);
        await _Subscriber.PublishAsync(new RedisChannel(this.ChannelName, patternMode), value);
    }
    private void OnUpdate(RedisChannel channel, RedisValue value)
    {
        var e = JsonSerializer.Deserialize<TableCacheUpdatedEventArgs>(value!);
        this.CacheUpdated?.Invoke(this, e!);
    }
}
