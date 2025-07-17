using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RevitTools.Settings
{
    public class SettingsStore
    {
        public Dictionary<string, SettingValue> Settings { get; set; }

        public SettingsStore()
        {
            Settings = new Dictionary<string, SettingValue>();
        }

        public void Set<T>(string key, T value)
        {
            Settings[key] = new SettingValue(value);
        }

        public T Get<T>(string key, T defaultValue = default)
        {
            if (Settings.TryGetValue(key, out var val))
            {
                try
                {
                    return val.GetValue<T>();
                }
                catch
                {
                    return defaultValue;
                }
            }

            return defaultValue;
        }

        public void Save(string path)
        {
            var json = JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(path, json);
        }

        public static SettingsStore Load(string path)
        {
            if (!File.Exists(path))
                return new SettingsStore();

            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<SettingsStore>(json);
        }
    }
}
