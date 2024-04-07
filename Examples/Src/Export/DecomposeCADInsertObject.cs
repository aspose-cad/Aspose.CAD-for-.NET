using Aspose.CAD.FileFormats.Cad;
using Aspose.CAD.FileFormats.Cad.CadConsts;
using Aspose.CAD.FileFormats.Cad.CadObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.CAD.Examples.CSharp.Export
{
	class DecomposeCADInsertObject
	{
		public static void Run()
		{

			//ExStart:DecomposeCADInsertObject

			string MyDir = RunExamples.GetDataDir_ConvertingCAD();
			string sourceFilePath = MyDir + "conic_pyramid.dxf";
			using (CadImage cadImage = (CadImage)Image.Load(sourceFilePath))
			{

				foreach (var entity in cadImage.Entities)
				{
					if (entity.TypeName == CadEntityTypeName.INSERT)
					{
						CadBlockEntity block = cadImage.BlockEntities[(entity as CadInsertObject).Name];
						foreach (CadEntityBase baseEntity in block.Entities)
						{
							//  processing of entities
						}
					}
				}

				//ExEnd:DecomposeCADInsertObject
			}
		}
	}
}