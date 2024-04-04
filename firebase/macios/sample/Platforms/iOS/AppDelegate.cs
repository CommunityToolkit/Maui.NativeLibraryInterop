using Foundation;
using UIKit;
using UserNotifications;

namespace MauiFirebaseMessagingSample;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    static TaskCompletionSource<NSData>? requestToken;
    public static async Task<NSData> RequestPush()
    {
        requestToken = new();
        var permission = await UNUserNotificationCenter.Current.RequestAuthorizationAsync(UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound);
        if (!permission.Item1)
            throw new InvalidOperationException(permission.Item2.LocalizedDescription);

        UIApplication.SharedApplication.RegisterForRemoteNotifications();
        var result = await requestToken.Task;
        return result;
    }


    [Export("application:didRegisterForRemoteNotificationsWithDeviceToken:")]
    public void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
    {
        Console.WriteLine("Received native push token");
        requestToken?.TrySetResult(deviceToken);
    }


    [Export("application:didFailToRegisterForRemoteNotificationsWithError:")]
    public void FailedToRegisterForRemoteNotifications(UIApplication application, NSError error)
    {
        Console.WriteLine("Failed to receive native push token");
        requestToken?.TrySetException(new InvalidOperationException(error.LocalizedDescription));
    }


    //[Export("application:didReceiveRemoteNotification:fetchCompletionHandler:")]
    //public void DidReceiveRemoteNotification(UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
    //{
    //}
}