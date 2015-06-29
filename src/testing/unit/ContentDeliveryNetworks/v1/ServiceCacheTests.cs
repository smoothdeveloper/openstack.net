﻿using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace OpenStack.ContentDeliveryNetworks.v1
{
    public class ServiceCacheTests
    {
        [Fact]
        public void SerializeTimeToLiveToSeconds()
        {
            var cache = new ServiceCache("cache", TimeSpan.FromSeconds(60));
            
            var json = JsonConvert.SerializeObject(cache);

            var result = JObject.Parse(json);
            Assert.Equal(60, result.Value<double>("ttl"));
        }

        [Fact]
        public void DeserializeTimeToLiveFromSeconds()
        {
            var cache = new ServiceCache("cache", TimeSpan.FromSeconds(60));
            var json = JsonConvert.SerializeObject(cache);
            
            var result = JsonConvert.DeserializeObject<ServiceCache>(json);

            Assert.Equal(60, result.TimeToLive.TotalSeconds);
        }
    }
}
