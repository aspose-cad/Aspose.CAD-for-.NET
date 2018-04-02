
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.CAD;
namespace Aspose.CAD.Examples.CSharp.ConvertingCAD
{
    public class CADLayersToRasterImageFormats
    {
        public static void Run()
        {
            //ExStart:CADLayersToRasterImageFormats
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_ConvertingCAD();
            string sourceFilePath = MyDir + "conic_pyramid.dxf";
            // Load a CAD drawing in an instance of Image
            using (var image = Aspose.CAD.Image.Load(sourceFilePath))
            {
                // Create an instance of CadRasterizationOptions
                var rasterizationOptions = new Aspose.CAD.ImageOptions.CadRasterizationOptions();
                // Set image width & height
                rasterizationOptions.PageWidth = 500;
                rasterizationOptions.PageHeight = 500;

                // Set the drawing to render at the center of image
                rasterizationOptions.CenterDrawing = true;

                // Add the layer name to the CadRasterizationOptions's layer list
                rasterizationOptions.Layers.Add("0"); // Most of the CAD drawings have a layer by name 0, you may specify any name

                // Create an instance of JpegOptions (or any ImageOptions for raster formats)
                var options = new Aspose.CAD.ImageOptions.JpegOptions();
                // Set VectorRasterizationOptions property to the instance of CadRasterizationOptions
                options.VectorRasterizationOptions = rasterizationOptions;
                //Export each layer to Jpeg format
                MyDir = MyDir + "CADLayersToRasterImageFormats_out.jpg";
                image.Save(MyDir, options);
            }
                       
            Console.WriteLine("\nCAD layers converted successfully to raster image format.\nFile saved at " + MyDir);            
        }
        public static void ConvertAllLayersToRasterImageFormats()
        {
           
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_ConvertingCAD();
            string sourceFilePath = MyDir + "conic_pyramid.dxf";
            // Load a CAD drawing in an instance of CadImage
            using (var image = (Aspose.CAD.FileFormats.Cad.CadImage)Aspose.CAD.Image.Load(sourceFilePath))
            {
                // Create an instance of CadRasterizationOptions
                var rasterizationOptions = new Aspose.CAD.ImageOptions.CadRasterizationOptions();
                // Set image width & height
                rasterizationOptions.PageWidth = 500;
                rasterizationOptions.PageHeight = 500;
                // Set the drawing to render at the center of image
                rasterizationOptions.CenterDrawing = true;

                // Get the layers in an instance of CadLayersDictionary
                var layersList = image.Layers;
                // Iterate over the layers
                foreach (var layerName in layersList.GetLayersNames())
                {
                    // Display layer name for tracking
                    Console.WriteLine("Start with " + layerName);

                    // Add the layer name to the CadRasterizationOptions's layer list
                    rasterizationOptions.Layers.Add(layerName);

                    // Create an instance of JpegOptions (or any ImageOptions for raster formats)
                    var options = new Aspose.CAD.ImageOptions.JpegOptions();
                    // Set VectorRasterizationOptions property to the instance of CadRasterizationOptions
                    options.VectorRasterizationOptions = rasterizationOptions;
                    //Export each layer to Jpeg format
                    image.Save(layerName + "_out.jpg", options);
                }
            }
           
            Console.WriteLine("\nCAD all layers converted successfully to raster image format.");
            //ExEnd:CADLayersToRasterImageFormats
        }

    }
}
