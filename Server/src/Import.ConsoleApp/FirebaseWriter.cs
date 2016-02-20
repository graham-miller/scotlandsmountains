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

        public void Write(MountainSummariesFactory mountainSummariesFactory)
        {
            Write("mountainSummaries/munros", mountainSummariesFactory.Munros);
            Write("mountainSummaries/munroTops", mountainSummariesFactory.MunroTops);
            Write("mountainSummaries/corbetts", mountainSummariesFactory.Corbetts);
            Write("mountainSummaries/corbettTops", mountainSummariesFactory.CorbettTops);
            Write("mountainSummaries/grahams", mountainSummariesFactory.Grahams);
            Write("mountainSummaries/grahamTops", mountainSummariesFactory.GrahamTops);
            Write("mountainSummaries/murdos", mountainSummariesFactory.Murdos);
            Write("mountainSummaries/donalds", mountainSummariesFactory.Donalds);
            Write("mountainSummaries/donaldDeweys", mountainSummariesFactory.DonaldDeweys);
            Write("mountainSummaries/highlandFives", mountainSummariesFactory.HighlandFives);

            Write("mountainSummaries/upto100M", mountainSummariesFactory.UpTo100M);
            Write("mountainSummaries/upto200M", mountainSummariesFactory.UpTo200M);
            Write("mountainSummaries/upto300M", mountainSummariesFactory.UpTo300M);
            Write("mountainSummaries/upto400M", mountainSummariesFactory.UpTo400M);
            Write("mountainSummaries/upto500M", mountainSummariesFactory.UpTo500M);
            Write("mountainSummaries/upto600M", mountainSummariesFactory.UpTo600M);
            Write("mountainSummaries/upto700M", mountainSummariesFactory.UpTo700M);
            Write("mountainSummaries/upto800M", mountainSummariesFactory.UpTo800M);
            Write("mountainSummaries/upto900M", mountainSummariesFactory.UpTo900M);
            Write("mountainSummaries/upto1000M", mountainSummariesFactory.UpTo1000M);
            Write("mountainSummaries/upto1100M", mountainSummariesFactory.UpTo1100M);
            Write("mountainSummaries/upto1200M", mountainSummariesFactory.UpTo1200M);
            Write("mountainSummaries/upto1300M", mountainSummariesFactory.UpTo1300M);
            Write("mountainSummaries/over1300M", mountainSummariesFactory.Over1300M);
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
