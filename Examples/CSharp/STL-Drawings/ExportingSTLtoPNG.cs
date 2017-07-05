using Aspose.CAD.FileFormats.Cad;
using Aspose.CAD.ImageOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.CAD.Examples.CSharp.STL_Drawings
{
    class ExportingSTLtoPNG
    {
        public static void ExportToPNG() 
        {
           // ExStart: ExportingSTLtoPNG
            string MyDir = RunExamples.GetDataDir_ConvertingCAD();
            string sourceFilePath = MyDir + "galeon.stl";

            using (var cadImage = (CadImage)Image.Load(sourceFilePath))
            {
                var rasterizationOptions = new CadRasterizationOptions();
                rasterizationOptions.CenterDrawing = true;
                rasterizationOptions.PageWidth = 100;
                rasterizationOptions.PageHeight = 100;

                PngOptions pngOptions = new PngOptions();
                pngOptions.VectorRasterizationOptions = rasterizationOptions;
               
                string outPath = sourceFilePath + ".png";
                cadImage.Save(outPath, pngOptions);
            }
        }
              //ExEnd:ExportingSTLtoPNG
    }
}
