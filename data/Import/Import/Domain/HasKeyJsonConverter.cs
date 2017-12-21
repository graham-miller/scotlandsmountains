using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ScotlandsMountains.Import.Domain
{
    public class HasIdListJsonConverter<T> : JsonConverter where T : HasId, new()
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
                    jObject.Add(item.Id, inner);
                }

                jObject.WriteTo(writer);
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);

            var list = new List<T>();

            foreach (var keyedJToken in jObject)
            {
                var item = new T {Id = keyedJToken.Key};

                using (var itemReader = keyedJToken.Value.CreateReader())
                    JsonSerializer.CreateDefault().Populate(itemReader, item);

                list.Add(item);
            }

            return list;
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}
