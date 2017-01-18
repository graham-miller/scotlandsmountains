using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Linq;

namespace ScotlandsMountains.Domain
{
    public interface IDomainRoot
    {
        IList<List> Lists { get; }
        IList<Section> Sections { get; }
        Maps Maps { get; }
        IList<Mountain> Mountains { get; }
        IList<Country> Countries { get; }
    }

    public class DomainRoot : IDomainRoot
    {
        public IList<List> Lists { get; set; }
        public IList<Section> Sections { get; set; }
        public Maps Maps { get; set; }
        public virtual IList<Mountain> Mountains { get; set; }
        public IList<Country> Countries { get; set; }

        public static DomainRoot Load()
        {
            var json = Resources.Load.ScotlandsMountains.DomainJson;
            return JsonConvert.DeserializeObject<DomainRoot>(json, JsonSerializerSettings);
        } 

        public void Save()
        {
            var json = JsonConvert.SerializeObject(this, JsonSerializerSettings);
            Resources.Save.ScotlandsMountains.DomainJson(json);
        }

        public IDomainRoot ScotlandOnly()
        {
            return new ScotlandOnlyDomainRoot(this);
        }

        private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
    }

    public class ScotlandOnlyDomainRoot : IDomainRoot
    {
        private readonly DomainRoot _inner;

        internal ScotlandOnlyDomainRoot(DomainRoot inner)
        {
            _inner = inner;
        }

        private IList<Mountain> _mountains = null;
        public IList<Mountain> Mountains
        {
            get
            {
                if (_mountains == null)
                    _mountains = _inner.Mountains.Where(x => x.CountryId == ScotlandId).ToList();

                return _mountains;
            }
        }

        private string _scotlandId = null;
        private string ScotlandId
        {
            get
            {
                if (_scotlandId == null)
                {
                    // TODO should be Single not First, but we've got two!?
                    _scotlandId = _inner.Countries.First(x => x.Name == "Scotland").Id;
                }

                return _scotlandId;
            }
        }

        private IList<List> _lists = null;
        public IList<List> Lists
        {
            get
            {
                if (_lists == null)
                    _lists = Get(d => d.Lists, m => m.ListIds);

                return _lists;
            }
        }

        private IList<Country> _countries = null;
        public IList<Country> Countries
        {
            get
            {
                if (_countries == null)
                    _countries = _inner.Countries.Where(x => x.Id == ScotlandId).Take(1).ToList();

                return _countries;
            }
        }

        private Maps _maps = null;
        public Maps Maps
        {
            get
            {
                if (_maps == null)
                    _maps = new Maps
                    {
                        Landranger = Get(d => d.Maps.Landranger, m => m.MapIds),
                        LandrangerActive = Get(d => d.Maps.LandrangerActive, m => m.MapIds),
                        Explorer = Get(d => d.Maps.Explorer, m => m.MapIds),
                        ExplorerActive = Get(d => d.Maps.ExplorerActive, m => m.MapIds),
                        Discoverer = new List<Map>(),
                        Discovery = new List<Map>()
                    };

                return _maps;
            }
        }

        private IList<Section> _sections = null;
        public IList<Section> Sections
        {
            get
            {
                if (_sections == null)
                    _sections = Get(d => d.Sections, m => new[] { m.SectionId });

                return _sections;
            }
        }

        private IList<T> Get<T>(Func<DomainRoot,IList<T>> domainRootProperty, Func<Mountain,IEnumerable<string>> mountainProperty) where T : Entity
        {
            return domainRootProperty(_inner).Where(x => Mountains.SelectMany(mountainProperty).Distinct().Contains(x.Id)).ToList();
        }
    }
}
