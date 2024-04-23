# Firebase Slim Binding
This folder contains a slim binding for the Firebase SDK which demonstrates simple [Analytics][0] and [Messaging][1] usage.

### Build and Run
```shell
    dotnet build sample -t:Run -f net8.0-ios
```

### Configure
The included sample requires some modification to fully function. You will need to log in to
a Firebase developer account and configure an app to interface with this sample.
For more details, reference the [Get Started (iOS)][2] page.

1. Download your `GoogleService-Info.plist` and replace `Platforms/iOS/GoogleService-Info.plist` with it.
2. Change the `<ApplicationId>` value in `Sample.csproj` to your Firebase iOS app identifier.


[0]: https://firebase.google.com/docs/analytics/get-started?platform=ios
[1]: https://firebase.google.com/docs/cloud-messaging/ios/client
[2]: https://firebase.google.com/docs/ios/setup
