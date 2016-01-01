using System.Collections.Generic;
using ScotlandsMountains.Domain.Entities.Maps;
using ScotlandsMountains.Domain.ValueObjects;

namespace ScotlandsMountains.Domain.Entities
{
    public class Mountain : Entity
    {
        public Mountain()
        {
            Countries = new List<Country>();
            Classifications = new List<Classification>();
            Maps = new List<Map>();
        }

        public string Name { get; set; }

        public Height Height { get; set; }

        public Location Location { get; set; }

        public Region Region { get; set; }

        public Summit Summit { get; set; }

        public Prominence Prominence { get; set; }

        public ICollection<Country> Countries { get; set; }

        public ICollection<Classification> Classifications { get; set; }

        public ICollection<Map> Maps { get; set; }

        public Mountain Parent { get; set; }

        public ICollection<Mountain> Children { get; set; }

        public ICollection<Alias> Aliases { get; set; }

        public int DobihId { get; set; }
    }
}
