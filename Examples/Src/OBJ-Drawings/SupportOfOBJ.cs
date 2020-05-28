using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.CAD.Examples.CSharp.OBJ_Drawings
{
    class SupportOfOBJ
    {
        public static void Run() {

            //ExStart:SupportOfOBJ

            string MyDir = RunExamples.GetDataDir_OBJDrawings();

            using (Aspose.CAD.Image CADDoc = Aspose.CAD.Image.Load(MyDir + "example-580-W.obj"))
            {
                Aspose.CAD.ImageOptions.CadRasterizationOptions rasterizationOptions =
                    new Aspose.CAD.ImageOptions.CadRasterizationOptions();

                rasterizationOptions.PageWidth = CADDoc.Size.Width;
                rasterizationOptions.PageHeight = CADDoc.Size.Height;

                Aspose.CAD.ImageOptions.PdfOptions CADf = new Aspose.CAD.ImageOptions.PdfOptions();
                CADf.VectorRasterizationOptions = rasterizationOptions;

                CADDoc.Save(MyDir + "example-580-W_custom.pdf", CADf);
            }

            //ExEnd:SupportOfOBJ

        }
    }
}
