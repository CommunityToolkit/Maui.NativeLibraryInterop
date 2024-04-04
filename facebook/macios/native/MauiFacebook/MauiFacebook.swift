//
//  MauiFacebook.swift
//  MauiFacebook
//
//  Created by Jonathan Dick on 2024-03-06.
//

import Foundation
import FBSDKCoreKit

@objc(FacebookSdk)
public class FacebookSdk : NSObject {
       
    // See: https://developers.facebook.com/docs/app-events/getting-started-app-events-ios/#manually-log-events
    
    static var _setupCompleted : Bool = false
    
    // MARK: - Public API
    
    @objc public static func finishedLaunching(
        application: UIApplication,
        didFinishLaunchingWithOptions launchOptions: NSObject?) -> Bool {
  
            if let nsObject = launchOptions as? [String: Any] {
                let convertedDictionary = Dictionary(uniqueKeysWithValues:
                    nsObject.map { key, value in (UIApplication.LaunchOptionsKey(rawValue: key), value) }
                )
                
                return FBSDKCoreKit.ApplicationDelegate.shared.application(
                    application,
                    didFinishLaunchingWithOptions: convertedDictionary)
            }
            
            return FBSDKCoreKit.ApplicationDelegate.shared.application(application, didFinishLaunchingWithOptions: nil)
    }
    
    @objc public static func finishedLaunching(
        application: UIApplication,
        url: NSURL,
        sourceApplication: NSString?,
        annotation: NSObject?) -> Bool {
            return FBSDKCoreKit.ApplicationDelegate.shared.application(
                application,
                open: url as URL,
                sourceApplication: sourceApplication as? String,
                annotation: annotation)
    }
    
    // See: https://developers.facebook.com/docs/ios/upgrade-guide
    // You must initialize the SDK explicitly with the initializeSDK method or implicitly by calling it in applicationDidFinishLaunching.
    @objc public static func setup(configFilename : NSString) {
        
        if (_setupCompleted) {
            return
        }
        
        var configValues = NSDictionary()
                
        let path = Bundle.main.path(forResource: configFilename as String, ofType: "plist")
        
        if let devSettings = NSDictionary(contentsOfFile: path!) {
            configValues = devSettings
        }
        
        let appId = configValues["appId"] as! String as NSString
        let clientToken = configValues["clientToken"] as! String as NSString
        
        setup(appId: appId, clientToken: clientToken)
    }
    
    @objc public static func setup(appId : NSString, clientToken: NSString) {
        
        if (_setupCompleted) {
            return
        }
        
        FBSDKCoreKit.Settings.shared.appID = appId as String
        FBSDKCoreKit.Settings.shared.clientToken = clientToken as String
        FBSDKCoreKit.Settings.shared.isAdvertiserTrackingEnabled = true
        FBSDKCoreKit.Settings.shared.isAdvertiserIDCollectionEnabled = true
        FBSDKCoreKit.Settings.shared.isAutoLogAppEventsEnabled = true
        FBSDKCoreKit.Settings.shared.enableLoggingBehavior(.appEvents)
        FBSDKCoreKit.ApplicationDelegate.shared.initializeSDK()
        
        _setupCompleted = true
    }
    
    // https://developers.facebook.com/docs/reference/ios/current/class/FBSDKAppEvents/
    
    @objc public static func logEvent(eventName: NSString) {
        AppEvents.shared.logEvent(AppEvents.Name(rawValue: eventName as String))
    }
    
    @objc public static func logEvent(eventName: NSString, parameters: [NSString : NSObject]) {
        var params : [AppEvents.ParameterName : Any] = [:]
        
        let keys = Array(parameters.keys)
        
        for i in 0..<keys.count {
            let key = keys[i] as String?
            
            guard let paramNameKey = key else {
                continue
            }
            
            let paramName = AppEvents.ParameterName(rawValue: paramNameKey)
            let paramValue = parameters[key! as NSString]! as Any
            params[paramName] = paramValue
        }
        
        AppEvents.shared.logEvent(AppEvents.Name(rawValue: eventName as String), parameters: params)
    }
    
    @objc public static func flush() {
        AppEvents.shared.flush()
    }
}
