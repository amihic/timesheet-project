using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using TimeSheet.Domain.Model;

namespace API.PDF
{
    public class PdfGenerator
    {
        public void GeneratePdf(IEnumerable<Activity> activities, string outputPath)
        {
            using (var writer = new PdfWriter(outputPath))
            {
                using (var pdf = new PdfDocument(writer))
                {
                    var document = new Document(pdf);

                    foreach (var activity in activities)
                    {
                        document.Add(new Paragraph($"Datum aktivnosti: {activity.Date}"));
                        document.Add(new Paragraph($"Kategorija aktivnosti: {activity.Category}"));
                        // Dodajte ostale informacije o aktivnosti prema potrebi
                        document.Add(new AreaBreak());
                    }
                }
            }
        }
    }
}
