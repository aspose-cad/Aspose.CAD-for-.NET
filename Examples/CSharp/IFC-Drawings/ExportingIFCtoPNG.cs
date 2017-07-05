﻿using Aspose.CAD.ImageOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.CAD.Examples.CSharp.IFC_Drawings
{
    class ExportingIFCtoPNG
    {
        public static void ExportToPNG()
        {
            //Setfile name path as other examples
            string MyDir = RunExamples.GetDataDir_ConvertingCAD();
            string sourceFilePath = MyDir + "example.ifc";

            using (IfcImage cadImage = (IfcImage)Image.Load(sourceFilePath))
            {
                IfcRasterizationOptions rasterizationOptions = new IfcRasterizationOptions();
                rasterizationOptions.CenterDrawing = true;
                rasterizationOptions.PageWidth = 100;
                rasterizationOptions.PageHeight = 100;

                PngOptions pngOptions = new PngOptions();
                pngOptions.VectorRasterizationOptions = rasterizationOptions;
              
                //Set output path as well
                string outPath = sourceFilePath + ".png";
                cadImage.Save(outPath, pngOptions);
            }
        }
    }
}
