using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        [Test]
        public void ImportHillData()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            string[] header;
            List<string[]> data;

            using (var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream($"{GetType().Namespace}.Files.hillcsv.zip"))
            using (var zip = new ZipArchive(resource))
            using (var csv = zip.Entries[0].Open())
            using (var parser = new TextFieldParser(csv)
            {
                TextFieldType = FieldType.Delimited,
                Delimiters = new []{","},
                HasFieldsEnclosedInQuotes = true,
                TrimWhiteSpace = true
            })
            {
                header = parser.ReadFields();
                data = new List<string[]>();

                while (!parser.EndOfData)
                    data.Add(parser.ReadFields());
            }

            const string expectedHeader = "Number,Name,Parent (SMC),Parent name (SMC),Section,Section name,Area,Island,Topo Section,County,Classification,Map 1:50k,Map 1:25k,Metres,Feet,Grid ref,Grid ref 10,Drop,Col grid ref,Col height,Feature,Observations,Survey,Climbed,Country,County Top,Revision,Comments,Streetmap/OSiViewer,Geograph/MountainViews,Hill-bagging,Xcoord,Ycoord,Latitude,Longitude,GridrefXY,_Section,Parent (Ma),Parent name (Ma),MVNumber,Ma,Ma=,Hu,Hu=,Tu,Tu=,Sim,M,MT,F,C,G,D,DT,Mur,CT,GT,Hew,N,5,5D,5H,4,3,2,1,1=,0,W,WO,B,CoH,CoH=,CoU,CoU=,CoA,CoA=,CoL,CoL=,SIB,sMa,sHu,sSim,s5,s5D,s5H,s5M,s4,Sy,Fel,BL,Bg,T100,xMT,xC,xG,xN,xDT,Dil,VL,A,5M,Ca,Bin,O,Un";
            Assert.That(string.Join(",", header), Is.EqualTo(expectedHeader));

            var dobihRecords = DobihRecord.BuildFrom(header, data);
            Assert.That(dobihRecords, Has.Count.EqualTo(12162).Or.Count.EqualTo(20781));

            var root = new Root(dobihRecords);
            File.WriteAllText(FileName, root.ToJson());

            stopwatch.Stop();
            Console.WriteLine("Time taken: {0:#,##0}s", stopwatch.ElapsedMilliseconds/1000);
        }

        [Test]
        public void TransferToFirebase()
        {
            var json = File.ReadAllText(FileName);
            var root = Root.FromJson(json);
        }

        private const string FileName = @"C:\Users\gmiller\Desktop\output.json";
    }
}
