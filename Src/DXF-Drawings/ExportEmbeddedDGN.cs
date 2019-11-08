using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.CAD;
using Aspose.CAD.FileFormats.Cad;
using Aspose.CAD.ImageOptions;

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
            using (CadImage cadImage = (CadImage)Image.Load(sourceFilePath))
            {
                CadRasterizationOptions rasterizationOptions = new CadRasterizationOptions();
                rasterizationOptions.Layouts = new[] { "Model" };

                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.VectorRasterizationOptions = rasterizationOptions;

                cadImage.Save(MyDir + "conic_pyramid.pdf", pdfOptions);
            }
            //ExEnd:ExportEmbeddedDGN           
            Console.WriteLine("\nThe DXF drawing exported successfully to PDF.\nFile saved at " + MyDir);
        }
    }
}
