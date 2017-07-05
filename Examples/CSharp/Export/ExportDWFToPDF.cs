using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.CAD;
using Aspose.CAD.ImageOptions;
namespace Aspose.CAD.Examples.CSharp.Export
{
    public class ExportDWFToPDF
    {
        public static void Run()
        {
            //ExStart:ExportDWFToPDF
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_ConvertingCAD();
            string fileName = GetFileFromDesktop("APFH Floor Plan.dwf");
            using (Aspose.CAD.Image image = Aspose.CAD.Image.Load(fileName))
            {
                var pdfOptions = new PdfOptions();
                var dwfRasterizationOptions = new DwfRasterizationOptions();
                pdfOptions.VectorRasterizationOptions = dwfRasterizationOptions;
                dwfRasterizationOptions.CenterDrawing = true;
                dwfRasterizationOptions.PageHeight = 500;
                dwfRasterizationOptions.PageWidth = 500;
                dwfRasterizationOptions.Layouts = new string[] { "Model" };
                // export
                string outPath = fileName + ".pdf";
                image.Save(outPath, pdfOptions);
            
            //ExEnd:ExportDWFToPDF          
            Console.WriteLine("\n3D images exported successfully to PDF.\nFile saved at " + MyDir);
        }
    }
}
