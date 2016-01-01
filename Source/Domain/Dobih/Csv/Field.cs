using System;

namespace ScotlandsMountains.Domain.Dobih.Csv
{
    class TitleAttribute : Attribute
    {
        public string Title { get; private set; }

        public TitleAttribute(string title)
        {
            Title = title;
        }
    }
    
    enum Field
    {
        [Title("Number")] Number = 0,
        [Title("Name")] Name = 1,
        [Title("Parent (Ma/M)")] Parent = 2,
        [Title("Parent Number")] ParentNumber = 3,
        [Title("Section")] Section = 4,
        [Title("Region")] Region = 5,
        [Title("Area")] Area = 6,
        [Title("Classification")] Classification = 7,
        [Title("Map")] Map = 8,
        [Title("Map25")] Map25 = 9,
        [Title("Metres")] Metres = 10,
        [Title("Feet")] Feet = 11,
        [Title("Grid ref")] GridRef = 12,
        [Title("Grid ref 10")] GridRef10 = 13,
        [Title("Drop")] Drop = 14,
        [Title("Col grid ref")] ColGridRef = 15,
        [Title("Col height")] ColHeight = 16,
        [Title("Feature")] Feature = 17,
        [Title("Observations")] Observations = 18,
        [Title("Survey")] Survey = 19,
        [Title("Climbed")] Climbed = 20,
        [Title("Country")] Country = 21,
        [Title("County")] County = 22,
        [Title("Revision")] Revision = 23,
        [Title("Comments")] Comments = 24,
        [Title("Streetmap/OSiViewer")] Streetmap = 25,
        [Title("Geograph")] Geograph = 26,
        [Title("Hill-bagging")] HillBagging = 27,
        [Title("Xcoord")] XCoord = 28,
        [Title("Ycoord")] YCoord = 29,
        [Title("Latitude")] Latitude = 30,
        [Title("Longitude")] Longitude = 31,
        [Title("GridrefXY")] GridRefXy = 32,
        [Title("_Section")] SectionNumber = 33,
        [Title("Parent Sort")] ParentSort = 34,
        [Title("Tumpnumber")] TumpNumber = 35,
        [Title("Tumponly")] TumpOnly = 36,
        [Title("MVNumber")] MvNumber = 37,
        [Title("Ma")] Marilyn = 38,
        [Title("Ma=")] MarilynTwin = 39,
        [Title("Hu")] Hump = 40,
        [Title("Hu=")] HumpTwin = 41,
        [Title("M")] Munro = 42,
        [Title("MT")] MunroTop = 43,
        [Title("Mur")] Murdo = 44,
        [Title("F")] Furth = 45,
        [Title("C")] Corbett = 46,
        [Title("CT")] CorbettTop = 47,
        [Title("CTM")] CorbettTopOfMunro = 48,
        [Title("CTC")] CorbettTopOfCorbett = 49,
        [Title("G")] Graham = 50,
        [Title("GT")] GrahamTop = 51,
        [Title("GTM")] GrahamTopOfMunro = 52,
        [Title("GTC")] GrahamTopOfCorbett = 53,
        [Title("GTG")] GrahamTopOfGraham = 54,
        [Title("GTH")] GrahamTopOfHewitt = 55,
        [Title("D")] Donald = 56,
        [Title("DT")] DonaldTop = 57,
        [Title("Hew")] Hewitt = 58,
        [Title("N")] Nuttall = 59,
        [Title("Dil")] Dillon = 60,
        [Title("A")] Arderin = 61,
        [Title("VL")] VandeleurLynam = 62,
        [Title("Tu")] Tump = 63,
        [Title("Sim")] Sim = 64,
        [Title("5")] Dewey = 65,
        [Title("5D")] DonaldDewey = 66,
        [Title("5H")] HighlandFive = 67,
        [Title("5M")] MyrddynDewey = 68,
        [Title("4")] Tump400To499M = 69,
        [Title("3")] TumpGb300To399M = 70,
        [Title("2")] TumpGb200To299M = 71,
        [Title("1")] TumpGb100To199M = 72,
        [Title("0")] TumpGb0To99M = 73,
        [Title("W")] Wainwright = 74,
        [Title("WO")] WainwrightOutlyingFell = 75,
        [Title("B")] Birkett = 76,
        [Title("CoH")] CountyTopHistoric = 77,
        [Title("CoU")] CountyTopCurrentCountyAndUnitaryAuthority = 78,
        [Title("CoU=")] CountyTopCurrentCountyAndUnitaryAuthorityTwin = 79,
        [Title("CoA")] CountyTopAdministrative = 80,
        [Title("CoL")] CountyTopLondonBorough = 81,
        [Title("CoL=")] CountyTopLondonBoroughTwin = 82,
        [Title("sMa")] SubsidiaryMarilyn = 83,
        [Title("sHu")] SubsidiaryHump = 84,
        [Title("sMur")] SubsidiaryMurdo = 85,
        [Title("sCT")] SubsidiaryCorbettTop = 86,
        [Title("sGT")] SubsidiaryGrahamTop = 87,
        [Title("sHew")] SubsidiaryHewitt = 88,
        [Title("s5")] SubsidiaryDewey = 89,
        [Title("s5D")] SubsidiaryDonaldDewey = 90,
        [Title("s5H")] SubsidiaryHighlandFive = 91,
        [Title("s5M")] SubsidiaryMyrddynDewey = 92,
        [Title("s4")] SubsidiaryTump400To499M = 93,
        [Title("xMT")] DeletedMunroTop = 94,
        [Title("xC")] DeletedCorbett = 95,
        [Title("xN")] DeletedNuttall = 96,
        [Title("xDT")] DeletedDonaldTop = 97,
        [Title("Sy")] Synge = 98,
        [Title("Fel")] Fellranger = 99,
        [Title("BL")] BuxtonAndLewis = 100,
        [Title("Bg")] Bridge = 101,
        [Title("T100")] Trail100 = 102,
        [Title("Ca")] Carn = 103,
        [Title("Bin")] Binnion = 104,
        [Title("O")] OtherList = 105,
        [Title("Un")] Unclassified = 106,
    }

    static class FieldExtensions
    {
        public static string Title(this Field field)
        {
            var attributes = (TitleAttribute[])field.GetType().GetField(field.ToString()).GetCustomAttributes(typeof(TitleAttribute), false);
            return attributes.Length > 0 ? attributes[0].Title : field.ToString();
        }
    }
}
