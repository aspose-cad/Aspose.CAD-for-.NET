using Aspose.CAD.FileFormats.Cad;
using Aspose.CAD.FileFormats.Cad.CadObjects;
using Aspose.CAD.ImageOptions;
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
            string dwgPathToFile = MyDir + "Drawing11.dwg";

            CadImage cadImage1 = (CadImage)Image.Load(dwgPathToFile);

            CadRasterImageDef cadRasterImageDef = new CadRasterImageDef("road-sign-custom.png", 640, 562);
            cadRasterImageDef.ObjectHandle = "A3B4";

            Cad3DPoint insertionPoint = new Cad3DPoint(26.77, 22.35);
            Cad3DPoint uVector = new Cad3DPoint(0.0061565450840500831, 0);
            Cad3DPoint vVector = new Cad3DPoint(0, 0.0061565450840500822);

            CadRasterImage cadRasterImage = new CadRasterImage(cadRasterImageDef, insertionPoint, uVector, vVector);
            cadRasterImage.ImageDefReference = "A3B4";
            cadRasterImage.DisplayFlags = 7;
            cadRasterImage.ClippingState = 0;
            cadRasterImage.ClipBoundaryVertexList.Add(new Cad2DPoint(-0.5, 0.5));
            cadRasterImage.ClipBoundaryVertexList.Add(new Cad2DPoint(639.5, 561.5));

            CadImage cadImage = (CadImage)cadImage1;
            cadImage.BlockEntities["*Model_Space"].AddEntity(cadRasterImage);

            List<CadBaseObject> list = new List<CadBaseObject>(cadImage.Objects);
            list.Add(cadRasterImageDef);
            cadImage.Objects = list.ToArray();


            PdfOptions pdfOptions = new PdfOptions();
            CadRasterizationOptions cadRasterizationOptions = new CadRasterizationOptions();
            pdfOptions.VectorRasterizationOptions = cadRasterizationOptions;
            cadRasterizationOptions.DrawType = CadDrawTypeMode.UseObjectColor;

            cadRasterizationOptions.PageHeight = 1600;
            cadRasterizationOptions.PageWidth = 1600;
            cadRasterizationOptions.Layouts = new string[] { "Model" };
            cadImage1.Save(MyDir + "export2.pdf", pdfOptions);
            //ExEnd:ImportImageToDWG
        }
    }
}
