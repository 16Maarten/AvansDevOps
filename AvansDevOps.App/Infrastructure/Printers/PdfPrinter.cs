using AvansDevOps.App.DomainServices;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Text;

namespace AvansDevOps.App.Infrastructure.Printers;

public class PdfPrinter : IPrinter
{
    public bool Print(string report)
    {
        try
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 10, XFontStyle.Bold);

            gfx.DrawString(report, font, XBrushes.Black,
            new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);

            string filename = $"../../../Exports/report-{DateTime.Now.ToLongDateString()}.pdf";
            document.Save(filename);

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }
}
