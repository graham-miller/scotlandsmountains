using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ScotlandsMountains.Import.Domain
{
    public class HasKeyListJsonConverter<T> : JsonConverter where T : HasKey
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var list = value as IList<T>;
            if (list != null)
            {
                var jObject = new JObject();
                foreach (var item in list)
                {
                    var inner = JObject.FromObject(item);
                    jObject.Add(item.Key, inner);
                }

                jObject.WriteTo(writer);
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}
