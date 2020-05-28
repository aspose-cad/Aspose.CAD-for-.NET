using Aspose.CAD.FileFormats.Cad;
using Aspose.CAD.ImageOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace Aspose.CAD.Examples.CSharp.ConvertingCAD
{
    class PenSupportInExport
    {
   public static void Run ()
   {
    //ExStart:PenSupportInExport 
       string MyDir = RunExamples.GetDataDir_ConvertingCAD();
       string sourceFilePath = MyDir + "conic_pyramid.dxf";
       CadImage cadImage = (CadImage)Image.Load(sourceFilePath);
       CadRasterizationOptions rasterizationOptions = new CadRasterizationOptions();
       PdfOptions pdfOptions = new PdfOptions();

       // Here user can change default start cap and end cap of pens when exporting CadImage object to
       // image. It can be using for all image formats: pdf, png, bmp, gif, jpeg2000, jpeg, psd, tiff, wmf.
       // If user doesn't use PenOptions, system will use its own default pens (different in defferent places).
       rasterizationOptions.PenOptions = new PenOptions
       {
           StartCap = LineCap.Flat,
           EndCap = LineCap.Flat
       };

       pdfOptions.VectorRasterizationOptions = rasterizationOptions;

       cadImage.Save(MyDir+"9LHATT-A56_generated.pdf", pdfOptions);
    
    
   //ExEnd:PenSupportInExport
     }

   private static System.IO.Stream GetFileFromDesktop(string p)
   {
       throw new NotImplementedException();
   }    
    }
}
