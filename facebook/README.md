# Facebook Slim Binding
This folder contains a slim binding for the Facebook SDK which demonstrates simple [App Events][0] usage.

### Build and Run
```shell
    dotnet build sample -t:Run -f net8.0-android
    dotnet build sample -t:Run -f net8.0-ios
```

### Configure
The included sample requires some modification to fully function. You will need to log in to
a Facebook developer account and configure an app to recieve App Events from this sample.
For more details, reference the [Get Started (Android)][1] or [Get Started (iOS)][2] pages.

#### Android
The following app identifiers should be updated in the `strings.xml` file of the sample application:

1. Replace the `YOUR_APP_ID` string in the `facebook/sample/Platforms/Android/Resources/values/strings.xml` file with your Facebook App ID.
2. Replace the `YOUR_CLIENT_TOKEN` string in the `facebook/sample/Platforms/Android/Resources/values/strings.xml` file with your Facebook App Client Token.

#### iOS
The following app identifiers should be updated in the `Info.plist` file of the sample application:

1. Replace the `YOUR_APP_ID` string in the `facebook/sample/Platforms/iOS/Info.plist` file with your Facebook App ID.
2. Replace the `YOUR_CLIENT_TOKEN` string in the `facebook/sample/Platforms/iOS/Info.plist` file with your Facebook App Client Token.


[0]: https://developers.facebook.com/docs/app-events/
[1]: https://developers.facebook.com/docs/app-events/getting-started-app-events-android
[2]: https://developers.facebook.com/docs/app-events/getting-started-app-events-ios
