using FluentAssertions;
using CommunityToolkit.Maui.BindingExtensions;
using NUnit.Framework;

namespace CommunityToolkit.Maui.BindingExtensions.Tests
{
    [TestFixture]
    public class SharpieTaskTests
    {
        MockBuildEngine engine = new MockBuildEngine();

        [SetUp]
        public void Setup()
        {
            engine.ClearEvents();
        }

        [Test]
        public void ShouldRunSuccessfully()
        {
            var task = new Sharpie()
            {
                BuildEngine = engine,
                Arguments = "xcode -sdks -x /Applications/Xcode.app",
            };

            var taskSucceeded = task.Execute();
            taskSucceeded.Should().Be(true, "Task should complete successfully.");
            task.ConsoleOutput.Should().Contain("iphoneos", "Sharpie 'xcode -sdks' output should contain at least one 'iphoneos' entry.");
        }
    }
}
