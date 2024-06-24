//
//  MauiGoogleCast.swift
//  MauiGoogleCast
//
//  Created by Jonathan Dick on 2024-03-05.
//

import Foundation
import GoogleCast

@objc(GoogleCastManager)
public class GoogleCastManager : NSObject, GCKLoggerDelegate, GCKRequestDelegate {
    
    let kReceiverAppID = kGCKDefaultMediaReceiverApplicationID
    let kDebugLoggingEnabled = true
    
    @objc
    public func configure() {
        let criteria = GCKDiscoveryCriteria(applicationID: kReceiverAppID)
        let options = GCKCastOptions(discoveryCriteria: criteria)
        GCKCastContext.setSharedInstanceWith(options)
        
        // Enable logger.
        GCKLogger.sharedInstance().delegate = self
    }
    
    @objc
    public func loadMedia(url: String, contentType: String, title: String, subtitle: String, imageUrl: String, imageHeight: Int, imageWidth: Int) {
        if !getIsCastSessionActive() {
            logMessage("cast session not found, please start one", at: GCKLoggerLevel.error, fromFunction: "loadMedia", location: "line 31")
            return
        }
        
        let url = URL.init(string: url)
        guard let mediaURL = url else {
            logMessage("invalid mediaURL", at: GCKLoggerLevel.error, fromFunction: "loadMedia", location: "line 36")
            return
        }
        
        let metadata = GCKMediaMetadata()
        metadata.setString(title, forKey: kGCKMetadataKeyTitle)
        metadata.setString(subtitle, forKey: kGCKMetadataKeySubtitle)
        metadata.addImage(GCKImage(url: URL(string: imageUrl)!,
                                   width: imageHeight,
                                   height: imageWidth))
        
        let mediaInfoBuilder = GCKMediaInformationBuilder.init(contentURL: mediaURL)
        mediaInfoBuilder.streamType = GCKMediaStreamType.none;
        mediaInfoBuilder.contentType = contentType //eg: video/mp4
        mediaInfoBuilder.metadata = metadata;
        let mediaInformation = mediaInfoBuilder.build()
        
        if let request = GCKCastContext.sharedInstance().sessionManager.currentSession?.remoteMediaClient?.loadMedia(mediaInformation) {
            request.delegate = self
        }
    }
    
    @objc
    public func getIsCastSessionActive() -> Bool {
        return GCKCastContext.sharedInstance().sessionManager.currentSession != nil
    }
    
    public func logMessage(_ message: String,
                           at level: GCKLoggerLevel,
                           fromFunction function: String,
                           location: String) {
        if (kDebugLoggingEnabled) {
            print(function + " - " + message)
        }
    }
}


@objc(GoogleCastButton)
public class GoogleCastButton : GCKUICastButton {
}
