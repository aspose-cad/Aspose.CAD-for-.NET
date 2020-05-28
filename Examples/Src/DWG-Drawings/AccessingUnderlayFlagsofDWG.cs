using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.CAD;

namespace Aspose.CAD.Examples.CSharp.DWG_Drawings
{
    class AccessingUnderlayFlagsofDWG
    {

        public static void Run()
        {
            //ExStart:AccessingUnderlayFlagsofDWG

            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_DWGDrawings();

            // Input file name and path
            string fileName = MyDir + "BlockRefDgn.dwg";

            // Load an existing DWG file and convert it into CadImage 
            using (Aspose.CAD.FileFormats.Cad.CadImage image = (Aspose.CAD.FileFormats.Cad.CadImage)Image.Load(fileName))
            {
                // Go through each entity inside the DWG file
                foreach (Aspose.CAD.FileFormats.Cad.CadObjects.CadBaseEntity entity in image.Entities)
                {
                    // Check if entity is of CadDgnUnderlay type
                    if (entity is Aspose.CAD.FileFormats.Cad.CadObjects.CadDgnUnderlay)
                    {
                        // Access different underlay flags 
                        Aspose.CAD.FileFormats.Cad.CadObjects.CadUnderlay underlay = entity as Aspose.CAD.FileFormats.Cad.CadObjects.CadUnderlay;
                        Console.WriteLine(underlay.UnderlayPath);
                        Console.WriteLine(underlay.UnderlayName);
                        Console.WriteLine(underlay.InsertionPoint.X);
                        Console.WriteLine(underlay.InsertionPoint.Y);
                        Console.WriteLine(underlay.RotationAngle);
                        Console.WriteLine(underlay.ScaleX);
                        Console.WriteLine(underlay.ScaleY);
                        Console.WriteLine(underlay.ScaleZ);
                        Console.WriteLine((underlay.Flags & Aspose.CAD.FileFormats.Cad.CadObjects.UnderlayFlags.UnderlayIsOn) == Aspose.CAD.FileFormats.Cad.CadObjects.UnderlayFlags.UnderlayIsOn);
                        Console.WriteLine((underlay.Flags & Aspose.CAD.FileFormats.Cad.CadObjects.UnderlayFlags.ClippingIsOn) == Aspose.CAD.FileFormats.Cad.CadObjects.UnderlayFlags.ClippingIsOn);
                        Console.WriteLine((underlay.Flags & Aspose.CAD.FileFormats.Cad.CadObjects.UnderlayFlags.Monochrome) != Aspose.CAD.FileFormats.Cad.CadObjects.UnderlayFlags.Monochrome);
                        break;
                    }
                }
            }
            //ExEnd:AccessingUnderlayFlagsofDWG
        }

    }
}
