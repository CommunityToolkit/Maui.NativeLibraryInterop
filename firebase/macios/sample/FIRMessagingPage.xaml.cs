using Firebase;

namespace MauiFirebaseMessagingSample;

public partial class FIRMessagingPage : ContentPage
{
    public FIRMessagingPage()
    {
        InitializeComponent();
    }

    void SetText()
    {
        lblFcmToken.Text = MauiFIRMessaging.FcmToken ?? "No app token available";
        btnFcmRegister.Text = (MauiFIRMessaging.FcmToken == null ? "Register" : "UnRegister") + " for Firebase Messaging";
    }

    async void OnRegisterClicked (object sender, EventArgs e)
    {
        try
        {
            AppTabbedPage.ConfigureFirebase(this);

            if (MauiFIRMessaging.FcmToken == null)
            {
                var native = await AppDelegate.RequestPush();
                var fcmToken = await MauiFIRMessaging.RegisterAsync(native);
                lblFcmToken.Text = fcmToken;
            }
            else
            {
                await MauiFIRMessaging.UnregisterAsync();
            }
            SetText();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Unable to fetch app token!", ex.ToString(), "OK");
        }
    }
}
