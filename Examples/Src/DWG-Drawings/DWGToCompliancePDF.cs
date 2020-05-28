using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.CAD;
using Aspose.CAD.ImageOptions;

namespace Aspose.CAD.Examples.CSharp.DWG_Drawings
{
    public class DWGToCompliancePDF
    {
        public static void Run()
        {
            //ExStart:DWGToCompliancePDF
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_DWGDrawings();
            string sourceFilePath = MyDir + "Bottom_plate.dwg";

            Aspose.CAD.Image cadImage = Aspose.CAD.Image.Load(sourceFilePath);
             // Create an instance of CadRasterizationOptions and set its various properties
            Aspose.CAD.ImageOptions.CadRasterizationOptions rasterizationOptions = new Aspose.CAD.ImageOptions.CadRasterizationOptions();
            rasterizationOptions.BackgroundColor = Aspose.CAD.Color.White;
            rasterizationOptions.PageWidth = 1600;
            rasterizationOptions.PageHeight = 1600;


            // Create an instance of PdfOptions
            PdfOptions pdfOptions = new Aspose.CAD.ImageOptions.PdfOptions
            {
            VectorRasterizationOptions = rasterizationOptions
            };

             pdfOptions.CorePdfOptions = new PdfDocumentOptions();

             pdfOptions.CorePdfOptions.Compliance = PdfCompliance.PdfA1a;
             cadImage.Save(MyDir + "PDFA1_A.pdf", pdfOptions);

             pdfOptions.CorePdfOptions.Compliance = PdfCompliance.PdfA1b;
             cadImage.Save(MyDir + "PDFA1_B.pdf", pdfOptions);
            //ExEnd:DWGToCompliancePDF     
            Console.WriteLine("\nThe DWG file exported successfully to PDF.\nFile saved at " + MyDir);

        }
    }
}
