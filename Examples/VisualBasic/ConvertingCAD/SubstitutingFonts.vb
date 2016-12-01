Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports Aspose.CAD
Namespace ConvertingCAD
    Public Class SubstitutingFonts
        Public Shared Sub Run()
            ' ExStart:SubstitutingFonts
            ' The path to the documents directory.
            Dim MyDir As String = RunExamples.GetDataDir_ConvertingCAD()
            Dim sourceFilePath As String = MyDir & Convert.ToString("conic_pyramid.dxf")
            ' Load a CAD drawing  in an instance of CadImage
            Using cadImage As Aspose.CAD.FileFormats.Cad.CadImage = DirectCast(Aspose.CAD.Image.Load(sourceFilePath), Aspose.CAD.FileFormats.Cad.CadImage)
                ' Iterate over the items of CadStyleDictionary
                For Each style In cadImage.Styles.ValuesTyped
                    ' Set the font name
                    style.PrimaryFontName = "Arial"
                Next style
            End Using
            ' ExEnd:SubstitutingFonts            
            Console.WriteLine(vbLf & "Font changed successfully.")
        End Sub
        Public Shared Sub SubstitutingFontByName()
            ' ExStart:SubstitutingFontByName
            ' The path to the documents directory.
            Dim MyDir As String = RunExamples.GetDataDir_ConvertingCAD()
            Dim sourceFilePath As String = MyDir & Convert.ToString("conic_pyramid.dxf")
            ' Load a CAD drawing in an instance of CadImage
            Using cadImage As Aspose.CAD.FileFormats.Cad.CadImage = DirectCast(Aspose.CAD.Image.Load(sourceFilePath), Aspose.CAD.FileFormats.Cad.CadImage)
                ' Specify the font for one particular style
                cadImage.Styles("Roman").PrimaryFontName = "Arial"
            End Using
            ' ExEnd:SubstitutingFontByName    
        End Sub
    End Class
End Namespace