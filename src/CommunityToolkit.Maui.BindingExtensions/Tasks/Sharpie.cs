using System;
using System.Runtime.InteropServices;

using Microsoft.Build.Framework;

namespace Microsoft.Maui.BindingExtensions.Build.Tasks
{
    public class Sharpie : BindingToolTask
    {
        public override string TaskPrefix => "SHRP";

        protected override string ToolName => "sharpie";


        public string Arguments { get; set; } = string.Empty;


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
                    Log.LogCodedWarning($"{TaskPrefix}1000", "Unable to locate `sharpie`, please install https://aka.ms/objective-sharpie.");
                    return false;
                }

                return base.RunTask();
            }
            else
            {
                Log.LogCodedWarning($"{TaskPrefix}1000", "sharpie is not currently supported on this platform. Please build this project on a macOS machine.");
                return false;
            }
        }

    }
}
