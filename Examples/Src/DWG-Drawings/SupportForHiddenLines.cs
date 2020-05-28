using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.CAD;
using Aspose.CAD.FileFormats.Cad;
using Aspose.CAD.ImageOptions;

namespace Aspose.CAD.Examples.CSharp.DWG_Drawings
{
    public class SupportForHiddenLines
    {
        public static void Run()
        {
            //ExStart:SupportForHiddenLines
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_DWGDrawings();
            string sourceFilePath = MyDir + "Bottom_plate.dwg";
            string outPath = MyDir + "Bottom_plate.pdf";
            using (CadImage cadImage = (CadImage)Image.Load(sourceFilePath))
        {
            CadRasterizationOptions rasterizationOptions = new CadRasterizationOptions();
            rasterizationOptions.PageHeight = cadImage.Height;
            rasterizationOptions.PageWidth = cadImage.Width;
            rasterizationOptions.Layers = new string[] { "Print", "L1_RegMark", "L2_RegMark" };
           


            PdfOptions pdfOptions = new PdfOptions();
            rasterizationOptions.Layouts = new string[] { "Model" };
            pdfOptions.VectorRasterizationOptions = rasterizationOptions;

            cadImage.Save(outPath, pdfOptions);
            }

            Console.WriteLine("\nThe DWG file exported successfully to PDF.\nFile saved at " + MyDir);
        }
        //ExEnd:SupportForHiddenLines  

        //rasterizationOptions.Layers.Add("Print");
        //rasterizationOptions.Layers.Add("L1_RegMark");
        //rasterizationOptions.Layers.Add("L2_RegMark");
    }
}