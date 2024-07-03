# Google Cast Slim Binding
This folder contains a slim binding for the Google Cast SDK.

### Build and Run
```shell
    dotnet build sample -t:Run
```

### Configure
To deploy this sample to a physical iOS device you will need to open `macios/native/MauiGoogleCast.xcodeproj`
in Xcode and configure the signing team/settings in Targets -> MauiGoogleCast -> Signing & Capabilities.

For more details, reference the [Get Started][0] page.

[0]: https://developers.google.com/cast
