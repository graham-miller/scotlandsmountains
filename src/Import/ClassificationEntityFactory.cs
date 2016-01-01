using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Import.DoBIH;

namespace ScotlandsMountains.Import
{
    internal class ClassificationEntityFactory
    {
        public IList<Classification> Classifications { get { return _lookup.Values.ToList(); } }

        private readonly IDictionary<int,Classification> _lookup = new Dictionary<int,Classification>();

        public ClassificationEntityFactory()
        {
            _lookup = new Dictionary<int, Classification>
                {
                    {38, new Classification {Name = "Marilyn", Mountains = new List<Mountain>()}},
                    {39, new Classification {Name = "Marilyn twin", Mountains = new List<Mountain>()}},
                    {40, new Classification {Name = "HuMP", Mountains = new List<Mountain>()}},
                    {41, new Classification {Name = "HuMP twin", Mountains = new List<Mountain>()}},
                    {42, new Classification {Name = "Munro", Mountains = new List<Mountain>()}},
                    {43, new Classification {Name = "Munro top", Mountains = new List<Mountain>()}},
                    {44, new Classification {Name = "Murdo", Mountains = new List<Mountain>()}},
                    {45, new Classification {Name = "Furth", Mountains = new List<Mountain>()}},
                    {46, new Classification {Name = "Corbett", Mountains = new List<Mountain>()}},
                    {47, new Classification {Name = "Corbett top", Mountains = new List<Mountain>()}},
                    {48, new Classification {Name = "Corbett top of Munro", Mountains = new List<Mountain>()}},
                    {49, new Classification {Name = "Corbett top of Corbett", Mountains = new List<Mountain>()}},
                    {50, new Classification {Name = "Graham", Mountains = new List<Mountain>()}},
                    {51, new Classification {Name = "Graham top", Mountains = new List<Mountain>()}},
                    {52, new Classification {Name = "Graham top of Munro", Mountains = new List<Mountain>()}},
                    {53, new Classification {Name = "Graham top of Corbett", Mountains = new List<Mountain>()}},
                    {54, new Classification {Name = "Graham top of Graham", Mountains = new List<Mountain>()}},
                    {55, new Classification {Name = "Graham top of Hewitt", Mountains = new List<Mountain>()}},
                    {56, new Classification {Name = "Donald", Mountains = new List<Mountain>()}},
                    {57, new Classification {Name = "Donald top", Mountains = new List<Mountain>()}},
                    {58, new Classification {Name = "Hewitt", Mountains = new List<Mountain>()}},
                    {59, new Classification {Name = "Nuttal", Mountains = new List<Mountain>()}},
                    {60, new Classification {Name = "Dillon", Mountains = new List<Mountain>()}},
                    {61, new Classification {Name = "Arderin", Mountains = new List<Mountain>()}},
                    {62, new Classification {Name = "Vandeleur-Lynam", Mountains = new List<Mountain>()}},
                    {63, new Classification {Name = "TuMP", Mountains = new List<Mountain>()}},
                    {64, new Classification {Name = "TuMP twin", Mountains = new List<Mountain>()}},
                    {65, new Classification {Name = "Sim", Mountains = new List<Mountain>()}},
                    {66, new Classification {Name = "Dewey", Mountains = new List<Mountain>()}},
                    {67, new Classification {Name = "Donald Dewey", Mountains = new List<Mountain>()}},
                    {68, new Classification {Name = "Highland Five", Mountains = new List<Mountain>()}},
                    {69, new Classification {Name = "Myrddyn Dewey", Mountains = new List<Mountain>()}},
                    {70, new Classification {Name = "TuMP 400m to 499m", Mountains = new List<Mountain>()}},
                    {71, new Classification {Name = "TuMP 300m to 399m", Mountains = new List<Mountain>()}},
                    {72, new Classification {Name = "TuMP 200m to 299m", Mountains = new List<Mountain>()}},
                    {73, new Classification {Name = "TuMP 100m to 199m", Mountains = new List<Mountain>()}},
                    {74, new Classification {Name = "TuMP 100m to 199m twin", Mountains = new List<Mountain>()}},
                    {75, new Classification {Name = "TuMP 0m to 99m", Mountains = new List<Mountain>()}},
                    {76, new Classification {Name = "Wainwright", Mountains = new List<Mountain>()}},
                    {77, new Classification {Name = "Wainwright outlying fell", Mountains = new List<Mountain>()}},
                    {78, new Classification {Name = "Birkett", Mountains = new List<Mountain>()}},
                    {79, new Classification {Name = "County top (historic)", Mountains = new List<Mountain>()}},
                    {80, new Classification {Name = "County top (current county and unitary authority)", Mountains = new List<Mountain>()}},
                    {81, new Classification {Name = "County top (current county and unitary authority twin)", Mountains = new List<Mountain>()}},
                    {82, new Classification {Name = "County top (administrative)", Mountains = new List<Mountain>()}},
                    {83, new Classification {Name = "County top London borough", Mountains = new List<Mountain>()}},
                    {84, new Classification {Name = "County top London borough twin", Mountains = new List<Mountain>()}},
                    {85, new Classification {Name = "Subsidiary Marilyn", Mountains = new List<Mountain>()}},
                    {86, new Classification {Name = "Subsidiary HuMP", Mountains = new List<Mountain>()}},
                    {87, new Classification {Name = "Subsidiary Murdo", Mountains = new List<Mountain>()}},
                    {88, new Classification {Name = "Subsidiary Corbett top", Mountains = new List<Mountain>()}},
                    {89, new Classification {Name = "Subsidiary Graham top", Mountains = new List<Mountain>()}},
                    {90, new Classification {Name = "Subsidiary Hewitt", Mountains = new List<Mountain>()}},
                    {91, new Classification {Name = "Subsidiary Dewey", Mountains = new List<Mountain>()}},
                    {92, new Classification {Name = "Subsidiary Donald Dewey", Mountains = new List<Mountain>()}},
                    {93, new Classification {Name = "Subsidiary Highland Five", Mountains = new List<Mountain>()}},
                    {94, new Classification {Name = "Subsidiary Myrddyn Dewey", Mountains = new List<Mountain>()}},
                    {95, new Classification {Name = "Subsidiary 400m to 499m TuMP", Mountains = new List<Mountain>()}},
                    {96, new Classification {Name = "Deleted Munro top", Mountains = new List<Mountain>()}},
                    {97, new Classification {Name = "Deleted Corbett", Mountains = new List<Mountain>()}},
                    {98, new Classification {Name = "Deleted Nuttall", Mountains = new List<Mountain>()}},
                    {99, new Classification {Name = "Deleted Donald top", Mountains = new List<Mountain>()}},
                    {100, new Classification {Name = "Synge", Mountains = new List<Mountain>()}},
                    {101, new Classification {Name = "Fellranger", Mountains = new List<Mountain>()}},
                    {102, new Classification {Name = "Buxton and Lewis", Mountains = new List<Mountain>()}},
                    {103, new Classification {Name = "Bridge", Mountains = new List<Mountain>()}},
                    {104, new Classification {Name = "Trail 100", Mountains = new List<Mountain>()}},
                    {105, new Classification {Name = "Carn", Mountains = new List<Mountain>()}},
                    {106, new Classification {Name = "Binnion", Mountains = new List<Mountain>()}}
                };
        }

        public void SetClassificationsFor(MountainTuple tuple)
        {
            tuple.Mountain.Classifications = new List<Classification>();

            foreach (var item in _lookup)
            {
                var field = item.Key;
                var classification = item.Value;

                if (tuple.Record.ElementAt(field) == "1")
                {
                    tuple.Mountain.Classifications.Add(classification);
                    classification.Mountains.Add(tuple.Mountain);
                }
            }
        }
    }
}