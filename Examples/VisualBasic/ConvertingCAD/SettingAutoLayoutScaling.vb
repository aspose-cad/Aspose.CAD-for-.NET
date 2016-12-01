Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports Aspose.CAD
Namespace ConvertingCAD
    Public Class SettingAutoLayoutScaling
        Public Shared Sub Run()
            ' ExStart:SettingAutoLayoutScaling
            ' The path to the documents directory.
            Dim MyDir As String = RunExamples.GetDataDir_ConvertingCAD()
            Dim sourceFilePath As String = MyDir & Convert.ToString("conic_pyramid.dxf")
            Using image As Aspose.CAD.Image = Aspose.CAD.Image.Load(sourceFilePath)
                ' Create an instance of CadRasterizationOptions and set its various properties
                Dim rasterizationOptions As New Aspose.CAD.ImageOptions.CadRasterizationOptions()
                rasterizationOptions.PageWidth = 1600
                rasterizationOptions.PageHeight = 1600

                ' Set Auto Layout Scaling
                rasterizationOptions.AutomaticLayoutsScaling = True

                ' Create an instance of PdfOptions
                Dim pdfOptions As New Aspose.CAD.ImageOptions.PdfOptions()

                ' Set the VectorRasterizationOptions property
                pdfOptions.VectorRasterizationOptions = rasterizationOptions

                MyDir = MyDir & Convert.ToString("result_out.pdf")
                ' Export the CAD to PDF
                image.Save(MyDir, pdfOptions)
            End Using
            ' ExEnd:SettingAutoLayoutScaling            
            Console.WriteLine(Convert.ToString(vbLf & "Auto layout scaling setup successfully." & vbLf & "File saved at ") & MyDir)
        End Sub
    End Class
End Namespace
