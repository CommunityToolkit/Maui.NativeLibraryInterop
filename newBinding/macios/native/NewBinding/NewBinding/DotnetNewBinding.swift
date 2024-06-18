//
//  DotnetNewBinding.swift
//  NewBinding
//
//  Created by .NET MAUI team on 6/18/24.
//

import Foundation

@objc(DotnetNewBinding)
public class DotnetNewBinding : NSObject {
    
    @objc
    public static func getString(myString: NSString) -> NSString {
        return myString
    }

}
