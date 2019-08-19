using Aspose.CAD.ImageOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.CAD.Examples.CSharp.DWG_Drawings
{
    class ExportToSVG
    {

        public static void Run() {

            //ExStart:ExportToSVG
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_DWGDrawings();

            using (Image image = Image.Load(MyDir + "sample.dwg"))
            {
                var options = new SvgOptions();
                options.ColorType = Aspose.CAD.ImageOptions.SvgOptionsParameters.SvgColorMode.Grayscale;
                options.TextAsShapes = true;
                image.Save(MyDir + "sample.svg");
            }
            //ExEnd:ExportToSVG
        }
    }
}
