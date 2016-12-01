Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports Aspose.CAD
Namespace ConvertingCAD
    Public Class ConvertLayoutsToRasterImage
        Public Shared Sub Run()
            ' ExStart:ConvertLayoutsToRasterImage
            ' The path to the documents directory.
            Dim MyDir As String = RunExamples.GetDataDir_ConvertingCAD()
            Dim sourceFilePath As String = MyDir & Convert.ToString("conic_pyramid.dxf")
            Using image As Aspose.CAD.Image = Aspose.CAD.Image.Load(sourceFilePath)
                ' Create an instance of CadRasterizationOptions
                Dim rasterizationOptions As New Aspose.CAD.ImageOptions.CadRasterizationOptions()

                ' Set page width & height
                rasterizationOptions.PageWidth = 1200
                rasterizationOptions.PageHeight = 1200

                ' Specify a list of layout names
                rasterizationOptions.Layouts = New String() {"Model", "Layout1"}

                ' Create an instance of TiffOptions for the resultant image
                Dim options As ImageOptionsBase = New Aspose.CAD.ImageOptions.TiffOptions(Aspose.CAD.FileFormats.Tiff.Enums.TiffExpectedFormat.[Default])

                ' Set rasterization options
                options.VectorRasterizationOptions = rasterizationOptions

                MyDir = MyDir & Convert.ToString("conic_pyramid_layoutstorasterimage_out.tiff")

                ' Save resultant image
                image.Save(MyDir, options)
            End Using
            ' ExEnd:ConvertLayoutsToRasterImage            
            Console.WriteLine(Convert.ToString(vbLf & "CAD layouts converted successfully to raster image format." & vbLf & "File saved at ") & MyDir)
        End Sub
    End Class
End Namespace