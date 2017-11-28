using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.CAD;
namespace Aspose.CAD.Examples.CSharp.DXF_Drawings
{
    public class ExportEmbeddedDGN
    {
        public static void Run()
        {
            //ExStart:ExportEmbeddedDGN
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_DXFDrawings();
            string sourceFilePath = MyDir + "conic_pyramid.dxf";
            using (CadImage cadImage = (CadImage)Image.Load(fileName))
            {
                CadRasterizationOptions rasterizationOptions = new CadRasterizationOptions();
                rasterizationOptions.Layouts = new[] { "Model" };

                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.VectorRasterizationOptions = rasterizationOptions;

                cadImage.Save(outDir + fileName + ".pdf", pdfOptions);
            }
            //ExEnd:ExportEmbeddedDGN           
            Console.WriteLine("\nThe DXF drawing exported successfully to PDF.\nFile saved at " + MyDir);
        }
    }
}
