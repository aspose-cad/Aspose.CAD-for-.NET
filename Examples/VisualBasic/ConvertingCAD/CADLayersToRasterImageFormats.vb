Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports Aspose.CAD
Namespace ConvertingCAD
    Public Class CADLayersToRasterImageFormats
        Public Shared Sub Run()
            ' ExStart:CADLayersToRasterImageFormats
            ' The path to the documents directory.
            Dim MyDir As String = RunExamples.GetDataDir_ConvertingCAD()
            Dim sourceFilePath As String = MyDir & Convert.ToString("conic_pyramid.dxf")
            ' Load a CAD drawing in an instance of Image
            Using image = Aspose.CAD.Image.Load(sourceFilePath)
                ' Create an instance of CadRasterizationOptions
                Dim rasterizationOptions = New Aspose.CAD.ImageOptions.CadRasterizationOptions()
                ' Set image width & height
                rasterizationOptions.PageWidth = 500
                rasterizationOptions.PageHeight = 500

                ' Set the drawing to render at the center of image
                rasterizationOptions.CenterDrawing = True

                ' Add the layer name to the CadRasterizationOptions's layer list
                rasterizationOptions.Layers.Add("0")
                ' Most of the CAD drawings have a layer by name 0, you may specify any name
                ' Create an instance of JpegOptions (or any ImageOptions for raster formats)
                Dim options = New Aspose.CAD.ImageOptions.JpegOptions()
                ' Set VectorRasterizationOptions property to the instance of CadRasterizationOptions
                options.VectorRasterizationOptions = rasterizationOptions
                ' Export each layer to Jpeg format
                MyDir = MyDir & Convert.ToString("CADLayersToRasterImageFormats_out.jpg")
                image.Save(MyDir, options)
            End Using
            ' ExEnd:CADLayersToRasterImageFormats            
            Console.WriteLine(Convert.ToString(vbLf & "CAD layers converted successfully to raster image format." & vbLf & "File saved at ") & MyDir)
        End Sub
        Public Shared Sub ConvertAllLayersToRasterImageFormats()
            ' ExStart:ConvertAllLayersToRasterImageFormats
            ' The path to the documents directory.
            Dim MyDir As String = RunExamples.GetDataDir_ConvertingCAD()
            Dim sourceFilePath As String = MyDir & Convert.ToString("conic_pyramid.dxf")
            ' Load a CAD drawing in an instance of CadImage
            Using image = DirectCast(Aspose.CAD.Image.Load(sourceFilePath), Aspose.CAD.FileFormats.Cad.CadImage)
                ' Create an instance of CadRasterizationOptions
                Dim rasterizationOptions = New Aspose.CAD.ImageOptions.CadRasterizationOptions()
                ' Set image width & height
                rasterizationOptions.PageWidth = 500
                rasterizationOptions.PageHeight = 500
                ' Set the drawing to render at the center of image
                rasterizationOptions.CenterDrawing = True

                ' Get the layers in an instance of CadLayersDictionary
                Dim layers = image.Layers
                ' Iterate over the layers
                For Each layer In layers.ValuesTyped
                    ' Display layer name for tracking
                    Console.WriteLine("Start with " + layer.Name)

                    ' Add the layer name to the CadRasterizationOptions's layer list
                    rasterizationOptions.Layers.Add(layer.Name)

                    ' Create an instance of JpegOptions (or any ImageOptions for raster formats)
                    Dim options = New Aspose.CAD.ImageOptions.JpegOptions()
                    ' Set VectorRasterizationOptions property to the instance of CadRasterizationOptions
                    options.VectorRasterizationOptions = rasterizationOptions
                    ' Export each layer to Jpeg format
                    image.Save(layer.Name + "_out.jpg", options)
                Next
            End Using
            ' ExEnd:ConvertAllLayersToRasterImageFormats
            Console.WriteLine(vbLf & "CAD all layers converted successfully to raster image format.")
        End Sub

    End Class
End Namespace

