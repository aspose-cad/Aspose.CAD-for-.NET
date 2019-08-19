using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.CAD;
using Aspose.CAD.FileFormats;
using Aspose.CAD.FileFormats.Cad;
using Aspose.CAD.ImageOptions;

namespace Aspose.CAD.Examples.CSharp.Export
{
    public class FreePointOfView
    {
        public static void Run()
        {
            //ExStart:FreePointOfView
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_ConvertingCAD();
            string sourceFilePath = MyDir + "conic_pyramid.dxf";
            var outPath = Path.Combine(MyDir, "FreePointOfView_out.jpg");
            using (CadImage cadImage = (CadImage)Image.Load(sourceFilePath))
            {
                JpegOptions options = new JpegOptions
                {
                    VectorRasterizationOptions = new CadRasterizationOptions
                    {
                        PageWidth = 1500, PageHeight = 1500
                    }
                };

                float xAngle = 10; //Angle of rotation along the X axis
                float yAngle = 30; //Angle of rotation along the Y axis
                float zAngle = 40; //Angle of rotation along the Z axis
                ((CadRasterizationOptions)(options.VectorRasterizationOptions)).ObserverPoint = new ObserverPoint(xAngle, yAngle, zAngle);

                cadImage.Save(outPath, options);
            }

            //ExEnd:FreePointOfView            
            Console.WriteLine("\n3D images exported successfully to JPEG.\nFile saved at " + outPath);
        }
    }
}
