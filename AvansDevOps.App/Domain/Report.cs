using AvansDevOps.App.DomainServices;
using AvansDevOps.App.Infrastructure.Printers;

namespace AvansDevOps.App.Domain;
// STRATEGY PATTERN// STRATEGY PATTERN (_printer)
public class Report
{
    private string _report { get; set; }
    private ReportAddition _header { get; set; }
    private ReportAddition _footer { get; set; }
    private IPrinter _printer { get; set; } = new PdfPrinter();

    public IPrinter Printer { get { return _printer; } set { _printer = value; } }

    public Report(string report)
    {
        _report = report;
    }

    public bool Print(PrintFormat format)
    {
        if (format == PrintFormat.PDF) _printer = new PdfPrinter();
        else if (format == PrintFormat.PNG) _printer = new PngPrinter();

        return _printer.Print($"{(_header != null ? _header.ToString() : "")}\n{_report}\n{(_footer != null ? _footer.ToString() : "")}");
    }
}
