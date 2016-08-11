using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ScotlandsMountains.Import
{
    internal class OsFileParser
    {
        private readonly OsFile _file;
        private readonly IList<string> _lines;

        private static class MapConstants
        {
            public const string OrdnanceSurvey = "Ordnance Survey";
            public const string Landranger = "Landranger";
            public const string LandrangerActive = "Landranger Active";
            public const string Explorer = "Explorer";
            public const string ExplorerActive = "Explorer Active";
            public const string Discovery = "Discovery";
            public const decimal OneTo50000 = 1 / 50000m;
            public const decimal OneTo25000 = 1 / 25000m;
        }

        public OsFileParser(OsFile file)
        {
            _file = file;
            _lines = file.Lines;

            ReadLandrangerMaps();
        }

        private void ReadLandrangerMaps()
        {
            var records = Capture(Pages(5,12), @"^[A-Z0-9]* (\S| )*\d{13} \d{2}(\/\d{2}){2} (Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec) \d{4} (January|February|March|April|May|June|July|August|September|October|November|December) \d{4}$", 10);
        }

        private List<string> Pages(int from, int to)
        {
            return _lines
                .SkipWhile(x => !x.Contains("Page " + (from - 1)))
                .Skip(1)
                .TakeWhile(x => !x.Contains("Page " + to))
                .ToList();
        }

        private static IEnumerable<string> Capture(List<string> lines, string pattern, int maxLIneCacheSize)
        {
            var regex = new Regex(pattern);
            var result = new List<string>();

            var position = 0;
            var cache = string.Empty;
            var cacheSize = 0;

            do
            {
                if (regex.IsMatch(cache))
                {
                    //yield return cache;
                    result.Add(cache);
                    position += cacheSize;
                    cache = string.Empty;
                    cacheSize = 0;
                }
                else
                {
                    if (cacheSize >= maxLIneCacheSize)
                    {
                        position++;
                        cache = string.Empty;
                        cacheSize = 0;
                    }

                    if (position + cacheSize >= lines.Count)
                        break;

                    if (string.IsNullOrEmpty(cache))
                        cache += lines[position + cacheSize];
                    else
                        cache = cache + " " + lines[position + cacheSize];

                    cacheSize++;
                }
            } while (true);

            return result;
        }
    }
}

/*
OS Landranger current editions
Landranger Title ISBN Pub date Edn Revised Date
1
Shetland – Yell, Unst and
Fetlar
9780319260999
24/02/16
Feb
2016
May 2015

Leisure map catalogue
v1.51 © Crown copyright
Page 5 of 60

OS Landranger – Active current editions
Landranger
Active
Title ISBN Pub date Edn  Revised Date
1
Shetland – Yell, Unst and
Fetlar
9780319473245
24/02/16
Feb
2016
May 2015

OS Explorer current editions
Explorer  Title ISBN
Pub
date
Edn Revised date
OL1 Peak District – Dark Peak area 9780319242407 10/06/15
May
2015 December 2010

OS Explorer – Active current editions
Explorer
Active
Title ISBN-13 Pub date Edn Revised Date
OL1 Peak District – Dark Peak area 9780319469194 10/06/15
May 2015 December 2010

Irish Discoverer Map current editions
Discoverer Title ISBN-13 Pub date Edn
4 Coleraine 9781905306640 11/04/12 E

Irish Discovery Map current editions
Discovery Title ISBN-13 Pub date Edn
1 Donegal (NW) 9781907122415 30/01/12 4th
*/
