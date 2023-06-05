using Aspose.CAD.ImageOptions;

namespace CadMauiApp;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    private void OnCleanClicked(object sender, EventArgs e)
    {

        Base64DecodedImage.Source = "dotnet_bot.png";

    }
    private async void OnSelectFileClicked(object sender, EventArgs e)
    {
        var result = await FilePicker.PickAsync(new PickOptions()
        {
            PickerTitle = "any"
        });

        if (result == null)
        {
            return;
        }

        var stream = await result.OpenReadAsync();

        var img = Aspose.CAD.Image.Load(stream);

        var ms = new MemoryStream();

        await img.SaveAsync(ms, new PngOptions());

        Base64DecodedImage.Source = ImageSource.FromStream(() => ms);
    }
}

