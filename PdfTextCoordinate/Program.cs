using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfTextCoordinate
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new PdfReader("input.pdf"))
            {

                var parser = new PdfReaderContentParser(reader);

                var strategy = parser.ProcessContent(1, new LocationTextExtractionStrategyWithPosition());

                var res = strategy.GetLocations();

                reader.Close();
                var searchResult = res.Where(p => p.Text.Contains("dummy")).OrderBy(p => p.Y).Reverse().ToList();
            }
        }
    }
}
