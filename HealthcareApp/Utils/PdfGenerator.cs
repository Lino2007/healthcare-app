
using HealthcareApp.Models.DataModels;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace HealthcareApp.Utils
{
    public class PdfGenerator
    {
        public byte[]  GetPdf(List<PatientAdmission> patientAdmissions)
        {
            /* var stream = new MemoryStream();
             var writer = new PdfWriter(stream);
             var pdf = new PdfDocument(writer);
             var document = new Document(pdf);

             document.Add(new Paragraph("Hello world!"));
             document.Close();
             byte[] data = stream.ToArray(); */
            using (MemoryStream ms = new MemoryStream())
            {
                PdfDocument pdfDoc = new PdfDocument(new PdfWriter(ms));

                PdfFont regularFont = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
                PdfFont titleFont = PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD);
                Document doc = new Document(pdfDoc);

                foreach(PatientAdmission admission in patientAdmissions)
                {
                    Table table = new Table(UnitValue.CreatePercentArray(2)).UseAllAvailableWidth();
                    table.AddCell(new Cell().SetFont(titleFont).Add(new Paragraph("Patient Name")));
                    table.AddCell(new Cell().SetFont(regularFont).Add(new Paragraph(admission.Patient.FullName)));
                    doc.Add(table);
                    doc.Add(new AreaBreak());
                }

                doc.Close();
                return ms.ToArray();
            }
        }
    }
}
