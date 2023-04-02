using AvansDevOps.App.DomainServices;
using System.Drawing;
using System.Drawing.Imaging;
using Image = System.Drawing.Image;

namespace AvansDevOps.App.Infrastructure.Printers;

public class PngPrinter : IPrinter
{
    public bool Print(string report)
    {
        Image img = new Bitmap(1, 1);
        Graphics drawing = Graphics.FromImage(img);
        Font font = new Font("Arial", 20.0f);
        SizeF textSize = drawing.MeasureString(report, font);

        img.Dispose();
        drawing.Dispose();

        img = new Bitmap((int)textSize.Width, (int)textSize.Height);
        drawing = Graphics.FromImage(img);
        drawing.Clear(Color.White);
        Brush textBrush = new SolidBrush(Color.Black);

        drawing.DrawString(report, font, textBrush, 0, 0);
        drawing.Save();

        img.Save($"../../../Exports/report-{DateTime.Now.ToLongDateString()}.png", ImageFormat.Png);

        textBrush.Dispose();
        drawing.Dispose();

        return true;
    }
}
