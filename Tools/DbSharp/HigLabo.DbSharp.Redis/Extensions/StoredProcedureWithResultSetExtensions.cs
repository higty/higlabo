using System;
using System.Collections.Generic;
using System.Linq;
using StackExchange.Redis;
using HigLabo.Core;
using HigLabo.DbSharp;

namespace HigLabo.Core
{
    public static class StoredProcedureWithResultSetExtensions
    {
        public static String GetRedisKey<T>(this StoredProcedureWithResultSet<T> storedProcedure)
            where T : StoredProcedureResultSet, new()
        {
            var sp = storedProcedure;
            var idx = sp as IDatabaseContext;
            return idx.DatabaseKey + Environment.NewLine + sp.ToString();
        }
        public static TimeSpan? GetCacheLiveTime<T>(this StoredProcedureWithResultSet<T> storedProcedure, RedisClient redisClient)
            where T : StoredProcedureResultSet, new()
        {
            var sp = storedProcedure;
            return redisClient.Database.KeyTimeToLive(sp.GetRedisKey());
        }

        public static List<T> GetResultSets<T>(this StoredProcedureWithResultSet<T> storedProcedure, RedisClient redisClient
            , TimeSpan expiry)
            where T : StoredProcedureResultSet, new()
        {
            return storedProcedure.GetResultSets(redisClient, expiry, When.Always, CommandFlags.None);
        }
        public static List<T> GetResultSets<T>(this StoredProcedureWithResultSet<T> storedProcedure
            , RedisClient redisClient, String key
            , TimeSpan expiry)
            where T : StoredProcedureResultSet, new()
        {
            return storedProcedure.GetResultSets(redisClient, key, expiry, When.Always, CommandFlags.None);
        }
        public static List<T> GetResultSets<T>(this StoredProcedureWithResultSet<T> storedProcedure, RedisClient redisClient
            , TimeSpan expiry, When when)
            where T : StoredProcedureResultSet, new()
        {
            return storedProcedure.GetResultSets(redisClient, expiry, when, CommandFlags.None);
        }
        public static List<T> GetResultSets<T>(this StoredProcedureWithResultSet<T> storedProcedure
            , RedisClient redisClient
            , TimeSpan expiry, When when = When.Always, CommandFlags flags = CommandFlags.None)
            where T : StoredProcedureResultSet, new()
        {
            return storedProcedure.GetResultSets(redisClient, storedProcedure.GetRedisKey(), expiry, when, flags);
        }
        public static List<T> GetResultSets<T>(this StoredProcedureWithResultSet<T> storedProcedure
            , RedisClient redisClient, String key
            , TimeSpan expiry, When when = When.Always, CommandFlags flags = CommandFlags.None)
            where T : StoredProcedureResultSet, new()
        {
            var sp = storedProcedure;
            var rs = redisClient.Get<List<T>>(key);
            if (rs == null)
            {
                var resultSets = sp.GetResultSets();
                redisClient.Set(key, resultSets, expiry, when, flags);
                return resultSets;
            }
            return rs;
        }
    }
}
