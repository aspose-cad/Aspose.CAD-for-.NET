using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.CAD;
namespace Aspose.CAD.Examples.CSharp.ConvertingCAD
{
    public class AdjustingCADDrawingSize
    {
        public static void Run()
        {
            //ExStart:AdjustingCADDrawingSizeUsingUnitType

            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_ConvertingCAD();

            string sourceFilePath = MyDir + "sample.dwg";
            
            // Load a CAD drawing in an instance of Image
            using (var image = Aspose.CAD.Image.Load(sourceFilePath))
            {
                // Create an instance of BmpOptions class
                Aspose.CAD.ImageOptions.BmpOptions bmpOptions = new Aspose.CAD.ImageOptions.BmpOptions();

                // Create an instance of CadRasterizationOptions and set its various properties
                Aspose.CAD.ImageOptions.CadRasterizationOptions cadRasterizationOptions = new Aspose.CAD.ImageOptions.CadRasterizationOptions();
                bmpOptions.VectorRasterizationOptions = cadRasterizationOptions;
                cadRasterizationOptions.CenterDrawing = true;

                // Set the UnitType property
                cadRasterizationOptions.UnitType = Aspose.CAD.ImageOptions.UnitType.Centimenter;

                // Set the layouts property
                cadRasterizationOptions.Layouts = new string[] { "Model" };

                // Export layout to BMP format
                string outPath = sourceFilePath + ".bmp";
                image.Save(outPath, bmpOptions);
            }

            //ExEnd:AdjustingCADDrawingSizeUsingUnitType
        }

        public static void AutoAdjustingCADDrawingSize()
        {
            //ExStart:AutoAdjustingCADDrawingSize

            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_ConvertingCAD();

            string sourceFilePath = MyDir + "sample.dwg";

            // Load a CAD drawing in an instance of Image
            using (var image = Aspose.CAD.Image.Load(sourceFilePath))
            {
                // Create an instance of BmpOptions class
                Aspose.CAD.ImageOptions.BmpOptions bmpOptions = new Aspose.CAD.ImageOptions.BmpOptions();

                // Create an instance of CadRasterizationOptions and set its various properties
                Aspose.CAD.ImageOptions.CadRasterizationOptions cadRasterizationOptions = new Aspose.CAD.ImageOptions.CadRasterizationOptions();
                bmpOptions.VectorRasterizationOptions = cadRasterizationOptions;
                cadRasterizationOptions.CenterDrawing = true;
                            
                // Set the layouts property
                cadRasterizationOptions.Layouts = new string[] { "Model" };

                // Export layout to BMP format
                string outPath = sourceFilePath + ".bmp";
                image.Save(outPath, bmpOptions);
            }

            //ExEnd:AutoAdjustingCADDrawingSize
            
        }

    }
}
