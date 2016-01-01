using System;
using System.Linq;
using ScotlandsMountains.Domain;
using ScotlandsMountains.Import.Dobih;
using ScotlandsMountains.Utility;

namespace ScotlandsMountains.Import
{
    internal static class ProminenceFactory
    {
        public static Prominence BuildFrom(Record record)
        {
            return new Prominence
                {
                    Drop = new Height { Metres = record.Drop },
                    MeasuredFrom = GetMeasuredFrom(record.ColHeight, record.ColGridRef)
                };
        }

        private static MeasuredFrom GetMeasuredFrom(decimal colHeight, string colGridRef)
        {
            var height = new Height { Metres = colHeight };

            if (IsGridReference(colGridRef))
                return new MeasuredFromCol { Height = height, GridReference = FormatGridReference(colGridRef) };

            return new MeasuredFromFeature { Height = height, Description = String.IsNullOrEmpty(colGridRef) ? null : colGridRef };
        }

        private static bool IsGridReference(string colGridRef)
        {
            if (String.IsNullOrEmpty(colGridRef)) return false;

            return colGridRef.First().IsLetter() && colGridRef.Last().IsNumber();
        }

        private static string FormatGridReference(string colGridRef)
        {
            var letters = colGridRef.Where(x => x.IsLetter());
            var numbers = colGridRef.Where(x => x.IsNumber());

            if (numbers.Count() > 6)
                numbers = numbers.Take(3).Concat(numbers.Skip(numbers.Count() / 2).Take(3));

            return String.Concat(letters) + String.Concat(numbers);
        }

    }
}