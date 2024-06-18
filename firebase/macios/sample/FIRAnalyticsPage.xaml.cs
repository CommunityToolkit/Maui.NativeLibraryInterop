using Firebase;

namespace MauiFirebaseMessagingSample;

public partial class FIRAnalyticsPage : ContentPage
{
    public FIRAnalyticsPage()
    {
        InitializeComponent();
    }

    async void OnAnalyticsClicked (object sender, EventArgs e)
    {
        try
        {
            AppTabbedPage.ConfigureFirebase(this);

            MauiFIRAnalytics.LogEvent("OnAnalyticsClicked", new Foundation.NSDictionary("param1", "value1"));
            var appInstanceId = await MauiFIRAnalytics.GetAppInstanceIdAsync();
            await DisplayAlert($"Logged event to app ID {appInstanceId}", "", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Unable to log event!", ex.ToString(), "OK");
        }
    }
}
