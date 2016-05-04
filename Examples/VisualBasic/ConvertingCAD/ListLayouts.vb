Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports Aspose.CAD
Namespace ConvertingCAD
    Public Class ListLayouts
        Public Shared Sub Run()
            ' ExStart:ListLayouts
            ' The path to the documents directory.
            Dim MyDir As String = RunExamples.GetDataDir_ConvertingCAD()
            Dim sourceFilePath As String = MyDir & Convert.ToString("conic_pyramid.dxf")
            Using image As Aspose.CAD.Image = Aspose.CAD.Image.Load(sourceFilePath)
                Dim cadImage As Aspose.CAD.FileFormats.Cad.CadImage = DirectCast(image, Aspose.CAD.FileFormats.Cad.CadImage)

                Dim layouts As Aspose.CAD.FileFormats.Cad.CadLayoutDictionary = cadImage.Layouts
                For Each layout As Aspose.CAD.FileFormats.Cad.CadObjects.CadLayout In layouts.Values
                    Console.WriteLine("Layout " + layout.LayoutName)
                Next
            End Using
            ' ExEnd:ListLayouts
        End Sub
    End Class
End Namespace