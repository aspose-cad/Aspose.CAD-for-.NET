Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports Aspose.CAD
Namespace ConvertingCAD
    Public Class SettingBackgroundAndDrawingColors
        Public Shared Sub Run()
            ' ExStart:SettingBackgroundAndDrawingColors
            ' The path to the documents directory.
            Dim MyDir As String = RunExamples.GetDataDir_ConvertingCAD()
            Dim sourceFilePath As String = MyDir & Convert.ToString("conic_pyramid.dxf")
            Using image As Aspose.CAD.Image = Aspose.CAD.Image.Load(sourceFilePath)
                ' Create an instance of CadRasterizationOptions and set its various properties
                Dim rasterizationOptions As New Aspose.CAD.ImageOptions.CadRasterizationOptions()
                rasterizationOptions.PageWidth = 1600
                rasterizationOptions.PageHeight = 1600
                rasterizationOptions.BackgroundColor = Aspose.CAD.Color.Beige
                rasterizationOptions.DrawType = Aspose.CAD.FileFormats.Cad.CadDrawTypeMode.UseDrawColor
                rasterizationOptions.DrawColor = Aspose.CAD.Color.Blue

                ' Create an instance of PdfOptions
                Dim pdfOptions As New Aspose.CAD.ImageOptions.PdfOptions()
                ' Set the VectorRasterizationOptions property
                pdfOptions.VectorRasterizationOptions = rasterizationOptions

                ' Export CAD to PDF
                image.Save(MyDir & Convert.ToString("result_out.pdf"), pdfOptions)

                ' Create an instance of TiffOptions
                Dim tiffOptions As New Aspose.CAD.ImageOptions.TiffOptions(Aspose.CAD.FileFormats.Tiff.Enums.TiffExpectedFormat.[Default])

                ' Set the VectorRasterizationOptions property
                tiffOptions.VectorRasterizationOptions = rasterizationOptions

                ' Export CAD to TIFF
                image.Save(MyDir & Convert.ToString("result_out.tiff"), tiffOptions)
            End Using
            ' ExEnd:SettingBackgroundAndDrawingColors            
            Console.WriteLine(vbLf & "Background and drawing colors setup successfully.")
        End Sub
    End Class
End Namespace