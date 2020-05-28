using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.CAD;
using Aspose.CAD.FileFormats.Cad.CadObjects;
using Aspose.CAD.FileFormats.Cad.CadConsts;
using Aspose.CAD.FileFormats.Cad;
using Aspose.CAD.FileFormats.Cad.CadObjects.AttEntities;
using Aspose.CAD.FileFormats.Cad.CadObjects.Polylines;

namespace Aspose.CAD.Examples.CSharp.DWG_Drawings
{    public class MeshSupportForDWG
    {
        
        public static void Run()
        {
            //ExStart:MeshSupportForDWG
            // The path to the documents directory.
            string MyDir = RunExamples.GetDataDir_DWGDrawings();
            string sourceFilePath = MyDir + "meshes.dwg";

            // Load an existing DWG file as CadImage.
            using (CadImage cadImage = (CadImage)Image.Load(sourceFilePath))
            {
                foreach (var entity in cadImage.Entities)
                {
                    if (entity is CadPolyFaceMesh)
                    {
                        CadPolyFaceMesh asFaceMesh = (CadPolyFaceMesh)entity;

                        if (asFaceMesh != null)
                        {
                            Console.WriteLine("Vetexes count: " + asFaceMesh.MeshMVertexCount);
                        }
                    }

                    else if (entity is CadPolygonMesh)
                    {
                        CadPolygonMesh asPolygonMesh = (CadPolygonMesh)entity;

                        if (asPolygonMesh != null)
                        {
                            Console.WriteLine("Vetexes count: " + asPolygonMesh.MeshMVertexCount);
                        }
                    }
                }
            }
            //ExEnd:MeshSupportForDWG
        }

    }

    
      
}

