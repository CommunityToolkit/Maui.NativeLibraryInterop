using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

using Microsoft.Build.Framework;

namespace Microsoft.Maui.BindingExtensions.Build.Tasks
{
    public class Gradle : BindingToolTask
    {
        public override string TaskPrefix => "GRDL";

        protected override string ToolName => RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "gradlew.bat" : "gradlew";


        public string AndroidSdkDirectory { get; set; } = string.Empty;

        public string JavaSdkDirectory { get; set; } = string.Empty;

        public string Arguments { get; set; } = string.Empty;


        public Gradle()
        {
        }

        protected override string GenerateFullPathToTool()
        {
            return Path.Combine(ToolPath, ToolExe);
        }

        protected override string GenerateCommandLineCommands() => Arguments;

        protected override ProcessStartInfo GetProcessStartInfo(string pathToTool, string commandLineCommands, string responseFileSwitch)
        {
            ProcessStartInfo psi = base.GetProcessStartInfo(pathToTool, commandLineCommands, responseFileSwitch);
            if (Directory.Exists(AndroidSdkDirectory))
                psi.Environment["ANDROID_HOME"] = AndroidSdkDirectory;

            if (Directory.Exists(JavaSdkDirectory))
                psi.Environment["JAVA_HOME"] = JavaSdkDirectory;

            return psi;
        }

    }
}
