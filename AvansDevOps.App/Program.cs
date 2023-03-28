// See https://aka.ms/new-console-template for more information
using AvansDevOps.App.Domain.Report;
using AvansDevOps.App.Infrastructure.Printers;
using AvansDevOps.App.Infrastructure.Services;

Console.WriteLine("Hello, World!");

var publisher = new PublisherService<string>();
var report = new Report("");
