using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.CAD;
namespace Aspose.CAD.Examples.CSharp.DXF_Drawings
{
    public class ExportDXFSpecificLayoutToPDF
    {
        public static void Run()
        {
            //ExStart:ExportDXFSpecificLayoutToPDF
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_DXFDrawings();
            string sourceFilePath = MyDir + "conic_pyramid.dxf";
            using (Aspose.CAD.Image image = Aspose.CAD.Image.Load(sourceFilePath))
            {
                // Create an instance of CadRasterizationOptions and set its various properties
                Aspose.CAD.ImageOptions.CadRasterizationOptions rasterizationOptions = new Aspose.CAD.ImageOptions.CadRasterizationOptions();
                rasterizationOptions.PageWidth = 1600;
                rasterizationOptions.PageHeight = 1600;
                // Specify desired layout name
                rasterizationOptions.Layouts = new string[] { "Model" };

                // Create an instance of PdfOptions
                Aspose.CAD.ImageOptions.PdfOptions pdfOptions = new Aspose.CAD.ImageOptions.PdfOptions();
                // Set the VectorRasterizationOptions property
                pdfOptions.VectorRasterizationOptions = rasterizationOptions;

                MyDir = MyDir + "conic_pyramid_layout_out.pdf";
                //Export the DXF to PDF
                image.Save(MyDir, pdfOptions);                
            }
            //ExEnd:ExportDXFSpecificLayoutToPDF            
            Console.WriteLine("\nThe DXF file with specific layout exported successfully to PDF.\nFile saved at " + MyDir);
        }
    }
}
