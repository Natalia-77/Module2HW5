using System.IO;
using Module2HW5.Configs;
using Module2HW5.Service.Abstractions;
using Newtonsoft.Json;

namespace Module2HW5.Service
{
    public class ConfigService : IConfigService
    {
        private const string Path = "config.json";
        private readonly Config _config;
        public ConfigService()
        {
            var text = File.ReadAllText(Path);
            _config = JsonConvert.DeserializeObject<Config>(text);
        }

        public Config Config => _config;
    }
}
