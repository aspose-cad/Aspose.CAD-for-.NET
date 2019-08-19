using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.CAD;
namespace Aspose.CAD.Examples.CSharp.ConvertingCAD
{
    public class SettingAutoLayoutScaling
    {
        public static void Run()
        {
            //ExStart:SettingAutoLayoutScaling
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_ConvertingCAD();
            string sourceFilePath = MyDir + "conic_pyramid.dxf";
            using (Aspose.CAD.Image image = Aspose.CAD.Image.Load(sourceFilePath))
            {
                // Create an instance of CadRasterizationOptions and set its various properties
                Aspose.CAD.ImageOptions.CadRasterizationOptions rasterizationOptions = new Aspose.CAD.ImageOptions.CadRasterizationOptions();
                rasterizationOptions.PageWidth = 1600;
                rasterizationOptions.PageHeight = 1600;

                // Set Auto Layout Scaling
                rasterizationOptions.AutomaticLayoutsScaling = true;

                // Create an instance of PdfOptions
                Aspose.CAD.ImageOptions.PdfOptions pdfOptions = new Aspose.CAD.ImageOptions.PdfOptions();

                // Set the VectorRasterizationOptions property
                pdfOptions.VectorRasterizationOptions = rasterizationOptions;

                MyDir = MyDir + "result_out.pdf";
                //Export the CAD to PDF
                image.Save(MyDir, pdfOptions);
            }
            //ExEnd:SettingAutoLayoutScaling            
            Console.WriteLine("\nAuto layout scaling setup successfully.\nFile saved at " + MyDir);
        }
    }
}
