using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace ScotlandsMountains.Domain
{
    [JsonObject]
    public class Maps : IEnumerable<Map>
    {
        public IList<Map> Landranger { get; set; }
        public IList<Map> LandrangerActive { get; set; }
        public IList<Map> Explorer { get; set; }
        public IList<Map> ExplorerActive { get; set; }
        public IList<Map> Discoverer { get; set; }
        public IList<Map> Discovery { get; set; }

        public IEnumerator<Map> GetEnumerator()
        {
            return MapSeries.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IEnumerable<Map> MapSeries
        {
            get
            {
                return Landranger
                    .Concat(LandrangerActive)
                    .Concat(Explorer)
                    .Concat(ExplorerActive)
                    .Concat(Discoverer)
                    .Concat(Discovery);
            }
        }
    }
}