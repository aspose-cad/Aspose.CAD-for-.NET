using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.CAD;
namespace CSharp.ConvertingCAD
{
    public class SettingBackgroundAndDrawingColors
    {
        public static void Run()
        {
            //ExStart:SettingBackgroundAndDrawingColors
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_ConvertingCAD();
            string sourceFilePath = MyDir + "conic_pyramid.dxf";
            using (Aspose.CAD.Image image = Aspose.CAD.Image.Load(sourceFilePath))
            {
                // Create an instance of CadRasterizationOptions and set its various properties
                Aspose.CAD.ImageOptions.CadRasterizationOptions rasterizationOptions = new Aspose.CAD.ImageOptions.CadRasterizationOptions();
                rasterizationOptions.PageWidth = 1600;
                rasterizationOptions.PageHeight = 1600;
                rasterizationOptions.BackgroundColor = Aspose.CAD.Color.Beige;
                rasterizationOptions.DrawType = Aspose.CAD.FileFormats.Cad.CadDrawTypeMode.UseDrawColor;
                rasterizationOptions.DrawColor = Aspose.CAD.Color.Blue;

                // Create an instance of PdfOptions
                Aspose.CAD.ImageOptions.PdfOptions pdfOptions = new Aspose.CAD.ImageOptions.PdfOptions();
                // Set the VectorRasterizationOptions property
                pdfOptions.VectorRasterizationOptions = rasterizationOptions;

                // Export CAD to PDF
                image.Save(MyDir + "result_out_.pdf", pdfOptions);

                // Create an instance of TiffOptions
                Aspose.CAD.ImageOptions.TiffOptions tiffOptions = new Aspose.CAD.ImageOptions.TiffOptions(Aspose.CAD.FileFormats.Tiff.Enums.TiffExpectedFormat.Default);

                // Set the VectorRasterizationOptions property
                tiffOptions.VectorRasterizationOptions = rasterizationOptions;

                // Export CAD to TIFF
                image.Save(MyDir + "result_out_.tiff", tiffOptions);
            }
            //ExEnd:SettingBackgroundAndDrawingColors            
            Console.WriteLine("\nBackground and drawing colors setup successfully.");
        }
    }
}
