using Firebase;

namespace MauiFirebaseMessagingSample;

public partial class FIRAuthPage : ContentPage
{
    string userEmail = "tester@example.com";
    string userPw = "abc123";

    public FIRAuthPage()
    {
        InitializeComponent();
    }

    void OnEmailEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        userEmail = EmailEntry.Text;
    }

    void OnPwEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        userPw = PwEntry.Text;
    }

    async void OnCreateUserClicked (object sender, EventArgs e)
    {
        try
        {
            AppTabbedPage.ConfigureFirebase(this);

            var authResult = await MauiFIRAuth.CreateUserAsync(userEmail, userPw);
            await DisplayAlert($"Created user: {authResult?.User?.Email}", "", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Unable to create user!", ex.ToString(), "OK");
        }
    }
}
