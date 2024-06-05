using System.Collections;
using Microsoft.Build.Framework;
using NUnit.Framework;

namespace CommunityToolkit.Maui.BindingExtensions.Tests
{
    public class MockBuildEngine : IBuildEngine4
    {
        public int ColumnNumberOfTaskNode { get; set; }

        public bool ContinueOnError { get; set; }

        public int LineNumberOfTaskNode { get; set; }

        public string ProjectFileOfTaskNode => "test.xml";

        public IList<CustomBuildEventArgs> CustomEvents { get; set; } = new List<CustomBuildEventArgs>();

        public IList<BuildErrorEventArgs> Errors { get; set; } = new List<BuildErrorEventArgs>();

        public IList<BuildMessageEventArgs> Messages { get; set; } = new List<BuildMessageEventArgs>();

        public IList<BuildWarningEventArgs> Warnings { get; set; } = new List<BuildWarningEventArgs>();

        Dictionary<object, object> RegisteredTaskObjects { get; } = new Dictionary<object, object>();

        int RegisteredTaskObjectsQueries = 0;

        public bool IsRunningMultipleNodes => false;

        public TextWriter Output { get; set; } = TestContext.Out;

        public void ClearEvents()
        {
            CustomEvents.Clear();
            Errors.Clear();
            Messages.Clear();
            Warnings.Clear();
        }

        public void LogCustomEvent(CustomBuildEventArgs e)
        {
            Output.WriteLine($"Custom: {e.Message}");
            CustomEvents.Add(e);
        }

        public void LogErrorEvent(BuildErrorEventArgs e)
        {
            Output.WriteLine($"Error: {e.Message}");
            Errors.Add(e);
        }

        public void LogMessageEvent(BuildMessageEventArgs e)
        {
            Output.WriteLine($"Message: {e.Message}");
            Messages.Add(e);
        }

        public void LogWarningEvent(BuildWarningEventArgs e)
        {
            Output.WriteLine($"Warning: {e.Message}");
            Warnings.Add(e);
        }

        public virtual object? GetRegisteredTaskObject(object key, RegisteredTaskObjectLifetime lifetime)
        {
            RegisteredTaskObjectsQueries++;
            RegisteredTaskObjects.TryGetValue(key, out object? ret);
            return ret;
        }

        public void RegisterTaskObject(object key, object obj, RegisteredTaskObjectLifetime lifetime, bool allowEarlyCollection)
        {
            RegisteredTaskObjects.Add(key, obj);
        }

        public object UnregisterTaskObject(object key, RegisteredTaskObjectLifetime lifetime)
        {
            var obj = RegisteredTaskObjects[key];
            RegisteredTaskObjects.Remove(key);
            return obj;
        }

        public void Yield() { }

        public void Reacquire() { }

        public bool BuildProjectFile(string projectFileName, string[] targetNames, IDictionary globalProperties, IDictionary targetOutputs) => true;

        public bool BuildProjectFile(string projectFileName, string[] targetNames, IDictionary globalProperties, IDictionary targetOutputs, string toolsVersion) => true;
        
        public BuildEngineResult BuildProjectFilesInParallel(string[] projectFileNames, string[] targetNames, IDictionary[] globalProperties, IList<string>[] removeGlobalProperties, string[] toolsVersion, bool returnTargetOutputs) => new();

        public bool BuildProjectFilesInParallel(string[] projectFileNames, string[] targetNames, IDictionary[] globalProperties, IDictionary[] targetOutputsPerProject, string[] toolsVersion, bool useResultsCache, bool unloadProjectsOnCompletion) => true;
    }
}
