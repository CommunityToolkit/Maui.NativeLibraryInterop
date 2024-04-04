namespace GoogleCast.Sample;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();	
	}

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

    GoogleCast.GoogleCastManager googleCastManager;

	private void OnCounterClicked(object sender, EventArgs e)
	{
		googleCastManager.LoadMedia("https://www.sample-videos.com/video123/mp4/720/big_buck_bunny_720p_1mb.mp4",
			"video/mp4",
			"Big Buck Bunny",
			"Big Buck Bunny (open-source movie)",
			"https://peach.blender.org/wp-content/uploads/title_anouncement.jpg",
			100,
			100);
	}
}

