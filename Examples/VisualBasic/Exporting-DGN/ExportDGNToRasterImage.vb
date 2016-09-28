Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports Aspose.CAD

Namespace Exporting_DGN
    Public Class ExportDGNToRasterImage
        Public Shared Sub Run()
            Try
                'ExStart:ExportDGNToRasterImage
                ' The path to the documents directory.
                Dim MyDir As String = RunExamples.GetDataDir_ExportingDGN()
                Dim sourceFilePath As String = MyDir & Convert.ToString("Nikon_D90_Camera.dgn")
                ' Load an existing DGN file as CadImage.
                Using cadImage As Aspose.CAD.FileFormats.Cad.CadImage = DirectCast(Aspose.CAD.Image.Load(sourceFilePath), Aspose.CAD.FileFormats.Cad.CadImage)
                    ' Create an object of DgnRasterizationOptions class and define/set different properties
                    Dim rasterizationOptions As New Aspose.CAD.ImageOptions.DgnRasterizationOptions()
                    rasterizationOptions.PageWidth = 600
                    rasterizationOptions.PageHeight = 300
                    rasterizationOptions.CenterDrawing = True
                    rasterizationOptions.ScaleMethod = Aspose.CAD.FileFormats.Cad.ScaleType.None
                    rasterizationOptions.AutomaticLayoutsScaling = True

                    ' Create an object of JpegOptions class as we are converting the DGN to jpeg and assign DgnRasterizationOptions object to it.
                    Dim options As Aspose.CAD.ImageOptionsBase = New Aspose.CAD.ImageOptions.JpegOptions()
                    options.VectorRasterizationOptions = rasterizationOptions

                    ' Call the save method of the CadImage class object.
                    cadImage.Save(MyDir & Convert.ToString("ExportDGNToRasterImage_out_.pdf"), options)
                End Using
                'ExEnd:ExportDGNToRasterImage            
                Console.WriteLine(Convert.ToString(vbLf & "The DGN file exported successfully to raster image." & vbLf & "File saved at ") & MyDir)
            Catch ex As Exception
                Console.WriteLine("Please use valid input file." + ex.Message)
            End Try
        End Sub
    End Class
End Namespace

