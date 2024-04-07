using Aspose.CAD.FileFormats.Cad;
using Aspose.CAD.FileFormats.Cad.CadObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.CAD.Examples.CSharp.Hyperlinks
{
    class EditHyperlink
    {

        public static void Run() {

            //ExStart:EditHyperlink


            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_DWGDrawings();
            string dwgPathToFile = MyDir + "AutoCad_Sample.dwg";

            using (CadImage cadImage = (CadImage)Image.Load(dwgPathToFile))
            {
                foreach (CadEntityBase entity in cadImage.Entities)
                {
                    if (entity is CadInsertObject)
                    {
                        CadBlockEntity block = cadImage.BlockEntities[((CadInsertObject)entity).Name];
                        if (!string.IsNullOrEmpty(block.XRefPathName))
                        {
                            block.XRefPathName = "new file reference.dwg";
                        }
                    }

                    if (entity.Hyperlink == "https://products.aspose.com")
                    {
                        entity.Hyperlink = "https://www.aspose.com";
                    }
                }
            }

            //ExEnd:EditHyperlink

        }
    }
}
