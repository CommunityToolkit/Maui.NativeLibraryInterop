#nullable enable
using System;
using Foundation;

namespace Firebase
{
    [BaseType(typeof(NSObject))]
    interface FirebaseMessaging
    {
        [Static]
        [Export("getIsAutoInitEnabled:")]
        bool IsAutoInitEnabled { get; [Bind("setIsAutoInitEnabled:")] set; }

        [Static]
        [Export("getFcmToken")]
        string FcmToken { get; }

        [Static]
        [Export("register:completion:")]
        [Async]
        void Register(NSData nativePush, Action<string?, NSError?> completion);

        [Static]
        [Export("unregister:")]
        [Async]
        void UnRegister(Action completion);

        [Static]
        [Export("subscribe:completion:")]
        [Async]
        void Subscribe(string topic, Action<NSError?> completion);

        [Static]
        [Export("unsubscribe:completion:")]
        [Async]
        void UnSubscribe(string topic, Action<NSError?> completion);
    }
}
