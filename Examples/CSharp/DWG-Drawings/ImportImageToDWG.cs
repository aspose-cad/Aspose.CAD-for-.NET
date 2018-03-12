using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.CAD.Examples.CSharp.DWG_Drawings
{
    class ImportImageToDWG
    {
   public static void Run()
    {
        string MyDir = RunExamples.GetDataDir_DWGDrawings();
        //ExStart:ImportImageToDWG
         string dwgPathToFile = MyDir +"Drawing11.dwg";
         using (Image image = ImageLoader.Load(dwgPathToFile))
        {
            CadRasterImageDef cadRasterImageDef = new CadRasterImageDef();
            cadRasterImageDef.ObjectHandle = "A3B4";
            cadRasterImageDef.FileName = "road-sign-custom.png";

            CadRasterImage cadRasterImage = new CadRasterImage();
            cadRasterImage.ImageDefReference = "A3B4";
            cadRasterImage.InsertionPoint.X = 26.77;
            cadRasterImage.InsertionPoint.Y = 22.35;
            cadRasterImage.DisplayFlags = 7;
            cadRasterImage.ImageSizeU = 640;
            cadRasterImage.ImageSizeV = 562;
            cadRasterImage.UVector.X = 0.0061565450840500831;
            cadRasterImage.UVector.Y = 0;
            cadRasterImage.VVector.X = 0;
            cadRasterImage.VVector.Y = 0.0061565450840500822;
            cadRasterImage.ClippingState = 0;
            cadRasterImage.ClipBoundaryVertexList.Add(new Cad2DPoint(-0.5, 0.5));
            cadRasterImage.ClipBoundaryVertexList.Add(new Cad2DPoint(639.5, 561.5));

            CadImage cadImage = (CadImage)image;
            cadImage.BlockEntities["*Model_Space"].AddEntity(cadRasterImage);

            List<CadBaseObject> list = new List<CadBaseObject>(cadImage.Objects);
            list.Add(cadRasterImageDef);
            cadImage.Objects = list.ToArray();


            PdfOptions pdfOptions = new PdfOptions();
            CadRasterizationOptions cadRasterizationOptions = new CadRasterizationOptions();
            pdfOptions.VectorRasterizationOptions = cadRasterizationOptions;
            cadRasterizationOptions.DrawType = CadDrawTypeMode.UseObjectColor;
            cadRasterizationOptions.CenterDrawing = true;
            cadRasterizationOptions.PageHeight = 1600;
            cadRasterizationOptions.PageWidth = 1600;
            cadRasterizationOptions.Layouts = new string[] { "Model" };
            image.Save(MyDir+"export2.pdf", pdfOptions);
        }
        //ExEnd:ImportImageToDWG
    }
    }
}
