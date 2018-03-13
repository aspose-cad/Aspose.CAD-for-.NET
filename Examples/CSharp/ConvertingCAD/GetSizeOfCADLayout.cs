using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Aspose.CAD;
using Aspose.CAD.FileFormats.Cad;
using Aspose.CAD.FileFormats.Cad.CadConsts;
using Aspose.CAD.FileFormats.Cad.CadObjects;
using Aspose.CAD.FileFormats.Cad.CadTables;
using Aspose.CAD.ImageOptions;

namespace Aspose.CAD.Examples.CSharp.ConvertingCAD
{
    public class GetSizeOfCADLayout
    {
        public static void Run()
        {
            //ExStart:GetSizeOfCADLayout
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_ConvertingCAD();
            string[] sourceFilePaths = new[] 
            {
                MyDir + "conic_pyramid.dxf",
                MyDir + "Bottom_plate.dwg"
            };

            foreach (var sourceFilePath in sourceFilePaths)
            {
                string extension = Path.GetExtension(sourceFilePath);
                using (CadImage cadImage = (CadImage)Aspose.CAD.Image.Load(sourceFilePath))
                {
                    List<string> layouts = GetNotEmptyLayouts(cadImage, extension);
                    const double Epsilon = 0.00001;
                    foreach (string layout in layouts)
                    {
                        System.Console.WriteLine("Layout= " + layout);
                        using (FileStream fs = new FileStream(MyDir + "layout_" + extension + "_" + layout + ".jpg", FileMode.Create))
                        {
                            JpegOptions jpegOptions = new JpegOptions();
                            CadRasterizationOptions options = new CadRasterizationOptions();
                            options.Layouts = new string[] { layout };

                            CadLayout l = cadImage.Layouts[layout];

                            if ((Math.Abs(l.MaxExtents.Y) < Epsilon && Math.Abs(l.MaxExtents.X) < Epsilon)
                                || (Math.Abs(l.MaxExtents.Y + 1E+20) < Epsilon
                                || Math.Abs(l.MaxExtents.X + 1E+20) < Epsilon)
                                || (Math.Abs(l.MinExtents.Y - 1E+20) < Epsilon
                                || Math.Abs(l.MinExtents.X - 1E+20) < Epsilon))
                            {
                                // do nothing, we can automatically detect size
                                // we can not rely on PlotPaperUnits here too because it is PlotInInches by default
                            }
                            else
                            {
                                double sizeExtX = l.MaxExtents.X - l.MinExtents.X;
                                double sizeExtY = l.MaxExtents.Y - l.MinExtents.Y;

                                if (l.PlotPaperUnits == CadPlotPaperUnits.PlotInInches)
                                {
                                    options.PageHeight = CommonHelper.INtoPixels(sizeExtY, CommonHelper.DPI);
                                    options.PageWidth = CommonHelper.INtoPixels(sizeExtX, CommonHelper.DPI);
                                }
                                else
                                {
                                    if (l.PlotPaperUnits == CadPlotPaperUnits.PlotInMillimeters)
                                    {
                                        options.PageHeight = CommonHelper.MMtoPixels(sizeExtY, CommonHelper.DPI);
                                        options.PageWidth = CommonHelper.MMtoPixels(sizeExtX, CommonHelper.DPI);
                                    }
                                    else
                                    {
                                        options.PageHeight = (float)sizeExtY;
                                        options.PageWidth = (float)sizeExtX;
                                    }
                                }
                            }

                            options.CenterDrawing = true;
                            jpegOptions.VectorRasterizationOptions = options;

                            cadImage.Save(fs, jpegOptions);
                        }
                    }
                }
            }
        }

        private static List<string> GetNotEmptyLayouts(Image cadImage, string extension)
        {
            List<string> nonEmptyLayouts = new List<string>();
            if (cadImage == null)
                return nonEmptyLayouts;

            switch (extension)
            {
                case ".dwg":
                    nonEmptyLayouts = GetNotEmptyLayoutsForDwg((CadImage)cadImage);
                    break;
                case ".dxf":
                    nonEmptyLayouts = GetNotEmptyLayoutsForDxf((CadImage)cadImage);
                    break;
            }

            return nonEmptyLayouts;
        }

        private static List<string> GetNotEmptyLayoutsForDwg(CadImage cadImage)
        {
            List<string> notEmptyLayouts = new List<string>();

            foreach (CadLayout layout in cadImage.Layouts.Values)
            {
                foreach (CadBlockTableObject tableObject in cadImage.BlocksTables)
                {
                    if (string.Equals(tableObject.HardPointerToLayout.Value, layout.ObjectHandle, StringComparison.InvariantCultureIgnoreCase))
                    {
                        if (cadImage.BlockEntities.ContainsKey(tableObject.BlockName))
                        {
                            CadBlockEntity cadBlockEntity = cadImage.BlockEntities[tableObject.BlockName];
                            if (cadBlockEntity.Entities.Length > 0)
                                notEmptyLayouts.Add(layout.LayoutName);
                        }
                        break;
                    }
                }
            }

            return notEmptyLayouts;
        }

        private static List<string> GetNotEmptyLayoutsForDxf(CadImage cadImage)
        {
            List<string> notEmptyLayouts = new List<string>();

            Dictionary<string, string> layoutBlockHandles = new Dictionary<string, string>();
            foreach (CadLayout layout in cadImage.Layouts.Values)
            {
                if (layout.BlockTableRecordHandle != null)
                    layoutBlockHandles.Add(layout.BlockTableRecordHandle, layout.LayoutName);
            }

            foreach (CadBaseEntity entity in cadImage.Entities)
            {
                if (layoutBlockHandles.ContainsKey(entity.SoftOwner.Value))
                {
                    string layoutName = layoutBlockHandles[entity.SoftOwner.Value];
                    if (!notEmptyLayouts.Contains(layoutName))
                        notEmptyLayouts.Add(layoutName);
                }
            }

            return notEmptyLayouts;
        }
     //ExEnd:GetSizeOfCADLayout
    
    }
}