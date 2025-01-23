using Foundation;

namespace RevenueCatBinding
{
	// @interface DotnetNewBinding : NSObject
	[BaseType (typeof(NSObject))]
	interface RevenueCatManager
	{
		[Static]
		[Export ("initialize:apiKey:userId:")]
		void Initialize (bool debugLog, string apiKey, string userId);

		[Static]
		[Export ("identify:")]
		void Identify (string userId);

		[Static]
		[Export ("update:")]
		void Update (bool force);

		[Static]
		[Export ("setEntitlementsUpdatedHandler:")]
		void SetEntitlementsUpdatedHandler (System.Action<string[]> entitlementsHandler);


		[Static]
		[Export ("showPaywall:offeringIdentifier:displayCloseButton:")]
		void ShowPaywall (UIKit.UIViewController viewController, string offeringIdentifier, bool showCloseButton);
	}
}
