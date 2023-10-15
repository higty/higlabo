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

namespace HigLabo.DbSharp
{
    public class TableCacheRedisClient
    {
        public event EventHandler<TableCacheUpdatedEventArgs>? CacheUpdated;

        private ConnectionMultiplexer _Connection;
        private ISubscriber _Subscriber;
        public String AccessToken { get; private set; }
        public String ChannelName { get; private set; }

        public TableCacheRedisClient(string accessKey, string channelName)
        {
            this.AccessToken = accessKey;
            this.ChannelName = channelName;
            _Connection = ConnectionMultiplexer.Connect(accessKey);
            _Subscriber = _Connection.GetSubscriber();
            _Subscriber.Subscribe(this.ChannelName, this.OnUpdate);
        }

        public void Publish(String tableName)
        {
            this.Publish(new String[] { tableName });
        }
        public void Publish(IEnumerable<String> tableNameList)
        {
            var e = new TableCacheUpdatedEventArgs(DateTimeOffset.Now);
            e.TableNameList.AddRange(tableNameList);
            RedisValue value = JsonSerializer.Serialize(e);
            _Subscriber.Publish(this.ChannelName, value);
        }
        private void OnUpdate(RedisChannel channel, RedisValue value)
        {
            var e = JsonSerializer.Deserialize<TableCacheUpdatedEventArgs>(value!);
            this.CacheUpdated?.Invoke(this, e!);
        }
    }
}
