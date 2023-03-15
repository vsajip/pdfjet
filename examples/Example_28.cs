using System;
using System.IO;
using System.Text;
using System.Diagnostics;

using PDFjet.NET;


/**
 *  Example_28.cs
 *
 */
public class Example_28 {

    public Example_28() {

        PDF pdf = new PDF(new BufferedStream(
                new FileStream("Example_28.pdf", FileMode.Create)));

        Font f1 = new Font(pdf, new BufferedStream(
                new FileStream(
                        "fonts/Droid/DroidSans.ttf.stream", FileMode.Open, FileAccess.Read)),
                Font.STREAM);
        f1.SetSize(11f);

        Font f2 = new Font(pdf,
                new FileStream(
                        "fonts/Droid/DroidSansFallback.ttf.stream",
                        FileMode.Open,
                        FileAccess.Read), Font.STREAM);
        f2.SetSize(11f);

        Page page = new Page(pdf, Letter.LANDSCAPE);

        StreamReader reader = new StreamReader(
                new FileStream("data/report.csv", FileMode.Open));

        float y = 40f;
        String str = null;
        while ((str = reader.ReadLine()) != null) {
            new TextLine(f1, str)
                    .SetFallbackFont(f2)
                    .SetLocation(50f, y += 20f)
                    .DrawOn(page);
        }
        reader.Close();

        float x = 50f;
        y = 210f;
        float dy = 22f;

        TextLine text = new TextLine(f1);
        StringBuilder buf = new StringBuilder();
        int count = 0;
        for (int i = 0x2200; i <= 0x22FF; i++) {
            // Draw the Math Symbols
            if (count % 80 == 0) {
                text.SetText(buf.ToString());
                text.SetLocation(x, y += dy);
                text.DrawOn(page);
                buf.Length = 0;
            }
            buf.Append((char) i);
            count++;
        }
        text.SetText(buf.ToString());
        text.SetLocation(x, y += dy);
        text.DrawOn(page);
        buf.Length = 0;

        count = 0;
        for (int i = 0x25A0; i <= 0x25FF; i++) {
            // Draw the Geometric Shapes
            if (count % 80 == 0) {
                text.SetText(buf.ToString());
                text.SetLocation(x, y += dy);
                text.DrawOn(page);
                buf.Length = 0;
            }
            buf.Append((char) i);
            count++;
        }
        text.SetText(buf.ToString());
        text.SetLocation(x, y += dy);
        text.DrawOn(page);
        buf.Length = 0;

        count = 0;
        for (int i = 0x2701; i <= 0x27ff; i++) {
            // Draw the Dingbats
            if (count % 80 == 0) {
                text.SetText(buf.ToString());
                text.SetLocation(x, y += dy);
                text.DrawOn(page);
                buf.Length = 0;
            }
            buf.Append((char) i);
            count++;
        }
        text.SetText(buf.ToString());
        text.SetLocation(x, y += dy);
        text.DrawOn(page);
        buf.Length = 0;

        count = 0;
        for (int i = 0x2800; i <= 0x28FF; i++) {
            // Draw the Braille Patterns
            if (count % 80 == 0) {
                text.SetText(buf.ToString());
                text.SetLocation(x, y += dy);
                text.DrawOn(page);
                buf.Length = 0;
            }
            buf.Append((char) i);
            count++;
        }
        text.SetText(buf.ToString());
        text.SetLocation(x, y);
        text.DrawOn(page);

        pdf.Complete();
    }


    public static void Main(String[] args) {
        Stopwatch sw = Stopwatch.StartNew();
        long time0 = sw.ElapsedMilliseconds;
        new Example_28();
        long time1 = sw.ElapsedMilliseconds;
        sw.Stop();
        Console.WriteLine("Example_28 => " + (time1 - time0));
    }

}   // End of Example_28.cs
