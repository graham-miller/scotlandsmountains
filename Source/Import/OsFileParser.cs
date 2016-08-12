using System.Collections.Generic;
using System.Text.RegularExpressions;
using ScotlandsMountains.Domain;

namespace ScotlandsMountains.Import
{
    internal class OsFileParser2
    {
        private const int MaxLIneCacheSize = 10;

        private readonly OsFile _file;
        private readonly IList<string> _lines;

        private int _position = 0;
        private string _cache = string.Empty;
        private int _cacheSize = 0;

        private Strategy _strategy = new NullStrategy();

        public OsFileParser2(OsFile file)
        {
            _file = file;
            _lines = file.Lines;

            do
            {
                if (CacheContainsMapRecord())
                    CreateMapEntityAndResetCache();
                else
                    AppendCacheFromFile();

            } while (!EndOfFile());
        }

        private bool CacheContainsMapRecord()
        {
            return _strategy.IsMatch(_cache);
        }

        private void AppendCacheFromFile()
        {
            if (_cacheSize >= MaxLIneCacheSize)
            {
                _position++;
                _cache = string.Empty;
                _cacheSize = 0;
            }

            var nextValueToCache = _lines[_position + _cacheSize];

            SetStrategyBasedOn(nextValueToCache);

            if (string.IsNullOrEmpty(_cache))
                _cache += nextValueToCache;
            else
                _cache = _cache + " " + nextValueToCache;

            _cacheSize++;
        }

        private void SetStrategyBasedOn(string nextValueToCache)
        {
            if (nextValueToCache.Contains("OS Landranger current editions"))
                _strategy = new LandrangerStrategy(_file);
            else if (nextValueToCache.Contains("OS Landranger – Active current editions"))
                _strategy = new LandrangerActiveStrategy(_file);
            else if (nextValueToCache.Contains("OS Explorer current editions"))
                _strategy = new ExplorerStrategy(_file);
            else if (nextValueToCache.Contains("OS Explorer – Active current editions"))
                _strategy = new ExplorerActiveStrategy(_file);
            else if (nextValueToCache.Contains("OS Travel – Tour current editions"))
                _strategy = new NullStrategy();
            else if (nextValueToCache.Contains("Historical map and guides current editions"))
                _strategy = new NullStrategy();
            else if (nextValueToCache.Contains("OS Wall Map (laminated & tubed)"))
                _strategy = new NullStrategy();
            else if (nextValueToCache.Contains("Administrative boundary maps"))
                _strategy = new NullStrategy();
            else if (nextValueToCache.Contains("Irish maps, atlases and guides"))
                _strategy = new NullStrategy();
            else if (nextValueToCache.Contains("Irish Discoverer Map current editions"))
                _strategy = new DiscovererStrategy(_file);
            else if (nextValueToCache.Contains("Irish Discovery Map current editions"))
                _strategy = new DiscoveryStrategy(_file);
            else if (nextValueToCache.Contains("Irish Street Map"))
                _strategy = new NullStrategy();
        }

        private void CreateMapEntityAndResetCache()
        {
            _strategy.CreateMap(_cache);
            _position += _cacheSize;
            _cache = string.Empty;
            _cacheSize = 0;
        }

        private bool EndOfFile()
        {
            return _position + _cacheSize >= _lines.Count;
        }

        abstract class Strategy
        {
            public virtual bool IsMatch(string record)
            {
                return CaptureRegex.IsMatch(record);
            }

            public virtual void CreateMap(string record)
            {
                var match = ExtractRegex.Match(record);
                AddTo.Add(new Map
                {
                    Publisher = "Ordnance Survey",
                    Series = Series,
                    Code = match.Groups["Code"].Value,
                    Name = match.Groups["Name"].Value,
                    Isbn = match.Groups["Isbn"].Value,
                    Scale = Scale
                });
            }

            protected Regex CaptureRegex = new Regex(@"^(OL\d{1,2}|\d{1,3}) (\S| )*\d{13} \d{2}(\/\d{2}){2} [a-zA-Z]{3,9} \d{4} [a-zA-Z]{3,9} \d{4}$");
            protected Regex ExtractRegex = new Regex(@"^(?'Code'(OL\d{1,2}|\d{1,3})) (?'Name'.*) (?'Isbn'\d{13}).*$");
            protected IList<Map> AddTo;
            protected string Series;
            protected decimal Scale;
        }

        private class NullStrategy : Strategy
        {
            public override bool IsMatch(string record) { return false; }
        }

        private class LandrangerStrategy : Strategy
        {
            public LandrangerStrategy(OsFile file)
            {
                AddTo = file.LandrangerMaps;
                Series = "Landranger";
                Scale = 1 / 50000m;
            }
        }

        private class LandrangerActiveStrategy : LandrangerStrategy
        {
            public LandrangerActiveStrategy(OsFile file) : base(file)
            {
                AddTo = file.LandrangerActiveMaps;
                Series = "Landranger Active";
            }
        }

        private class ExplorerStrategy : Strategy
        {
            public ExplorerStrategy(OsFile file)
            {
                AddTo = file.ExplorerMaps;
                Series = "Explorer";
                Scale = 1 / 50000m;
            }
        }

        private class ExplorerActiveStrategy : ExplorerStrategy
        {
            public ExplorerActiveStrategy(OsFile file) : base(file)
            {
                AddTo = file.ExplorerActiveMaps;
                Series = "Explorer Active";
            }
        }

        private class DiscovererStrategy : Strategy
        {
            public DiscovererStrategy(OsFile file)
            {
                CaptureRegex = new Regex(@"^(OL\d{1,2}|\d{1,3}) (\S| )*\d{13} \d{2}(\/\d{2}){2} .*$");
                AddTo = file.DiscovererMaps;
                Series = "Discoverer";
                Scale = 1 / 50000m;
            }
        }

        private class DiscoveryStrategy : DiscovererStrategy
        {
            public DiscoveryStrategy(OsFile file) : base(file)
            {
                AddTo = file.DiscoveryMaps;
                Series = "Discovery";
            }
        }
    }
}
