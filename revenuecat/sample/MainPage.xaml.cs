namespace MauiSample;


public partial class MainPage : ContentPage
{
    readonly IRevenueCatManager revenueCatManager;

	public MainPage(IRevenueCatManager revenueCatManager)
	{
		InitializeComponent();

        this.revenueCatManager = revenueCatManager;

        this.revenueCatManager.SetEntitlementsUpdatedHandler(entitlements =>
        {
            Dispatcher.Dispatch(() =>
            {
                txtEntitlements.Text = "Entitlements: "
                                        + string.Join(", ", entitlements)
                                        + Environment.NewLine
                                        + "Refreshed at: " + DateTime.Now.ToLongDateString() + ", " + DateTime.Now.ToLongTimeString();
            });
        });
    }


    private bool isInitialized = false;

    private void Identify_Clicked(object? sender, EventArgs e)
    {
        if (!isInitialized)
        {
            if (string.IsNullOrEmpty(rcApiKey.Text))
            {
                this.DisplayAlert("Error", "API Key is required", "OK");
                return;
            }

            string? appStore = null;
            object platformContext = null;
            #if ANDROID
            appStore = "google";
            platformContext = this.Window.Handler.MauiContext.Context;
            #endif

            revenueCatManager.Initialize(platformContext, true, appStore, rcApiKey.Text, rcUserId.Text);
            isInitialized = true;
        }

        if (string.IsNullOrEmpty(rcUserId.Text))
        {
            this.DisplayAlert("Error", "User ID is required", "OK");
            return;
        }

        revenueCatManager.Identify(rcUserId.Text);
    }


    private void Purchase_Clicked(object? sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(rcOfferingId.Text))
        {
            this.DisplayAlert("Error", "Offering Identifier is required", "OK");
            return;
        }

        try
        {

            object platformView = null;
            #if ANDROID
            platformView = (this.Window.Handler.PlatformView as AndroidX.Activity.ComponentActivity);
            #elif MACCATALYST || IOS
            platformView = (this.Window.Handler.PlatformView as UIKit.UIWindow).RootViewController;
            #endif

            revenueCatManager.ShowPaywall(platformView, rcOfferingId.Text, true);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    private void Update_Clicked(object? sender, EventArgs e)
    {
        revenueCatManager.Update(true);
    }
}

