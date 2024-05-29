using Microsoft.Build.Utilities;

namespace Microsoft.Maui.BindingExtensions.Build.Tasks
{
    public static class MSBuildExtensions
    {
        public static void LogCodedError(this TaskLoggingHelper log, string code, string message, params object[] messageArgs)
        {
            log.LogError(
                subcategory: string.Empty,
                errorCode: code,
                helpKeyword: string.Empty,
                file: string.Empty,
                lineNumber: 0,
                columnNumber: 0,
                endLineNumber: 0,
                endColumnNumber: 0,
                message: message,
                messageArgs: messageArgs);
        }

        public static void LogCodedWarning(this TaskLoggingHelper log, string code, string message, params object [] messageArgs)
        {
            log.LogWarning(
                subcategory: string.Empty,
                warningCode: code,
                helpKeyword: string.Empty,
                file: string.Empty,
                lineNumber: 0,
                columnNumber: 0,
                endLineNumber: 0,
                endColumnNumber: 0,
                message: message,
                messageArgs: messageArgs);
        }

    }
}
