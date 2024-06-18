//
//  MauiFIRAuth.swift
//  MauiFirebase
//
//  Created by Peter Collins on 6/18/24.
//

import UIKit
import FirebaseAuth

@objc(MauiFIRAuth)
public class MauiFIRAuth : NSObject {

    static var authStateDidChangeListenerHandle: AuthStateDidChangeListenerHandle?

    @objc(setAuthStateListener:)
    public static func setAuthStateListener(callback: @escaping (MauiFIRAuthUser?) -> Void) -> Void {
        let auth = Auth.auth()

        if (authStateDidChangeListenerHandle != nil) {
            auth.removeStateDidChangeListener(authStateDidChangeListenerHandle!)
        }

        authStateDidChangeListenerHandle = auth.addStateDidChangeListener { auth, user in
            callback(MauiFIRAuthUser(user: user!))
        }
    }

    @objc(createUser:password:callback:)
    public static func createUser(email: String, password: String, callback: @escaping (MauiFIRAuthResult?, NSError?) -> Void) -> Void {
        Auth.auth().createUser(withEmail: email, password: password) { authResult, authError in

            var far: MauiFIRAuthResult? = nil;

            if (authResult != nil) {
                far = MauiFIRAuthResult(authResult: authResult!)
            }

            callback(far, authError as NSError?)
        }
    }

    @objc(signIn:password:callback:)
    public static func signIn(email: String, password: String, callback: @escaping (MauiFIRAuthResult?, NSError?) -> Void) -> Void {
        Auth.auth().signIn(withEmail: email, password: password) { authResult, authError in
            var far: MauiFIRAuthResult? = nil;

            if (authResult != nil) {
                far = MauiFIRAuthResult(authResult: authResult!)
            }

            callback(far, authError as NSError?)
        }
    }

    @objc
    public static func signOut() -> NSError? {
        let firebaseAuth = Auth.auth()
        do {
          try firebaseAuth.signOut()
        } catch let signOutError as NSError {
          return signOutError
        }
        return nil
    }
}

@objc(MauiFIRAuthUser)
public class MauiFIRAuthUser : NSObject
{
    var _user: User?

    internal init(user: User) {
        _user = user;
    }

    @objc
    public var uid: String? {
        get { return _user?.uid }
    }

    @objc
    public var displayName: String? {
        get { return _user?.displayName }
    }

    @objc
    public var email: String? {
        get { return _user?.email }
    }

    @objc
    public var refreshToken: String? {
        get { return _user?.refreshToken }
    }

    @objc
    public var providerId: String? {
        get { return _user?.providerID }
    }

    @objc
    public var tenantId: String? {
        get { return _user?.tenantID }
    }

    @objc
    public var phoneNumber: String? {
        get { return _user?.phoneNumber }
    }

    @objc
    public var isAnonymous: Bool {
        get { return _user?.isAnonymous ?? false }
    }

    @objc
    public var isEmailVerified: Bool {
        get { return _user?.isEmailVerified ?? false }
    }

    @objc
    public var photoUrl: URL? {
        get { return _user?.photoURL }
    }
}


@objc(MauiFIRAuthResult)
public class MauiFIRAuthResult : NSObject
{
    var _authResult: AuthDataResult?

    internal init(authResult: AuthDataResult) {
        _authResult = authResult
    }

    @objc
    public var user: MauiFIRAuthUser? {
        get {
            var r: MauiFIRAuthUser? = nil

            let authResultUser = _authResult?.user as User?

            if (authResultUser != nil) {
                r = MauiFIRAuthUser(user: authResultUser!)
            }

            return r;
        }
    }
}
