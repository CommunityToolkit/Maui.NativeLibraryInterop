#nullable enable
using System;
using Foundation;

namespace Firebase
{
	// @interface MauiFIRAnalytics : NSObject
	[BaseType (typeof(NSObject))]
	interface MauiFIRAnalytics
	{
		// +(void)logEventWithEventName:(NSString * _Nonnull)eventName parameters:(NSDictionary<NSString *,id> * _Nonnull)parameters;
		[Static]
		[Export ("logEventWithEventName:parameters:")]
		void LogEvent (string eventName, NSDictionary parameters);

		// +(void)getAppInstanceIdWithCompletion:(void (^ _Nonnull)(NSString * _Nullable))completion;
		[Static]
		[Export ("getAppInstanceIdWithCompletion:")]
		[Async]
		void GetAppInstanceId (Action<NSString?> completion);

		// +(void)setUserIdWithUserId:(NSString * _Nonnull)userId;
		[Static]
		[Export ("setUserIdWithUserId:")]
		void SetUserId (string userId);

		// +(void)setUserPropertyWithPropertyName:(NSString * _Nonnull)propertyName value:(NSString * _Nonnull)value;
		[Static]
		[Export ("setUserPropertyWithPropertyName:value:")]
		void SetUserProperty (string propertyName, string value);

		// +(void)setSessionTimeoutWithSeconds:(NSInteger)seconds;
		[Static]
		[Export ("setSessionTimeoutWithSeconds:")]
		void SetSessionTimeout (nint seconds);

		// +(void)resetAnalyticsData;
		[Static]
		[Export ("resetAnalyticsData")]
		void ResetAnalyticsData ();
	}

	// @interface MauiFIRApp : NSObject
	[BaseType (typeof(NSObject))]
	interface MauiFIRApp
	{
		// +(void)autoConfigure;
		[Static]
		[Export ("autoConfigure")]
		void AutoConfigure ();

		// +(void)configure:(NSString * _Nonnull)googleAppId gcmSenderId:(NSString * _Nonnull)gcmSenderId;
		[Static]
		[Export ("configure:gcmSenderId:")]
		void Configure (string googleAppId, string gcmSenderId);
	}

	// @interface MauiFIRMessaging : NSObject
	[BaseType (typeof(NSObject))]
	interface MauiFIRMessaging
	{
		// +(BOOL)getIsAutoInitEnabled __attribute__((warn_unused_result("")));
		// +(void)setIsAutoInitEnabled:(BOOL)enabled;
		[Static]
		[Export ("getIsAutoInitEnabled")]
		bool IsAutoInitEnabled { get; [Bind("setIsAutoInitEnabled:")] set; }

		// +(NSString * _Nullable)getFcmToken __attribute__((warn_unused_result("")));
		[Static]
		[NullAllowed, Export ("getFcmToken")]
		string FcmToken { get; }

		// +(void)register:(NSData * _Nonnull)apnsToken completion:(void (^ _Nonnull)(NSString * _Nullable, NSError * _Nullable))completion;
		[Static]
		[Export ("register:completion:")]
		[Async]
		void Register (NSData apnsToken, Action<string?, NSError?> completion);

		// +(void)unregister:(void (^ _Nonnull)(NSError * _Nullable))completion;
		[Static]
		[Export ("unregister:")]
		[Async]
		void Unregister (Action<NSError?> completion);

		// +(void)subscribe:(NSString * _Nonnull)topic completion:(void (^ _Nonnull)(NSError * _Nullable))completion;
		[Static]
		[Export ("subscribe:completion:")]
		[Async]
		void Subscribe (string topic, Action<NSError?> completion);

		// +(void)unsubscribe:(NSString * _Nonnull)topic completion:(void (^ _Nonnull)(NSError * _Nullable))completion;
		[Static]
		[Export ("unsubscribe:completion:")]
		[Async]
		void Unsubscribe (string topic, Action<NSError?> completion);
	}
}
