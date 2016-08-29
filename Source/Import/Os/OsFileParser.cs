using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ScotlandsMountains.Import.Os
{
    public interface IOsFileParser
    {
        void Parse(OsFile file);
    }

    public class OsFileParser : IOsFileParser
    {
        private OsFile _file;
        private IList<string> _lines;
        private int _position;
        private string _cache = string.Empty;
        private int _cacheSize;

        private Strategy _strategy = new NullStrategy();

        public void Parse(OsFile file)
        {
            _file = file;
            _lines = file.Lines;

            do
            {
                if (CacheContainsMapRecord())
                    CreateMapEntityAndResetCache();
                else if (CacheIsTooBig())
                    ResetCache();
                else
                    ReadNextLine();

            } while (!EndOfFile());
        }

        private bool CacheContainsMapRecord()
        {
            return _strategy.IsMatch(_cache);
        }

        private void CreateMapEntityAndResetCache()
        {
            _strategy.CreateMap(_cache);
            ResetCache();
        }

        private bool CacheIsTooBig()
        {
            return (_cacheSize > _strategy.MaxLineCacheSize) || (_position + _cacheSize >= _lines.Count);
        }

        private void ReadNextLine()
        {
            var line = _lines[_position + _cacheSize];

            if (string.IsNullOrEmpty(_cache))
            {
                SetStrategyBasedOn(line);
                _cache += line;
            }
            else
            {
                _cache = _cache + " " + line;
            }

            _cacheSize++;
        }

        private void ResetCache()
        {
            _position++;
            _cache = string.Empty;
            _cacheSize = 0;
        }

        private bool EndOfFile()
        {
            return _position > _lines.Count;
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

        abstract class Strategy
        {
            protected Strategy(OsFile file)
            {
                File = file;
            }

            public virtual bool IsMatch(string record)
            {
                return CaptureRegex.IsMatch(record);
            }

            public virtual void CreateMap(string record)
            {
                var match = _extractRegex.Match(record);
                AddTo.Add(new OsRecord
                {
                    Code = match.Groups["Code"].Value.Trim(),
                    Name = match.Groups["Name"].Value.Trim(),
                    Isbn = match.Groups["Isbn"].Value.Trim()
                });
            }


            private readonly Regex _extractRegex = new Regex(@"^(?'Code'(OL\d{1,2}|\d{1,3})) (?'Name'.*) (?'Isbn'\d{13}).*$");

            public virtual int MaxLineCacheSize { get; } = 1;

            protected readonly OsFile File;

            protected abstract Regex CaptureRegex { get; }
            protected abstract IList<OsRecord> AddTo { get; }
        }

        private class NullStrategy : Strategy
        {
            public NullStrategy() : base(null) { }

            public override int MaxLineCacheSize => 0;
            protected override Regex CaptureRegex => null;
            protected override IList<OsRecord> AddTo => null;
            public override bool IsMatch(string record) { return false; }
        }

        private class LandrangerStrategy : Strategy
        {
            public LandrangerStrategy(OsFile file) : base(file) { }

            public override int MaxLineCacheSize => 10;
            protected override Regex CaptureRegex => new Regex(@"^\d{1,3} \S(\S| )* \d{13} \d{2}(\/\d{2}){2} [a-zA-Z]{3,9} \d{4} [a-zA-Z]{3,9} \d{4}$");
            protected override IList<OsRecord> AddTo => File.Landranger;
        }

        private class LandrangerActiveStrategy : LandrangerStrategy
        {
            public LandrangerActiveStrategy(OsFile file) : base(file) { }

            protected override IList<OsRecord> AddTo => File.LandrangerActive;
        }

        private class ExplorerStrategy : Strategy
        {
            public ExplorerStrategy(OsFile file) : base(file) { }

            public override int MaxLineCacheSize => 9;
            protected override Regex CaptureRegex => new Regex(@"^(OL\d{1,2}|\d{1,3}) \S(\S| )* \d{13} \d{2}(\/\d{2}){2} [a-zA-Z]{3,9} \d{4} [a-zA-Z]{3,9} \d{4}$");
            protected override IList<OsRecord> AddTo => File.Explorer;
        }

        private class ExplorerActiveStrategy : ExplorerStrategy
        {
            public ExplorerActiveStrategy(OsFile file) : base(file) { }

            protected override IList<OsRecord> AddTo => File.ExplorerActive;
        }

        private class DiscovererStrategy : Strategy
        {
            public DiscovererStrategy(OsFile file) : base(file) { }

            public override int MaxLineCacheSize => 3;
            protected override Regex CaptureRegex => new Regex(@"^\d{1,2} \S(\S| )*\d{13} \d{2}(\/\d{2}){2} .*$");
            protected override IList<OsRecord> AddTo => File.Discoverer;
        }

        private class DiscoveryStrategy : DiscovererStrategy
        {
            public DiscoveryStrategy(OsFile file) : base(file) { }

            protected override IList<OsRecord> AddTo => File.Discovery;
        }
    }
}
