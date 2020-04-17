using System;
using System.IO;
using System.Web.Http;
using Aspose.CAD.Live.Demos.UI.Models;
using System.Threading.Tasks;
using Aspose.CAD.Live.Demos.UI.Config;
using System.IO.Compression;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Drawing.Imaging;
using System.Drawing;
using System.Net;

using System.Linq;
using Aspose.CAD.Live.Demos.UI.Helpers;


namespace Aspose.CAD.Live.Demos.UI.Controllers
{
	///<Summary>
	/// AsposeViewerController class to get document page
	///</Summary>
	public class AsposeViewerController : ApiController
	{
		
		///<Summary>
		/// GetDocumentPage method to get document page
		///</Summary>
		[HttpGet]		
		public HttpResponseMessage GetDocumentPage( string file, string folderName,  int currentPage)
		{
			string outfileName = Path.GetFileNameWithoutExtension(file) + "_{0}";
			string outPath = Config.Configuration.OutputDirectory + folderName + "/" + outfileName;

			currentPage = currentPage - 1;

			string imagePath = string.Format(outPath, currentPage) + ".jpeg";
			Directory.CreateDirectory(Config.Configuration.OutputDirectory + folderName);

			if (System.IO.File.Exists(imagePath))
			{
				return GetImageFromPath(imagePath);
			}
			return null;

			
		}
		
		///<Summary>
		/// DocumentPages method to get document pages
		///</Summary>
		[HttpGet]		
		public List<string> DocumentPages( string file, string folderName, int currentPage)
		{			
			List<string> output;			
			
			
			try
			{
				output = GetDocumentPages( file, folderName, currentPage);

				
			}
			catch (Exception ex)
			{
				
				throw ex;
			}

			return output;
		}

		private List<string> GetDocumentPages(string file, string folderName,  int currentPage)
		{
			List<string> lstOutput = new List<string>();
			string outfileName = "page_{0}";
			string outPath =  Config.Configuration.OutputDirectory + folderName + "/" + outfileName;

			currentPage = currentPage - 1;
			Directory.CreateDirectory(Config.Configuration.OutputDirectory + folderName);
			string imagePath = string.Format(outPath, currentPage) + ".jpeg";
						
			if (System.IO.File.Exists(imagePath) && currentPage > 0)
			{
				lstOutput.Add(imagePath);
				return lstOutput;
			}

			int i = currentPage;

			var filename = System.IO.File.Exists(Config.Configuration.WorkingDirectory + folderName + "/" + file)
				? Config.Configuration.WorkingDirectory + folderName + "/" + file
				: Config.Configuration.OutputDirectory + folderName + "/" + file;
			
			using (FilePathLock.Use(filename))
			{
				
				
					try
					{
					Aspose.CAD.Live.Demos.UI.Models.License.SetAsposeCADLicense();

					
						// Load an existing CAD document
						Aspose.CAD.FileFormats.Cad.CadImage image = (Aspose.CAD.FileFormats.Cad.CadImage)Aspose.CAD.Image.Load(filename);

						// Create an instance of CadRasterizationOptions
						Aspose.CAD.ImageOptions.CadRasterizationOptions rasterizationOptions = new Aspose.CAD.ImageOptions.CadRasterizationOptions();

						// Set image width & height
						rasterizationOptions.PageWidth = 1024;
						rasterizationOptions.PageHeight = 1024;
						// Set the drawing to render at the center of image
						//rasterizationOptions.CenterDrawing = true;
						//rasterizationOptions.TypeOfEntities = Aspose.CAD.ImageOptions.TypeOfEntities.Entities3D;

						rasterizationOptions.AutomaticLayoutsScaling = true;
						rasterizationOptions.NoScaling = false;
						rasterizationOptions.ContentAsBitmap = true;

						// Set Graphics options
						rasterizationOptions.GraphicsOptions.SmoothingMode = Aspose.CAD.SmoothingMode.HighQuality;
						rasterizationOptions.GraphicsOptions.TextRenderingHint = Aspose.CAD.TextRenderingHint.AntiAliasGridFit;
						rasterizationOptions.GraphicsOptions.InterpolationMode = Aspose.CAD.InterpolationMode.HighQualityBicubic;


						// Get the layers in an instance of CadLayersDictionary
						var layersList = image.Layers;
						lstOutput.Add(layersList.Count.ToString());
						i = 0;
						// Iterate over the layers
						foreach (var layerName in layersList.GetLayersNames())
						{
							if (i == currentPage)
							{
								// Add the layer name to the CadRasterizationOptions's layer list
								rasterizationOptions.Layers[i] = layerName;

								// Create an instance of PngOptions for the resultant image
								Aspose.CAD.ImageOptions.JpegOptions options = new Aspose.CAD.ImageOptions.JpegOptions();

								// Set rasterization options
								options.VectorRasterizationOptions = rasterizationOptions;
								image.Save(imagePath, options);
								lstOutput.Add(imagePath);
								image.Dispose();
								break;
							}
							i++;
						}
						if (!image.Disposed)
							image.Dispose();
					
				}
				catch (Exception ex)
				{
					throw ex;
				}
				return lstOutput;

			}
		}
		///<Summary>
		/// DownloadDocument method to download document
		///</Summary>
		[HttpGet]
		
