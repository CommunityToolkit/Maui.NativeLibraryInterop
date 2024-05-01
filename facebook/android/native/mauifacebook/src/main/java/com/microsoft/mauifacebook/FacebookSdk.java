package com.microsoft.mauifacebook;

import android.app.Activity;
import android.app.Application;
import android.os.Bundle;
import android.util.Log;

import com.facebook.LoggingBehavior;
import com.facebook.appevents.AppEventsLogger;

public class FacebookSdk {

    // See: https://developers.facebook.com/docs/app-events/getting-started-app-events-android/#log-manually

    static AppEventsLogger _logger;

    public static void initializeSDK(Activity activity, Boolean isDebug) {
        Application application = activity.getApplication();
        com.facebook.FacebookSdk.sdkInitialize(application);

        if (isDebug) {
            com.facebook.FacebookSdk.setIsDebugEnabled(true);
        }

        com.facebook.FacebookSdk.addLoggingBehavior(LoggingBehavior.APP_EVENTS);

        AppEventsLogger.activateApp(application);

        _logger = AppEventsLogger.newLogger(activity);
    }

    public static void enableAutoLogAppEvents(Boolean enabled) {
        com.facebook.FacebookSdk.setAutoLogAppEventsEnabled(enabled);
    }

    public static void logEvent(String eventName) {
        _logger.logEvent(eventName);
    }

    public static void logEvent(String eventName, Bundle bundle) {
        _logger.logEvent(eventName, bundle);
    }

    public static void flush() {
        _logger.flush();
    }
}