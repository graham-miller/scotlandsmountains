using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Resources;

namespace ScotlandsMountains.Import
{
    internal class CacheFactory
    {
        private readonly Root _root;
        private readonly IConsole _console;

        public CacheFactory(Root root, IConsole console)
        {
            _root = root;
            _console = console;
        }

        public void Create()
        {
            CreateIndex();

            foreach (var classification in _root.Classifications)
                CreateCacheFor(classification);
        }

        private void CreateIndex()
        {
            _console.WriteLine("Creating classification index cache...");
            var cache = _root.Classifications.Select(x => new {x.Id, x.Name});
            var json = JsonConvert.SerializeObject(cache, DefaultJsonSerializerSettings.Get);
            _console.WriteLine("Saving classification index cache...");
            File.WriteAllText(FileHelper.ClassificationsIndexCacheJsonPath, json);
        }

        private void CreateCacheFor(Classification classification)
        {
            _console.WriteLine($"Creating {classification.Name} classification cache...");
            var mountains = classification.MountainIds.Join(_root.Mountains, id => id, mountain => mountain.Id, (id, mountain) => mountain);
            var json = JsonConvert.SerializeObject(mountains, DefaultJsonSerializerSettings.Get);

            _console.WriteLine($"Saving {classification.Name} classification cache...");
            File.WriteAllText(FileHelper.ClassificationCacheJsonPath(classification.Name), json);
        }
    }
}
