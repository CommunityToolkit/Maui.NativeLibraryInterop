namespace Facebook.Sample;

public partial class MainPage : ContentPage
{
    bool facebookSdkIntialized = false;

    public MainPage()
    {
        InitializeComponent();
    }

    async Task InitializeFacebookSdk()
    {
        try
        {
#if ANDROID
            Facebook.FacebookSdk.InitializeSDK(Microsoft.Maui.ApplicationModel.Platform.CurrentActivity, Java.Lang.Boolean.True);
#elif IOS
            string appId = Foundation.NSBundle.MainBundle.ObjectForInfoDictionary("FacebookAppID").ToString();
            string clientToken = Foundation.NSBundle.MainBundle.ObjectForInfoDictionary("FacebookClientToken").ToString();
            Facebook.FacebookSdk.SetupWithAppId(appId, clientToken);
#endif
            facebookSdkIntialized = true;
        }
        catch (Exception ex)
        {
           await DisplayAlert("Unable to initialize Facebook SDK!", ex.ToString(), "OK");
        }
    }

    async void OnAppEventClicked(object sender, EventArgs e)
    {
        if (!facebookSdkIntialized)
        {
            await InitializeFacebookSdk();
        }

        try
        {
#if ANDROID
            Facebook.FacebookSdk.LogEvent("OnAppEventClicked");
#elif IOS
            Facebook.FacebookSdk.LogEventWithEventName("OnAppEventClicked");
#endif
            await DisplayAlert("Attempted to send App Event", "", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Failed to send App Event!", ex.ToString(), "OK");
        }
    }
}
