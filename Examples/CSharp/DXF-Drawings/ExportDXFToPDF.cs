using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.CAD;
namespace Aspose.CAD.Examples.CSharp.DXF_Drawings
{
    public class ExportDXFToPDF
    {
        public static void Run()
        {
            //ExStart:ExportDXFToPDF
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_DXFDrawings();
            string sourceFilePath = MyDir + "conic_pyramid.dxf";
            using (Aspose.CAD.Image image = Aspose.CAD.Image.Load(sourceFilePath))
            {
                // Create an instance of CadRasterizationOptions and set its various properties
                Aspose.CAD.ImageOptions.CadRasterizationOptions rasterizationOptions = new Aspose.CAD.ImageOptions.CadRasterizationOptions();
                rasterizationOptions.BackgroundColor = Aspose.CAD.Color.White;
                rasterizationOptions.PageWidth = 1600;
                rasterizationOptions.PageHeight = 1600;

                // Create an instance of PdfOptions
                Aspose.CAD.ImageOptions.PdfOptions pdfOptions = new Aspose.CAD.ImageOptions.PdfOptions();
                // Set the VectorRasterizationOptions property
                pdfOptions.VectorRasterizationOptions = rasterizationOptions;

                MyDir = MyDir + "conic_pyramid_out.pdf";
                // Export the DXF to PDF
                image.Save(MyDir, pdfOptions);                
            }
            //ExEnd:ExportDXFToPDF            
            Console.WriteLine("\nThe DXF drawing exported successfully to PDF.\nFile saved at " + MyDir);
        }
    }
}
