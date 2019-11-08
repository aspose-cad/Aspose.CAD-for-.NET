using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.CAD;
using Aspose.CAD.FileFormats.Cad;
using Aspose.CAD.ImageOptions;

namespace Aspose.CAD.Examples.CSharp.DXF_Drawings
{
    public class RenderDXFAsPDF
    {
        public static void Run()
        {
            //ExStart:RenderDXFAsPDF
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_DXFDrawings();
            string sourceFilePath = MyDir + "conic_pyramid.dxf";
            string outPath = MyDir + "conic_pyramid.jpg";

            using (CadImage image = (CadImage)Image.Load(sourceFilePath))
            {
                ImageOptionsBase options = new JpegOptions();
                options.VectorRasterizationOptions = new CadRasterizationOptions() { PdfProductLocation = MyDir /*path to pdf product and licence*/ };
                options.VectorRasterizationOptions.PageHeight = 1000;
                options.VectorRasterizationOptions.PageWidth = 1000;
                image.Save(outPath, options);
            }

            //ExEnd:RenderDXFAsPDF         
        }
    }
}
