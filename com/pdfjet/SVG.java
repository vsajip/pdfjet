/**
 *  SVG.java
 *
 Copyright 2023 Innovatics Inc.

 Permission is hereby granted, free of charge, to any person obtaining a copy
 of this software and associated documentation files (the "Software"), to deal
 in the Software without restriction, including without limitation the rights
 to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 copies of the Software, and to permit persons to whom the Software is
 furnished to do so, subject to the following conditions:

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 SOFTWARE.
 */
package com.pdfjet;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.List;

public class SVG {
    public static List<String> getSVGPaths(String fileName) throws IOException {
        List<String> paths = new ArrayList<>();
        StringBuilder buf = new StringBuilder();
        boolean inPath = false;
        String str = new String(Files.readAllBytes(Paths.get(fileName)));
        for (int i = 0; i < str.length(); i++) {
            char ch = str.charAt(i);
            if (!inPath && buf.toString().endsWith("<path d=")) {
                inPath = true;
                buf.setLength(0);
            } else if (inPath && ch == '\"') {
                inPath = false;
                paths.add(buf.toString());
                buf.setLength(0);
            } else {
                buf.append(ch);
            }
        }
        return paths;
    }
}
