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

    public static void initialize(Activity activity, Boolean isDebug) {
        Application application = activity.getApplication();

        if (isDebug) {
            com.facebook.FacebookSdk.setIsDebugEnabled(true);
        }

        com.facebook.FacebookSdk.addLoggingBehavior(LoggingBehavior.APP_EVENTS);

        AppEventsLogger.activateApp(application);

        _logger = AppEventsLogger.newLogger(activity);
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