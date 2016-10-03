Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports Aspose.CAD

Namespace DWG_Drawings
    Public Class SearchText
        Public Shared Sub Run()
            'ExStart:SearchText
            ' The path to the documents directory.
            Dim MyDir As String = RunExamples.GetDataDir_DWGDrawings()
            Dim sourceFilePath As String = MyDir & Convert.ToString("sample.dwg")
            ' Load an existing DWG file as CadImage.
            Using cadImage As Aspose.CAD.FileFormats.Cad.CadImage = DirectCast(Aspose.CAD.Image.Load(sourceFilePath), Aspose.CAD.FileFormats.Cad.CadImage)
                ' Search for text in the file 
                For Each entity As Aspose.CAD.FileFormats.Cad.CadObjects.CadBaseEntity In cadImage.Entities
                    ' Please, note: we iterate through CadText entities here, but some other entities may contain text also, e.g. CadMText and others
                    If entity.[GetType]() = GetType(Aspose.CAD.FileFormats.Cad.CadObjects.CadText) Then
                        Dim text As Aspose.CAD.FileFormats.Cad.CadObjects.CadText = DirectCast(entity, Aspose.CAD.FileFormats.Cad.CadObjects.CadText)
                        System.Console.WriteLine(text.DefaultValue)
                    End If
                Next

                ' Search for text on specific layout get all layout names and link each layout with corresponding block with entities
                Dim layouts As Aspose.CAD.FileFormats.Cad.CadLayoutDictionary = cadImage.Layouts
                Dim layoutNames As String() = New String(layouts.Count - 1) {}
                Dim i As Integer = 0
                For Each layout As Aspose.CAD.FileFormats.Cad.CadObjects.CadLayout In layouts.Values
                    layoutNames(i) = layout.LayoutName
                    System.Console.WriteLine("Layout " + layout.LayoutName + " is found")

                    ' Find block, applicable for DWG only
                    Dim blockTableObjectReference As Aspose.CAD.FileFormats.Cad.CadTables.CadBlockTableObject = Nothing
                    For Each tableObject As Aspose.CAD.FileFormats.Cad.CadTables.CadBlockTableObject In cadImage.BlocksTables
                        If String.Equals(tableObject.HardPointerToLayout, layout.ObjectHandle) Then
                            blockTableObjectReference = tableObject
                            Exit For
                        End If
                    Next

                    ' Collection cadBlockEntity.Entities contains information about all entities on specific layout if this collection has no elements it means layout is a copy of Model layout and contains the same entities
                    Dim cadBlockEntity As Aspose.CAD.FileFormats.Cad.CadObjects.CadBlockEntity = cadImage.BlockEntities(blockTableObjectReference.BlockName)
                Next

                ' Export to pdf
                Dim rasterizationOptions As New Aspose.CAD.ImageOptions.CadRasterizationOptions()
                rasterizationOptions.PageWidth = 1600
                rasterizationOptions.PageHeight = 1600
                rasterizationOptions.AutomaticLayoutsScaling = True
                rasterizationOptions.CenterDrawing = True

                ' Please, note: if cadBlockEntity collection mentioned above (for dwg) for selected layout or entitiesOnLayouts collection by layout's BlockTableRecordHandle (for dxf) is empty - export result file will be empty and you should draw Model layout instead
                rasterizationOptions.Layouts = New String() {"Layout1"}

                Dim pdfOptions As New Aspose.CAD.ImageOptions.PdfOptions()

                pdfOptions.VectorRasterizationOptions = rasterizationOptions
                cadImage.Save(MyDir & Convert.ToString("SearchText_out_.pdf"), pdfOptions)
            End Using
            'ExEnd:SearchText  
        End Sub
    End Class
End Namespace
