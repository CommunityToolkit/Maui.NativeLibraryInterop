# Firebase Slim Binding
This folder contains a slim binding for the Firebase SDK which demonstrates simple [Analytics][0], [Auth][1], and [Messaging][2] usage.

### Build and Run
```shell
    dotnet build sample -t:Run -f net8.0-ios
```

### Configure
The included sample requires some modification to fully function. You will need to log in to
a Firebase developer account and configure an app to interface with this sample.
For more details, reference the [Get Started (iOS)][3] page.

1. Download your `GoogleService-Info.plist` and replace `Platforms/iOS/GoogleService-Info.plist` with it.
2. Change the `<ApplicationId>` value in `Sample.csproj` to your Firebase iOS app identifier.

To deploy this sample to a physical iOS device you will need to open `native/MauiFirebase.xcodeproj`
in Xcode and configure the signing team/settings in Targets -> MauiFirebase -> Signing & Capabilities.
A provisioning profile that supports Apple Notification Service (APNs) must also be configured and installed.

[0]: https://firebase.google.com/docs/analytics/get-started?platform=ios
[1]: https://firebase.google.com/docs/auth/ios/start
[2]: https://firebase.google.com/docs/cloud-messaging/ios/client
[3]: https://firebase.google.com/docs/ios/setup
