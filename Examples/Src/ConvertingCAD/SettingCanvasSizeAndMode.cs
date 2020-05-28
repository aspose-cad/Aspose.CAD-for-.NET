using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.CAD;
namespace Aspose.CAD.Examples.CSharp.ConvertingCAD
{
    public class SettingCanvasSizeAndMode
    {
        public static void Run()
        {
            //ExStart:SettingCanvasSizeAndMode
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_ConvertingCAD();
            string sourceFilePath = MyDir + "conic_pyramid.dxf";
            using (Aspose.CAD.Image image = Aspose.CAD.Image.Load(sourceFilePath))
            {
                // Create an instance of CadRasterizationOptions and set its various properties
                Aspose.CAD.ImageOptions.CadRasterizationOptions rasterizationOptions = new Aspose.CAD.ImageOptions.CadRasterizationOptions();
                rasterizationOptions.PageWidth = 1600;
                rasterizationOptions.PageHeight = 1600;
                rasterizationOptions.AutomaticLayoutsScaling = true;
                rasterizationOptions.NoScaling = false;

                // Create an instance of PdfOptions
                Aspose.CAD.ImageOptions.PdfOptions pdfOptions = new Aspose.CAD.ImageOptions.PdfOptions();

                // Set the VectorRasterizationOptions property
                pdfOptions.VectorRasterizationOptions = rasterizationOptions;

                //Export CAD to PDF
                image.Save(MyDir + "result_out.pdf", pdfOptions);

                // Create an instance of TiffOptions
                Aspose.CAD.ImageOptions.TiffOptions tiffOptions = new Aspose.CAD.ImageOptions.TiffOptions(Aspose.CAD.FileFormats.Tiff.Enums.TiffExpectedFormat.Default);

                // Set the VectorRasterizationOptions property
                tiffOptions.VectorRasterizationOptions = rasterizationOptions;

                //Export CAD to TIFF
                image.Save(MyDir + "result_out.tiff", tiffOptions);
            }
            //ExEnd:SettingCanvasSizeAndMode            
            Console.WriteLine("\nCanvas size and mode setup successfully.");
        }
    }
}