		public HttpResponseMessage DownloadDocument(string file, string folderName, bool isImage)
		{			
			string outfileName = Path.GetFileNameWithoutExtension(file) + "_Out.zip";
			string outPath;

			if (!isImage)
			{
				if (System.IO.File.Exists(Config.Configuration.WorkingDirectory + folderName + "/" + file))
					outPath = Config.Configuration.WorkingDirectory + folderName + "/" + file;
				else
					outPath = Config.Configuration.OutputDirectory + folderName + "/" + file;
			}
			else
			{
				outPath = Config.Configuration.OutputDirectory + outfileName;
			}

			using (FilePathLock.Use(outPath))
			{
				if (isImage)
				{
					if (System.IO.File.Exists(outPath))
						System.IO.File.Delete(outPath);

					List<string> lst = GetDocumentPages(file, folderName,  1);

					if (lst.Count > 1)
					{
						int tmpPageCount = int.Parse(lst[0]);
						for (int i = 2; i <= tmpPageCount; i++)
						{
							GetDocumentPages( file, folderName,  i);
						}
					}

					ZipFile.CreateFromDirectory(Config.Configuration.OutputDirectory + folderName + "/", outPath);
				}


				if ((!System.IO.File.Exists(outPath)) || !Path.GetFullPath(outPath).StartsWith(Path.GetFullPath( System.Web.HttpContext.Current.Server.MapPath("~/Assets/"))))
				{
					var exception = new HttpResponseException(HttpStatusCode.NotFound);
					
					throw exception;
				}

				try
				{
					using (var fileStream = new FileStream(outPath, FileMode.Open, FileAccess.Read))
					{
						
						using (var ms = new MemoryStream())
						{
							fileStream.CopyTo(ms);
							var result = new HttpResponseMessage(HttpStatusCode.OK)
							{
								Content = new ByteArrayContent(ms.ToArray())
							};
							result.Content.Headers.ContentDisposition =
								new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
								{
									FileName = (isImage ? outfileName : file)
								};
							result.Content.Headers.ContentType =
								new MediaTypeHeaderValue("application/octet-stream");

							return result;
						}
					}

				}
				catch (Exception x)
				{

					Console.WriteLine(x.Message);
				}
			}

			return null;
		}

		///<Summary>
		/// PageImage method to get page image
		///</Summary>
		[HttpGet]
		
		public HttpResponseMessage PageImage(string imagePath)
		{
			return GetImageFromPath(imagePath);
		}

		private HttpResponseMessage GetImageFromPath(string imagePath)
		{
			HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
			FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
			System.Drawing.Image image = System.Drawing.Image.FromStream(fileStream);
			MemoryStream memoryStream = new MemoryStream();


			image.Save(memoryStream, ImageFormat.Jpeg);
			result.Content = new ByteArrayContent(memoryStream.ToArray());
			result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
			fileStream.Close();

			return result;
		}
	}
}
