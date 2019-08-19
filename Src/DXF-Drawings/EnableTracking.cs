using Aspose.CAD.ImageOptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Aspose.CAD.Examples.CSharp.DXF_Drawings
{
    class EnableTracking
    {
        public static void Run() {

            //ExStart:EnableTracking
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_DXFDrawings();
            using (Image image = Image.Load(MyDir + "conic_pyramid.dxf"))
            {
                using (FileStream stream = new FileStream(MyDir + "output_conic_pyramid.pdf", FileMode.Create))
                {
                    PdfOptions pdfOptions = new PdfOptions();

                    CadRasterizationOptions cadRasterizationOptions = new CadRasterizationOptions();
                    pdfOptions.VectorRasterizationOptions = cadRasterizationOptions;
                    cadRasterizationOptions.PageWidth = 800;
                    cadRasterizationOptions.PageHeight = 600;

                    int idxError = 1;
                    cadRasterizationOptions.RenderResult += new CadRasterizationOptions.CadRenderHandler(
                        delegate (CadRenderResult result)
                        {

                            Console.WriteLine("Tracking results of exporting");

                            if (result.IsRenderComplete)
                                return;

                            Console.WriteLine("Have some problems:");

                            foreach (RenderResult rr in result.Failures)
                                Console.WriteLine(string.Format("{0}. {1}, {2}", idxError++, rr.RenderCode.ToString(),
                                    rr.Message));

                        });

                    Console.WriteLine("Exporting to pdf format");
                    image.Save(stream, pdfOptions);
                }
            }

            //ExEnd:EnableTracking

        }
    }
}
