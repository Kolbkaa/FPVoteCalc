using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace VoteCalc.Logic
{
    class ExportDataToPdf : ExportData
    {
        private readonly PdfDocument _document;
        private PdfPage _page;
        private XGraphics _gfx;
        private readonly XFont _font;
        private int _line = -350;

        private int GetLine()
        {
            var temp = _line;
            _line += 20;
            if (_line > 350)
            {
                _line = -350;
                _page = AddPage();
                _gfx = FromPdfPage();
            }
            return temp;
        }
        public ExportDataToPdf() : base("pdf")
        {
            _document = new PdfDocument();
            _document.Info.Title = "Vote Statistic";

            // Create an empty page
            _page = AddPage();

            // Get an XGraphics object for drawing
            _gfx = FromPdfPage();

            // Create a font
            _font = new XFont("Verdana", 12, XFontStyle.BoldItalic);

            // Draw the text



        }

        private XGraphics FromPdfPage()
        {
            return XGraphics.FromPdfPage(_page);
        }

        private PdfPage AddPage()
        {
            return _document.AddPage();
        }

        public override void AddDataToFile(string dataName, string value)
        {
            _gfx.DrawString($"{dataName.PadRight(20)}: {value}", _font, XBrushes.Black,
                new XRect(20, GetLine(), _page.Width, _page.Height),
                XStringFormats.CenterLeft);
        }
        public void AddTextToFile(string text)
        {
            _gfx.DrawString($"{text}", _font, XBrushes.Black,
                new XRect(20, GetLine(), _page.Width, _page.Height),
                XStringFormats.CenterLeft);
        }
        public override void AddDataToFile(Dictionary<string, string> data)
        {
            foreach (var d in data)
            {
                _gfx.DrawString($"{d.Key.PadRight(20)}: {d.Value}", _font, XBrushes.Black,
                    new XRect(20, GetLine(), _page.Width, _page.Height),
                    XStringFormats.CenterLeft);
            }
        }

        public new void Export()
        {
            try
            {
                _document.Save(FilePath);
                Process.Start(FilePath);
            }
            catch (Exception)
            {
                MessageBox.Show("Error file export to pdf","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            finally
            {
                _document.Dispose();
            }
            
        }
    }
}
