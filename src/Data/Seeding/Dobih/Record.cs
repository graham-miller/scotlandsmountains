using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ScotlandsMountains.Data.Seeding.DatabaseOfBritishAndIrishHills.Factories;
using ScotlandsMountains.Domain.Entities;
using ScotlandsMountains.Domain.ValueObjects;

namespace ScotlandsMountains.Data.Seeding.DatabaseOfBritishAndIrishHills
{
    internal class Record
    {
        public Record(IList<string> fields)
        {
            _fields = fields;
            MapFields();
        }

        private Mountain _mountain;
        public Mountain Mountain
        {
            get
            {
                if (_mountain == null)
                {
                    _mountain  = new Mountain
                        {
                            Name = Name,
                            Height = new Height(Metres),
                            Location = new Location(Latitude, Longitude, GridRef, GridRef10),
                            Summit = new Summit {Description = Feature, Notes = Observations},
                            Prominence = ProminenceFactory.Build(Drop, ColGridRef, ColHeight),
                            Aliases = new Collection<Alias>(),
                            DobihId = Number
                        };
                    ExtractAliases();
                }
                return _mountain;
            }
        }

        private void ExtractAliases()
        {
            var aliases = new List<Alias>();
            var name = "";
            var insideAlias = false;

            for (var index = 0; index < _mountain.Name.Length; index++)
            {
                var letter = _mountain.Name.Substring(index, 1);

                switch (letter)
                {
                    case "[":
                        insideAlias = true;
                        aliases.Add(new Alias());
                        break;
                    case "]":
                        insideAlias = false;
                        break;
                    default:
                        if (insideAlias)
                            aliases.Last().Name += letter;
                        else
                            name += letter;
                        break;
                }
            }
            
            name = name.Replace("  ", " ").Trim();
            aliases.ForEach(x => x.Name = x.Name.Replace("  ", " ").Trim());

            _mountain.Name = name;
            _mountain.Aliases = aliases;
        }

        public bool IsIrish()
        {
            return Country == "I";
        }

