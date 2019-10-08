using Aspose.CAD.FileFormats.Cad;
using Aspose.CAD.ImageOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.CAD.Examples.CSharp.Features
{
    class SinglePDFWithDifferentLayouts
    {

        public static void Run() {

            //ExStart:SinglePDFWithDifferentLayouts

            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_DWGDrawings();


            using (CadImage cadImage = (CadImage)Image.Load(MyDir + "City skyway map.dwg"))
            {
                CadRasterizationOptions rasterizationOptions = new CadRasterizationOptions();
                rasterizationOptions.PageWidth = 1000;
                rasterizationOptions.PageHeight = 1000;

                //custom sizes for several layouts
                rasterizationOptions.LayoutPageSizes.Add("ANSI C Plot", new SizeF(500, 1000));
                rasterizationOptions.LayoutPageSizes.Add("8.5 x 11 Plot", new SizeF(1000, 100));

                PdfOptions pdfOptions = new PdfOptions() { VectorRasterizationOptions = rasterizationOptions };

                cadImage.Save(MyDir + "singlePDF_out.pdf", pdfOptions);

            }

            //ExEnd:SinglePDFWithDifferentLayouts

        }

    }
}
