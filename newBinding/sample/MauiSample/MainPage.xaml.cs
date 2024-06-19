namespace MauiSample;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();

#if IOS || MACCATALYST
		string labelText = NewBinding.DotnetNewBinding.GetStringWithMyString(new Foundation.NSString("Rachel"));
#elif ANDROID
		var dotnetNewBinding = new NewBinding.DotnetNewBinding();
		string labelText = dotnetNewBinding.GetString("Rachel") ?? string.Empty;
#endif

		newBindingSampleLabel.Text = "Hello, " + labelText;
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

