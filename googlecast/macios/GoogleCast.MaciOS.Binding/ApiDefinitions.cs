using System;
using Foundation;

namespace GoogleCast
{
	// @interface GoogleCastManager : NSObject
	[BaseType (typeof(NSObject))]
	interface GoogleCastManager
	{
		// -(void)configure;
		[Export ("configure")]
		void Configure ();

		// -(void)loadMediaWithUrl:(NSString * _Nonnull)url contentType:(NSString * _Nonnull)contentType title:(NSString * _Nonnull)title subtitle:(NSString * _Nonnull)subtitle imageUrl:(NSString * _Nonnull)imageUrl imageHeight:(NSInteger)imageHeight imageWidth:(NSInteger)imageWidth;
		[Export ("loadMediaWithUrl:contentType:title:subtitle:imageUrl:imageHeight:imageWidth:")]
		void LoadMedia (string url, string contentType, string title, string subtitle, string imageUrl, nint imageHeight, nint imageWidth);

		// +(BOOL)getIsCastSessionActive __attribute__((warn_unused_result("")));
		[Export ("getIsCastSessionActive")]
		bool IsCastSessionActive { get; }
	}


	[BaseType (typeof(UIKit.UIButton))]
	interface GoogleCastButton
	{
		
	}
}
