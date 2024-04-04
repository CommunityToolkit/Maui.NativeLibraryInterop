
using Microsoft.Maui;
using Microsoft.Maui.Handlers;

#if IOS
using NativeGoogleCastButton = GoogleCast.GoogleCastButton;
#elif ANDROID
using NativeGoogleCastButton = Android.Widget.Button;
#else
using NativeGoogleCastButton = object;
#endif

namespace GoogleCast.Sample;

public interface IGoogleCastButton : IView
{

}

public partial class GoogleCastButtonHandler : ViewHandler<IGoogleCastButton, NativeGoogleCastButton>
{

	public GoogleCastButtonHandler() : base(ViewHandler.ViewMapper)
	{
		
	}


	protected override NativeGoogleCastButton CreatePlatformView()
	{
#if IOS
		var b = new GoogleCastButton();
		b.Frame = new CoreGraphics.CGRect(0, 0, 24, 24);
		b.TintColor = UIKit.UIColor.Gray;
		return b;
#else
		return null;
#endif
	}
}

public partial class GoogleCastButtonView : View, IGoogleCastButton
{
}