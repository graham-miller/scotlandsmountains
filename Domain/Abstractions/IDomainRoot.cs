using System.Collections.Generic;
using ScotlandsMountains.Domain.Entities;

namespace ScotlandsMountains.Domain.Abstractions
{
    public interface IDomainRoot
    {
        IList<Classification> Classifications { get; }
        IList<County> Counties { get; }
        IList<Island> Islands { get; }
        IList<Map> Maps { get; }
        IList<Mountain> Mountains { get; }
        IEnumerable<Section> Sections { get; }
        IList<TopologicalSection> TopologicalSections { get; }
    }
}