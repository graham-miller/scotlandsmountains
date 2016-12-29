using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ScotlandsMountains.Import.Dobih;

namespace ScotlandsMountains.Import.Tests.Dobih
{
    [TestFixture]
    public class DobihRecordTests
    {
        [Test]
        public void GivenRawWhenCreatingRecordThenPropertiesCorrectlyMapped()
        {
            var sut = new DobihRecord(Record, ColumnIndexes);

            Assert.That(sut.Number, Is.EqualTo(278));
            Assert.That(sut.Name, Is.EqualTo("Ben Nevis"));
            Assert.That(sut.SectionCode, Is.EqualTo("04A"));
            Assert.That(sut.SectionName, Is.EqualTo("Fort William to Loch Treig & Loch Leven"));
            Assert.That(sut.Lists.Count, Is.EqualTo(8));
            Assert.That(sut.Maps1To50000.Count, Is.EqualTo(1));
            Assert.That(sut.Maps1To25000.Count, Is.EqualTo(1));
            Assert.That(sut.Metres, Is.EqualTo(1344.5));
            Assert.That(sut.Feet, Is.EqualTo(4411));
            Assert.That(sut.Latitude, Is.EqualTo(56.796849));
            Assert.That(sut.Longitude, Is.EqualTo(-5.003525));
            Assert.That(sut.GridRef, Is.EqualTo("NN1667571283"));
            Assert.That(sut.Drop, Is.EqualTo(1344.5));
            Assert.That(sut.ColGridRef, Is.EqualTo("Sea"));
            Assert.That(sut.ColMetres, Is.EqualTo(0));
            Assert.That(sut.Feature, Is.EqualTo("trig point on plinth"));
            Assert.That(sut.Observations, Is.EqualTo("man-made structure supporting emergency structure is higher"));
            Assert.That(sut.Country, Is.EqualTo("S"));
        }

        private static readonly IDictionary<string, int> ColumnIndexes = new []
        {
            "Number", "Name", "Parent (SMC)", "Parent name (SMC)", "Section", "Section name", "Area", "Island", "Topo Section", "County", "Classification", "Map 1:50k", "Map 1:25k", "Metres", "Feet", "Grid ref", "Grid ref 10", "Drop", "Col grid ref", "Col height", "Feature", "Observations", "Survey", "Climbed", "Country", "County Top", "Revision", "Comments", "Streetmap/OSiViewer", "Geograph/MountainViews", "Hill-bagging", "Xcoord", "Ycoord", "Latitude", "Longitude", "GridrefXY", "_Section", "Parent (Ma)", "Parent name (Ma)", "MVNumber", "Ma", "Ma=", "Hu", "Hu=", "Tu", "Tu=", "Sim", "M", "MT", "F", "C", "G", "D", "DT", "Mur", "CT", "GT", "Hew", "N", "5", "5D", "5H", "4", "3", "2", "1", "1=", "0", "W", "WO", "B", "CoH", "CoH=", "CoU", "CoU=", "CoA", "CoA=", "CoL", "CoL=", "SIB", "sMa", "sHu", "sSim", "s5", "s5D", "s5H", "s5M", "s4", "Sy", "Fel", "BL", "Bg", "T100", "xMT", "xC", "xG", "xN", "xDT", "Dil", "VL", "A", "5M", "Ca", "Bin", "O", "Un",
        }
        .Select((s, i) => new { Key = s, Value = i })
        .ToDictionary(k => k.Key, v => v.Value);


        private static readonly string[] Record =
        {
            "278", "Ben Nevis", "", "", "04A", "04A: Fort William to Loch Treig & Loch Leven", "", "", "I01:Ben Nevis to Loch Treig", "Highland", "Ma,M,Sim,Mur,CoH,CoU,CoA,SIB", "41", "392", "1344.5", "4411", "NN166712", "NN 16679 71274", "1344.5", "Sea", "0", "trig point on plinth", "man-made structure supporting emergency structure is higher", "Ordnance Survey", "", "S", "Highland (UA) Inverness-shire (CoH) Highland (CoA)", "42460", "", "http://www.streetmap.co.uk/newmap.srf?x=216675&y=771283&z=3&sv=216675,771283&st=4&tl=~&bi=~&lu=N&ar=y", "http://www.geograph.org.uk/mapper/coverage.php?zoom=10&layers=FTTB00000000000FT&lat=56.796849&lon=-5.003525", "http://www.hill-bagging.co.uk/mountaindetails.php?qu=S&rf=278", "216675", "771283", "56.796849", "-5.003525", "NN1667571283", "4.1", "278", "", "", "1", "0", "1", "0", "1", "0", "1", "1", "0", "0", "0", "0", "0", "0", "1", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "1", "0", "1", "0", "1", "0", "0", "0", "1", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "1", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0",
        };
    }
}
