using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.CAD;
namespace Aspose.CAD.Examples.CSharp.DWG_Drawings
{
    public class RenderDWGDocument
    {
        public static void Run()
        {
            //ExStart:RenderDWGDocument
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_DWGDrawings();
            string sourceFilePath = MyDir + "Bottom_plate.dwg";
            using (Aspose.CAD.Image image = Aspose.CAD.Image.Load(sourceFilePath))
            {
                CadRasterizationOptions rasterizationOptions = new CadRasterizationOptions();
                rasterizationOptions.Layouts = new string[] { "Model" };
                rasterizationOptions.NoScaling = true;

                // note: preserving some empty borders around part of image is the responsibility of customer
                // top left point of region to draw
                Point topLeft = new Point(6156, 7053);
                double width = 3108;
                double height = 2489;

                CadVportTableObject newView = new CadVportTableObject();

                // note: exactly such table name is required for active view
                newView.TableName = "*Active";
                newView.CenterPoint.X = topLeft.X + width / 2f;
                newView.CenterPoint.Y = topLeft.Y - height / 2f;
                newView.ViewHeight.Value = height;
                newView.ViewAspectRatio.Value = width / height;

                // search for active viewport and replace it
                for (int i = 0; i < cadImage.ViewPorts.Count; i++)
                {
                    CadVportTableObject currentView = (CadVportTableObject)(cadImage.ViewPorts[i]);
                    if ((currentView.TableName == null && cadImage.ViewPorts.Count == 1) ||
                    string.Equals(currentView.TableName.ToLowerInvariant(), "*active"))
                    {
                        cadImage.ViewPorts[i] = newView;
                        break;
                    }
                }
                image.Save(MyDir, pdfOptions);                
            }
            //ExEnd:RenderDWGDocument        
            Console.WriteLine("\nThe DWG file exported successfully to PDF.\nFile saved at " + MyDir);

        }
    }
}
