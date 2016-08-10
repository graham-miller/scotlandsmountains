using System;
using System.Collections.Generic;
using System.Linq;

namespace ScotlandsMountains.Import
{
    internal class DobihRecord
    {
        private class FieldNames
        {
            public const string Number = "Number";
            public const string Name = "Name";
            public const string SectionName = "Section name";
            public const string Classification = "Classification";
            public const string Map1To50000 = "Map 1:50k";
            public const string Map1To25000 = "Map 1:25k";
            public const string Metres = "Metres";
            public const string Feet = "Feet";
            public const string Latitude = "Latitude";
            public const string Longitude = "Longitude";
            public const string GridRefXY = "GridrefXY";
            public const string GridRef = "Grid ref";
        }

        private class Separators
        {
            public const string Space = " ";
            public const string Comma = ",";
            public const string Colon = ":";
        }

        public DobihRecord(string[] fields, DobihFile dobihFile)
        {
            _fields = fields;
            _dobihFile = dobihFile;
        }

        public int Number { get { return GetInt(FieldNames.Number); } }

        public string Name { get { return GetString(FieldNames.Name); } }

        public string Section { get { return GetSectionName(FieldNames.SectionName); } }

        public List<string> Classifications { get { return GetList(FieldNames.Classification, Separators.Comma); } }

        public List<string> Maps1To50000 { get { return GetList(FieldNames.Map1To50000, Separators.Space); } }

        public List<string> Maps1To25000 { get { return GetList(FieldNames.Map1To25000, Separators.Space); } }

        public double Metres { get { return GetDouble(FieldNames.Metres); } }

        public double Feet { get { return GetDouble(FieldNames.Feet); } }

        public double Latitude { get { return GetDouble(FieldNames.Latitude); } }

        public double Longitude { get { return GetDouble(FieldNames.Longitude); } }

        public string GridRef { get { return GetGridRef(); } }

        private string GetString(string fieldName)
        {
            return _fields[_dobihFile.ColumnIndex[fieldName]];
        }

        private List<string> GetList(string fieldName, string separator)
        {
            return GetString(fieldName).Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToList();
        }

        private double GetDouble(string fieldName)
        {
            return double.Parse(GetString(fieldName));
        }

        private int GetInt(string fieldName)
        {
            return int.Parse(GetString(fieldName));
        }

        private string GetSectionName(string fieldName)
        {
            var s = GetString(fieldName);
            return s.Substring(s.IndexOf(Separators.Colon) + 1).Trim();
        }

        private string GetGridRef()
        {
            var raw = GetString(FieldNames.GridRefXY);

            if (string.IsNullOrWhiteSpace(raw))
                raw = GetString(FieldNames.GridRef);

            return raw;
        }

        private DobihFile _dobihFile;
        private string[] _fields;

        //Number
        //Name
        //Parent(SMC)
        //Parent name(SMC)
        //Section
        //Section name
        //Area
        //Island
        //Topo Section
        //County
        //Classification
        //Map 1:50k
        //Map 1:25k
        //Metres
        //Feet
        //Grid ref
        //Grid ref 10
        //Drop
        //Col grid ref
        //Col height
        //Feature
        //Observations
        //Survey
        //Climbed
        //Country
        //County Top
        //Revision
        //Comments
        //Streetmap/OSiViewer
        //Geograph/MountainViews
        //Hill-bagging
        //Xcoord
        //Ycoord
        //Latitude
        //Longitude
        //GridrefXY
        //_Section
        //Parent(Ma)
        //Parent name(Ma)
        //MVNumber
        //Ma
        //Ma=
        //Hu
        //Hu =
        //Tu
        //Tu=
        //Sim
        //M
        //MT
        //F
        //C
        //G
        //D
        //DT
        //Mur
        //CT
        //GT
        //Hew
        //N
        //5
        //5D
        //5H
        //4
        //3
        //2
        //1
        //1=
        //0
        //W
        //WO
        //B
        //CoH
        //CoH=
        //CoU
        //CoU =
        //CoA
        //CoA=
        //CoL
        //CoL =
        //SIB
        //sMa
        //sHu
        //sSim
        //s5
        //s5D
        //s5H
        //s5M
        //s4
        //Sy
        //Fel
        //BL
        //Bg
        //T100
        //xMT
        //xC
        //xG
        //xN
        //xDT
        //Dil
        //VL
        //A
        //5M
        //Ca
        //Bin
        //O
        //Un
    }
}
