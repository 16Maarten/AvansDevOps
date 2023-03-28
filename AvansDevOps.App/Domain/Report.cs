﻿using AvansDevOps.App.DomainServices;
using AvansDevOps.App.Infrastructure.Printers;

namespace AvansDevOps.App.Domain;

public class Report
{
    private string _report { get; set; }
    private string _header { get; set; } = string.Empty;
    private string _footer { get; set; } = string.Empty;
    private IPrinter _printer { get; set; } = new PdfPrinter();

    public IPrinter Printer { get { return _printer; } set { _printer = value; } }

    public Report(string report)
    {
        _report = report;
    }

    public void Print()
    {
        _printer.Print($"{_header}\n{_report}\n{_footer}");
    }
}