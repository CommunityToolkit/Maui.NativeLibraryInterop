using System.Text;

using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Microsoft.Maui.BindingExtensions.Build.Tasks
{
    public abstract class BindingToolTask : ToolTask
    {
        public abstract string TaskPrefix { get; }

        public string WorkingDirectory { get; set; } = Directory.GetCurrentDirectory();

        StringBuilder toolOutput = new StringBuilder();

        public BindingToolTask()
        {
        }

        public override bool Execute()
        {
            try
            {
                bool taskResult = RunTask();
                if (!taskResult && !string.IsNullOrEmpty(toolOutput.ToString()))
                {
                    Log.LogCodedError($"{TaskPrefix}0000", toolOutput.ToString().Trim());

                }
                toolOutput.Clear();
                return taskResult;
            }
            catch (Exception ex)
            {
                Log.LogCodedError($"{TaskPrefix}0100", ex.ToString());
                return false;
            }
        }

        protected override void LogEventsFromTextOutput(string singleLine, MessageImportance messageImportance)
        {
            base.LogEventsFromTextOutput(singleLine, messageImportance);
            toolOutput.AppendLine(singleLine);
        }

        protected override string GetWorkingDirectory()
        {
            return WorkingDirectory;
        }

        public virtual bool RunTask() => base.Execute();

        protected object ProjectSpecificTaskObjectKey(object key) => (key, WorkingDirectory);
    }
}
