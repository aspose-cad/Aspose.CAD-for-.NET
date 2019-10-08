using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.CAD;

namespace Aspose.CAD.Examples.CSharp.Exporting_DGN
{
    public class ExportDGNToPdf
    {
        public static void Run()
        {
            try
            {
                //ExStart:ExportDGNToPdf
                // The path to the documents directory.
                string MyDir = RunExamples.GetDataDir_ExportingDGN();
                string sourceFilePath = MyDir + "Nikon_D90_Camera.dgn";
                // Load an existing DGN file as CadImage.
                using (Aspose.CAD.FileFormats.Dgn.DgnImage cadImage = (Aspose.CAD.FileFormats.Dgn.DgnImage)Aspose.CAD.Image.Load(sourceFilePath))
                {
                    // Create an object of CadRasterizationOptions class and define/set different properties
                    Aspose.CAD.ImageOptions.CadRasterizationOptions rasterizationOptions = new Aspose.CAD.ImageOptions.CadRasterizationOptions();
                    rasterizationOptions.PageWidth = 600;
                    rasterizationOptions.PageHeight = 300;                    
                    rasterizationOptions.NoScaling = true;
                    rasterizationOptions.AutomaticLayoutsScaling = false;

                    // Create an object of PdfOptions class as we are converting the image to PDF format and assign CadRasterizationOptions object to it.
                    Aspose.CAD.ImageOptions.PdfOptions pdfOptions = new Aspose.CAD.ImageOptions.PdfOptions();
                    pdfOptions.VectorRasterizationOptions = rasterizationOptions;

                    // Call the save method of the CadImage class object.
                    cadImage.Save(MyDir + "ExportDGNToPdf_out.pdf", pdfOptions);
                }
                //ExEnd:ExportDGNToPdf            
                Console.WriteLine("\nThe DGN file exported successfully to PDF.\nFile saved at " + MyDir);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please use valid input file." + ex.Message);
            }

        }
    }
}
