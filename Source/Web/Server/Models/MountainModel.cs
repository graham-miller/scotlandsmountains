using ScotlandsMountains.Domain;
using ScotlandsMountains.Web.Server.Helpers;
using System.Collections.Generic;

namespace ScotlandsMountains.Web.Server.Models
{
    public class MountainModel
    {
        public MountainModel(Mountain mountain, IDomainRoot domainRoot)
        {
            Name = mountain.Name;
            Height = mountain.Height;
            Location = mountain.Location;
            Prominence = mountain.Prominence;
            Feature = mountain.Feature;
            Observations = mountain.Observations;

            var resolver = new EntityResolver(domainRoot);
            Classifications = resolver.Classifications(mountain.ClassificationIds);
            Maps = resolver.Maps(mountain.MapIds);
            Section = resolver.Section(mountain.SectionId);
            Country = resolver.Country(mountain.CountryId);
        }

        public string Name { get; set; }
        public Height Height { get; set; }
        public Location Location { get; set; }
        public Prominence Prominence { get; set; }
        public string Feature { get; set; }
        public string Observations { get; set; }

        public IList<EntityModel> Classifications { get; set; }
        public IList<EntityModel> Maps { get; set; }
        public EntityModel Section { get; set; }
        public EntityModel Country { get; set; }
    }
}
