using Aspose.CAD.FileFormats.Cad;
using Aspose.CAD.ImageOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.CAD.Examples.CSharp.DXF_Drawings
{
    class SupportOfBlockClipping
    {
        public static void Run()
        {
            //ExStart:SupportOfBlockClipping
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_DXFDrawings();

            string inputFile = MyDir + "SLS-CW-CD-CE001-R01_blockClip.dxf";
            string outputFile = MyDir + "SLS-CW-CD-CE001-R01_blockClip.pdf";
            using (CadImage cadImage = (CadImage)Image.Load(inputFile))
            {
                var rasterizationOptions = new Aspose.CAD.ImageOptions.CadRasterizationOptions
                {
                    BackgroundColor = Aspose.CAD.Color.White,
                    DrawType = Aspose.CAD.FileFormats.Cad.CadDrawTypeMode.UseObjectColor,
                    PageWidth = 1200,
                    PageHeight = 1600,
                    BorderX = 30,
                    BorderY = 5,
                    CenterDrawing = true,
                    Layouts = new string[] { "Model" }
                };

                PdfOptions pdfOptions = new Aspose.CAD.ImageOptions.PdfOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                cadImage.Save(outputFile, pdfOptions);
                //ExEnd:SupportOfBlockClipping

            }
        }
    }
}
