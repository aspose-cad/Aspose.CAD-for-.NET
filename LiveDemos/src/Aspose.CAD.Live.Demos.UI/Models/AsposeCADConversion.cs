using System.Threading.Tasks;
using System.IO;
using Aspose.CAD;
using Aspose.CAD.ImageOptions;
using System.Diagnostics;

namespace Aspose.CAD.Live.Demos.UI.Models
{
	///<Summary>
	/// AsposeCADConversion to convert cad file to other format
	///</Summary>
	public class AsposeCADConversion : CADBase
	{
		private Response ProcessTask(string fileName, string folderName, string outFileExtension, bool createZip, bool checkNumberofPages, ActionDelegate action)
		{
			Aspose.CAD.Live.Demos.UI.Models.License.SetAsposeCADLicense();
			return  Process(this.GetType().Name, fileName, folderName, outFileExtension, createZip, checkNumberofPages, this.GetType().Name, action);

		}
		///<Summary>
		/// ConvertCadToPdf method to convert cad to pdf
		///</Summary>
		public Response ConvertCadToPdf(string fileName, string folderName, string outputType)
		{
			return  ProcessTask(fileName, folderName, ".pdf", false, false, delegate (string inFilePath, string outPath, string zipOutFolder)
			{
				using (Aspose.CAD.Image image = Aspose.CAD.Image.Load(inFilePath))
				{
					Aspose.CAD.ImageOptions.PdfOptions pdfSaveOptions = new Aspose.CAD.ImageOptions.PdfOptions();

					if (outputType == "pdfa_1b")
					{
						pdfSaveOptions.CorePdfOptions.Compliance = CAD.ImageOptions.PdfCompliance.PdfA1b;
					}
					else if (outputType == "pdfa_1a")
					{
						pdfSaveOptions.CorePdfOptions.Compliance = CAD.ImageOptions.PdfCompliance.PdfA1a;
					}
					else if (outputType == "pdf_15")
					{
						pdfSaveOptions.CorePdfOptions.Compliance = CAD.ImageOptions.PdfCompliance.Pdf15;
					}

					using (Stream stream = new FileStream(outPath, FileMode.CreateNew))
					{
						image.Save(stream, pdfSaveOptions);
					}
				}
			});
		}
		///<Summary>
		/// ConvertCadToTiff method to convert cad to tiff
		///</Summary>
		public Response ConvertCadToTiff(string fileName, string folderName)
		{
			return  ProcessTask(fileName, folderName, ".tiff", false, false, delegate (string inFilePath, string outPath, string zipOutFolder)
			{
				using (Aspose.CAD.Image image = Aspose.CAD.Image.Load(inFilePath))
				{
					Aspose.CAD.ImageOptions.TiffOptions tiffSaveOptions = new Aspose.CAD.ImageOptions.TiffOptions(CAD.FileFormats.Tiff.Enums.TiffExpectedFormat.TiffJpegRgb);
					image.Save(outPath, tiffSaveOptions);
				}
			});
		}
		///<Summary>
		/// ConvertCadToImages method to convert cad to images
		///</Summary>
		public Response ConvertCadToImages(string fileName, string folderName, string outputType)
		{

			if (outputType.Equals("bmp") || outputType.Equals("jpg") || outputType.Equals("png") || outputType.Equals("gif") || outputType.Equals("svg"))
			{
				ImageOptionsBase imageOptionsBase = new BmpOptions();

				if (outputType.Equals("jpg"))
				{
					imageOptionsBase = new JpegOptions();
				}
				else if (outputType.Equals("png"))
				{
					imageOptionsBase = new PngOptions();
				}
				else if (outputType.Equals("gif"))
				{
					imageOptionsBase = new GifOptions();
				}
				else if (outputType.Equals("svg"))
				{
					imageOptionsBase = new SvgOptions();
				}
				return  ProcessTask(fileName, folderName, "." + outputType, false, false, delegate (string inFilePath, string outPath, string zipOutFolder)
				{
					using (Aspose.CAD.Image image = Aspose.CAD.Image.Load(inFilePath))
					{
						image.Save(outPath, imageOptionsBase);
					}

				});
			}
			return new Response
			{
				FileName = null,
				Status = "Output type not found",
				StatusCode = 500
			};
		}
		///<Summary>
		/// ConvertFile
		///</Summary>
		public Response ConvertFile(string fileName, string folderName, string outputType)
		{
			outputType = outputType.ToLower();

			if (outputType.StartsWith("pdf"))
			{
				return  ConvertCadToPdf(fileName, folderName, outputType);
			}
			else if (outputType.Equals("bmp") || outputType.Equals("jpg") || outputType.Equals("svg") || outputType.Equals("png") || outputType.Equals("gif"))
			{
				return  ConvertCadToImages(fileName, folderName, outputType);
			}
			else if (outputType.Equals("tiff"))
			{
				return  ConvertCadToTiff(fileName, folderName);
			}

			return new Response
			{
				FileName = null,
				Status = "Output type not found",
				StatusCode = 500
			};
		}

	}
}
