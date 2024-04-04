using Foundation;
using ObjCRuntime;
using UIKit;

namespace Facebook
{
    // @interface FacebookSdk : NSObject
    [BaseType(typeof(NSObject))]
    interface FacebookSdk
    {
        // +(BOOL)finishedLaunchingWithApplication:(UIApplication * _Nonnull)application didFinishLaunchingWithOptions:(NSObject * _Nullable)launchOptions __attribute__((warn_unused_result("")));
        [Static]
        [Export("finishedLaunchingWithApplication:didFinishLaunchingWithOptions:")]
        bool FinishedLaunchingWithApplication(UIApplication application, [NullAllowed] NSObject launchOptions);

        // +(BOOL)finishedLaunchingWithApplication:(UIApplication * _Nonnull)application url:(NSURL * _Nonnull)url sourceApplication:(NSString * _Nullable)sourceApplication annotation:(NSObject * _Nullable)annotation __attribute__((warn_unused_result("")));
        [Static]
        [Export("finishedLaunchingWithApplication:url:sourceApplication:annotation:")]
        bool FinishedLaunchingWithApplication(UIApplication application, NSUrl url, [NullAllowed] string sourceApplication, [NullAllowed] NSObject annotation);

        // +(void)setupWithConfigFilename:(NSString * _Nonnull)configFilename;
        [Static]
        [Export("setupWithConfigFilename:")]
        void SetupWithConfigFilename(string configFilename);

        // +(void)setupWithAppId:(NSString * _Nonnull)appId clientToken:(NSString * _Nonnull)clientToken;
        [Static]
        [Export("setupWithAppId:clientToken:")]
        void SetupWithAppId(string appId, string clientToken);

        // +(void)logEventWithEventName:(NSString * _Nonnull)eventName;
        [Static]
        [Export("logEventWithEventName:")]
        void LogEventWithEventName(string eventName);

        // +(void)logEventWithEventName:(NSString * _Nonnull)eventName parameters:(NSDictionary<NSString *,NSObject *> * _Nonnull)parameters;
        [Static]
        [Export("logEventWithEventName:parameters:")]
        void LogEventWithEventName(string eventName, NSDictionary<NSString, NSObject> parameters);

        // +(void)flush;
        [Static]
        [Export("flush")]
        void Flush();
    }
}