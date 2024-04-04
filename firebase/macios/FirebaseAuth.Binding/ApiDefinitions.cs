using System;
using Foundation;
using ObjCRuntime;

namespace Firebase
{
	// @interface FirebaseAuth : NSObject
	[BaseType (typeof(NSObject))]
	interface FirebaseAuth
	{
		// -(void)setAuthStateListener:(void (^ _Nonnull)(FirebaseAuthUser * _Nullable))callback;
		[Export ("setAuthStateListener:")]
		void SetAuthStateListener (Action<FirebaseAuthUser> callback);

		// -(void)createUser:(NSString * _Nonnull)email password:(NSString * _Nonnull)password callback:(void (^ _Nonnull)(FirebaseAuthResult * _Nullable, NSError * _Nullable))callback;
		[Export ("createUser:password:callback:")]
		void CreateUser (string email, string password, Action<FirebaseAuthResult, NSError> callback);

		// -(void)signIn:(NSString * _Nonnull)email password:(NSString * _Nonnull)password callback:(void (^ _Nonnull)(FirebaseAuthResult * _Nullable, NSError * _Nullable))callback;
		[Export ("signIn:password:callback:")]
		void SignIn (string email, string password, Action<FirebaseAuthResult, NSError> callback);

		// -(NSError * _Nullable)signOut __attribute__((warn_unused_result("")));
		[NullAllowed, Export ("signOut")]
		NSError SignOut();
	}

	// @interface FirebaseAuthResult : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface FirebaseAuthResult
	{
		// @property (readonly, nonatomic, strong) FirebaseAuthUser * _Nullable user;
		[NullAllowed, Export ("user", ArgumentSemantic.Strong)]
		FirebaseAuthUser User { get; }
	}

	// @interface FirebaseAuthUser : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface FirebaseAuthUser
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
}