        public int Number { get; private set; }
        public string Name { get; private set; }
        public string ParentName { get; private set; }
        public int? ParentNumber { get; private set; }
        public string Section { get; private set; }
        public string Region { get; private set; }
        public string Area { get; private set; }
        public string Classification { get; private set; }
        public IEnumerable<string> Map1To50000 { get; private set; }
        public IEnumerable<string> Map1To25000 { get; private set; }
        public double Metres { get; private set; }
        public string Feet { get; private set; }
        public string GridRef { get; private set; }
        public string GridRef10 { get; private set; }
        public double Drop { get; private set; }
        public string ColGridRef { get; private set; }
        public double ColHeight { get; private set; }
        public string Feature { get; private set; }
        public string Observations { get; private set; }
        public string Survey { get; private set; }
        public string Climbed { get; private set; }
        public string Country { get; private set; }
        public string County { get; private set; }
        public string Revision { get; private set; }
        public string Comments { get; private set; }
        public string StreetmapOSiViewer { get; private set; }
        public string GeographMountainViews { get; private set; }
        public string HillBagging { get; private set; }
        public string XCoord { get; private set; }
        public string YCoord { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public string GridRefXY { get; private set; }
        public string SectionNumber { get; private set; }
        public string ParentSort { get; private set; }
        public string TumpNumber { get; private set; }
        public string TumpOnly { get; private set; }
        public string MvNumber { get; private set; }
        public bool IsMarilyn { get; private set; }
        public bool IsMarilynTwin { get; private set; }
        public bool IsHump { get; private set; }
        public bool IsHumpTwin { get; private set; }
        public bool IsMunro { get; private set; }
        public bool IsMunroTop { get; private set; }
        public bool IsMurdo { get; private set; }
        public bool IsFurth { get; private set; }
        public bool IsCorbett { get; private set; }
        public bool IsCorbettTop { get; private set; }
        public bool IsCorbettTopOfMunro { get; private set; }
        public bool IsCorbettTopOfCorbett { get; private set; }
        public bool IsGraham { get; private set; }
        public bool IsGrahamTop { get; private set; }
        public bool IsGrahamTopOfMunro { get; private set; }
        public bool IsGrahamTopOfCorbett { get; private set; }
        public bool IsGrahamTopOfGraham { get; private set; }
        public bool IsGrahamTopOfHewitt { get; private set; }
        public bool IsDonald { get; private set; }
        public bool IsDonaldTop { get; private set; }
        public bool IsHewitt { get; private set; }
        public bool IsNuttal { get; private set; }
        public bool IsDillon { get; private set; }
        public bool IsArderin { get; private set; }
        public bool IsVandeleurLynam { get; private set; }
        public bool IsTump { get; private set; }
        public bool IsTumpTwin { get; private set; }
        public bool IsSim { get; private set; }
        public bool IsDewey { get; private set; }
        public bool IsDonalDewey { get; private set; }
        public bool IsHighlandFive { get; private set; }
        public bool IsMyrddynDewey { get; private set; }
        public bool IsTump400To499M { get; private set; }
        public bool IsTump300To399M { get; private set; }
        public bool IsTump200To299M { get; private set; }
        public bool IsTump100To199M { get; private set; }
        public bool IsTump100To199MTwin { get; private set; }
        public bool IsTump0To99M { get; private set; }
        public bool IsWainwright { get; private set; }
        public bool IsWainwrightOutlyingFell { get; private set; }
        public bool IsBirkett { get; private set; }
        public bool IsCountyTopHistoric { get; private set; }
        public bool IsCountyTopHistoricTwin { get; private set; }
        public bool IsCountyTopCurrentCountyAndUnitaryAuthority { get; private set; }
        public bool IsCountyTopCurrentCountyAndUnitaryAuthorityTwin { get; private set; }
        public bool IsCountyTopAdministrative { get; private set; }
        public bool IsCountyTopAdministrativeTwin { get; private set; }
        public bool IsCountyTopLondonBorough { get; private set; }
        public bool IsCountyTopLondonBoroughTwin { get; private set; }
        public bool IsSignificantIslandOfBritain { get; private set; }
        public bool IsSubsiduaryMarilyn { get; private set; }
        public bool IsSubsiduaryHump { get; private set; }
        public bool IsSubsiduaryMurdo { get; private set; }
        public bool IsSubsiduaryCorbettTop { get; private set; }
        public bool IsSubsiduaryGrahamTop { get; private set; }
        public bool IsSubsiduaryHewitt { get; private set; }
        public bool IsSubsiduaryDewey { get; private set; }
        public bool IsSubsiduaryDonaldDewey { get; private set; }
        public bool IsSubsiduaryHighlandFive { get; private set; }
        public bool IsSubsiduaryMyrddynDewey { get; private set; }
        public bool IsSubsiduaryTump400To499M { get; private set; }
        public bool IsDeletedMunroTop { get; private set; }
        public bool IsDeletedCorbett { get; private set; }
        public bool IsDeletedGraham { get; private set; }
        public bool IsDeletedNuttal { get; private set; }
        public bool IsDeletedDonaldTop { get; private set; }
        public bool IsSynge { get; private set; }
        public bool IsFellranger { get; private set; }
        public bool IsBuxtonAndLewis { get; private set; }
        public bool IsBridge { get; private set; }
        public bool IsTrail100 { get; private set; }
        public bool IsCarn { get; private set; }
        public bool IsBinnion { get; private set; }
        public bool IsOther { get; private set; }
        public bool IsUnclassified { get; private set; }

        private void MapFields()
        {
            Number = Int32.Parse(GetRawValue(0));
            Name = GetRawValue(1);
            ParentName = GetRawValue(2);
            ParentNumber = ParseParentNumber(GetRawValue(3));
            Section = GetRawValue(4);
            Region = ParseRegion(GetRawValue(5));
            Area = GetRawValue(6);
            Classification = GetRawValue(7);
            Map1To50000 = ParseMaps(GetRawValue(8));
            Map1To25000 = ParseMaps(GetRawValue(9));
            Metres = Double.Parse(GetRawValue(10));
            Feet = GetRawValue(11);
            GridRef = GetRawValue(12);
            GridRef10 = ParseGridRef10(GetRawValue(13));
            Drop = Double.Parse(GetRawValue(14));
            ColGridRef = GetRawValue(15);
            ColHeight = Double.Parse(GetRawValue(16));
            Feature = ParseSentence(GetRawValue(17));
            Observations = ParseSentence(GetRawValue(18));
            Survey = GetRawValue(19);
            Climbed = GetRawValue(20);
            Country = GetRawValue(21);
            County = GetRawValue(22);
            Revision = GetRawValue(23);
            Comments = GetRawValue(24);
            StreetmapOSiViewer = GetRawValue(25);
            GeographMountainViews = GetRawValue(26);
            HillBagging = GetRawValue(27);
            XCoord = GetRawValue(28);
            YCoord = GetRawValue(29);
            Latitude = Double.Parse(GetRawValue(30));
            Longitude = Double.Parse(GetRawValue(31));
            GridRefXY = GetRawValue(32);
            SectionNumber = GetRawValue(33);
            ParentSort = GetRawValue(34);
            TumpNumber = GetRawValue(35);
            TumpOnly = GetRawValue(36);
            MvNumber = GetRawValue(37);
            IsMarilyn = ParseHasClassification(GetRawValue(38));
            IsMarilynTwin = ParseHasClassification(GetRawValue(39));
            IsHump = ParseHasClassification(GetRawValue(40));
            IsHumpTwin = ParseHasClassification(GetRawValue(41));
            IsMunro = ParseHasClassification(GetRawValue(42));
            IsMunroTop = ParseHasClassification(GetRawValue(43));
            IsMurdo = ParseHasClassification(GetRawValue(44));
            IsFurth = ParseHasClassification(GetRawValue(45));
            IsCorbett = ParseHasClassification(GetRawValue(46));
            IsCorbettTop = ParseHasClassification(GetRawValue(47));
            IsCorbettTopOfMunro = ParseHasClassification(GetRawValue(48));
            IsCorbettTopOfCorbett = ParseHasClassification(GetRawValue(49));
            IsGraham = ParseHasClassification(GetRawValue(50));
            IsGrahamTop = ParseHasClassification(GetRawValue(51));
            IsGrahamTopOfMunro = ParseHasClassification(GetRawValue(52));
            IsGrahamTopOfCorbett = ParseHasClassification(GetRawValue(53));
            IsGrahamTopOfGraham = ParseHasClassification(GetRawValue(54));
            IsGrahamTopOfHewitt = ParseHasClassification(GetRawValue(55));
            IsDonald = ParseHasClassification(GetRawValue(56));
            IsDonaldTop = ParseHasClassification(GetRawValue(57));
            IsHewitt = ParseHasClassification(GetRawValue(58));
            IsNuttal = ParseHasClassification(GetRawValue(59));
            IsDillon = ParseHasClassification(GetRawValue(60));
            IsArderin = ParseHasClassification(GetRawValue(61));
            IsVandeleurLynam = ParseHasClassification(GetRawValue(62));
            IsTump = ParseHasClassification(GetRawValue(63));
            IsTumpTwin = ParseHasClassification(GetRawValue(64));
            IsSim = ParseHasClassification(GetRawValue(65));
            IsDewey = ParseHasClassification(GetRawValue(66));
            IsDonalDewey = ParseHasClassification(GetRawValue(67));
            IsHighlandFive = ParseHasClassification(GetRawValue(68));
            IsMyrddynDewey = ParseHasClassification(GetRawValue(69));
            IsTump400To499M = ParseHasClassification(GetRawValue(70));
            IsTump300To399M = ParseHasClassification(GetRawValue(71));
            IsTump200To299M = ParseHasClassification(GetRawValue(72));
            IsTump100To199M = ParseHasClassification(GetRawValue(73));
            IsTump100To199MTwin = ParseHasClassification(GetRawValue(74));
            IsTump0To99M = ParseHasClassification(GetRawValue(75));
            IsWainwright = ParseHasClassification(GetRawValue(76));
            IsWainwrightOutlyingFell = ParseHasClassification(GetRawValue(77));
            IsBirkett = ParseHasClassification(GetRawValue(78));
            IsCountyTopHistoric = ParseHasClassification(GetRawValue(79));
            IsCountyTopHistoricTwin = ParseHasClassification(GetRawValue(80));
            IsCountyTopCurrentCountyAndUnitaryAuthority = ParseHasClassification(GetRawValue(81));
            IsCountyTopCurrentCountyAndUnitaryAuthorityTwin = ParseHasClassification(GetRawValue(82));
            IsCountyTopAdministrative = ParseHasClassification(GetRawValue(83));
            IsCountyTopAdministrativeTwin = ParseHasClassification(GetRawValue(84));
            IsCountyTopLondonBorough = ParseHasClassification(GetRawValue(85));
            IsCountyTopLondonBoroughTwin = ParseHasClassification(GetRawValue(86));
            IsSignificantIslandOfBritain = ParseHasClassification(GetRawValue(87));
            IsSubsiduaryMarilyn = ParseHasClassification(GetRawValue(88));
            IsSubsiduaryHump = ParseHasClassification(GetRawValue(89));
            IsSubsiduaryMurdo = ParseHasClassification(GetRawValue(90));
            IsSubsiduaryCorbettTop = ParseHasClassification(GetRawValue(91));
            IsSubsiduaryGrahamTop = ParseHasClassification(GetRawValue(92));
            IsSubsiduaryHewitt = ParseHasClassification(GetRawValue(93));
            IsSubsiduaryDewey = ParseHasClassification(GetRawValue(94));
            IsSubsiduaryDonaldDewey = ParseHasClassification(GetRawValue(95));
            IsSubsiduaryHighlandFive = ParseHasClassification(GetRawValue(96));
            IsSubsiduaryMyrddynDewey = ParseHasClassification(GetRawValue(97));
            IsSubsiduaryTump400To499M = ParseHasClassification(GetRawValue(98));
            IsDeletedMunroTop = ParseHasClassification(GetRawValue(99));
            IsDeletedCorbett = ParseHasClassification(GetRawValue(100));
            IsDeletedGraham = ParseHasClassification(GetRawValue(101));
            IsDeletedNuttal = ParseHasClassification(GetRawValue(102));
            IsDeletedDonaldTop = ParseHasClassification(GetRawValue(103));
            IsSynge = ParseHasClassification(GetRawValue(104));
            IsFellranger = ParseHasClassification(GetRawValue(105));
            IsBuxtonAndLewis = ParseHasClassification(GetRawValue(106));
            IsBridge = ParseHasClassification(GetRawValue(107));
            IsTrail100 = ParseHasClassification(GetRawValue(108));
            IsCarn = ParseHasClassification(GetRawValue(109));
            IsBinnion = ParseHasClassification(GetRawValue(110));
            IsOther = ParseHasClassification(GetRawValue(111));
            IsUnclassified = ParseHasClassification(GetRawValue(112));
        }

        private static int? ParseParentNumber(string s)
        {
            return String.IsNullOrWhiteSpace(s) ? (int?)null : Int32.Parse(s);
        }

        private static string ParseRegion(string s)
        {
            return String.IsNullOrWhiteSpace(s) ? null : s.Substring(s.IndexOf(":", StringComparison.Ordinal) + 1).Trim();
        }

        private static IEnumerable<string> ParseMaps(string s)
        {
            if (String.IsNullOrWhiteSpace(s)) return new String[0];

            return s.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(RemoveNonDigitCharacters);
        }

        private static string RemoveNonDigitCharacters(string s)
        {
            return new string(s.Where(char.IsDigit).ToArray());
        }

        private string GetRawValue(int index)
        {
            return String.IsNullOrWhiteSpace(_fields[index]) ? null : _fields[index].Trim();
        }

        private static string ParseSentence(string s)
        {
            if (String.IsNullOrWhiteSpace(s)) return null;

            var sentence = s.Trim();
            sentence = sentence.Substring(0, 1).ToUpper() + sentence.Substring(1);

            if (!sentence.EndsWith("."))
                sentence += ".";

            return sentence;
        }

        private static string ParseGridRef10(string s)
        {
            return String.IsNullOrWhiteSpace(s) ? null : s.Replace(" ", "");
        }

        private static bool ParseHasClassification(string s)
        {
            return s == "1";
        }

        private readonly IList<string> _fields;
    }
}