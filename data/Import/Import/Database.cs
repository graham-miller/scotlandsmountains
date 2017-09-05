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
            await Save(root.Countries, Paths.Countries);
            await Save(root.Maps, Paths.Maps);
            root.LinkMountainsToRelatedEntities();
            await Save(root.Mountains, Paths.Mountains);
        }

        private async Task Clear()
        {
            await _firebase.DeleteAsync(Paths.Classifications);
            await _firebase.DeleteAsync(Paths.Sections);
            await _firebase.DeleteAsync(Paths.Countries);
            await _firebase.DeleteAsync(Paths.Maps);
            await _firebase.DeleteAsync(Paths.Mountains);
        }

        private async Task Save<T>(IList<T> collection, string resourceName) where T : HasKey
        {
            var path = resourceName;

            if (collection.Count > MaxSimultaneousConnections)
            {
                Partition(collection, MaxSimultaneousConnections).ToList().ForEach(async x => await Save(x, resourceName));
            }
            else
            {
                var tasks = collection.Select(item =>
                {
                    return _firebase
                        .PushAsync(path, item)
                        .ContinueWith(task => item.Key = task.Result.Result.name);
                });

                await Task.WhenAll(tasks);
            }
        }

        private IEnumerable<IList<T>> Partition<T>(IList<T> collection, int size)
        {
            var partition = new List<T>(size);
            foreach (var item in collection)
            {
                partition.Add(item);
                if (partition.Count == size)
                {
                    yield return partition;
                    partition = new List<T>(size);
                }
            }
            if (partition.Count > 0)
                yield return partition;
        }

        private static class Paths
        {
            public const string Classifications = "classifications";
            public const string Sections = "sections";
            public const string Countries = "countries";
            public const string Maps = "maps";
            public const string Mountains = "mountains";
        }

        private const int MaxSimultaneousConnections = 100;

        private readonly IFirebaseClient _firebase;

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
}
