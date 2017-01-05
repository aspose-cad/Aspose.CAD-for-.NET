
Namespace Exporting_DGN

    Public Class ExportDGNAsPartofDWG

        Public Shared Sub Run()
            
            Try
                'ExStart: ExportDGNAsPartofDWG

                ' Input and Output file paths
                Dim fileName As String = "BlockRefDgn.dwg"
                Dim outPath As String = fileName & Convert.ToString(".pdf")

                ' Create an instance of PdfOptions class as we are exporting the DWG file to PDF format
                Dim exportOptions As New Aspose.CAD.ImageOptions.PdfOptions()

                ' Load any existing DWG file as image and convert it to CadImage type
                Using cadImage As Aspose.CAD.FileFormats.Cad.CadImage = DirectCast(Image.Load(fileName), Aspose.CAD.FileFormats.Cad.CadImage)
                    ' Go through each entity inside the DWG file
                    For Each baseEntity As Aspose.CAD.FileFormats.Cad.CadObjects.CadBaseEntity In cadImage.Entities
                        ' Check if entity is an image definition
                        If baseEntity.TypeName = Aspose.CAD.FileFormats.Cad.CadConsts.CadEntityTypeName.DGNUNDERLAY Then
                            Dim dgnFile As Aspose.CAD.FileFormats.Cad.CadObjects.CadDgnUnderlay = DirectCast(baseEntity, Aspose.CAD.FileFormats.Cad.CadObjects.CadDgnUnderlay)

                            ' Get external reference to object
                            System.Console.WriteLine(dgnFile.UnderlayPath)
                        End If
                    Next

                    ' Define settings for CadRasterizationOptions object
		exportOptions.VectorRasterizationOptions = New Aspose.CAD.ImageOptions.CadRasterizationOptions() With { _
			Key .PageWidth = 1600, _
			Key .PageHeight = 1600, _
			Key .CenterDrawing = True, _
			Key .Layouts = New String() {"Model"}, _
			Key .ScaleMethod = Aspose.CAD.FileFormats.Cad.ScaleType.None, _
			Key .BackgroundColor = Color.Black, _
			Key .DrawType = Aspose.CAD.FileFormats.Cad.CadDrawTypeMode.UseObjectColor _
		}

                    ' Export the DWG to PDF by calling Save method
                    cadImage.Save(outPath, exportOptions)
                    'ExEnd:ExportDGNAsPartofDWG

                End Using
            Catch ex As Exception
                Console.WriteLine("Please use valid input file." + ex.Message)
            End Try


        End Sub

    End Class

End Namespace
