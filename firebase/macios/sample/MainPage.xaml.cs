using Firebase;

namespace MauiFirebaseMessagingSample;


public partial class MainPage : ContentPage
{
    bool configured = false;

    public MainPage()
    {
        InitializeComponent();
    }


    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (!configured)
        {
            try
            {
                configured = true;
                FirebaseApplication.AutoConfigure();
                FirebaseMessaging.EnableAutoInit(true);
            }
            catch (Exception ex)
            {
                await this.DisplayAlert("Fail", ex.ToString(), "OK");
            }
        }
        this.SetText();
    }


    void SetText()
    {
        lblFcmToken.Text = FirebaseMessaging.FcmToken ?? "No FCM Token";
        btnRegister.Text = (FirebaseMessaging.FcmToken == null ? "Register" : "UnRegister") + " for Firebase Messaging";
    }

    async void OnClicked(object sender, EventArgs e)
    {
        try
        {
            if (FirebaseMessaging.FcmToken == null)
            {
                var native = await AppDelegate.RequestPush();

                //FirebaseMessaging.Configure("no", "no");
                var fcmToken = await FirebaseMessaging.RegisterAsync(native);
                lblFcmToken.Text = fcmToken;
            }
            else
            {
                await FirebaseMessaging.UnRegisterAsync();
            }
            SetText();
        }
        catch (Exception ex)
        {
            await this.DisplayAlert("Fail", ex.ToString(), "OK");
        }
    }
}