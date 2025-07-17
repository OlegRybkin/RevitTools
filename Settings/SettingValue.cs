using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitTools.Settings
{
    public class SettingValue
    {
        public object Value { get; set; }
        public string Type { get; set; } // Для сериализации типа

        public SettingValue() { }

        public SettingValue(object value)
        {
            Value = value;
            Type = value.GetType().AssemblyQualifiedName;
        }

        public T GetValue<T>()
        {
            return (T)Convert.ChangeType(Value, typeof(T));
        }
    }
}
