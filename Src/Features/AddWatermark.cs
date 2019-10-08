using Aspose.CAD.FileFormats.Cad;
using Aspose.CAD.FileFormats.Cad.CadObjects;
using Aspose.CAD.ImageOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.CAD.Examples.CSharp.Features
{
    class AddWatermark
    {
        public static void Run() {

            //ExStart:AddWatermark

            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_DWGDrawings();
            

           using(CadImage cadImage = (CadImage)Image.Load(MyDir + "Drawing11.dwg")) {

                //add new MTEXT
                CadMText watermark = new CadMText();
                watermark.Text = "Watermark message";
                watermark.InitialTextHeight = 40;
                watermark.InsertionPoint = new Cad3DPoint(300, 40);
                watermark.LayerName = "0";
                cadImage.BlockEntities["*Model_Space"].AddEntity(watermark);

                // or add more simple entity like Text
                CadText text = new CadText();
                text.DefaultValue = "Watermark text";
                text.TextHeight = 40;
                text.FirstAlignment = new Cad3DPoint(300, 40);
                text.LayerName = "0";
                cadImage.BlockEntities["*Model_Space"].AddEntity(text);

                // export to pdf
                CadRasterizationOptions rasterizationOptions = new CadRasterizationOptions();
                rasterizationOptions.PageWidth = 1600;
                rasterizationOptions.PageHeight = 1600;
                rasterizationOptions.Layouts = new[] { "Model" };
                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.VectorRasterizationOptions = rasterizationOptions;
                cadImage.Save(MyDir + "AddWatermark_out.pdf", pdfOptions);

            }

                

            //ExEnd:AddWatermark


        }


    }
}
