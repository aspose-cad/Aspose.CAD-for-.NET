Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports Aspose.CAD
Imports System.IO
Namespace ConvertingCAD
    Public Class EnableTrackingForCADRendering
        Public Shared Sub Run()
            ' ExStart:EnableTrackingForCADRendering
            ' The path to the documents directory.
            Dim MyDir As String = RunExamples.GetDataDir_ConvertingCAD()
            Dim sourceFilePath As String = MyDir & Convert.ToString("conic_pyramid.dxf")
            Using image As Aspose.CAD.Image = Aspose.CAD.Image.Load(sourceFilePath)
                Dim stream As New MemoryStream()
                Dim pdfOptions As New Aspose.CAD.ImageOptions.PdfOptions()
                ' Create an instance of CadRasterizationOptions and set its various properties
                Dim cadRasterizationOptions As New Aspose.CAD.ImageOptions.CadRasterizationOptions()
                pdfOptions.VectorRasterizationOptions = cadRasterizationOptions
                cadRasterizationOptions.PageWidth = 800
                cadRasterizationOptions.PageHeight = 600
                image.Save(stream, pdfOptions)
            End Using
            ' ExEnd:EnableTrackingForCADRendering            
            Console.WriteLine(vbLf & "Tracking enabled successfully for CAD rendering process.")
        End Sub
    End Class
End Namespace
