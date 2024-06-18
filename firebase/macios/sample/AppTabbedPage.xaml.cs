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
                page.DisplayAlert("Unable to configure Firebase app!", ex.ToString(), "OK");
            }
        }
    }
}
