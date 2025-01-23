namespace MauiSample;


public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

        RevenueCatBinding.RevenueCatManager.SetEntitlementsUpdatedHandler(entitlements =>
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

            RevenueCatBinding.RevenueCatManager.Initialize(true, rcApiKey.Text, rcUserId.Text);
            isInitialized = true;
        }

        if (string.IsNullOrEmpty(rcUserId.Text))
        {
            this.DisplayAlert("Error", "User ID is required", "OK");
            return;
        }

        RevenueCatBinding.RevenueCatManager.Identify(rcUserId.Text);
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

#if IOS || MACCATALYST
            var vc = (this.Window.Handler.PlatformView as UIKit.UIWindow).RootViewController;
            RevenueCatBinding.RevenueCatManager.ShowPaywall(vc, rcOfferingId.Text, true);
#endif
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    private void Update_Clicked(object? sender, EventArgs e)
    {
        RevenueCatBinding.RevenueCatManager.Update(true);
    }
}

