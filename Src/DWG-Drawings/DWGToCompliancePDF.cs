using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.CAD;
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
            
            // Create an instance of PdfOptions
            PdfOptions pdfOptions = new Aspose.CAD.ImageOptions.PdfOptions
            {
            VectorRasterizationOptions = rasterizationOptions
            };

             pdfOptions.CorePdfOptions = new PdfDocumentOptions();

             pdfOptions.CorePdfOptions.Compliance = PdfCompliance.PdfA1a;
             cadImage.Save(outPath, pdfOptions);

             pdfOptions.CorePdfOptions.Compliance = PdfCompliance.PdfA1b;
             cadImage.Save(outPath, pdfOptions);
            //ExEnd:DWGToCompliancePDF     
            Console.WriteLine("\nThe DWG file exported successfully to PDF.\nFile saved at " + MyDir);

        }
    }
}
