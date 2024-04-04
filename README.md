# Community Slim Bindings for .NET iOS/Android & .NET MAUI

This repository contains samples and starting points demonstrating how to use the [slim binding approach](#slim-binding-approach) to interop with native iOS and Android SDKs from your .NET iOS/Android and .NET MAUI iOS/Android apps.

## Community Maintained

The long term goal is to move this repository into a community maintained space, (eg: potentially the CommunityToolkit org) and work with community owners/maintainers to add more samples and expan the slim/wrapper API surface for existing samples.

## Slim Binding Approach

Slim binding refers to a pattern for accessing native SDKs in .NET apps indirectly via a 'thin' wrapper with a simplified API surface. This approach is especially beneficial when you only need a small slice of the API surface of the SDK, though it also works well for larger API surface usage all the same.

The idea is to create your own abstraction or 'wrapper' API to the native SDK's you're interested in calling from .NET. The native 'wrapper' library/framework projects get created in Android Studio and/or Xcode using Java/Kotlin and/or Objective-C/Swift. The implementation of this wrapper API would typically follow the SDK documentation which is likely easier to follow and apply when using the same language as the documentation. It may even be possible to copy and paste code from the vendor documentation directly. 

A key benefits of the pattern is based on the premise that **.NET Android and iOS binding tools work great with simple API surfaces**. Assuming the wrapper contains only primitive types which .NET already knows about and has bindings for, the existing binding tools are able to more reliably generate working binding definitions without the amount of manual intervention often required for traditional bindings. 

While the initial setup may take some time, it's possible to script the building and preparation of the native components (and binding definitions) to reduce the overhead of future updates. For example, updating the underlying SDKs may need only involve updating the version and rebuilding. If there's breaking changes to the API surfaces being used, or to how SDKs work in general, then native code may need changing. However, there's a greater chance that the wrapper API surface (and the usage in the .NET app) can remain unchanged compared to traditional bindings.

### Resources

- [GoneMobile.io: Slim Bindings Podcast Episode](https://www.gonemobile.io/101)
- [MonkeyFest 2020: Bridge the gap with Bindings to native iOS and Android SDK's](https://www.youtube.com/watch?v=bgK_6anwMcw)

### Benefits

- Easier to follow SDK documentation using native languages and tools
- Little or no manual intervention required to create working bindings
- Typically easier to maintain and less work to update to latest versions
- App can be more isolated from changes to the underlying SDKs

### Limitations

- Requires the same effort as traditional bindings to resolve dependency chains (notably on Android)
- When using Swift, the ```@objc``` attribute is required to generate Objective-C compatible headers


## Goals / Samples

As previously mentioned, the hardest part in creating a Slim binding is setting up the native projects, getting the correct native dependencies referenced in those projects, and then referencing the output of those native projects from a .NET Binding library project and .NET MAUI app.

The goal of this repository is first to help provide an easier to use starting point for developers to build from and customize for their own app's needs.

### Where are the NuGet Packages?

Initially the goal is to provide a foundation to build off of, as the API's everyone needs from a given native library may vary.  However we also recognize that there may be cases where most developers do need the same set of API's and we will monitor feedback in this area and may eventually decide there's enough value to a group of developers to warrant publishing packages to consume.  Stay tuned!


## Environment setup

### Install prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download)
- [.NET MAUI workload](https://github.com/dotnet/core/blob/main/release-notes/6.0/install-maui.md#cli-installation) (via Visual Studio or CLI ```dotnet workload install maui```)
- [Android SDK](https://developer.android.com/tools)
- [Android Studio](https://developer.android.com/studio)
- [Objective-Sharpie](https://aka.ms/objective-sharpie)
- [Visual Studio](https://visualstudio.microsoft.com/downloads/) or [Visual Studio Code](https://code.visualstudio.com/download)
- [Xcode](https://developer.apple.com/xcode/)
- [Xcode Command Line Tools](https://developer.apple.com/download/all/?q=command%20line%20tools) (```xcode-select --install```)

> [!NOTE]
> 
> It's possible to install the [Android SDK](https://developer.android.com/tools) and/or the [Xcode Command Line Tools](https://developer.apple.com/download/all/?q=command%20line%20tools) in a standalone manner. However, installation of the [Xcode Command Line Tools](https://developer.apple.com/download/all/?q=command%20line%20tools) is typically handled via [Xcode](https://developer.apple.com/xcode/). Likewise, [Android SDK](https://developer.android.com/tools) installation is also typically handled via [Android Studio](https://developer.android.com/studio) and/or the [.NET MAUI VS Code Extension](https://aka.ms/mauidevkit-marketplace) as-per the [.NET MAUI Getting Started](https://learn.microsoft.com/dotnet/maui/get-started/installation?view=net-maui-8.0&tabs=visual-studio-code#install-visual-studio-code-and-the-net-maui-extension) documentation.

## Building

Each .NET Binding project contains some additional MSBuild logic to help obtain and build the native SDK dependencies along with the native slim binding project.

In the `eng/` folder you will find `Common.android.targets` and `Common.macios.targets` files which contain some custom build targets to help with this, and are imported into the binding projects.
