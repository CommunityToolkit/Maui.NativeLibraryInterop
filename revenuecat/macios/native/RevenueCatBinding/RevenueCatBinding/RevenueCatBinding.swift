//
//  DotnetNewBinding.swift
//  NewBinding
//
//  Created by .NET MAUI team on 6/18/24.
//

import Foundation
import UIKit
import RevenueCat
import RevenueCatUI

@objc(RevenueCatManager)
public class RevenueCatManager : NSObject //, PaywallViewControllerDelegate
{

    @objc(initialize:apiKey:userId:)
    public static func initialize(debugLog: Bool, apiKey: String, userId: String?) {
        Purchases.logLevel = .debug
        Purchases.configure(withAPIKey: apiKey, appUserID: userId)
    }
    
    @objc(identify:)
    public static func identify(userId: String) {
        Purchases.shared.logIn(userId) { (customerInfo, created, error) in
            handleCustomerInfoUpdated(customerInfo: customerInfo)
        }
    }
    
    
    @objc(update:)
    public static func update(force: Bool) {
        
        let fetchPolicy = force ? CacheFetchPolicy.fetchCurrent : CacheFetchPolicy.notStaleCachedOrFetched
        
        Purchases.shared.getCustomerInfo(fetchPolicy: fetchPolicy) { (customerInfo, error) in
            handleCustomerInfoUpdated(customerInfo: customerInfo)
        }
    }
    
    
    static var entitlementsUpdatedHandler: (([String]) -> Void)?

    @objc(setEntitlementsUpdatedHandler:)
    public static func setEntitlementsUpdatedHandler(callback: @escaping ([String]) -> Void) -> Void {
        entitlementsUpdatedHandler = callback
    }
    
    public func purchases(_ purchases: Purchases, receivedUpdated customerInfo: CustomerInfo) {
        RevenueCatManager.handleCustomerInfoUpdated(customerInfo: customerInfo)
    }

    static func handleCustomerInfoUpdated(customerInfo: CustomerInfo?)
    {
        if (customerInfo != nil && entitlementsUpdatedHandler != nil) {
            let entitlements = customerInfo!.entitlements.active
                .map { $0.value.identifier }
            entitlementsUpdatedHandler!(entitlements)
        }
    }

    @objc(showPaywall:)
    public static func showPaywall(viewController: UIViewController) {
        let paywallManager = PaywallManager()

        paywallManager.presentPaywall(viewController: viewController)
    }
}

public class PaywallManager {

    public func presentPaywall(viewController: UIViewController) {
        let controller = PaywallViewController()
        controller.delegate = self

        viewController.present(controller, animated: true, completion: nil)
    }

}

extension PaywallManager: PaywallViewControllerDelegate {

    public func paywallViewController(_ controller: PaywallViewController,
                               didFinishPurchasingWith customerInfo: CustomerInfo) {
        RevenueCatManager.handleCustomerInfoUpdated(customerInfo: customerInfo)
    }

}
