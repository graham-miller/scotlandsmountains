using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ScotlandsMountains.Domain
{
    public partial class DobihRecord
    {
        public static IList<DobihRecord> BuildFrom(string[] header, List<string[]> data)
        {
            var propertyMapper = GetPropertyMappers(header);

            return data
                //.Where(x => x[24] == "S" || x[24] == "ES") // HACK restrict to Scottish hills for now
                .Select(x => new DobihRecord(x, propertyMapper))
                .ToList();
        }

        private DobihRecord(string[] line, Action<DobihRecord, string>[] propertyMapper)
        {
            for (var index = 0; index < line.Length; index++)
                propertyMapper[index](this, line[index]);
        }

        private static Action<DobihRecord, string>[] GetPropertyMappers(string[] dobihFieldNames)
        {
            return dobihFieldNames.Select(PropertyMapperByDobihFieldName).ToArray();
        }

        private static Action<DobihRecord, string> PropertyMapperByDobihFieldName(string dobihFieldName)
        {
            var propertyInfo = GetPropertyInfoBy(dobihFieldName);
            return (record, value) => propertyInfo.SetValue(record, value);
        }

        private static PropertyInfo GetPropertyInfoBy(string dobihFieldName)
        {
            return typeof(DobihRecord).GetProperties()
                .Where(x => Attribute.IsDefined(x, typeof(DobihFieldNameAttribute)))
                .Single(x =>
                    ((DobihFieldNameAttribute) Attribute.GetCustomAttribute(x, typeof(DobihFieldNameAttribute))).Name == dobihFieldName);
        }

        [DobihFieldName("Number")]
        public string Number { get; set; }

        [DobihFieldName("Name")]
        public string Name { get; set; }

        [DobihFieldName("Parent (SMC)")]
        public string ParentSmc { get; set; }

        [DobihFieldName("Parent name (SMC)")]
        public string ParentNameSmc { get; set; }

        [DobihFieldName("Section")]
        public string Section { get; set; }

        [DobihFieldName("Region")]
        public string Region { get; set; }

        [DobihFieldName("Area")]
        public string Area { get; set; }

        [DobihFieldName("Island")]
        public string Island { get; set; }

        [DobihFieldName("Topo Section")]
        public string TopoSection { get; set; }

        [DobihFieldName("County")]
        public string County { get; set; }

        [DobihFieldName("Classification")]
        public string Classification { get; set; }

        [DobihFieldName("Map 1:50k")]
        public string Map1To50000 { get; set; }

        [DobihFieldName("Map 1:25k")]
        public string Map1To25000 { get; set; }

        [DobihFieldName("Metres")]
        public string Metres { get; set; }

        [DobihFieldName("Feet")]
        public string Feet { get; set; }

        [DobihFieldName("Grid ref")]
        public string GridRef { get; set; }

        [DobihFieldName("Grid ref 10")]
        public string GridRef10 { get; set; }

        [DobihFieldName("Drop")]
        public string Drop { get; set; }

        [DobihFieldName("Col grid ref")]
        public string ColGridRef { get; set; }

        [DobihFieldName("Col height")]
        public string ColHeight { get; set; }

        [DobihFieldName("Feature")]
        public string Feature { get; set; }

        [DobihFieldName("Observations")]
        public string Observations { get; set; }

        [DobihFieldName("Survey")]
        public string Survey { get; set; }

        [DobihFieldName("Climbed")]
        public string Climbed { get; set; }

        [DobihFieldName("Country")]
        public string Country { get; set; }

        [DobihFieldName("County Top")]
        public string CountyTop { get; set; }

        [DobihFieldName("Revision")]
        public string Revision { get; set; }

        [DobihFieldName("Comments")]
        public string Comments { get; set; }

        [DobihFieldName("Streetmap/OSiViewer")]
        public string StreetMapOSiViewer { get; set; }

        [DobihFieldName("Geograph/MountainViews")]
        public string GeographMountainViews { get; set; }

        [DobihFieldName("Hill-bagging")]
        public string HillBagging { get; set; }

        [DobihFieldName("Xcoord")]
        public string XCoord { get; set; }

        [DobihFieldName("Ycoord")]
        public string YCoord { get; set; }

        [DobihFieldName("Latitude")]
        public string Latitude { get; set; }

        [DobihFieldName("Longitude")]
        public string Longitude { get; set; }

        [DobihFieldName("GridrefXY")]
        public string GridRefXY { get; set; }

        [DobihFieldName("_Section")]
        public string NumericSection { get; set; }

        [DobihFieldName("Parent (Ma)")]
        public string ParentMa { get; set; }

        [DobihFieldName("Parent name (Ma)")]
        public string ParentNameMa { get; set; }

        [DobihFieldName("MVNumber")]
        public string MvNumber { get; set; }

        [DobihFieldName("Ma")]
        public string Marilyn { get; set; }

        [DobihFieldName("Ma=")]
        public string MarilynTwin { get; set; }

        [DobihFieldName("Hu")]
        public string Hump { get; set; }

        [DobihFieldName("Hu=")]
        public string HumpTwin { get; set; }

        [DobihFieldName("Tu")]
        public string Tump { get; set; }

        [DobihFieldName("Tu=")]
        public string TumpTwin { get; set; }

        [DobihFieldName("Sim")]
        public string Simm { get; set; }

        [DobihFieldName("5")]
        public string Dodd { get; set; }

        [DobihFieldName("M")]
        public string Munro { get; set; }

        [DobihFieldName("MT")]
        public string MunroTop { get; set; }

        [DobihFieldName("F")]
        public string Furth { get; set; }

        [DobihFieldName("C")]
        public string Corbett { get; set; }

        [DobihFieldName("G")]
        public string Graham { get; set; }

        [DobihFieldName("D")]
        public string Donald { get; set; }

        [DobihFieldName("DT")]
        public string DonaldTop { get; set; }

        [DobihFieldName("Mur")]
        public string Murdo { get; set; }

        [DobihFieldName("CT")]
        public string CorbettTop { get; set; }

        [DobihFieldName("GT")]
        public string GrahamTop { get; set; }

        [DobihFieldName("Hew")]
        public string Hewitt { get; set; }

        [DobihFieldName("N")]
        public string Nuttall { get; set; }

        [DobihFieldName("Dew")]
        public string Dewey { get; set; }

        [DobihFieldName("DDew")]
        public string DonaldDewey { get; set; }

        [DobihFieldName("HF")]
        public string HighlandFive { get; set; }

        [DobihFieldName("4")]
        public string Tump400To499M { get; set; }

        [DobihFieldName("3")]
        public string Tump300To399M { get; set; }

        [DobihFieldName("2")]
        public string Tump200To299M { get; set; }

        [DobihFieldName("1")]
        public string Tump100To199M { get; set; }

        [DobihFieldName("1=")]
        public string Tump100To199MTwin { get; set; }

        [DobihFieldName("0")]
        public string Tump0To99M { get; set; }

        [DobihFieldName("W")]
        public string Wainwright { get; set; }

        [DobihFieldName("WO")]
        public string WainwrightOutlyingFell { get; set; }

        [DobihFieldName("B")]
        public string Birkett { get; set; }

        [DobihFieldName("CoH")]
        public string CountyTopHistoric { get; set; }

        [DobihFieldName("CoH=")]
        public string CountyTopHistoricTwin { get; set; }

        [DobihFieldName("CoU")]
        public string CountyTopCurrentCountyAndUnitaryAuthority { get; set; }

        [DobihFieldName("CoU=")]
        public string CountyTopCurrentCountyAndUnitaryAuthorityTwin { get; set; }

        [DobihFieldName("CoA")]
        public string CountyTopAdministrative { get; set; }

        [DobihFieldName("CoA=")]
        public string CountyTopAdministrativeTwin { get; set; }

        [DobihFieldName("CoL")]
        public string CountyTopLondonBorough { get; set; }

        [DobihFieldName("CoL=")]
        public string CountyTopLondonBoroughTwin { get; set; }

        [DobihFieldName("SIB")]
        public string SignificantIslandofBritain { get; set; }

        [DobihFieldName("sMa")]
        public string SubMarylin { get; set; }

        [DobihFieldName("sHu")]
        public string SubHump { get; set; }

        [DobihFieldName("sSim")]
        public string SubSimm { get; set; }

        [DobihFieldName("s5")]
        public string SubDodd { get; set; }

        [DobihFieldName("sMDew")]
        public string SubMyrddynDewey { get; set; }

        [DobihFieldName("s4")]
        public string SubTump400To499M { get; set; }

        [DobihFieldName("Sy")]
        public string Synge { get; set; }

        [DobihFieldName("Fel")]
        public string Fellranger { get; set; }

        [DobihFieldName("BL")]
        public string BuxtonAndLewis { get; set; }

        [DobihFieldName("Bg")]
        public string Bridge { get; set; }

        [DobihFieldName("T100")]
        public string Trail100 { get; set; }

        [DobihFieldName("xMT")]
        public string DeletedMunroTop { get; set; }

        [DobihFieldName("xC")]
        public string DeletedCorbett { get; set; }

        [DobihFieldName("xG")]
        public string DeletedGraham { get; set; }

        [DobihFieldName("xN")]
        public string DeletedNuttall { get; set; }

        [DobihFieldName("xDT")]
        public string DeletedDonaldTop { get; set; }

        [DobihFieldName("Dil")]
        public string Dillon { get; set; }

        [DobihFieldName("VL")]
        public string VandeleurLynam { get; set; }

        [DobihFieldName("A")]
        public string Arderin { get; set; }

        [DobihFieldName("MDew")]
        public string MyrddynDewey { get; set; }

        [DobihFieldName("Ca")]
        public string Carn { get; set; }

        [DobihFieldName("Bin")]
        public string Binnion { get; set; }

        [DobihFieldName("O")]
        public string Other { get; set; }

        [DobihFieldName("Un")]
        public string Unclassified { get; set; }
    }

    public class DobihFieldNameAttribute : Attribute
    {
        public DobihFieldNameAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}