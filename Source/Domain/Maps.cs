using System.Collections.Generic;

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
    }
}