Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports Aspose.CAD

Namespace DWG_Drawings
    Public Class GetBlockAttributeValue
        Public Shared Sub Run()
            'ExStart:GetBlockAttributeValue
            ' The path to the documents directory.
            Dim MyDir As String = RunExamples.GetDataDir_DWGDrawings()
            Dim sourceFilePath As String = MyDir & Convert.ToString("sample.dwg")
            ' Load an existing DWG file as CadImage.
            Using cadImage As Aspose.CAD.FileFormats.Cad.CadImage = DirectCast(Aspose.CAD.Image.Load(sourceFilePath), Aspose.CAD.FileFormats.Cad.CadImage)
                System.Console.WriteLine(cadImage.BlockEntities("*MODEL_SPACE").XRefPathName)
            End Using
            'ExEnd:GetBlockAttributeValue  
        End Sub
    End Class
End Namespace
