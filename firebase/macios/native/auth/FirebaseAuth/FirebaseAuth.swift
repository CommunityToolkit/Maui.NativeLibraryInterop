import UIKit

@objc(FirebaseAuth)
public class FirebaseAuth : NSObject {
    
    var authStateDidChangeListenerHandle: AuthStateDidChangeListenerHandle?
    
    @objc(setAuthStateListener:)
    public func setAuthStateListener(callback: @escaping (FirebaseAuthUser?) -> Void) -> Void {
        let auth = Auth.auth()
        
        if (authStateDidChangeListenerHandle != nil) {
            auth.removeStateDidChangeListener(authStateDidChangeListenerHandle!)
        }
        
        authStateDidChangeListenerHandle = auth.addStateDidChangeListener { auth, user in
            callback(FirebaseAuthUser(user: user!))
        }
    }

    @objc(createUser:password:callback:)
    public func createUser(email: String, password: String, callback: @escaping (FirebaseAuthResult?, NSError?) -> Void) -> Void {
        Auth.auth().createUser(withEmail: email, password: password) { authResult, authError in
            
            var far: FirebaseAuthResult? = nil;
            
            if (authResult != nil) {
                far = FirebaseAuthResult(authResult: authResult!)
            }
            
            callback(far, authError as NSError?)
        }
    }
    
    @objc(signIn:password:callback:)
    public func signIn(email: String, password: String, callback: @escaping (FirebaseAuthResult?, NSError?) -> Void) -> Void {
        Auth.auth().signIn(withEmail: email, password: password) { authResult, authError in
            var far: FirebaseAuthResult? = nil;
            
            if (authResult != nil) {
                far = FirebaseAuthResult(authResult: authResult!)
            }
            
            callback(far, authError as NSError?)
        }
    }
    
    @objc
    public func signOut() -> NSError? {
        let firebaseAuth = Auth.auth()
        do {
          try firebaseAuth.signOut()
        } catch let signOutError as NSError {
          return signOutError
        }
        return nil
    }
}

@objc(FirebaseAuthUser)
public class FirebaseAuthUser : NSObject
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


@objc(FirebaseAuthResult)
public class FirebaseAuthResult : NSObject
{
    var _authResult: AuthDataResult?
    
    internal init(authResult: AuthDataResult) {
        _authResult = authResult
    }
    
    @objc
    public var user: FirebaseAuthUser? {
        get {
            var r: FirebaseAuthUser? = nil
            
            let authResultUser = _authResult?.user as User?
            
            if (authResultUser != nil) {
                r = FirebaseAuthUser(user: authResultUser!)
            }
            
            return r;
        }
    }
}
