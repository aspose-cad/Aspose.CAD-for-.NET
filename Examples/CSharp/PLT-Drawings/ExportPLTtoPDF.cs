using Aspose.CAD.FileFormats.Cad;
using Aspose.CAD.FileFormats.Cad.CadConsts;
using Aspose.CAD.FileFormats.Cad.CadObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Aspose.CAD.Examples.CSharp.DWG_Drawings.SupportMLeaderEntityForDWGFormat;
using Aspose.CAD.ImageOptions;

namespace Aspose.CAD.Examples.CSharp.PLT_Drawings
{
    class ExportPLTtoPDF
    {
        public static void Run()
        {
            //ExStart:ExportPLTtoPDF
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_PLTDrawings();
            string sourceFilePath = MyDir + "50states.plt";
           
            using (Image cadImage = Image.Load(sourceFilePath))
            {

                CadRasterizationOptions options = new CadRasterizationOptions
                {
                    PageHeight = 1600,
                    PageWidth = 1600,
                    CenterDrawing = true,
                    DrawType= CadDrawTypeMode.UseObjectColor,
                    BackgroundColor=Color.White
                };

                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.VectorRasterizationOptions = options;

                cadImage.Save(MyDir+ "50states.pdf", pdfOptions);
            }
            //ExEnd:ExportPLTtoPDF
        }


    }
    
}

 
