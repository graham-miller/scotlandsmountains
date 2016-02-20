using System;
using System.Collections.Generic;
using FireSharp;
using FireSharp.Config;
using ScotlandsMountains.Import.ConsoleApp.DatabaseOfBritishAndIrishHills.EntityFactories;
using ScotlandsMountains.Domain.Entities;

namespace ScotlandsMountains.Import.ConsoleApp
{
    public sealed class FirebaseWriter : IDisposable
    {
        public void Write(EntityFactory entityFactory)
        {
            Write("sections", entityFactory.Sections);
            Write("islands", entityFactory.Islands);
            Write("counties", entityFactory.Counties);
            Write("topologicalSections", entityFactory.TopologicalSections);
            Write("maps", entityFactory.Maps);
            Write("classifications", entityFactory.Classifications);
        }

        internal void Write(IList<Mountain> mountains)
        {
            Write("mountains", mountains);
        }

        private void Write<T>(string path, IEnumerable<T> items) where T : Entity
        {
            foreach (var item in items)
            {
                var response = _client.Push(path, item);
                item.Key = response.Result.Name;
            }
        }

        public void Dispose()
        {
            _client = null;
        }

        private FirebaseClient _client = new FirebaseClient(new FirebaseConfig
        {
            AuthSecret = "",
            BasePath = "https://scotlandsmountains.firebaseio.com/"
        });
    }
}
