namespace MauiSample;


public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

        RevenueCatBinding.RevenueCatManager.SetEntitlementsUpdatedHandler(entitlements =>
        {
            Console.WriteLine("Entitlements: " + string.Join(", ", entitlements));
        });

        RevenueCatBinding.RevenueCatManager.Initialize(true, "<CLIENT-ID>", "<USER-ID>");
        // Call the native binding, which will append a platform specific string to the input string


        //newBindingSampleLabel.Text = "Hello, " + labelText;
    }

	async void OnDocsButtonClicked(object sender, EventArgs e)
    {
        #if IOS || MACCATALYST
        var vc = (this.Window.Handler.PlatformView as UIKit.UIWindow).RootViewController;
        RevenueCatBinding.RevenueCatManager.ShowPaywall(vc);
        #endif
        //RevenueCatBinding.RevenueCatManager.Update();
    }
}

