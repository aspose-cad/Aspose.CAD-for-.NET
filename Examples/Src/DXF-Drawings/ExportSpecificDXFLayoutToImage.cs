
using System;

namespace Aspose.CAD.Examples.CSharp.DXF_Drawings
{
    class ExportSpecificDXFLayoutToImage
    {
        public static void Run()
        {
            //ExStart:ExportSpecificDXFLayoutToImage

            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_DXFDrawings();
            string sourceFilePath = MyDir + "for_layers_test.dwf";

            using (var image = (Aspose.CAD.FileFormats.Cad.CadImage)Aspose.CAD.Image.Load(sourceFilePath))
            {
                // Create an instance of CadRasterizationOptions
                var rasterizationOptions = new Aspose.CAD.ImageOptions.CadRasterizationOptions();
                // Set image width & height
                rasterizationOptions.PageWidth = 500;
                rasterizationOptions.PageHeight = 500;
                // Set the drawing to render at the center of image
                // rasterizationOptions.CenterDrawing = true;

                // Get the layers in an instance of CadLayersDictionary
                var layersList = image.Layers;
                // Iterate over the layers
                foreach (var layerName in layersList.GetLayersNames())
                {
                    // Display layer name for tracking
                    Console.WriteLine("Start with " + layerName);

                    // Add the layer name to the CadRasterizationOptions's layer list
                    rasterizationOptions.Layers = new string[] { "LayerA" };
                    // Create an instance of JpegOptions (or any ImageOptions for raster formats)
                    var options = new Aspose.CAD.ImageOptions.JpegOptions();
                    // Set VectorRasterizationOptions property to the instance of CadRasterizationOptions
                    options.VectorRasterizationOptions = rasterizationOptions;
                    //Export each layer to Jpeg format
                    image.Save(layerName + "_out.jpg", options);
                }
            }
            //ExEnd:ExportSpecificDXFLayoutToImage
        }
    }
}
