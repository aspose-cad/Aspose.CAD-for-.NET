Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports Aspose.CAD
Imports Aspose.CAD.ImageOptions
Imports Aspose.CAD.FileFormats.Cad
Namespace Export
    Public Class CADLayoutsToPDF
        Public Shared Sub Run()
            ' ExStart:CADLayoutsToPDF
            ' The path to the documents directory.
            Dim MyDir As String = RunExamples.GetDataDir_ConvertingCAD()
            Dim sourceFilePath As String = MyDir & Convert.ToString("conic_pyramid.dxf")
            ' Create an instance of CadImage class and load the file.
            Using cadImage As Aspose.CAD.Image = DirectCast(Image.Load(sourceFilePath), Aspose.CAD.Image)
                ' Create an instance of CadRasterizationOptions class
                Dim rasterizationOptions As New CadRasterizationOptions()
                rasterizationOptions.PageWidth = 1600
                rasterizationOptions.PageHeight = 1600

                ' Set the Entities type property to Entities3D.
                rasterizationOptions.TypeOfEntities = TypeOfEntities.Entities3D

                rasterizationOptions.ScaleMethod = ScaleType.GrowToFit
                rasterizationOptions.ContentAsBitmap = True

                ' Set Layouts
                rasterizationOptions.Layouts = New String() {"Model"}

                ' Create an instance of PDF options class
                Dim pdfOptions As New PdfOptions()
                pdfOptions.VectorRasterizationOptions = rasterizationOptions

                MyDir = MyDir & Convert.ToString("CADLayoutsToPDF_out.pdf")

                ' Set Graphics options
                rasterizationOptions.GraphicsOptions.SmoothingMode = SmoothingMode.HighQuality
                rasterizationOptions.GraphicsOptions.TextRenderingHint = TextRenderingHint.AntiAliasGridFit
                rasterizationOptions.GraphicsOptions.InterpolationMode = InterpolationMode.HighQualityBicubic

                ' Export to PDF by calling the Save method
                cadImage.Save(MyDir, pdfOptions)
            End Using
            ' ExEnd:CADLayoutsToPDF            
            Console.WriteLine(Convert.ToString(vbLf & "3D images exported successfully to PDF." & vbLf & "File saved at ") & MyDir)
        End Sub
    End Class
End Namespace