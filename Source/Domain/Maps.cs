using System.Collections.Generic;
using System.Linq;

namespace ScotlandsMountains.Domain
{
    public class Maps
    {
        public IList<Map> Landranger { get; set; }
        public IList<Map> LandrangerActive { get; set; }
        public IList<Map> Explorer { get; set; }
        public IList<Map> ExplorerActive { get; set; }
        public IList<Map> Discoverer { get; set; }
        public IList<Map> Discovery { get; set; }

        public Map GetById(string id)
        {
            return (MapSeries.SelectMany(x => x.Where(y => y.Id == id))).Single();
        }

        private IEnumerable<IList<Map>> MapSeries
        {
            get
            {
                yield return Landranger;
                yield return LandrangerActive;
                yield return Explorer;
                yield return ExplorerActive;
                yield return Discoverer;
                yield return Discovery;
            }
        }
    }
}