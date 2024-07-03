namespace GoogleCast.Sample;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	GoogleCast.GoogleCastManager? googleCastManager;

	protected override async void OnAppearing()
	{
		base.OnAppearing();

		if (googleCastManager is null)
		{
			googleCastManager = new GoogleCast.GoogleCastManager();
			googleCastManager.Configure();

			#if IOS
			await Permissions.RequestAsync<Permissions.NetworkState>();
			#endif
		}
	}

	void OnLoadMediaBtnClicked(object sender, EventArgs e)
	{
		if (!googleCastManager?.IsCastSessionActive ?? true)
		{
			DisplayAlert("Error", "Please tap the cast button to begin casting.", "OK");
			return;
		}

		googleCastManager?.LoadMedia(
				"https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4",
				"video/mp4",
				"Big Buck Bunny (2008)",
				"Big Buck Bunny tells the story of a giant rabbit with a heart bigger than himself.",
				"https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/images/BigBuckBunny.jpg",
				480,
				360);
	}
}
