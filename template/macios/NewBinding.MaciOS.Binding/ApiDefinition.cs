using Foundation;

namespace NewBindingMaciOS
{
	// @interface DotnetNewBinding : NSObject
	[BaseType (typeof(NSObject))]
	interface DotnetNewBinding
	{
		// +(NSString * _Nonnull)getStringWithMyString:(NSString * _Nonnull)myString __attribute__((warn_unused_result("")));
		[Static]
		[Export ("getStringWithMyString:")]
		string GetString (string myString);
	}
}
