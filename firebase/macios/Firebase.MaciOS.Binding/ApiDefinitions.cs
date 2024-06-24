#nullable enable
using System;
using Foundation;
using ObjCRuntime;

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

	// @interface MauiFIRAuth : NSObject
	[BaseType (typeof(NSObject))]
	interface MauiFIRAuth
	{
		// -(void)setAuthStateListener:(void (^ _Nonnull)(MauiFIRAuthUser * _Nullable))callback;
		[Static]
		[Export ("setAuthStateListener:")]
		[Async]
		void SetAuthStateListener (Action<MauiFIRAuthUser> callback);

		// -(void)createUser:(NSString * _Nonnull)email password:(NSString * _Nonnull)password callback:(void (^ _Nonnull)(MauiFIRAuthResult * _Nullable, NSError * _Nullable))callback;
		[Static]
		[Export ("createUser:password:callback:")]
		[Async]
		void CreateUser (string email, string password, Action<MauiFIRAuthResult, NSError> callback);

		// -(void)signIn:(NSString * _Nonnull)email password:(NSString * _Nonnull)password callback:(void (^ _Nonnull)(MauiFIRAuthResult * _Nullable, NSError * _Nullable))callback;
		[Static]
		[Export ("signIn:password:callback:")]
		[Async]
		void SignIn (string email, string password, Action<MauiFIRAuthResult, NSError> callback);

		// -(NSError * _Nullable)signOut __attribute__((warn_unused_result("")));
		[Static]
		[Export ("signOut")]
		NSError SignOut();
	}

	// @interface MauiFIRAuthResult : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MauiFIRAuthResult
	{
		// @property (readonly, nonatomic, strong) MauiFIRAuthUser * _Nullable user;
		[NullAllowed, Export ("user", ArgumentSemantic.Strong)]
		MauiFIRAuthUser User { get; }
	}

	// @interface MauiFIRAuthUser : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MauiFIRAuthUser
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable uid;
		[NullAllowed, Export ("uid")]
		string Uid { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable displayName;
		[NullAllowed, Export ("displayName")]
		string DisplayName { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable email;
		[NullAllowed, Export ("email")]
		string Email { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable refreshToken;
		[NullAllowed, Export ("refreshToken")]
		string RefreshToken { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable providerId;
		[NullAllowed, Export ("providerId")]
		string ProviderId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable tenantId;
		[NullAllowed, Export ("tenantId")]
		string TenantId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable phoneNumber;
		[NullAllowed, Export ("phoneNumber")]
		string PhoneNumber { get; }

		// @property (readonly, nonatomic) BOOL isAnonymous;
		[Export ("isAnonymous")]
		bool IsAnonymous { get; }

		// @property (readonly, nonatomic) BOOL isEmailVerified;
		[Export ("isEmailVerified")]
		bool IsEmailVerified { get; }

		// @property (readonly, copy, nonatomic) NSURL * _Nullable photoUrl;
		[NullAllowed, Export ("photoUrl", ArgumentSemantic.Copy)]
		NSUrl PhotoUrl { get; }
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
