using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.CAD;
namespace Aspose.CAD.Examples.CSharp.ConvertingCAD
{
    public class ConvertLayoutsToRasterImage
    {
        public static void Run()
        {
            //ExStart:ConvertLayoutsToRasterImage
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_ConvertingCAD();
            string sourceFilePath = MyDir + "conic_pyramid.dxf";
            using (Aspose.CAD.Image image = Aspose.CAD.Image.Load(sourceFilePath))
            {
                // Create an instance of CadRasterizationOptions
                Aspose.CAD.ImageOptions.CadRasterizationOptions rasterizationOptions = new Aspose.CAD.ImageOptions.CadRasterizationOptions();

                // Set page width & height
                rasterizationOptions.PageWidth = 1200;
                rasterizationOptions.PageHeight = 1200;

                // Specify a list of layout names
                rasterizationOptions.Layouts = new string[] { "Model", "Layout1" };

                // Create an instance of TiffOptions for the resultant image
                var options = new Aspose.CAD.ImageOptions.TiffOptions(
                    Aspose.CAD.FileFormats.Tiff.Enums.TiffExpectedFormat.Default);

                // Set rasterization options
                options.VectorRasterizationOptions = rasterizationOptions;

                MyDir = MyDir + "conic_pyramid_layoutstorasterimage_out.tiff";

                // Save resultant image
                image.Save(MyDir, options);                
            }
            //ExEnd:ConvertLayoutsToRasterImage            
            Console.WriteLine("\nCAD layouts converted successfully to raster image format.\nFile saved at " + MyDir);

        }
    }
}
