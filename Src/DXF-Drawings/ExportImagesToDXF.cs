using Aspose.CAD.FileFormats.Cad;
using Aspose.CAD.FileFormats.Cad.CadConsts;
using Aspose.CAD.FileFormats.Cad.CadObjects;
using Aspose.CAD.FileFormats.Cad.CadTables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Aspose.CAD.Examples.CSharp.DXF_Drawings
{
    class ExportImagesToDXF
    {
        public static void Run() {

            //ExStart:ExportImagesToDXF
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_DXFDrawings();

            foreach (var file in new DirectoryInfo(MyDir).EnumerateFiles("*.dxf"))
            {
                // ****************************
                //  Set new font per document
                // ****************************
                using (var cadImage = (CadImage)Image.Load(file.FullName))
                {
                    // Iterate over the items of CadStyleTableObject
                    foreach (CadStyleTableObject style in cadImage.Styles)
                    {
                        // Set font name
                        style.PrimaryFontName = "Broadway";
                    }
                    cadImage.Save(file.FullName + "_font.dxf");
                }
                // ****************************
                //  Hide all "straight" lines
                // ****************************
                using (var cadImage = (CadImage)Image.Load(file.FullName))
                {
                    foreach (var entity in cadImage.Entities)
                    {
                        // Make lines invisible
                        if (entity.TypeName == CadEntityTypeName.LINE)
                        {
                            entity.Visible = 0;
                        }
                    }
                    cadImage.Save(file.FullName + "_lines.dxf");
                }
                // ****************************
                //  Manipulations with text
                // ****************************
                using (var cadImage = (CadImage)Image.Load(file.FullName))
                {
                    foreach (var entity in cadImage.Entities)
                    {
                        if (entity.TypeName == CadEntityTypeName.TEXT)
                        {
                            ((CadText)entity).DefaultValue = "New text here!!! :)";
                            break;
                        }
                    }
                    cadImage.Save(file.FullName + "_text.dxf");
                }
            }

            //ExEnd:ExportImagesToDXF

        }
    }
}
