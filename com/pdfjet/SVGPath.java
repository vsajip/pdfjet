package com.pdfjet;

public class SVGPath {
    String data;            // The path data
    int fill = Color.black; // The fill color or -1 (don't fill)
    int stroke = -1;        // The stroke color or -1 (don't stroke)
    float strokeWidth;      // The stroke width

    public SVGPath() {
    }
}
