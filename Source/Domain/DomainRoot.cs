using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Linq;
using System;

namespace ScotlandsMountains.Domain
{
    public interface IDomainRoot
    {
        IList<Classification> Classifications { get; }
        IList<Section> Sections { get; }
        Maps Maps { get; }
        IList<Mountain> Mountains { get; }
        IList<Country> Countries { get; }
    }

    public class DomainRoot : IDomainRoot
    {
        public IList<Classification> Classifications { get; set; }
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
                    _scotlandId = Countries.First(x => x.Name == "Scotland").Id;
                }

                return _scotlandId;
            }
        }

        public IList<Classification> Classifications { get { return _inner.Classifications; } }
        public IList<Country> Countries { get { return _inner.Countries; } }
        public Maps Maps { get { return _inner.Maps; } }
        public IList<Section> Sections { get { return _inner.Sections; } }
    }
}
