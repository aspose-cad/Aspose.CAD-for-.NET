using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.CAD;
using Aspose.CAD.ImageOptions;
using Aspose.CAD.FileFormats.Cad;
namespace Aspose.CAD.Examples.CSharp.Export
{
    public class CADLayoutsToPDF
    {
        public static void Run()
        {
            //ExStart:CADLayoutsToPDF
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_ConvertingCAD();
            string sourceFilePath = MyDir + "conic_pyramid.dxf";
            // Create an instance of CadImage class and load the file.
            using (Aspose.CAD.Image cadImage = (Aspose.CAD.Image)Image.Load(sourceFilePath))
            {
                // Create an instance of CadRasterizationOptions class
                CadRasterizationOptions rasterizationOptions = new CadRasterizationOptions();
                rasterizationOptions.PageWidth = 1600;
                rasterizationOptions.PageHeight = 1600;

                // Set the Entities type property to Entities3D.
                rasterizationOptions.TypeOfEntities = TypeOfEntities.Entities3D;

                rasterizationOptions.AutomaticLayoutsScaling = true;
                rasterizationOptions.NoScaling = false;
                rasterizationOptions.ContentAsBitmap = true;

                // Set Layouts
                rasterizationOptions.Layouts = new string[] { "Model" };

                // Create an instance of PDF options class
                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.VectorRasterizationOptions = rasterizationOptions;

                MyDir = MyDir + "CADLayoutsToPDF_out.pdf";

                // Set Graphics options
                rasterizationOptions.GraphicsOptions.SmoothingMode = SmoothingMode.HighQuality;
                rasterizationOptions.GraphicsOptions.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                rasterizationOptions.GraphicsOptions.InterpolationMode = InterpolationMode.HighQualityBicubic;

                // Export to PDF by calling the Save method
                cadImage.Save(MyDir, pdfOptions);
            }
            //ExEnd:CADLayoutsToPDF            
            Console.WriteLine("\n3D images exported successfully to PDF.\nFile saved at " + MyDir);
        }
    }
}
