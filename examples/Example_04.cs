using System;
using System.IO;
using System.Diagnostics;

using PDFjet.NET;


/**
 *  Example_04.cs
 *
 *  The PDF generated by this example program will only work with Adobe Reader 8
 *  or Foxit Reader v2.0 or higher versions. It also requires the Asian Font Packs
 *  from Adobe or Foxit Software respectively.
 */
public class Example_04 {

    public Example_04() {
        PDF pdf = new PDF(new BufferedStream(
                new FileStream("Example_04.pdf", FileMode.Create)));

        // Chinese (Traditional) font
        Font f1 = new Font(pdf, CJKFont.ADOBE_MING_STD_LIGHT);

        // Chinese (Simplified) font
        Font f2 = new Font(pdf, CJKFont.ST_HEITI_SC_LIGHT);

        // Japanese font
        Font f3 = new Font(pdf, CJKFont.KOZ_MIN_PRO_VI_REGULAR);

        // Korean font
        Font f4 = new Font(pdf, CJKFont.ADOBE_MYUNGJO_STD_MEDIUM);

        Page page = new Page(pdf, Letter.PORTRAIT);

        f1.SetSize(14f);
        f2.SetSize(14f);
        f3.SetSize(14f);
        f4.SetSize(14f);

        String fileName = "data/happy-new-year.txt";
        float x_pos = 100f;
        float y_pos = 100f;
        StreamReader reader = new StreamReader(
                new FileStream(fileName, FileMode.Open, FileAccess.Read));
        TextLine text = new TextLine(f1);
        String line = null;
        while ((line = reader.ReadLine()) != null) {
            if (line.Contains("Simplified")) {
                text.SetFont(f2);
            }
            else if (line.Contains("Japanese")) {
                text.SetFont(f3);
            }
            else if (line.Contains("Korean")) {
                text.SetFont(f4);
            }
            text.SetText(line);
            text.SetLocation(x_pos, y_pos);
            text.DrawOn(page);
            y_pos += 25f;
        }
        reader.Close();

        pdf.Complete();
    }


    public static void Main(String[] args) {
        Stopwatch sw = Stopwatch.StartNew();
        long time0 = sw.ElapsedMilliseconds;
        new Example_04();
        long time1 = sw.ElapsedMilliseconds;
        TextUtils.PrintDuration("Example_04", time0, time1);
    }

}   // End of Example_04.cs
