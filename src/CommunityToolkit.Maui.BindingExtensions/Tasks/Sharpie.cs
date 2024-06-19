using System;
using System.Runtime.InteropServices;

using Microsoft.Build.Framework;

namespace CommunityToolkit.Maui.BindingExtensions
{
    public class Sharpie : BindingToolTask
    {
        public override string TaskPrefix => "SHRP";

        protected override string ToolName => "sharpie";

        public string Arguments { get; set; } = string.Empty;


        const string ClassicXIAssembly = "/Library/Frameworks/Xamarin.iOS.framework/Versions/Current/lib/64bits/iOS/Xamarin.iOS.dll";

        public Sharpie()
        {
        }

        protected override string GenerateFullPathToTool()
        {
            return Path.Combine("/usr", "local", "bin", ToolExe);
        }

        protected override string GenerateCommandLineCommands() => Arguments;

        public override bool RunTask()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                if (!File.Exists (GenerateFullPathToTool ())) {
                    Log.LogCodedError($"{TaskPrefix}1000", "Unable to run `sharpie`, please install Objective-Sharpie. https://aka.ms/objective-sharpie.");
                    return false;
                }

                if (!File.Exists (ClassicXIAssembly)) {
                    Log.LogCodedError($"{TaskPrefix}1001", "Unable to run `sharpie`, please install Xamarin.iOS. https://github.com/xamarin/xamarin-macios/blob/main/DOWNLOADS.md");
                    return false;
                }

                return base.RunTask();
            }
            else
            {
                Log.LogCodedWarning($"{TaskPrefix}1010", "Unable to run `sharpie` on this platform. Please build this project on a macOS machine.");
                return true;
            }
        }

    }
}
