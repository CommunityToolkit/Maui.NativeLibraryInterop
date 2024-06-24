using Firebase;

namespace MauiFirebaseMessagingSample;

public partial class AppTabbedPage : TabbedPage
{
    static bool FirebaseConfigured { get; set; } = false;

    public AppTabbedPage()
    {
        InitializeComponent();
    }

    public static void ConfigureFirebase(ContentPage page)
    {
        if (!FirebaseConfigured)
        {
            try
            {
                MauiFIRApp.AutoConfigure();
                FirebaseConfigured = true;
            }
            catch (Exception ex)
            {
                page.DisplayAlert("Please configure your Firebase app.", "Possible missing or invalid GOOGLE_APP_ID in GoogleService-Info.plist.", "OK");
            }
        }
    }
}
