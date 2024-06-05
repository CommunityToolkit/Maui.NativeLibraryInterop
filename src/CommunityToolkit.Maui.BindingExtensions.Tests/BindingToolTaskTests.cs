using FluentAssertions;
using Microsoft.Maui.BindingExtensions.Build.Tasks;
using NUnit.Framework;

namespace Microsoft.Maui.BindingExtensions.Build.Tests
{
    [TestFixture]
    public class BindingToolTaskTests
    {
        MockBuildEngine engine = new MockBuildEngine();

        public class DotnetToolOutputTestTask : BindingToolTask
        {
            public override string TaskPrefix { get; } = "DTOT";
            protected override string ToolName => "dotnet";
            protected override string GenerateFullPathToTool() => ToolExe;
            public string CommandLineArgs { get; set; } = "--info";
            protected override string GenerateCommandLineCommands() => CommandLineArgs;
        }

        [SetUp]
        public void Setup()
        {
            engine.ClearEvents();
        }

        [Test]
        [TestCase("invalidcommand", false, "You intended to execute a .NET program, but dotnet-invalidcommand does not exist.")]
        [TestCase("--info", true, "")]
        public void ShouldRunAndLogOnError(string args, bool expectedResult, string expectedErrorText)
        {
            var task = new DotnetToolOutputTestTask()
            {
                BuildEngine = engine,
                CommandLineArgs = args,
            };
            var taskSucceeded = task.Execute();
            taskSucceeded.Should().Be(expectedResult, "Task execution did not return expected value.");
           
            if (taskSucceeded)
            {
                engine.Errors.Should().BeEmpty("Successful task should not have any errors.");
            }
            else
            {
                engine.Errors.Should().NotBeEmpty("Task expected to fail should have errors.");
                engine.Errors[0].Code.Should().Be("MSB6006");
                engine.Errors[1].Code.Should().Be("DTOT0000");
                engine.Errors[1].Message.Should().Contain(expectedErrorText);
            }
        }
    }
}
