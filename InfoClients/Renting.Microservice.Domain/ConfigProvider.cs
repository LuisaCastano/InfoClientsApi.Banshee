using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Renting.Microservice.Domain
{
    public class ConfigProvider : IConfigProvider
    {
        private readonly IConfigurationRoot configuration;

        public ConfigProvider(IConfigurationRoot configuration)
        {
            this.configuration = configuration;

        }

        public string GetVal(string key)
        {
            return configuration.GetSection(key).Value;
        }
    }
}
