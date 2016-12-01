Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports Aspose.CAD
Namespace ConvertingCAD
    Public Class ConvertDrawingToRasterImage
        Public Shared Sub Run()
            ' ExStart:ConvertDrawingToRasterImage
            ' The path to the documents directory.
            Dim MyDir As String = RunExamples.GetDataDir_ConvertingCAD()
            Dim sourceFilePath As String = MyDir & Convert.ToString("conic_pyramid.dxf")
            Using image As Aspose.CAD.Image = Aspose.CAD.Image.Load(sourceFilePath)
                ' Create an instance of CadRasterizationOptions
                Dim rasterizationOptions As New Aspose.CAD.ImageOptions.CadRasterizationOptions()
                ' Set page width & height
                rasterizationOptions.PageWidth = 1200
                rasterizationOptions.PageHeight = 1200

                ' Create an instance of PngOptions for the resultant image
                Dim options As ImageOptionsBase = New Aspose.CAD.ImageOptions.PngOptions()
                ' Set rasterization options
                options.VectorRasterizationOptions = rasterizationOptions

                MyDir = MyDir & Convert.ToString("conic_pyramid_raster_image_out.png")
                ' Save resultant image
                image.Save(MyDir, options)
            End Using
            ' ExEnd:ConvertDrawingToRasterImage            
            Console.WriteLine(Convert.ToString(vbLf & "CAD drawing converted successfully to raster image format." & vbLf & "File saved at ") & MyDir)
        End Sub
    End Class
End Namespace