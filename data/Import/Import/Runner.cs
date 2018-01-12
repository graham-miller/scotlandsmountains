using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using Microsoft.VisualBasic.FileIO;
using NUnit.Framework;
using ScotlandsMountains.Import.Domain;

namespace ScotlandsMountains.Import
{
    [TestFixture]
    public class Runner
    {
        private static readonly string FileName;

        private LoadedFile _loadedFile;
        private Root _root;

        static Runner()
        {
            //FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "output.json");
            FileName = @"C:\Users\gmiller\Source\Personal\scotlandsmountains\data\Import\Import\Upload\output.json";
        }

        [Test]
        public void ImportTestHarness()
        {
            try
            {
                LoadCsvZip();
                ParseCsvZip();
                SaveJsonAs(FileName);
                //LoadJsonFrom(FileName);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }

        private void LoadCsvZip()
        {
            _loadedFile = new LoadedFile();

            using (var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream($"{GetType().Namespace}.Files.hillcsv.zip"))
            using (var zip = new ZipArchive(resource))
            using (var csv = zip.Entries[0].Open())
            using (var parser = new TextFieldParser(csv) { TextFieldType = FieldType.Delimited, Delimiters = new[] { "," }, HasFieldsEnclosedInQuotes = true, TrimWhiteSpace = true })
            {
                _loadedFile.Header = parser.ReadFields();

                while (!parser.EndOfData)
                    _loadedFile.Data.Add(parser.ReadFields());
            }
        }

        private void ParseCsvZip()
        {
            const string expectedHeader = "Number,Name,Parent (SMC),Parent name (SMC),Section,Section name,Area,Island,Topo Section,County,Classification,Map 1:50k,Map 1:25k,Metres,Feet,Grid ref,Grid ref 10,Drop,Col grid ref,Col height,Feature,Observations,Survey,Climbed,Country,County Top,Revision,Comments,Streetmap/OSiViewer,Geograph/MountainViews,Hill-bagging,Xcoord,Ycoord,Latitude,Longitude,GridrefXY,_Section,Parent (Ma),Parent name (Ma),MVNumber,Ma,Ma=,Hu,Hu=,Tu,Tu=,Sim,M,MT,F,C,G,D,DT,Mur,CT,GT,Hew,N,5,5D,5H,4,3,2,1,1=,0,W,WO,B,CoH,CoH=,CoU,CoU=,CoA,CoA=,CoL,CoL=,SIB,sMa,sHu,sSim,s5,s5D,s5H,s5M,s4,Sy,Fel,BL,Bg,T100,xMT,xC,xG,xN,xDT,Dil,VL,A,5M,Ca,Bin,O,Un";
            Assert.That(string.Join(",", _loadedFile.Header), Is.EqualTo(expectedHeader));

            var dobihRecords = DobihRecord.BuildFrom(_loadedFile.Header, _loadedFile.Data);
            Assert.That(dobihRecords, Has.Count.EqualTo(12162).Or.Count.EqualTo(20781));

            _root = new Root(dobihRecords);
        }

        private void SaveJsonAs(string fileName)
        {
            File.WriteAllText(fileName, _root.ToJson());
        }

        private void LoadJsonFrom(string fileName)
        {
            _root = Root.FromJson(File.ReadAllText(fileName));
        }

        private class LoadedFile
        {
            public LoadedFile()
            {
                Data = new List<string[]>();
            }

            public string[] Header { get; set; }
            public List<string[]> Data { get; private set; }
        }
    }
}

