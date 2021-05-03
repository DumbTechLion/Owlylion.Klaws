using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Owlylion.Klaws.Core
{
    public class Patch<TModel>
    {
        private readonly Dictionary<string, object> _updatesToApply = new();

        public void ApplyTo(TModel toUpdate)
        {
            Dictionary<string, PropertyInfo> propertyList = toUpdate
                .GetType()
                .GetProperties()
                .Select(prop => new
                {
                    Name = prop.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ?? prop.Name,
                    Property = prop
                })
                .ToDictionary(p => p.Name, p => p.Property);

            foreach (var (name, value) in _updatesToApply)
            {
                if(!propertyList.ContainsKey(name))
                    continue;
                
                propertyList[name].SetValue(toUpdate, value);
            }
        }

        public void AddUpdate(string property, object value)
        {
            _updatesToApply[property] = value;
        }
    }
}
