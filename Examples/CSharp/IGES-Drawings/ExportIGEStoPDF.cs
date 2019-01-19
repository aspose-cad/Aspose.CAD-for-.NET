using Aspose.CAD.FileFormats.Cad;
using Aspose.CAD.FileFormats.Cad.CadConsts;
using Aspose.CAD.FileFormats.Cad.CadObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Aspose.CAD.Examples.CSharp.DWG_Drawings.SupportMLeaderEntityForDWGFormat;
using Aspose.CAD.ImageOptions;

namespace Aspose.CAD.Examples.CSharp.IGES_Drawings
{
    class ExportIGEStoPDF
    {
        public static void Run()
        {
            //ExStart:ExportIGEStoPDF
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_IGESDrawings();
            string sourceFilePath = MyDir + "figa2.igs";
           
            using (Image cadImage = Image.Load(sourceFilePath))
            {

                CadRasterizationOptions options = new CadRasterizationOptions
                {
                    PageHeight = 1000,
                    PageWidth = 1000,
                    CenterDrawing = true,
                };

                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.VectorRasterizationOptions = options;

                cadImage.Save(MyDir+ "figa2.pdf", pdfOptions);
            }
            //ExEnd:ExportIGEStoPDF
        }


    }
    
}

    


