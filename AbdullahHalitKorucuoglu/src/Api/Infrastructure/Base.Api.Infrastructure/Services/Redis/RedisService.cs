﻿using Base.Api.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System.Threading.Tasks;

namespace Base.Api.Infrastructure.Services.Redis
{
    public class RedisService : CacheHelper, IRedisService
    {
        public IDatabase Db { get; set; }

        public RedisService(IConfiguration configuration)
        {
            Db = ConnectionMultiplexer.Connect($"{configuration["Redis:Host"]}:{configuration["Redis:Port"]}").GetDatabase(0);
        }

        public async Task<T> GetAsync<T>(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return default;
            }

            if (!await IsKeyAsync(key))
            {
                return default;
            }

            var value = await Db.StringGetAsync(key);

            if (value.IsNullOrEmpty)
            {
                return default;
            }

            return Deserialize<T>(value);
        }

        public async Task SetAsync(string key, object data)
        {
            if (await IsKeyAsync(key))
            {
                await RemoveAsync(key);
            }
            var serializeData = Serialize(data);
            await Db.StringSetAsync(key, serializeData);
        }

        public async Task<bool> IsKeyAsync(string key)
        {
            return await Db.KeyExistsAsync(key);
        }

        public async Task RemoveAsync(string key)
        {
            if (await IsKeyAsync(key))
            {
                await Db.KeyDeleteAsync(key);
            }
        }
    }
}