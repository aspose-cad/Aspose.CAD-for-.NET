Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports Aspose.CAD
Imports Aspose.CAD.ImageOptions
Namespace Export
    Public Class Export3DImagestoPDF
        Public Shared Sub Run()
            ' ExStart:Export3DImagestoPDF
            ' The path to the documents directory.
            Dim MyDir As String = RunExamples.GetDataDir_ConvertingCAD()
            Dim sourceFilePath As String = MyDir & Convert.ToString("conic_pyramid.dxf")
            Using cadImage As Aspose.CAD.Image = Aspose.CAD.Image.Load(sourceFilePath)
                Dim rasterizationOptions As New Aspose.CAD.ImageOptions.CadRasterizationOptions()
                rasterizationOptions.PageWidth = 500
                rasterizationOptions.PageHeight = 500
                rasterizationOptions.TypeOfEntities = TypeOfEntities.Entities3D

                rasterizationOptions.Layouts = New String() {"Model"}
                Dim pdfOptions As New PdfOptions()
                pdfOptions.VectorRasterizationOptions = rasterizationOptions
                MyDir = MyDir & Convert.ToString("Export3DImagestoPDF_out_.pdf")
                cadImage.Save(MyDir, pdfOptions)
            End Using
            ' ExEnd:Export3DImagestoPDF            
            Console.WriteLine(Convert.ToString(vbLf & "3D images exported successfully to PDF." & vbLf & "File saved at ") & MyDir)
        End Sub
    End Class
End Namespace
