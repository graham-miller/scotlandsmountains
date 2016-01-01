using System.Collections.Generic;
using ScotlandsMountains.Import.OrdnanceSurvey;

namespace ScotlandsMountains.Import
{
    internal interface IMapReader
    {
        IList<Record> ExplorerMaps { get; }
        IList<Record> ExplorerMapsActive { get; }
        IList<Record> LandrangerMaps { get; }
        IList<Record> LandrangerMapsActive { get; }
        IList<Record> IrishDiscoverMaps { get; }
    }
}