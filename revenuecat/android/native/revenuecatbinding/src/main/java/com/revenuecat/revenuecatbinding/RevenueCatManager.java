package com.revenuecat.revenuecatbinding;

import android.content.Context;

import androidx.activity.ComponentActivity;
import androidx.annotation.NonNull;
import androidx.annotation.OptIn;

import com.revenuecat.purchases.CacheFetchPolicy;
import com.revenuecat.purchases.CustomerInfo;
import com.revenuecat.purchases.EntitlementInfo;
import com.revenuecat.purchases.LogLevel;
import com.revenuecat.purchases.Purchases;
import com.revenuecat.purchases.PurchasesConfiguration;
import com.revenuecat.purchases.PurchasesError;
import com.revenuecat.purchases.amazon.AmazonConfiguration;
import com.revenuecat.purchases.interfaces.ReceiveCustomerInfoCallback;
import com.revenuecat.purchases.interfaces.UpdatedCustomerInfoListener;
import com.revenuecat.purchases.ui.revenuecatui.ExperimentalPreviewRevenueCatUIPurchasesAPI;
import com.revenuecat.purchases.ui.revenuecatui.activity.PaywallActivityLauncher;
import com.revenuecat.purchases.ui.revenuecatui.activity.PaywallResult;
import com.revenuecat.purchases.ui.revenuecatui.activity.PaywallResultHandler;

@ExperimentalPreviewRevenueCatUIPurchasesAPI
public class RevenueCatManager
{
    static PaywallActivityLauncher launcher;

    public static void initialize(Context context, boolean debugLog, String appStore, String apiKey, String userId) {

        if (debugLog)
            Purchases.setLogLevel(LogLevel.DEBUG);
        else
            Purchases.setLogLevel(LogLevel.ERROR);

        PurchasesConfiguration.Builder builder = new PurchasesConfiguration.Builder(context, apiKey);

        if (userId != null) {
            builder.appUserID(userId);
        }

        Purchases.configure(builder.build());
    }

    public static void identify(String userId) {
        Purchases.getSharedInstance().logIn(userId);
    }


    public static void update(boolean force) {
        Purchases.getSharedInstance().getCustomerInfo(
            force ? CacheFetchPolicy.FETCH_CURRENT : CacheFetchPolicy.CACHED_OR_FETCHED,
            new ReceiveCustomerInfoCallback() {
                @Override
                public void onReceived(@NonNull CustomerInfo customerInfo) {
                    handleCustomerInfoUpdated(customerInfo);
                }

                @Override
                public void onError(@NonNull PurchasesError purchasesError) {
                }
            });
    }


    static RevenueCatEntitlementsUpdatedListener entitlementsUpdatedListener;

    public static void setEntitlementsUpdatedHandler(RevenueCatEntitlementsUpdatedListener listener) {
        entitlementsUpdatedListener = listener;
    }

    @OptIn(markerClass = ExperimentalPreviewRevenueCatUIPurchasesAPI.class)
    public static void showPaywall(ComponentActivity componentActivity, String offeringIdentifier) {

        if (launcher == null) {
            launcher = new PaywallActivityLauncher(componentActivity, new PaywallResultHandler() {
                @Override
                public void onActivityResult(PaywallResult o) {
                    if (o instanceof PaywallResult.Purchased) {
                        PaywallResult.Purchased purchased = (PaywallResult.Purchased) o;
                        handleCustomerInfoUpdated(purchased.getCustomerInfo());
                    }
                }
            });
        }

        launcher.launchIfNeeded(offeringIdentifier);
    }

    static void handleCustomerInfoUpdated(CustomerInfo customerInfo)
    {
        if (entitlementsUpdatedListener != null) {
            String[] entitlements = customerInfo.getEntitlements().getActive().keySet().toArray(new String[0]);
            entitlementsUpdatedListener.onEntitlementsUpdated(entitlements);
        }
    }
}
