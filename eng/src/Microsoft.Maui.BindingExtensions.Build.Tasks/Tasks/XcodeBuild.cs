using System;
using System.Runtime.InteropServices;

using Microsoft.Build.Framework;

namespace Microsoft.Maui.BindingExtensions.Build.Tasks
{
    public class XcodeBuild : BindingToolTask
    {
        public override string TaskPrefix => "XCBD";

        protected override string ToolName => "xcodebuild";


        public string Arguments { get; set; } = string.Empty;


        public XcodeBuild()
        {
        }

        protected override string GenerateFullPathToTool()
        {
            return Path.Combine("/usr", "bin", ToolExe);
        }

        protected override string GenerateCommandLineCommands() => Arguments;

        public override bool RunTask()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return base.RunTask();
            }
            else
            {
                Log.LogCodedWarning($"{TaskPrefix}1000", "xcodebuild is not currently supported on this platform. Please build this project on a macOS machine.");
                return false;
            }
        }

    }
}
