using AndroidX.Activity.Result;

namespace MauiSample;

public interface IRevenueCatManager
{
    void Initialize(object platformContext, bool debugLog, string appStore, string apiKey, string userId);
    void Identify(string userId);
    void Update(bool force);
    void SetEntitlementsUpdatedHandler(System.Action<string[]> entitlementsHandler);
    void ShowPaywall(object platformView, string offeringIdentifier, bool showCloseButton);
}

#if IOS || MACCATALYST
public class RevenueCatManagerApple : IRevenueCatManager
{
    public void Initialize(object platformContext, bool debugLog, string appStore, string apiKey, string userId)
    {
        RevenueCatBinding.RevenueCatManager.Initialize(debugLog, apiKey, userId);
    }

    public void Identify(string userId)
    {
        RevenueCatBinding.RevenueCatManager.Identify(userId);
    }

    public void Update(bool force)
    {
        RevenueCatBinding.RevenueCatManager.Update(force);
    }

    public void SetEntitlementsUpdatedHandler(System.Action<string[]> entitlementsHandler)
    {
        RevenueCatBinding.RevenueCatManager.SetEntitlementsUpdatedHandler(entitlementsHandler);
    }

    public void ShowPaywall(object platformView, string offeringIdentifier, bool showCloseButton)
    {
        RevenueCatBinding.RevenueCatManager.ShowPaywall((UIKit.UIViewController)platformView, offeringIdentifier, showCloseButton);
    }
}
#elif ANDROID
public class RevenueCatManagerAndroid : Java.Lang.Object, IRevenueCatManager, Com.Revenuecat.Revenuecatbinding.IRevenueCatEntitlementsUpdatedListener
{
    public void Initialize(object platformContext, bool debugLog, string appStore, string apiKey, string userId)
    {
        Com.Revenuecat.Revenuecatbinding.RevenueCatManager.Initialize((Android.Content.Context)platformContext, debugLog, appStore, apiKey, userId);
    }

    public void Identify(string userId)
    {
        Com.Revenuecat.Revenuecatbinding.RevenueCatManager.Identify(userId);
    }

    public void Update(bool force)
    {
        Com.Revenuecat.Revenuecatbinding.RevenueCatManager.Update(force);
    }

    Action<string[]> entitlementsHandler;

    public void SetEntitlementsUpdatedHandler(System.Action<string[]> entitlementsHandler)
    {
        this.entitlementsHandler = this.entitlementsHandler;
        Com.Revenuecat.Revenuecatbinding.RevenueCatManager.SetEntitlementsUpdatedHandler(this);
    }

    public void ShowPaywall(object platformView, string offeringIdentifier, bool showCloseButton)
    {
        Com.Revenuecat.Revenuecatbinding.RevenueCatManager.ShowPaywall(offeringIdentifier);
    }

    public void OnEntitlementsUpdated(string[] entitlements)
    {
        entitlementsHandler?.Invoke(entitlements);
    }
}
#endif
