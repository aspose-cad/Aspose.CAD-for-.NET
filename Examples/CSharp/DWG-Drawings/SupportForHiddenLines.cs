using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.CAD;
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
            using (CadImage cadImage = (CadImage)Image.Load(fileName))
        {
            CadRasterizationOptions rasterizationOptions = new CadRasterizationOptions();
            rasterizationOptions.PageHeight = cadImage.Height;
            rasterizationOptions.PageWidth = cadImage.Width;
            rasterizationOptions.Layers.Add("Print");
            rasterizationOptions.Layers.Add("L1_RegMark");
            rasterizationOptions.Layers.Add("L2_RegMark");

            PdfOptions pdfOptions = new PdfOptions();
            rasterizationOptions.Layouts = new string[] { "Model" };
            pdfOptions.VectorRasterizationOptions = rasterizationOptions;

            cadImage.Save(outDir, pdfOptions);
            }
              
            }
            //ExEnd:SupportForHiddenLines  
            Console.WriteLine("\nThe DWG file exported successfully to PDF.\nFile saved at " + MyDir);

        }
    }