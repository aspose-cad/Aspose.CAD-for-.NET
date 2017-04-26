using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.CAD;

namespace Aspose.CAD.Examples.CSharp.DWG_Drawings
{    public class SearchText
    {
        //ExStart:SearchText
        public static void Run()
        {
            
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_DWGDrawings();
            string sourceFilePath = MyDir + "sample.dwg";
            // Load an existing DWG file as CadImage.
            using (Aspose.CAD.FileFormats.Cad.CadImage cadImage = (Aspose.CAD.FileFormats.Cad.CadImage)Aspose.CAD.Image.Load(sourceFilePath))
            {
                // Search for text in the file 
                foreach (Aspose.CAD.FileFormats.Cad.CadObjects.CadBaseEntity entity in cadImage.Entities)
                {
                    // Please, note: we iterate through CadText entities here, but some other entities may contain text also, e.g. CadMText and others
                    IterateCADNodes(entity);
                }

                // Search for text on specific layout get all layout names and link each layout with corresponding block with entities
                Aspose.CAD.FileFormats.Cad.CadLayoutDictionary layouts = cadImage.Layouts;
                string[] layoutNames = new string[layouts.Count];
                int i = 0;
                foreach (Aspose.CAD.FileFormats.Cad.CadObjects.CadLayout layout in layouts.Values)
                {
                    layoutNames[i++] = layout.LayoutName;
                    System.Console.WriteLine("Layout " + layout.LayoutName + " is found");

                    // Find block, applicable for DWG only
                    Aspose.CAD.FileFormats.Cad.CadTables.CadBlockTableObject blockTableObjectReference = null;
                    foreach (Aspose.CAD.FileFormats.Cad.CadTables.CadBlockTableObject tableObject in cadImage.BlocksTables)
                    {
                        if (string.Equals(tableObject.HardPointerToLayout, layout.ObjectHandle))
                        {
                            blockTableObjectReference = tableObject;
                            break;
                        }
                    }

                    // Collection cadBlockEntity.Entities contains information about all entities on specific layout if this collection has no elements it means layout is a copy of Model layout and contains the same entities
                    Aspose.CAD.FileFormats.Cad.CadObjects.CadBlockEntity cadBlockEntity = cadImage.BlockEntities[blockTableObjectReference.BlockName];
                }

                // Export to pdf
                Aspose.CAD.ImageOptions.CadRasterizationOptions rasterizationOptions = new Aspose.CAD.ImageOptions.CadRasterizationOptions();
                rasterizationOptions.PageWidth = 1600;
                rasterizationOptions.PageHeight = 1600;
                rasterizationOptions.AutomaticLayoutsScaling = true;
                rasterizationOptions.CenterDrawing = true;

                // Please, note: if cadBlockEntity collection mentioned above (for dwg) for selected layout or entitiesOnLayouts collection by layout's BlockTableRecordHandle (for dxf) is empty - export result file will be empty and you should draw Model layout instead
                rasterizationOptions.Layouts = new[] { "Layout1" };

                Aspose.CAD.ImageOptions.PdfOptions pdfOptions = new Aspose.CAD.ImageOptions.PdfOptions();

                pdfOptions.VectorRasterizationOptions = rasterizationOptions;
                cadImage.Save(MyDir + "SearchText_out.pdf", pdfOptions);
            }
            
        }

        public static void IterateCADNodes(CadBaseEntity obj)
        {
            if (obj.GetType() == typeof(Aspose.CAD.FileFormats.Cad.CadObjects.CadText))
            {
                Aspose.CAD.FileFormats.Cad.CadObjects.CadText childObj = (Aspose.CAD.FileFormats.Cad.CadObjects.CadText)obj;

                if (childObj.ChildObjects.Count != 0)
                {
                    foreach (var tempobj in childObj.ChildObjects)
                    {
                        IterateCADNodes(tempobj);
                    }
                }
                else
                {
                    System.Console.WriteLine(childObj.DefaultValue);
                }
            }
            else if (obj.GetType() == typeof(Aspose.CAD.FileFormats.Cad.CadObjects.CadMText))
            {
                Aspose.CAD.FileFormats.Cad.CadObjects.CadMText childObj = (Aspose.CAD.FileFormats.Cad.CadObjects.CadMText)obj;

                if (childObj.ChildObjects.Count != 0)
                {
                    foreach (var tempobj in childObj.ChildObjects)
                    {
                        IterateCADNodes(tempobj);
                    }
                }
                else
                {
                    System.Console.WriteLine(childObj.Text);
                }
            }
            else if (obj.GetType() == typeof(Aspose.CAD.FileFormats.Cad.CadObjects.CadInsertObject))
            {
                Aspose.CAD.FileFormats.Cad.CadObjects.CadInsertObject childObj = (Aspose.CAD.FileFormats.Cad.CadObjects.CadInsertObject)obj;
                if (childObj.ChildObjects.Count != 0)
                {
                    foreach (var tempobj in childObj.ChildObjects)
                    {
                        IterateCADNodes(tempobj);
                    }
                }
                else
                {
                    if (childObj.TypeName == CadEntityTypeName.ATTDEF)
                    {
                        Console.WriteLine(((CadAttDef)((CadBaseEntity)childObj)).DefaultString);
                    }
                    else if (childObj.TypeName == CadEntityTypeName.ATTRIB)
                    {
                        Console.WriteLine(((CadAttrib)((CadBaseEntity)childObj)).DefaultText);
                    }
                }

            }
        }
        //ExEnd:SearchText  
    }
}
