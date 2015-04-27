using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using StackExchange.Redis;

namespace HigLabo.Core
{
    public class RedisClient
    {
        public SerializeMode Mode { get; set; }
        public IDatabase Database { get; private set; }
        public Serializer JsonSerializer { get; set; }
        public BinarySerializer BinarySerializer { get; set; }

        public RedisClient(IDatabase database)
        {
            this.Database = database;
        }

        public T Get<T>(String key)
        {
            return this.Get<T>(key, CommandFlags.None);
        }
        public T Get<T>(String key, CommandFlags flags)
        {
            switch (this.Mode)
            {
                case SerializeMode.Json:
                    {
                        String json = this.Database.StringGet(key, flags);
                        if (json == null) { return default(T); }
                        return this.JsonSerializer.Deserialize<T>(json);
                    }
                case SerializeMode.Binary:
                    {
                        Byte[] bb = (Byte[])this.Database.StringGet(key, flags);
                        if (bb == null) { return default(T); }
                        return this.BinarySerializer.Deserialize<T>(bb);
                    }
                default: throw new InvalidOperationException();
            }
        }
        public void Set<T>(String key, T obj)
        {
            this.Set(key, obj, null, When.Always, CommandFlags.None);
        }
        public void Set<T>(String key, T obj, TimeSpan? expiry)
        {
            this.Set(key, obj, expiry, When.Always, CommandFlags.None);
        }
        public void Set<T>(String key, T obj, TimeSpan? expiry, When when)
        {
            this.Set(key, obj, expiry, when, CommandFlags.None);
        }
        public void Set<T>(String key, T obj, TimeSpan? expiry, When when, CommandFlags flags)
        {
            switch (this.Mode)
            {
                case SerializeMode.Json:
                    {
                        String json = this.JsonSerializer.Serialize(obj);
                        this.Database.StringSet(key, json, expiry, when, flags);
                        break;
                    }
                case SerializeMode.Binary:
                    {
                        Byte[] bb = this.BinarySerializer.Serialize(obj);
                        this.Database.StringSet(key, bb);
                        break;
                    }
                default: throw new InvalidOperationException();
            }
        }
    }
}
