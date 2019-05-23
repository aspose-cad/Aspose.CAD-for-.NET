using Aspose.CAD.FileFormats.Cad;
using Aspose.CAD.FileFormats.Dwf;
using Aspose.CAD.ImageOptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Aspose.CAD.Examples.CSharp.DWF_Drawings
{
    class GetSizeOfDwfLayout
    {
        public static void Run()
        {
            //ExStart:GetSizeOfDwfLayout
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_DWFDrawings();
            string sourceFilePath = MyDir + "blocks_and_tables.dwf";
            string extension = Path.GetExtension(sourceFilePath);
            using (DwfImage image = (DwfImage)Aspose.CAD.Image.Load(sourceFilePath))
            {
                foreach (var page in image.Pages)
                {
                    var layout = page.Name;
                    System.Console.WriteLine("Layout= " + layout);
                    using (FileStream fs = new FileStream(MyDir + "layout_" + layout + ".jpg", FileMode.Create))
                    {
                        JpegOptions jpegOptions = new JpegOptions();
                        CadRasterizationOptions options = new CadRasterizationOptions();
                        options.Layouts = new string[] { layout };

                        double sizeExtX = page.MaxPoint.X - page.MinPoint.X;
                        double sizeExtY = page.MaxPoint.Y - page.MinPoint.Y;

                        if (page.UnitType == UnitType.Inch)
                        {
                            options.PageHeight = CommonHelper.INtoPixels(sizeExtY, CommonHelper.DPI);
                            options.PageWidth = CommonHelper.INtoPixels(sizeExtX, CommonHelper.DPI);
                        }
                        else if (page.UnitType == UnitType.Millimeter)
                        {
                            options.PageHeight = CommonHelper.MMtoPixels(sizeExtY, CommonHelper.DPI);
                            options.PageWidth = CommonHelper.MMtoPixels(sizeExtX, CommonHelper.DPI);
                        }
                        else
                        {
                            options.PageHeight = (float)sizeExtY;
                            options.PageWidth = (float)sizeExtX;
                        }

                        //options.CenterDrawing = true;
                        jpegOptions.VectorRasterizationOptions = options;

                        image.Save(fs, jpegOptions);
                    }
                }
            }
            //ExEnd:GetSizeOfDwfLayout
        }
    }
}
