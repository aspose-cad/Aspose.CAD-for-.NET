using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.CAD;
using Aspose.CAD.FileFormats.Dgn;
using Aspose.CAD.FileFormats.Dgn.DgnElements;

namespace Aspose.CAD.Examples.CSharp.Exporting_DGN
{
    public class SupportedDGNElements
    {
        public static void Run()
        {
            try
            {
                //ExStart:SupportedDGNElements
                // The path to the documents directory.
                string MyDir = RunExamples.GetDataDir_ExportingDGN();
                string sourceFilePath = MyDir + "Nikon_D90_Camera.dgn";
                // Load an existing DGN file as CadImage.
                using (DgnImage dgnImage = (DgnImage)Image.Load(sourceFilePath))
                {
                    foreach (DgnDrawingElementBase element in dgnImage.Elements)
                    {
                        switch (element.Metadata.Type)
                        {
                            case DgnElementType.Line:
                            case DgnElementType.Ellipse:
                            case DgnElementType.Curve:
                            case DgnElementType.BSplineCurveHeader:
                            case DgnElementType.Arc:
                            case DgnElementType.Shape:
                            case DgnElementType.PolyLine:
                            case DgnElementType.TextNode:
                            case DgnElementType.Text:
                            case DgnElementType.ComplexShapeHeader:
                            case DgnElementType.ComplexChainHeader:
                                {
                                    //previously supported entities, now supported also for 3D
                                    break;
                                }

                            case DgnElementType.SolidHeader3D:
                            case DgnElementType.Cone:
                            case DgnElementType.CellHeader:
                                {
                                    //supported 3D entities
                                    break;
                                }
                        }
                    }
                }
                //ExEnd:SupportedDGNElements     
                Console.WriteLine("\nThe DGN file exported successfully to raster image.\nFile saved at " + MyDir);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please use valid input file." + ex.Message);
            }

        }
    }
}
