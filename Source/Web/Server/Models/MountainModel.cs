using ScotlandsMountains.Domain;
using ScotlandsMountains.Web.Server.Helpers;
using System.Collections.Generic;

namespace ScotlandsMountains.Web.Server.Models
{
    public class MountainModel : EntityModel
    {
        public MountainModel(Mountain mountain, IDomainRoot domainRoot) : base(mountain)
        {
            Height = mountain.Height.ToString();
            Latitude = mountain.Location.Latitude;
            Longitude = mountain.Location.Longitude;
            SixFigureGridRef = mountain.Location.GridRef.SixFigure;
            TenFigureGridRef = mountain.Location.GridRef.TenFigure;
            Prominence = mountain.Prominence.ToString();
            Feature = mountain.Feature;
            Observations = mountain.Observations;

            var resolver = new EntityModelResolver(domainRoot);
            Lists = resolver.Lists(mountain.ListIds);
            Maps = resolver.Maps(mountain.MapIds);
            Section = resolver.Section(mountain.SectionId);
            Country = resolver.Country(mountain.CountryId);
        }

        public string Height { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string SixFigureGridRef { get; set; }
        public string TenFigureGridRef { get; set; }
        public string Prominence { get; set; }
        public string Feature { get; set; }
        public string Observations { get; set; }

        public IList<EntityModel> Lists { get; set; }
        public IList<EntityModel> Maps { get; set; }
        public EntityModel Section { get; set; }
        public EntityModel Country { get; set; }
    }
}
