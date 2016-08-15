using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using ScotlandsMountains.Resources;

namespace ScotlandsMountains.Import
{
    public interface IOsFileReader
    {
        List<string> ReadLines();
    }

    internal class OsFileReader : IOsFileReader
    {
        public List<string> ReadLines()
        {
            using (var stream = Load.Os.MapCatalogue)
            using (var binary = new BinaryReader(stream))
            using (var reader = new PdfReader(binary.ReadBytes((int)stream.Length)))
            using (var output = new StringWriter())
            {
                for (var i = 1; i <= reader.NumberOfPages; i++)
                    output.WriteLine(PdfTextExtractor.GetTextFromPage(reader, i, new SimpleTextExtractionStrategy()));

                return output
                    .ToString()
                    .Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries)
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Select(x => x.Trim())
                    .ToList();
            }
        }
    }
}
