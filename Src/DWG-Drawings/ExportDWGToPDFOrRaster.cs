using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.CAD;
using Aspose.CAD.FileFormats.Cad;
using Aspose.CAD.ImageOptions;

namespace Aspose.CAD.Examples.CSharp.DWG_Drawings
{
    public class ExportDWGToPDFOrRaster
    {
        public static void Run()
        {
            //ExStart:ExportDWGToPDFOrRaster
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_DWGDrawings();
            string sourceFilePath = MyDir + "Bottom_plate.dwg";
            string outPath = MyDir + "Bottom_plate.pdf";

            using (CadImage cadImage = (CadImage)Image.Load(sourceFilePath))
            {

                // export to pdf
                CadRasterizationOptions rasterizationOptions = new CadRasterizationOptions();
                rasterizationOptions.Layouts = new string[] { "Model" };

                bool currentUnitIsMetric = false;
                double currentUnitCoefficient = 1.0;
                DefineUnitSystem(cadImage.UnitType, out currentUnitIsMetric, out currentUnitCoefficient);

                if (currentUnitIsMetric)
                {
                    double metersCoeff = 1 / 1000.0;

                    double scaleFactor = metersCoeff / currentUnitCoefficient;

                    rasterizationOptions.PageWidth = (float)(210 * scaleFactor);
                    rasterizationOptions.PageHeight = (float)(297 * scaleFactor);
                    rasterizationOptions.UnitType = UnitType.Millimeter;
                }
                else
                {
                    rasterizationOptions.PageWidth = (float)(8.27f / currentUnitCoefficient);
                    rasterizationOptions.PageHeight = (float)(11.69f / currentUnitCoefficient);
                    rasterizationOptions.UnitType = UnitType.Inch;
                }

                rasterizationOptions.AutomaticLayoutsScaling = true;

                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                cadImage.Save(outPath, pdfOptions);

                // export to raster
                //A4 size at 300 DPI - 2480 x 3508   
                rasterizationOptions.PageHeight = 3508;
                rasterizationOptions.PageWidth = 2480;

                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };
                cadImage.Save(outPath.Replace("pdf", "png"), pngOptions);

            }
        }
        private static void DefineUnitSystem(UnitType unitType, out bool isMetric, out double coefficient)
        {
            isMetric = false;
            coefficient = 1.0;

            switch (unitType)
            {
                case UnitType.Parsec:
                    coefficient = 3.0857 * 10000000000000000.0;
                    isMetric = true;
                    break;
                case UnitType.LightYear:
                    coefficient = 9.4607 * 1000000000000000.0;
                    isMetric = true;
                    break;
                case UnitType.AstronomicalUnit:
                    coefficient = 1.4960 * 100000000000.0;
                    isMetric = true;
                    break;
                case UnitType.Gigameter:
                    coefficient = 1000000000.0;
                    isMetric = true;
                    break;
                case UnitType.Kilometer:
                    coefficient = 1000.0;
                    isMetric = true;
                    break;
                case UnitType.Decameter:
                    isMetric = true;
                    coefficient = 10.0;
                    break;
                case UnitType.Hectometer:
                    isMetric = true;
                    coefficient = 100.0;
                    break;
                case UnitType.Meter:
                    isMetric = true;
                    coefficient = 1.0;
                    break;
                case UnitType.Centimenter:
                    isMetric = true;
                    coefficient = 0.01;
                    break;
                case UnitType.Decimeter:
                    isMetric = true;
                    coefficient = 0.1;
                    break;
                case UnitType.Millimeter:
                    isMetric = true;
                    coefficient = 0.001;
                    break;
                case UnitType.Micrometer:
                    isMetric = true;
                    coefficient = 0.000001;
                    break;
                case UnitType.Nanometer:
                    isMetric = true;
                    coefficient = 0.000000001;
                    break;
                case UnitType.Angstrom:
                    isMetric = true;
                    coefficient = 0.0000000001;
                    break;
                case UnitType.Inch:
                    coefficient = 1.0;
                    break;
                case UnitType.MicroInch:
                    coefficient = 0.000001;
                    break;
                case UnitType.Mil:
                    coefficient = 0.001;
                    break;
                case UnitType.Foot:
                    coefficient = 12.0;
                    break;
                case UnitType.Yard:
                    coefficient = 36.0;
                    break;
                case UnitType.Mile:
                    coefficient = 63360.0;
                    break;
            }
        }
        //ExEnd:ExportDWGToPDFOrRaster    
        

        }
}
