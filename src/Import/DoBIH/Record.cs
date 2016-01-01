using System;
using System.Collections.Generic;
using System.Linq;
using ScotlandsMountains.Import.DoBIH;

namespace ScotlandsMountains.Import.Dobih
{
    public class Record
    {
        private readonly string[] _fields;

        public Record(string[] fields)
        {
            _fields = fields;
        }

        public int FieldCount { get { return _fields.Count(); } }
        public string ElementAt(int position) { return ReadField(position); }

        public int Number { get { return Int32.Parse(ReadField(0)); } }
        public string Name { get { return ReadField(1); } }
        //public string Parent { get { return ReadField(2); } }
        public string ParentNumber { get { return ReadField(3); } }
        //public string Section { get { return ReadField(4); } }
        public string Region { get { return ReadField(5); } }
        public string Area { get { return ReadField(6); } }
        //public string Classification { get { return ReadField(7); } }
        public string Map1To50K { get { return ReadField(8); } }
        public string Map1To25K { get { return ReadField(9); } }
        public decimal Metres { get { return Decimal.Parse(ReadField(10)); } }
        //public string Feet { get { return ReadField(11); } }
        public string GridRef { get { return ReadField(12); } }
        //public string GridRef10 { get { return ReadField(13); } }
        public decimal Drop { get { return Decimal.Parse(ReadField(14)); } }
        public string ColGridRef { get { return ReadField(15); } }
        public decimal ColHeight { get { return Decimal.Parse(ReadField(16)); } }
        public string Feature { get { return ReadField(17); } }
        public string Observations { get { return ReadField(18); } }
        //public string Survey { get { return ReadField(19); } }
        //public string Climbed { get { return ReadField(20); } }
        public string Country { get { return ReadField(21); } }
        //public string County { get { return ReadField(22); } }
        //public string Revision { get { return ReadField(23); } }
        //public string Comments { get { return ReadField(24); } }
        //public string StreetmapOsiViewer { get { return ReadField(25); } }
        //public string GeographMountainViews { get { return ReadField(26); } }
        //public string HillBagging { get { return ReadField(27); } }
        //public string XCoord { get { return ReadField(28); } }
        //public string YCoord { get { return ReadField(29); } }
        public decimal Latitude { get { return Decimal.Parse(ReadField(30)); } }
        public decimal Longitude { get { return Decimal.Parse(ReadField(31)); } }
        //public string Gridrefxy { get { return ReadField(32); } }
        //public string AltSection { get { return ReadField(33); } }
        //public string ParentSort { get { return ReadField(34); } }
        //public string TumpNumber { get { return ReadField(35); } }
        //public string TumpOnly { get { return ReadField(36); } }
        //public string MvNumber { get { return ReadField(37); } }
        //public string Marilyn { get { return ReadField(38); } }
        //public string MarilynTwin { get { return ReadField(39); } }
        //public string Hump { get { return ReadField(40); } }
        //public string HumpTwin { get { return ReadField(41); } }
        //public string Munro { get { return ReadField(42); } }
        //public string MunroTop { get { return ReadField(43); } }
        //public string Murdo { get { return ReadField(44); } }
        //public string Furth { get { return ReadField(45); } }
        //public string Corbett { get { return ReadField(46); } }
        //public string CorbettTop { get { return ReadField(47); } }
        //public string CorbettTopOfMunro { get { return ReadField(48); } }
        //public string CorbettTopOfCorbett { get { return ReadField(49); } }
        //public string Graham { get { return ReadField(50); } }
        //public string GrahamTop { get { return ReadField(51); } }
        //public string GrahamTopOfMunro { get { return ReadField(52); } }
        //public string GrahamTopOfCorbett { get { return ReadField(53); } }
        //public string GrahamToOfGraham { get { return ReadField(54); } }
        //public string GrahamTopOfHewitt { get { return ReadField(55); } }
        //public string Donald { get { return ReadField(56); } }
        //public string DonaldTop { get { return ReadField(57); } }
        //public string Hewitt { get { return ReadField(58); } }
        //public string Nuttal { get { return ReadField(59); } }
        //public string Dillon { get { return ReadField(60); } }
        //public string Arderin { get { return ReadField(61); } }
        //public string VandeleurLynam { get { return ReadField(62); } }
        //public string Tump { get { return ReadField(63); } }
        //public string TumpTwin { get { return ReadField(64); } }
        //public string Sim { get { return ReadField(65); } }
        //public string Dewey { get { return ReadField(66); } }
        //public string DonaldDewey { get { return ReadField(67); } }
        //public string HighlandFive { get { return ReadField(68); } }
        //public string MyrddynDewey { get { return ReadField(69); } }
        //public string Tump400To499 { get { return ReadField(70); } }
        //public string Tump300To399 { get { return ReadField(71); } }
        //public string Tump200To299 { get { return ReadField(72); } }
        //public string Tump100To199 { get { return ReadField(73); } }
        //public string Tump100To199Twin { get { return ReadField(74); } }
        //public string Tump0To99 { get { return ReadField(75); } }
        //public string Wainwright { get { return ReadField(76); } }
        //public string WainwrightOutlyingFell { get { return ReadField(77); } }
        //public string Birkett { get { return ReadField(78); } }
        //public string CountyTopHistoric { get { return ReadField(79); } }
        //public string CountyTopCurrentCountyAndUnitaryAuthority { get { return ReadField(80); } }
        //public string CountyTopCurrentCountyAndUnitaryAuthorityTwin { get { return ReadField(81); } }
        //public string CountyTopAdministrative { get { return ReadField(82); } }
        //public string CountyTopLondonBorough { get { return ReadField(83); } }
        //public string CountyTopLondonBoroughTwin { get { return ReadField(84); } }
        //public string SubMarilyn { get { return ReadField(85); } }
        //public string SubHump { get { return ReadField(86); } }
        //public string SubMurdo { get { return ReadField(87); } }
        //public string SubCorbettTop { get { return ReadField(88); } }
        //public string SubGrahamTop { get { return ReadField(89); } }
        //public string SubHewitt { get { return ReadField(90); } }
        //public string SubDewey { get { return ReadField(91); } }
        //public string SubDonaldDewey { get { return ReadField(92); } }
        //public string SubHighlandFive { get { return ReadField(93); } }
        //public string SubMyrddynDewey { get { return ReadField(94); } }
        //public string Sub400To499Tump { get { return ReadField(95); } }
        //public string DeletedMunroTop { get { return ReadField(96); } }
        //public string DeletedCorbett { get { return ReadField(97); } }
        //public string DeletedNuttall { get { return ReadField(98); } }
        //public string DeletedDonaldTop { get { return ReadField(99); } }
        //public string Synge { get { return ReadField(100); } }
        //public string Fellranger { get { return ReadField(101); } }
        //public string BuxtonAndLewis { get { return ReadField(102); } }
        //public string Bridge { get { return ReadField(103); } }
        //public string Trail100 { get { return ReadField(104); } }
        //public string Carn { get { return ReadField(105); } }
        //public string Binnion { get { return ReadField(106); } }
        //public string OtherList { get { return ReadField(107); } }
        //public string Unclassified { get { return ReadField(108); } }

        public IList<string> LandrangerSheets { get { return IsIrish ? new List<string>() : ParseSheetCodes(Map1To50K); } }

        public IList<string> ExplorerSheets { get { return IsIrish ? new List<string>() : ParseSheetCodes(Map1To25K); } }

        public IList<string> DiscoverySheets { get { return !IsIrish ? new List<string>() : ParseSheetCodes(Map1To50K); } }

        private bool IsIrish { get { return Country == Constants.IrelandAbbreviation; } }

        private static IList<string> ParseSheetCodes(string sheetCodes)
        {
            return sheetCodes
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(RemoveTrailingSpecifier)
                .ToList();
        }

        private static string RemoveTrailingSpecifier(string value)
        {
            if (
                value.EndsWith(Constants.North) || 
                value.EndsWith(Constants.East) || 
                value.EndsWith(Constants.West) || 
                value.EndsWith(Constants.South))
                return value.Substring(0, value.Length - 1);

            return value;
        }

        private string ReadField(int fieldIndex)
        {
            return _fields[fieldIndex].Trim();
        }
    }
}
