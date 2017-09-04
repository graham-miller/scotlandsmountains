using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ScotlandsMountains.Import.Domain;

namespace ScotlandsMountains.Import
{
    public class Database
    {
        private static class Paths
        {
            public const string Classifications = "classifications";
            public const string Sections = "sections";
        }

        private readonly IFirebaseClient _firebase;

        public Database()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                //AuthSecret = "firebase_secret",
                BasePath = "https://scotlandsmountains.firebaseio.com/",
                Serializer = new Serializer()
            };

            _firebase = new FirebaseClient(config);
        }

        internal async Task Save(Root root)
        {
            await Clear();
            await Save(root.Classifications, Paths.Classifications);
            await Save(root.Sections, Paths.Sections);
        }

        private async Task Save<T>(IList<T> collection, string resourceName) where T : HasKey
        {
            var path = resourceName;

            var tasks = collection.Select(item =>
            {
                return _firebase
                    .PushAsync(path, item)
                    .ContinueWith(task => item.Key = task.Result.Result.name);
            });
            
            await Task.WhenAll(tasks);
        }

        private async Task Clear()
        {
            await _firebase.DeleteAsync(Paths.Classifications);
            await _firebase.DeleteAsync(Paths.Sections);
        }
    }

    public class Serializer : ISerializer
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            DateParseHandling = DateParseHandling.None,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        public T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, Settings);
        }

        public string Serialize<T>(T value)
        {
            return JsonConvert.SerializeObject(value, Settings);
        }
    }
}
