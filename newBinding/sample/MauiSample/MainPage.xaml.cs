namespace MauiSample;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();

		string myName = "Community Toolkit";

#if IOS || MACCATALYST
		string labelText = NewBinding.DotnetNewBinding.GetStringWithMyString(new Foundation.NSString(myName));
#elif ANDROID
		var dotnetNewBinding = new NewBinding.DotnetNewBinding();
		string labelText = dotnetNewBinding.GetString(myName) ?? string.Empty;
#endif

		newBindingSampleLabel.Text = "Hello, " + labelText + "!";
	}

	private async void OnDocsButtonClicked(object sender, EventArgs e)
	{
		try
		{
			Uri uri = new Uri("https://learn.microsoft.com/dotnet/communitytoolkit/maui/native-library-interop/get-started");
			await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
		}
		catch (Exception ex)
		{
			throw new Exception("Browser failed to launch", ex);
		}
	}
}

