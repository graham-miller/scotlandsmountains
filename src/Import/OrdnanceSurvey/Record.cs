using System;
using System.Globalization;
using System.Linq;

namespace ScotlandsMountains.Import.OrdnanceSurvey
{
    public class Record
    {
        public Record(string record)
        {
            var parts = record.Split(new [] {" "}, StringSplitOptions.RemoveEmptyEntries);

            Sheet = parts[0];
            Name = String.Join(" ", parts.Skip(1).Take(parts.Length - 4));
            Isbn = parts[parts.Length-3];
            PublicationDate = DateTime.ParseExact(parts[parts.Length-2], "dd/M/yy", CultureInfo.InvariantCulture);
            Edition = parts[parts.Length-1];
        }

        public string Sheet { get; set; }
        public string Name { get; set; }
        public string Isbn { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Edition { get; set; }
    }
}